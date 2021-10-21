using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTest.Models
{
    public class UserIdResult
    {
        public long UserId { get; set; }

        public UserIdResult()
        {

        }

        public UserIdResult(long result)
        {
            UserId = result;
        }
    }

}
