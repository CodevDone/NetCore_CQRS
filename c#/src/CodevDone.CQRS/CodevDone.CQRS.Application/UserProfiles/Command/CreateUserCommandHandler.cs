using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using CodevDone.CQRS.Domain.Exceptions;
using MediatR;

namespace CodevDone.CQRS.Application.UserProfiles
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddres,
          request.Phone, request.DateOfBirth, request.CurrentCity, request.Address);

                // TO DO : Validation try catch block
                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

                _ctx.UserProfile.Add(userProfile);
                await _ctx.SaveChangesAsync();

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
            catch (Exception ex)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Message = $"{ex.Message}",
                    Code = ErrorCode.UnknownError
                });
            }



            return result;
        }

        // public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        // {
        //     var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddres,
        //     request.Phone, request.DateOfBirth, request.CurrentCity, request.Address);
        //     // TO DO : Validation try catch block
        //     var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

        //     _ctx.UserProfile.Add(userProfile);
        //     await _ctx.SaveChangesAsync();

        //     return userProfile;
        // }


    }
}