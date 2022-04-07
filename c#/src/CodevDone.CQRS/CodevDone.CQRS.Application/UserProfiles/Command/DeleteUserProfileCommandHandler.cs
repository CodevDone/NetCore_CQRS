using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodevDone.CQRS.Application.UserProfiles.Command
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _context;

        public DeleteUserProfileCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var userProfile = await _context.UserProfile.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);


            if (userProfile == null)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"No user profile found with id {request.UserProfileId}"
                });
                return result;
            }


            _context.UserProfile.Remove(userProfile);
            await _context.SaveChangesAsync();

            return result;
        }


    }

}