using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SMSApi.Api 
{

    public enum RequestMethod { GET, POST, PUT, DELETE };

    public interface IProxy
    {

        Stream Execute(String uri, NameValueCollection data, RequestMethod method = RequestMethod.POST);
        Stream Execute(String uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST);
        Stream Execute(String uri, NameValueCollection data, Dictionary<String, Stream> files, RequestMethod method = RequestMethod.POST);

        void BasicAuthentication(Client client);

    }

}
