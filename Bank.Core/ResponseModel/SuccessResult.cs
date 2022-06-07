using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class SuccessResult:Result   
    {

        public SuccessResult(int statusCode, string message) : base(statusCode, message, true)
        {

        }
        public SuccessResult(int statusCode) : base(statusCode, true)
        {

        }
    }
}
