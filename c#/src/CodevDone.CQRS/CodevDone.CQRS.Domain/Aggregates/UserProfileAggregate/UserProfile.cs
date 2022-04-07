using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate
{
    public class UserProfile
    {
        private UserProfile()
        {
        }
        public Guid UserProfileId { get; private set; }
        public string IdentyId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }
        //Factory method
        public static UserProfile CreateUserProfile(string IdentityId, BasicInfo basicInfo)
        {
            // TODO: add validation, error handling stratigies, error notification strategies
            return new UserProfile
            {
                IdentyId = IdentityId,
                BasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }

        // public method
        public void UpdateBasicInfo(BasicInfo newInfo)
        {
            BasicInfo = newInfo;
            LastModified = DateTime.UtcNow;
        }

    }
}