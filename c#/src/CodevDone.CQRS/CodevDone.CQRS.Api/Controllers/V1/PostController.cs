using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Api.Contracts.Posts.Response;
using CodevDone.CQRS.Api.Filters;
using CodevDone.CQRS.Application.Posts.Query;
using CodevDone.CQRS.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodevDone.CQRS.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRutes.BaseRute)]
    [ApiController]

    public class PostController : BaseController
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController(ILogger<PostController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRutes.Posts.IdRoute)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllPostsQuery();
            var response = await _mediator.Send(query, cancellationToken);
            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }
            var posts = _mapper.Map<List<PostResponse>>(response.Payload);
            return Ok(posts);
        }

        [HttpGet]
        [Route(ApiRutes.Posts.IdRoute)]
        [ValidateModelGuid("id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var postId = new Guid(id.ToString());
            var query = new GetPostByIdQuery { PostId = postId };
            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsError)
            {
                return HandleErrorResponse(result.Errors);
            }

            var post = _mapper.Map<PostResponse>(result.Payload);
            return Ok(post);
        }
    }
}