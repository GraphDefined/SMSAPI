namespace SMSApi.Api.Action
{

    public abstract class BaseSimple<T> : Base<T, T>
    {

        public BaseSimple(Credentials Client,
                          HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override T ConvertResponse(T response)
        {
            return response;
        }

    }

}
