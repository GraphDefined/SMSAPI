using System;
using System.Collections.Generic;

namespace SMSApi.Api
{

    public class HLRFactory : Factory
    {

        public HLRFactory()
            : base()
        { }

        public HLRFactory(Credentials Credentials)
            : base(Credentials)
        { }

        public HLRFactory(Credentials Credentials, HTTPClient proxy)
            : base(Credentials, proxy)
        { }


        public Action.HLRCheckNumber ActionCheckNumber(String Number)
            => new Action.HLRCheckNumber(Credentials, HTTPClient, Number);

        public Action.HLRCheckNumber ActionCheckNumber(IEnumerable<String> Numbers)
            => new Action.HLRCheckNumber(Credentials, HTTPClient, Numbers);

    }

}
