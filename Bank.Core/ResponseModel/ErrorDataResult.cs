using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, int statusCode, string message) : base(data, statusCode, message, false)
        {

        }
        public ErrorDataResult(T data, int statusCode) : base(data, statusCode, false)
        {

        }
        public ErrorDataResult(int statusCode) : base(default, statusCode, false)
        {

        }
        public ErrorDataResult(int statusCode, string message) : base(default, statusCode, message, false)
        {

        }
    }
}
