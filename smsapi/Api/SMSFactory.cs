using System;
using System.Collections.Generic;

namespace SMSApi.Api
{

    public class SMSFactory : Factory
    {

        public SMSFactory()
            : base()
        { }

        public SMSFactory(Credentials Credentials)
            : base(Credentials)
        { }

        public SMSFactory(Credentials Credentials, HTTPClient proxy)
            : base(Credentials, proxy)
        { }


        public Action.SMSDelete ActionDelete(String Id)
            => new Action.SMSDelete(Credentials, HTTPClient, Id);

        public Action.SMSGet    ActionGet   (String Id)
            => new Action.SMSGet   (Credentials, HTTPClient, Id);

        public Action.SMSGet    ActionGet   (IEnumerable<String> Ids)
            => new Action.SMSGet   (Credentials, HTTPClient, Ids);

        public Action.SMSSend   ActionSend  (String text, String to)
            => new Action.SMSSend  (Credentials, HTTPClient, new String[] { to }, text);

        public Action.SMSSend   ActionSend  (String text, String[] to)
            => new Action.SMSSend  (Credentials, HTTPClient, to, text);

    }

}
