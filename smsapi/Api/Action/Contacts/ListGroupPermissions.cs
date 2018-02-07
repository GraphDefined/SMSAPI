using System;

namespace SMSApi.Api.Action
{
    public class ListGroupPermissions : Rest<Response.GroupPermissions>
    {

        public ListGroupPermissions(Client Client,
                                    IProxy  Proxy,
                                    String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions"; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        public string GroupId { get; }

    }

}
