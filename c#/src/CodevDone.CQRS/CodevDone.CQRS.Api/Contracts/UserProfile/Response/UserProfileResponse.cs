using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Api.Contracts.UserProfile.Response
{
    public record UserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public BasicInfoResponse BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}