using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization.Json;

namespace com.GraphDefined.SMSApi.API.Action
{

    public abstract class Base<T, TResult>
    {

        protected Credentials   Credentials     { get; }
        protected SMSAPIClient  SMSAPIClient    { get; }

        public Base(Credentials   Credentials,
                    SMSAPIClient  SMSAPIClient)
        {

            this.Credentials   = Credentials;
            this.SMSAPIClient  = SMSAPIClient;

        }


        abstract protected String              Uri      { get; }
        abstract protected NameValueCollection Values();

        protected virtual RequestMethods Method
            => RequestMethods.POST;

        protected TT ResponseToObject<TT>(Stream resultStream)
        {

            TT result;

            var uu = (resultStream as MemoryStream).ToArray();
            var aa = Encoding.UTF8.GetString(uu, 0, uu.Length);


            if (resultStream.Length > 0)
            {
                resultStream.Position = 0;
                var serializer = new DataContractJsonSerializer(typeof(TT));
                result = (TT) serializer.ReadObject(resultStream);
                resultStream.Position = 0;
            }

            else
                result = Activator.CreateInstance<TT>();

            return result;

        }

        protected virtual void Validate()
        { }

        protected virtual Dictionary<String, Stream> Files()
            => null;

        protected abstract TResult ConvertResponse(T response);

/*        protected virtual TResult ConvertResponse(T response)
        {
            return (TResult)Convert.ChangeType(response, typeof(TResult));
        }*/

        public TResult Execute()
        {

            Validate();

            var resultStream = SMSAPIClient.Execute(Uri, Values(), Files(), Method).Result;

            var result = default(TResult);

            HandleError(resultStream);

            try
            {
                T response = ResponseToObject<T>(resultStream);
                result     = ConvertResponse(response);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                //Problem z prasowaniem json'a
                throw new HostException(e.Message + " /" + Uri, HostException.E_JSON_DECODE);
            }

            resultStream.Close();

            return result;

        }

        protected void HandleError(Stream resultStream)
        {

            resultStream.Position = 0;

            try
            {

                var error = ResponseToObject<Response.Error>(resultStream);

                if (error.Code != 0)
                {
                    if (IsHostError(error.Code))
                    {
                        throw new HostException(error.Message, error.Code);
                    }
                    if (IsClientError(error.Code))
                    {
                        throw new ClientException(error.Message, error.Code);
                    }
                    else
                    {
                        throw new ActionException(error.Message, error.Code);
                    }
                }

            }
            catch (System.Runtime.Serialization.SerializationException)
            { }

            resultStream.Position = 0;

        }

        /**
         * 101 Niepoprawne lub brak danych autoryzacji.
         * 102 Nieprawidłowy login lub hasło
         * 103 Brak punków dla tego użytkownika
         * 105 Błędny adres IP
         * 110 Usługa nie jest dostępna na danym koncie
         * 1000 Akcja dostępna tylko dla użytkownika głównego
         * 1001 Nieprawidłowa akcja
         */
        private Boolean IsClientError(int code)
        {

            if (code ==  101) return true;
            if (code ==  102) return true;
            if (code ==  103) return true;
            if (code ==  105) return true;
            if (code ==  110) return true;
            if (code == 1000) return true;
            if (code == 1001) return true;

            return false;

        }

        /**
         * 8 Błąd w odwołaniu
         * 666 Wewnętrzny błąd systemu
         * 999 Wewnętrzny błąd systemu
         * 201 Wewnętrzny błąd systemu
         */
        private Boolean IsHostError(int code)
        {

            if (code ==   8) return true;
            if (code == 201) return true;
            if (code == 666) return true;
            if (code == 999) return true;

            return false;

        }

    }

}
