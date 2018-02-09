using System;

namespace SMSApi.Api.Action
{
    public class GetContactGroup : Rest<Response.Group>
    {
        public GetContactGroup(Credentials Client,
                               HTTPClient Proxy,
                               String contactId,
                               String groupId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
            GroupId   = groupId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        public String ContactId { get; }
        public String GroupId   { get; }

    }
}
