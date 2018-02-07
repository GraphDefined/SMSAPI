using System;

namespace SMSApi.Api
{

    /// <summary>
    /// The sender API.
    /// </summary>
    public class SenderAPI : ABaseAPI
    {

        #region Constructor(s)

        public SenderAPI()
        { }

        public SenderAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public SenderAPI(Credentials  Credentials,
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
