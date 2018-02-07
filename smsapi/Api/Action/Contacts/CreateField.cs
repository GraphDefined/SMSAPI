using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class CreateField : Rest<Response.Field>
    {

        public CreateField(Credentials Client,
                           HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/fields"; } }

        protected override RequestMethods Method { get { return RequestMethods.POST; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Name != null) parameters.Add("name", Name);
                if (Type != null) parameters.Add("type", Type);
                return parameters;
            }
        }

        public string Name;
        public CreateField SetName(string name)
        {
            Name = name;
            return this;
        }

        public string Type;
        public CreateField SetType(string type)
        {
            Type = type;
            return this;
        }
    }
}
