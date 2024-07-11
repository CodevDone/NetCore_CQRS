using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;

namespace CodevDone.CQRS.Application.UserProfiles.Command
{
    public class DeleteUserProfileCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }



}