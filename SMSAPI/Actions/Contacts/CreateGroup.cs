using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class CreateGroup : Rest<Response.Group>
    {

        public CreateGroup(Credentials Client,
                           SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/groups"; } }

        protected override RequestMethods Method { get { return RequestMethods.POST; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Name        is not null) parameters.Add("name",       Name);
                if (Description is not null) parameters.Add("desciption", Description);
                if (Idx         is not null) parameters.Add("idx",        Idx);
                return parameters;
            }
        }

        public string Name;
        public CreateGroup SetName(string name)
        {
            Name = name;
            return this;
        }

        public string Description;
        public CreateGroup SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public string Idx;
        public CreateGroup SetIdx(string idx)
        {
            Idx = idx;
            return this;
        }
    }
}
