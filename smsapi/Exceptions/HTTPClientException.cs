using System;

namespace SMSApi.Api
{

    public class HTTPClientException : Exception
    {

        public HTTPClientException(String Message)
            : base(Message)
        { }

        public HTTPClientException(String Message, Exception InnerException)
            : base(Message, InnerException)
        { }

    }

}
