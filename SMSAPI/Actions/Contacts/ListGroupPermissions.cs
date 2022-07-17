using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class ListGroupPermissions : Rest<Response.GroupPermissions>
    {

        public ListGroupPermissions(Credentials Client,
                                    SMSAPIClient  Proxy,
                                    String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions"; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        public string GroupId { get; }

    }

}
