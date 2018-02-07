using System;

namespace SMSApi.Api
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : Factory
    {

        public PhonebookFactory() : base() { }
        public PhonebookFactory(Client client) : base(client) { }
        public PhonebookFactory(Client client, IProxy proxy) : base(client, proxy) { }

        public Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new Action.PhonebookContactAdd(Client, Proxy);
            action.SetNumber(number);

            return action;
        }

        public Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new Action.PhonebookContactGet(Client, Proxy);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new Action.PhonebookContactEdit(Client, Proxy);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new Action.PhonebookContactDelete(Client, Proxy);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactList ActionContactList()
            => new Action.PhonebookContactList(Client, Proxy);

        public Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new Action.PhonebookGroupAdd(Client, Proxy);
            action.SetName(name);

            return action;
        }

        public Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new Action.PhonebookGroupEdit(Client, Proxy);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new Action.PhonebookGroupGet(Client, Proxy);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new Action.PhonebookGroupDelete(Client, Proxy);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupList ActionGroupList()
            => new Action.PhonebookGroupList(Client, Proxy);

    }

}
