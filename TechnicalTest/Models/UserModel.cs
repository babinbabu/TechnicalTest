using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;
using TechnicalTest.WebApi;

namespace TechnicalTest.Models
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }


        public void Validate()
        {

            if (string.IsNullOrEmpty(FullName))
            {
                throw new WebApiException(
                    new WebApiError(WebApiErrorCode.InvalidArguments, "Full Name cannot be null or empty"));
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new WebApiException(
                    new WebApiError(WebApiErrorCode.InvalidArguments, "Email cannot be null or empty"));
            }
            if (!IsValid(Email))
            {
                throw new WebApiException(
                    new WebApiError(WebApiErrorCode.InvalidArguments, "Invaild Email Format"));
            }
            
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public UserModel()
        {

        }
        public UserModel(Entity.User entityEnity)
        {
           UserId = entityEnity.UserId;
           FullName = entityEnity.FullName;
           Email = entityEnity.Email;
           Phone = entityEnity.Phone;
           Age = entityEnity.Age;
        }

    }

    
}