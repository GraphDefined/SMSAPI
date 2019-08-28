using System;

namespace com.GraphDefined.SMSApi.API
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
