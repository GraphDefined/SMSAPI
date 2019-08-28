using System;

namespace com.GraphDefined.SMSApi.API 
{

    public enum RequestMethods {
        GET,
        POST,
        PUT,
        DELETE
    };

    public static class Extentions
    {

        public static String RequestMethodToString(this RequestMethods method)
        {

            switch (method)
            {

                case RequestMethods.GET:
                    return "GET";

                case RequestMethods.PUT:
                    return "PUT";

                case RequestMethods.POST:
                    return "POST";

                case RequestMethods.DELETE:
                    return "DELETE";

                default:
                    throw new HTTPClientException("Invalid request method");

            }

        }

    }

}
