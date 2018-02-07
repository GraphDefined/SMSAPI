using System;

namespace SMSApi.Api
{

    public class SMSAPIException : Exception
    {

        public Int32 Code   { get; }

        public SMSAPIException(String Message, Int32 Code)
            : base(Message)
        {
            this.Code = Code;
        }

    }

}
