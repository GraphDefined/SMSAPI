using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class DeleteField : Rest<Response.Base>
    {

        public DeleteField(Credentials Client,
                           SMSAPIClient  Proxy,
                           String fieldId)
            : base(Client, Proxy)
        {
            FieldId = fieldId;
        }

        protected override string Resource { get { return "contacts/fields/" + FieldId; } }

        protected override RequestMethods Method { get { return RequestMethods.DELETE; } }

        public string FieldId { get; }

    }

}
