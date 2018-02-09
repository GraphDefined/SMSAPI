using System;

namespace SMSApi.Api
{

    /// <summary>
    /// The SMS Sender API.
    /// </summary>
    public class SMSSenderAPI : ABaseAPI
    {

        #region Constructor(s)

        public SMSSenderAPI()
        { }

        public SMSSenderAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public SMSSenderAPI(Credentials  Credentials,
                         HTTPClient   HTTPClient)
            : base(Credentials,
                   HTTPClient)
        { }

        #endregion


        public Action.SenderAdd        Add       (String Name)
            => new Action.SenderAdd       (Credentials, HTTPClient, Name);

        public Action.SenderDelete     Delete    (String Name)
            => new Action.SenderDelete    (Credentials, HTTPClient, Name);

        public Action.SenderSetDefault SetDefault(String DefaultName)
            => new Action.SenderSetDefault(Credentials, HTTPClient, DefaultName);

        public Action.SenderList       GetAllSenderNames()
            => new Action.SenderList      (Credentials, HTTPClient);

    }

}
