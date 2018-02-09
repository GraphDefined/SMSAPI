using System;

namespace SMSApi.Api.Action
{
    public class UnbindContactFromGroup : Rest<Response.Base>
    {

        public UnbindContactFromGroup(Credentials Client,
                                      HTTPClient  Proxy,
                                      String contactId,
                                      String groupId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
            GroupId   = groupId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.DELETE; } }

        public string ContactId { get; }
        public string GroupId { get; }

    }

}
