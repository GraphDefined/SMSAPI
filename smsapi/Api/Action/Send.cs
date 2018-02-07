using System;

namespace SMSApi.Api.Action
{

    public abstract class Send : BaseSimple<Response.Status>
    {

        protected Send(Client Client,
                       IProxy Proxy)

            : base(Client, Proxy)

        { }

        protected String[] To;
        protected String   Group;
        protected String   DateSent;
        protected String[] Idx;
        protected Boolean  IdxCheck = false;
        protected String   Partner;
        protected Boolean  Test     = false;

    }

}
