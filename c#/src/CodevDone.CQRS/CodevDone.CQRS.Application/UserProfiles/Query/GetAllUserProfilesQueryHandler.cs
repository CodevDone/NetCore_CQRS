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
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, OperationResult<IEnumerable<UserProfile>>>
    {
        private readonly DataContext _ctx;
        public GetAllUserProfilesQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UserProfile>>();

            result.Payload = await _ctx.UserProfile.ToListAsync();

            return result;
        }

        // public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request,
        //  CancellationToken cancellationToken)
        // {
        //    
        // }
    }
}