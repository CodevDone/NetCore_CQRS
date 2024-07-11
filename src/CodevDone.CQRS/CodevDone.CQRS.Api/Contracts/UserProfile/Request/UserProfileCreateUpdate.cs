using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Api.Contracts.UserProfile.Request
{
    public class UserProfileCreateUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddres { get; set; }
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
        public string Address { get; set; }

    }
}