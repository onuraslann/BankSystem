using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class Result : IResult
    {

        public Result(int statusCode,string message,bool success):this(statusCode,success)
        {
            Message = message;
        }
        public Result(int statusCode,bool success)
        {
            Success = success;

            StatusCode = statusCode;
        }
        public int StatusCode { get; }

        public string Message { get; }

        public bool Success { get; }
    }
}
