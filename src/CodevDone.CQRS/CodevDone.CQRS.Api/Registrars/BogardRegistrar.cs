using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.UserProfiles;
using MediatR;

namespace CodevDone.CQRS.Api.Registrars
{
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program),typeof(GetAllUserProfilesQuery));
            builder.Services.AddMediatR(typeof(GetAllUserProfilesQuery));
        }
    }
}