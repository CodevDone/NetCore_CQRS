using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Api.Contracts.UserProfile.Request;
using CodevDone.CQRS.Api.Contracts.UserProfile.Response;
using CodevDone.CQRS.Api.Filters;
using CodevDone.CQRS.Application.UserProfiles;
using CodevDone.CQRS.Application.UserProfiles.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodevDone.CQRS.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRutes.BaseRute)]
    [ApiController]
    public class UserProfileController : BaseController
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(ILogger<UserProfileController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException("Sin implementar");
            var query = new GetAllUserProfilesQuery();
            var response = await _mediator.Send(query, cancellationToken);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            return Ok(profiles);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command, cancellationToken);

            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);

            }
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);


            return CreatedAtAction(nameof(GetUserProfileById),
             new { id = userProfile.UserProfileId }, userProfile);
        }


        [HttpGet]
        [Route(ApiRutes.UserProfiles.IdRoute)]
        [ValidateModelGuid("id")]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);

            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }


            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }


        [HttpPatch]
        [Route(ApiRutes.UserProfiles.IdRoute)]
        [ValidateModel]
        [ValidateModelGuid("id")]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] UserProfileCreateUpdate profile, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(profile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command, cancellationToken);

            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRutes.UserProfiles.IdRoute)]
        [ValidateModelGuid("id")]
        public async Task<IActionResult> DeleteUserProfile(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command, cancellationToken);
            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }

            return NoContent();
        }


    }
}