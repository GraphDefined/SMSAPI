using System;

namespace SMSApi.Api.Action
{
    public class GetGroupPermission : Rest<Response.GroupPermission>
    {

        public GetGroupPermission(Client Client,
                                  IProxy  Proxy,
                                  String groupId,
                                  String username)
            : base(Client, Proxy)
        {
            GroupId  = groupId;
            Username = username;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

        public string GroupId { get; }
        public string Username { get; }

    }
}
