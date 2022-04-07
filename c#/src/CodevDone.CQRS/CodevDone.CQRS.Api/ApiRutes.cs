using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Api
{
    public class ApiRutes
    {
        public const string BaseRute = "api/v{version:apiVersion}/[controller]";

        public class UserProfiles
        {
            public const string IdRoute = "{id}";
        }


        public class Posts
        {
            public const string IdRoute = "{id}";
        }



    }
}