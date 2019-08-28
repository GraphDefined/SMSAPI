using org.GraphDefined.Vanaheimr.Hermod;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;
using System;

namespace com.GraphDefined.SMSApi.API
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new PhonebookFactory HTTP client.
        /// </summary>
        /// <param name="Hostname">The remote hostname.</param>
        /// <param name="RemotePort">The remote HTTPS port.</param>
        /// <param name="URLPathPrefix">The common URL prefix.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        public PhonebookFactory(HTTPHostname? Hostname             = null,
                                IPPort?       RemotePort           = null,
                                HTTPPath?     URLPathPrefix        = null,
                                Credentials   BasicAuthentication  = null,
                                Credentials   Credentials          = null)

            : base(Hostname,
                   RemotePort,
                   URLPathPrefix,
                   BasicAuthentication,
                   Credentials)

        { }

        #endregion


        public Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new Action.PhonebookContactAdd(Credentials, this);
            action.SetNumber(number);

            return action;
        }

        public Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new Action.PhonebookContactGet(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new Action.PhonebookContactEdit(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new Action.PhonebookContactDelete(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactList ActionContactList()
            => new Action.PhonebookContactList(Credentials, this);

        public Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new Action.PhonebookGroupAdd(Credentials, this);
            action.SetName(name);

            return action;
        }

        public Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new Action.PhonebookGroupEdit(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new Action.PhonebookGroupGet(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new Action.PhonebookGroupDelete(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupList ActionGroupList()
            => new Action.PhonebookGroupList(Credentials, this);

    }

}
