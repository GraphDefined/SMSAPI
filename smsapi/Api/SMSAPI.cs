using System;
using System.Collections.Generic;

namespace SMSApi.Api
{

    /// <summary>
    /// The SMS API.
    /// </summary>
    public class SMSAPI : ABaseAPI
    {

        #region Constructor(s)

        public SMSAPI()
        { }

        public SMSAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public SMSAPI(Credentials  Credentials,
                      HTTPClient   HTTPClient)
            : base(Credentials,
                   HTTPClient)
        { }

        #endregion


        public Action.SMSDelete Delete(String Id)
            => new Action.SMSDelete(Credentials, HTTPClient, Id);

        public Action.SMSGet    Get   (String Id)
            => new Action.SMSGet   (Credentials, HTTPClient, Id);

        public Action.SMSGet    Get   (IEnumerable<String> Ids)
            => new Action.SMSGet   (Credentials, HTTPClient, Ids);

        public Action.SMSSend   Send  (String text, String to)
            => new Action.SMSSend  (Credentials, HTTPClient, new String[] { to }, text);

        public Action.SMSSend   Send  (String text, String[] to)
            => new Action.SMSSend  (Credentials, HTTPClient, to, text);

    }

}
