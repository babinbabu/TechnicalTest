using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTest.Models
{
    public class BoolResult
    {
        public bool Result { get; set; }

        public BoolResult()
        {

        }

        public BoolResult(bool result)
        {
            Result = result;
        }
    }
}