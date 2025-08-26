using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class ListGroups : Rest<Response.Groups>
    {

        public ListGroups(Credentials Client,
                          SMSAPIClient Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/groups"; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Id   is not null) parameters.Add("id",   Id);
                if (Name is not null) parameters.Add("name", Name);
                return parameters;
            }
        }

        public string Id;
        public ListGroups SetId(string id)
        {
            Id = id;
            return this;
        }

        public string Name;
        public ListGroups SetName(string name)
        {
            Name = name;
            return this;
        }

    }

}
