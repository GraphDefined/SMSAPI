using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class GetGroupPermission : Rest<Response.GroupPermission>
    {

        public GetGroupPermission(Credentials Client,
                                  SMSAPIClient  Proxy,
                                  String groupId,
                                  String username)
            : base(Client, Proxy)
        {
            GroupId  = groupId;
            Username = username;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        public string GroupId { get; }
        public string Username { get; }

    }
}
