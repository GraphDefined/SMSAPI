using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class DeleteGroup : Rest<Response.Base>
    {

        public DeleteGroup(Client Client,
                           IProxy  Proxy,
                           String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId; } }

        protected override RequestMethod Method { get { return RequestMethod.DELETE; } }

        public string GroupId { get; }

    }

}
