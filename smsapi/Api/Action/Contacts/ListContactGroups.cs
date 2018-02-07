using System;

namespace SMSApi.Api.Action
{
    public class ListContactGroups : Rest<Response.Groups>
    {

        public ListContactGroups(Client Client,
                                 IProxy  Proxy,
                                 String contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups"; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        public string ContactId { get; }

    }

}
