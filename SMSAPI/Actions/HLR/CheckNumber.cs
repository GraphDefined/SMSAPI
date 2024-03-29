﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class HLRCheckNumber : BaseSimple<Response.CheckNumber>
    {

        protected IEnumerable<String>  Numbers   { get; }


        public HLRCheckNumber(Credentials Client,
                              SMSAPIClient  Proxy,
                              String      Number)

            : base(Client, Proxy)

        {
            this.Numbers = new String[] { Number };
        }

        public HLRCheckNumber(Credentials          Client,
                              SMSAPIClient           Proxy,
                              IEnumerable<String>  Numbers)

            : base(Client, Proxy)

        {
            this.Numbers = Numbers;
        }


        protected override String Uri => "hlrsync.do";

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Credentials.Username },
                   { "password", Credentials.Password },
                   { "number",   String.Join(",", Numbers) }
               };

    }

}
