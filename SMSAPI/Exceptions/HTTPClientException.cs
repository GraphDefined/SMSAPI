using System;

namespace com.GraphDefined.SMSApi.API
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
