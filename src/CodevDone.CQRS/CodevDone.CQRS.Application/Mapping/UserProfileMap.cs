using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Application.UserProfiles;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;

namespace CodevDone.CQRS.Application.Mapping
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand, BasicInfo>();
        }

    }
}