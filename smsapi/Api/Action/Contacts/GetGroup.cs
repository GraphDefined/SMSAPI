using System;

namespace SMSApi.Api.Action
{
    public class GetGroup : Rest<Response.Group>
    {

        public GetGroup(Client Client,
                        IProxy  Proxy,
                        String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }


        public string GroupId { get; }

    }

}
