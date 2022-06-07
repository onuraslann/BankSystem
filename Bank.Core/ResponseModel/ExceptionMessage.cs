using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ResponseModel
{
    [Serializable]
    public class ExceptionMessage:Exception
    {
        public ExceptionMessage()
        {

        }
        public ExceptionMessage(string messageFormat, params object[] args)
           : base(string.Format(messageFormat, args))
        {
        }

        protected ExceptionMessage(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ExceptionMessage(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}


