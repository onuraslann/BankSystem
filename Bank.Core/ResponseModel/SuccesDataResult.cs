using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, int statusCode,string message) : base(data, statusCode, message,true)
        {

        }
        public SuccessDataResult(T data, int statusCode) : base(data, statusCode,true)
        {

        }
        public SuccessDataResult(int statusCode) : base(default,statusCode, true)
        {

        }
        public SuccessDataResult(int statusCode,string message) : base(default, statusCode,message,true)
        {

        }
    }
}
