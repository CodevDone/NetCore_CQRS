using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodevDone.CQRS.Application.UserProfiles
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public GetUserProfileByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            var profile = await _ctx.UserProfile.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

            if (profile == null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"No user profile found with id {request.UserProfileId}"
                });
                return result;
            }

            result.Payload = profile;

            return result;
        }

        // public async Task<UserProfile> Handle(GetUserProfileByIdQuery request,
        //  CancellationToken cancellationToken)
        // {
        //     return await _ctx.UserProfile
        //     .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
        // }
    }
}