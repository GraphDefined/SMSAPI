using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class DeleteGroup : Rest<Response.Base>
    {

        public DeleteGroup(Credentials Client,
                           SMSAPIClient  Proxy,
                           String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.DELETE; } }

        public string GroupId { get; }

    }

}
