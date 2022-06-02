using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDto Error { get; private set; }

        public static Response<T> SuccessResponse(T data, int statusCode)
        {
            return new Response<T>
            {
                Data = data,
                StatusCode = statusCode,
            };
        }

        public static Response<T> SuccessResponse(int statusCode)
        {
            return new Response<T>
            {
                Data = default,
                StatusCode = statusCode,
            };
        }
        public static Response<T> ErrorResponse(ErrorDto errorMesage, int statusCode)
        {
            return new Response<T>
            {
                Error = errorMesage,
                StatusCode = statusCode
            };
        }
        public static Response<T> ErrorResponse(string errorMesage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMesage, isShow);
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode
            };

        }
    }
}
