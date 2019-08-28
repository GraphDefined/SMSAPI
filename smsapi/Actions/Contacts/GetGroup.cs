using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class GetGroup : Rest<Response.Group>
    {

        public GetGroup(Credentials Client,
                        SMSAPIClient  Proxy,
                        String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }


        public string GroupId { get; }

    }

}
