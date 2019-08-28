
//namespace com.GraphDefined.SMSApi.API
//{

//    /// <summary>
//    /// The abstract base API.
//    /// </summary>
//    public abstract class ABaseAPI
//    {

//        #region Properties

//        /// <summary>
//        /// The credentials used for accessing the remote API.
//        /// </summary>
//        public Credentials   Credentials     { get; }

//        /// <summary>
//        /// The HTTP client used for accessing the remote API.
//        /// </summary>
//        public SMSAPIClient  SMSAPIClient    { get; }

//        #endregion

//        #region Constructor(s)

//        public ABaseAPI()

//            : this(null,
//                   new SMSAPIClient("https://api.smsapi.com/api/"))

//        { }

//        public ABaseAPI(Credentials  Credentials)

//            : this(Credentials,
//                   new SMSAPIClient("https://api.smsapi.com/api/"))

//        { }

//        public ABaseAPI(Credentials   Credentials,
//                        SMSAPIClient  SMSAPIClient)
//        {

//            this.Credentials   = Credentials;
//            this.SMSAPIClient  = SMSAPIClient;

//        }

//        #endregion

//    }

//}
