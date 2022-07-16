using System;
using System.Collections.Generic;

namespace com.GraphDefined.SMSApi.API.Action
{

    public abstract class Send : BaseSimple<Response.SMSAPIResponseStatus>
    {

        protected IEnumerable<String>  To;
        protected String               Group;
        protected String               DateSent;
        protected IEnumerable<String>  Idx;
        protected Boolean              IdxCheck = false;
        protected String               Partner;
        protected Boolean              Test     = false;

        protected Send(Credentials   Credentials,
                       SMSAPIClient  SMSAPIClient)

            : base(Credentials, SMSAPIClient)

        { }

    }

}
