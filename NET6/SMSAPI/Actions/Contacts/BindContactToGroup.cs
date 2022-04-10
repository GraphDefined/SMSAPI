using System;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class BindContactToGroup : Rest<Response.Base>
    {

        public BindContactToGroup(Credentials Client,
                                  SMSAPIClient  Proxy,
                                  String contactId,
                                  String groupId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
            GroupId   = groupId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.PUT; } }

        public string ContactId { get; }
        public string GroupId   { get; }

    }

}
