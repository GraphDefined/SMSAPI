using System;

namespace SMSApi.Api.Action
{

    public class BindContactToGroup : Rest<Response.Base>
    {

        public BindContactToGroup(Client Client,
                                  IProxy  Proxy,
                                  String contactId,
                                  String groupId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
            GroupId   = groupId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups/" + GroupId; } }

        protected override RequestMethod Method { get { return RequestMethod.PUT; } }

        public string ContactId { get; }
        public string GroupId   { get; }

    }

}
