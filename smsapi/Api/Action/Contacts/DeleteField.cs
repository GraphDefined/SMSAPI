using System;

namespace SMSApi.Api.Action
{
    public class DeleteField : Rest<Response.Base>
    {

        public DeleteField(Client Client,
                           IProxy  Proxy,
                           String fieldId)
            : base(Client, Proxy)
        {
            FieldId = fieldId;
        }

        protected override string Resource { get { return "contacts/fields/" + FieldId; } }

        protected override RequestMethod Method { get { return RequestMethod.DELETE; } }

        public string FieldId { get; }

    }

}
