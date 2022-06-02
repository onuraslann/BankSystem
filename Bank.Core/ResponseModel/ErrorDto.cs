using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public class ErrorDto   
    {
        public List<String> Errors { get; private set; }

        public bool IsShow { get; private set; }

        public ErrorDto()
        {
            Errors = new List<String>();
        }
        public ErrorDto(string errorMessage, bool isShow)
        {

            Errors.Add(errorMessage);
            IsShow = true;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;

        }
    }
}
