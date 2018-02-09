
namespace SMSApi.Api
{

    /// <summary>
    /// The abstract base API.
    /// </summary>
    public abstract class ABaseAPI
    {

        #region Properties

        /// <summary>
        /// The credentials used for accessing the remote API.
        /// </summary>
        public Credentials Credentials   { get; }

        /// <summary>
        /// The HTTP client used for accessing the remote API.
        /// </summary>
        public HTTPClient  HTTPClient    { get; }

        #endregion

        #region Constructor(s)

        public ABaseAPI()

            : this(null,
                   new HTTPClient("https://api.smsapi.com/api/"))

        { }

        public ABaseAPI(Credentials  Credentials)

            : this(Credentials,
                   new HTTPClient("https://api.smsapi.com/api/"))

        { }

        public ABaseAPI(Credentials  Credentials,
                        HTTPClient   HTTPClient)
        {
            this.Credentials  = Credentials;
            this.HTTPClient   = HTTPClient;
        }

        #endregion

    }

}
