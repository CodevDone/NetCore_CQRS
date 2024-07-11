using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using CodevDone.CQRS.Application.Models;

namespace CodevDone.CQRS.Application.UserProfiles
{
    public class CreateUserCommand : IRequest<OperationResult<UserProfile>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddres { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
        public string Address { get; set; }
    }
}