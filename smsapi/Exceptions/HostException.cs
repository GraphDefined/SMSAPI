using System;

namespace SMSApi.Api
{

    public class HostException : SMSAPIException
    {

        public static readonly Int32 E_JSON_DECODE = -1;

        public HostException(String Message, Int32 Code)
            : base(Message, Code)
        { }

    }

}
