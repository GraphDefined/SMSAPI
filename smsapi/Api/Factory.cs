
namespace SMSApi.Api 
{
    public abstract class Factory
    {

        protected Credentials Credentials   { get; }
        protected HTTPClient  HTTPClient    { get; }

        public Factory()
        {
            this.HTTPClient   = new HTTPClient("https://api.smsapi.com/api/");
        }

        public Factory(Credentials credentials)
        {
            this.Credentials  = credentials;
            this.HTTPClient   = new HTTPClient("https://api.smsapi.com/api/");
        }

        public Factory(Credentials credentials, HTTPClient proxy)
        {
            this.Credentials  = credentials;
            this.HTTPClient   = proxy;
        }

    }

}
