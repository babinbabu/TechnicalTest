using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;

namespace TechnicalTest.WebApi
{
    public enum WebApiErrorCode
    {
        [Description("Unexpected error happened in server. Please try again later.")]
        [HttpStatusCode(HttpStatusCode.InternalServerError)]
        UnknownError = 1,

        [Description("Server Busy. Please try again later.")]
        [HttpStatusCode(HttpStatusCode.InternalServerError)]
        ServerBusy = 2,

        [Description("Missing required data")]
        [HttpStatusCode(HttpStatusCode.BadRequest)]
        BadRequest = 3,

        [Description("Invalid arguments")]
        [HttpStatusCode(HttpStatusCode.BadRequest)]
        InvalidArguments = 4,

        [Description("Requested item not found")]
        [HttpStatusCode(HttpStatusCode.NotFound)]
        NotFound = 5,

        [Description("Unauthorized action")]
        [HttpStatusCode(HttpStatusCode.Unauthorized)]
        Unauthorized = 6,

        [Description("Invalid action")]
        [HttpStatusCode(HttpStatusCode.Forbidden)]
        InvalidAction = 8,

        [Description("Duplicated item")]
        [HttpStatusCode(HttpStatusCode.Forbidden)]
        Duplicated = 9,

        [Description("Requested item not registered")]
        [HttpStatusCode(HttpStatusCode.Unauthorized)]
        NotRegistered = 10,

        
    }
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class HttpStatusCodeAttribute : System.Attribute
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpStatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}