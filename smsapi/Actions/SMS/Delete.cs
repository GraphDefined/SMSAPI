﻿using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class SMSDelete : BaseSimple<Response.Countable>
    {

        public SMSDelete(Credentials  Client,
                         HTTPClient  Proxy,
                         String  Id)

            : base(Client, Proxy)

        {
            this.Id = Id;
        }

        protected override String Uri => "sms.do";

        protected String Id { get; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",    "json" },
                   { "username",  Credentials.Username },
                   { "password",  Credentials.Password },
                   { "sch_del",   Id }
               };


    }

}