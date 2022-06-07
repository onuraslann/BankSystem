using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class ErrorResult:Result
    {
        public ErrorResult(int statusCode,string message):base(statusCode,message,false)
        {

        }
        public ErrorResult(int statusCode):base(statusCode,false)
        {

        }
    }
}
