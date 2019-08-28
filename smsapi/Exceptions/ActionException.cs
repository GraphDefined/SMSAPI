using System;

namespace com.GraphDefined.SMSApi.API
{

    public class ActionException : SMSAPIException
    {

        public ActionException(String Message, Int32 Code)
            : base(Message, Code)
        { }

    }

}
