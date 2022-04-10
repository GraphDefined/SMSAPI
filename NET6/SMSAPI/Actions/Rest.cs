using System;
using System.Collections.Specialized;
using System.Web;

namespace com.GraphDefined.SMSApi.API.Action
{

    public abstract class Rest<T> : BaseSimple<T>
    {

        public Rest(Credentials Client,
                    SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }


        protected override String Uri
            => Method == RequestMethods.GET && Parameters.Count > 0
                   ? Resource + "?" + Parameters.ToString()
                   : Resource;

        protected override NameValueCollection Values()
            => Method == RequestMethods.POST || Method == RequestMethods.PUT
                   ? Parameters
                   : new NameValueCollection();

        protected abstract String Resource { get; }

        protected virtual NameValueCollection Parameters { get { return HttpUtility.ParseQueryString(String.Empty); } }

    }

}
