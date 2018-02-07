using System;

namespace SMSApi.Api.Action
{
    public class ListFieldOptions : Rest<Response.FieldOptions>
    {

        public ListFieldOptions(Client Client,
                                IProxy  Proxy,
                                String fieldId)
            : base(Client, Proxy)
        {
            FieldId = fieldId;
        }

        protected override string Resource { get { return "contacts/fields/" + FieldId + "/options"; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        public string FieldId { get; }

    }
}
