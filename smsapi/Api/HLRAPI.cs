using System;
using System.Collections.Generic;

namespace SMSApi.Api
{

    /// <summary>
    /// The HLR API.
    /// </summary>
    public class HLRAPI : ABaseAPI
    {

        #region Constructor(s)

        public HLRAPI()
        { }

        public HLRAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public HLRAPI(Credentials  Credentials,
                      HTTPClient   HTTPClient)
            : base(Credentials, HTTPClient)
        { }

        #endregion


        public Action.HLRCheckNumber CheckNumber(String Number)
            => new Action.HLRCheckNumber(Credentials, HTTPClient, Number);

        public Action.HLRCheckNumber CheckNumber(IEnumerable<String> Numbers)
            => new Action.HLRCheckNumber(Credentials, HTTPClient, Numbers);

    }

}
