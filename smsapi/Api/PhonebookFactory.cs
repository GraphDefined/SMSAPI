using System;

namespace SMSApi.Api
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : ABaseAPI
    {

        public PhonebookFactory() : base() { }
        public PhonebookFactory(Credentials Credentials) : base(Credentials) { }
        public PhonebookFactory(Credentials Credentials, HTTPClient proxy) : base(Credentials, proxy) { }

        public Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new Action.PhonebookContactAdd(Credentials, HTTPClient);
            action.SetNumber(number);

            return action;
        }

        public Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new Action.PhonebookContactGet(Credentials, HTTPClient);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new Action.PhonebookContactEdit(Credentials, HTTPClient);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new Action.PhonebookContactDelete(Credentials, HTTPClient);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactList ActionContactList()
            => new Action.PhonebookContactList(Credentials, HTTPClient);

        public Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new Action.PhonebookGroupAdd(Credentials, HTTPClient);
            action.SetName(name);

            return action;
        }

        public Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new Action.PhonebookGroupEdit(Credentials, HTTPClient);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new Action.PhonebookGroupGet(Credentials, HTTPClient);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new Action.PhonebookGroupDelete(Credentials, HTTPClient);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupList ActionGroupList()
            => new Action.PhonebookGroupList(Credentials, HTTPClient);

    }

}
