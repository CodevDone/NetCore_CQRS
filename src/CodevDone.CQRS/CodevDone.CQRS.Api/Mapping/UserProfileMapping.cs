using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Api.Contracts.UserProfile.Request;
using CodevDone.CQRS.Api.Contracts.UserProfile.Response;
using CodevDone.CQRS.Application.UserProfiles;
using CodevDone.CQRS.Application.UserProfiles.Command;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;

namespace CodevDone.CQRS.Api.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInfoCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInfoResponse>();
        }

    }
}