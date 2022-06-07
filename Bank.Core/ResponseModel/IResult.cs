﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    public interface IResult
    {
        public int StatusCode { get;  }
        public string Message { get; }
        bool Success { get; }
    }
}
