using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodevDone.CQRS.Application.Posts.Query
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, OperationResult<Post>>
    {
        private readonly DataContext _ctx;
        public GetPostByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<Post>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();

            var post = await _ctx.Post.FirstOrDefaultAsync(p => p.PostId == request.PostId);

            if (post == null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"{request.PostId} not found"
                });
                return result;
            }

            result.Payload = post;
            return result;
        }
    }

}