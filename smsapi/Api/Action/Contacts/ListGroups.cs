using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class ListGroups : Rest<Response.Groups>
    {

        public ListGroups(Client Client,
                          IProxy Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/groups"; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Id   != null) parameters.Add("id",   Id);
                if (Name != null) parameters.Add("name", Name);
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
