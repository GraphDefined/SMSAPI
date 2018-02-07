using System;

namespace SMSApi.Api
{

    public class ActionException : SMSAPIException
    {

        public ActionException(String Message, Int32 Code)
            : base(Message, Code)
        { }

    }

}
