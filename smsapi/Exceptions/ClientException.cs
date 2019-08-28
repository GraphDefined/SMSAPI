using System;

namespace com.GraphDefined.SMSApi.API
{

    public class ClientException : SMSAPIException
    {

        public ClientException(String Message, Int32 Code)
            : base(Message, Code)
        { }

    }

}
