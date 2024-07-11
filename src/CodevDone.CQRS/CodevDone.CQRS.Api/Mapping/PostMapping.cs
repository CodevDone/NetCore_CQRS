using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodevDone.CQRS.Api.Contracts.Posts.Response;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;

namespace CodevDone.CQRS.Api.Mapping
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<Post, PostResponse>();
        }
    }
}