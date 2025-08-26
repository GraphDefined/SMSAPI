using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class CreateGroupPermission : Rest<Response.GroupPermission>
    {

        public CreateGroupPermission(Credentials Client,
                                     SMSAPIClient  Proxy,
                                     String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions"; } }

        protected override RequestMethods Method { get { return RequestMethods.POST; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Username is not null) parameters.Add("username", Username);
                if (Read     is not null) parameters.Add("read",     Convert.ToInt32(Read.Value).ToString());
                if (Write    is not null) parameters.Add("write",    Convert.ToInt32(Write.Value).ToString());
                if (Send     is not null) parameters.Add("send",     Convert.ToInt32(Send.Value).ToString());
                return parameters;
            }
        }

        public string GroupId { get; }

        public string Username;
        public CreateGroupPermission SetUsername(string username)
        {
            Username = username;
            return this;
        }

        public bool? Read;
        public CreateGroupPermission SetRead(bool? read)
        {
            Read = read;
            return this;
        }

        public bool? Write;
        public CreateGroupPermission SetWrite(bool? write)
        {
            Write = write;
            return this;
        }

        public bool? Send;
        public CreateGroupPermission SetSend(bool? send)
        {
            Send = send;
            return this;
        }
    }
}
