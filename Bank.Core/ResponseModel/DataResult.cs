using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class DataResult<T>:Result, IDataResult<T>
    {
        public DataResult(T data, int statusCode, string message,bool success) : base(statusCode,message, success)
        {
            Data = data;

        }
        public DataResult(T data, int statusCode,bool success) : base( statusCode,success)
        {

            Data = data;
        }
        public T Data { get; }
    }
}

