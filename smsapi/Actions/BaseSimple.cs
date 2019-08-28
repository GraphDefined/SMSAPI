namespace com.GraphDefined.SMSApi.API.Action
{

    public abstract class BaseSimple<T> : Base<T, T>
    {

        public BaseSimple(Credentials   Credentials,
                          SMSAPIClient  SMSAPIClient)

            : base(Credentials, SMSAPIClient)

        { }

        protected override T ConvertResponse(T response)
        {
            return response;
        }

    }

}
