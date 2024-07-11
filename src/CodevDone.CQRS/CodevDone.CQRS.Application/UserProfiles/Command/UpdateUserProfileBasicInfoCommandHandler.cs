using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Exceptions;

namespace CodevDone.CQRS.Application.UserProfiles.Command
{
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _context;
        public UpdateUserProfileBasicInfoCommandHandler(DataContext context)
        {
            _context = context;
        }



        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInfoCommand request,
         CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _context.UserProfile
                .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

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


                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                 request.EmailAddres, request.Phone, request.DateOfBirth, request.CurrentCity, request.Address);

                userProfile.UpdateBasicInfo(basicInfo);

                _context.UserProfile.Update(userProfile);
                await _context.SaveChangesAsync();

                result.Payload = userProfile;
            }
            catch (UserProfileNotValidException ex)
            {
                result.IsError = true;

                ex.ValidationErrors.ForEach(x =>
                    result.Errors.Add(new Error
                    {
                        Message = $"{ex.Message}",
                        Code = ErrorCode.ValidationError
                    })
                );
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.ServerError,
                    Message = e.Message
                });
            }
            return result;
        }
    }
}