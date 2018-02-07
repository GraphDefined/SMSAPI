using System;

namespace SMSApi.Api.Action
{
    public class GetContactGroup : Rest<Response.Group>
    {
        public GetContactGroup(Client Client,
                               IProxy Proxy,
                               String contactId,
                               String groupId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
            GroupId   = groupId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups/" + GroupId; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        public String ContactId { get; }
        public String GroupId   { get; }

    }
}
