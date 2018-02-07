using System;
using System.Collections.Generic;

namespace SMSApi.Api.Action
{

    public abstract class Send : BaseSimple<Response.Status>
    {

        protected Send(Credentials Client,
                       HTTPClient Proxy)

            : base(Client, Proxy)

        { }

        protected IEnumerable<String>  To;
        protected String               Group;
        protected String               DateSent;
        protected IEnumerable<String>  Idx;
        protected Boolean              IdxCheck = false;
        protected String               Partner;
        protected Boolean              Test     = false;

    }

}
