using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class ListFieldOptions : Rest<Response.FieldOptions>
    {

        public ListFieldOptions(Credentials Client,
                                SMSAPIClient  Proxy,
                                String fieldId)
            : base(Client, Proxy)
        {
            FieldId = fieldId;
        }

        protected override string Resource { get { return "contacts/fields/" + FieldId + "/options"; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        public string FieldId { get; }

    }
}
