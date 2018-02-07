
using System;

namespace SMSApi.Api
{

    public class SMSFactory : Factory
    {

        public SMSFactory()
            : base()
        { }

        public SMSFactory(Client client)
            : base(client)
        { }

        public SMSFactory(Client client, IProxy proxy)
            : base(client, proxy)
        { }


        public Action.SMSDelete ActionDelete(string id = null)
        {

            Action.SMSDelete action = new Action.SMSDelete(Client, Proxy);
            action.Id(id);

            return action;

        }

        public Action.SMSGet ActionGet(string id = null)
        {

            Action.SMSGet action = new Action.SMSGet(Client, Proxy);
            action.Id(id);

            return action;

        }

        public Action.SMSGet ActionGet(string[] id)
        {

            Action.SMSGet action = new Action.SMSGet(Client, Proxy);
            action.Ids(id);

            return action;

        }

        public Action.SMSSend ActionSend(String to    = null,
                                         String text  = null)
        {

            return ActionSend(to == null ? null : new String[] { to },
                              text);

        }

        public Action.SMSSend ActionSend(String[] to,
                                         String   text = null)
        {

            Action.SMSSend action = new Action.SMSSend(Client, Proxy);
            action.SetTo(to);
            action.SetText(text);

            return action;

        }

    }

}
