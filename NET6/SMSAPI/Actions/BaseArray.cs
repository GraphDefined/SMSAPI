using System.Collections.Generic;

namespace com.GraphDefined.SMSApi.API.Action
{

    public abstract class BaseArray<T> : Base<List<T>, Response.Array<T>>
    {

        public BaseArray(Credentials Client,
                         SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override Response.Array<T> ConvertResponse(List<T> response)
        {
            return new Response.Array<T>(response);
        }

    }

}
