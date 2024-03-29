using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class EditField : Rest<Response.Field>
    {
        public EditField(Credentials Client,
                         SMSAPIClient  Proxy,
                         String fieldId)
            : base(Client, Proxy)
        {
            FieldId = fieldId;
        }

        protected override string Resource { get { return "contacts/fields/" + FieldId; } }

        protected override RequestMethods Method { get { return RequestMethods.PUT; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Name != null) parameters.Add("name", Name);
                return parameters;
            }
        }

        public string FieldId { get; }

        public string Name;
        public EditField SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
