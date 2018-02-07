
namespace SMSApi.Api 
{
    public abstract class Factory
    {

        protected Client Client { get; }
        protected IProxy  Proxy  { get; }

        public Factory()
        {
            this.Proxy  = new ProxyHTTP("https://api.smsapi.com/api/");
        }

        public Factory(Client client)
        {
            this.Client = client;
            this.Proxy  = new ProxyHTTP("https://api.smsapi.com/api/");
        }

        public Factory(Client client, IProxy proxy)
        {
            this.Client = client;
            this.Proxy  = proxy;
        }

    }

}
