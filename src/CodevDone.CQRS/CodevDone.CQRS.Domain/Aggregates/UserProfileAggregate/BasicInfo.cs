using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Exceptions;
using CodevDone.CQRS.Domain.Validators.UserProfileValidators;

namespace CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate
{
    public class BasicInfo
    {
        private BasicInfo()
        {
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddres { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CurrentCity { get; private set; }
        public string Address { get; private set; }
        //Factory method
        public static BasicInfo CreateBasicInfo(string firstName, string lastName, string emailAddres, string phone,
                                                DateTime dateOfBirth, string currentCity, string address)
        {
            //TODO: Implement validation , error, handling stratigies ,error nofication
            var validator = new BasicInfoValidator();

            var objToValidate = new BasicInfo
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddres = emailAddres,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                CurrentCity = currentCity,
                Address = address
            };

            var validationResult = validator.Validate(objToValidate);

            if (!validationResult.IsValid)
            {
                var exception = new UserProfileNotValidException("The user profile is not valid");
                foreach (var ex in validationResult.Errors)
                {
                    exception.ValidationErrors.Add(ex.ErrorMessage);
                }

                throw exception;
            }
            return objToValidate;

        }

        // public method


    }
}