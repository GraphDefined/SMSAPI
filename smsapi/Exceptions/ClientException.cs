using System;

namespace SMSApi.Api
{

    public class ClientException : SMSAPIException
    {

        public ClientException(String Message, Int32 Code)
            : base(Message, Code)
        { }

    }

}
