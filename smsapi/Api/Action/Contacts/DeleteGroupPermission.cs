using System;

namespace SMSApi.Api.Action
{
    public class DeleteGroupPermission : Rest<Response.GroupPermission>
    {
        public DeleteGroupPermission(Client Client,
                                     IProxy  Proxy,
                                     String groupId,
                                     String username)
            : base(Client, Proxy)
        {
            GroupId  = groupId;
            Username = username;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

        protected override RequestMethod Method { get { return RequestMethod.DELETE; } }

        public string GroupId  { get; }
        public string Username { get; }

    }
}
