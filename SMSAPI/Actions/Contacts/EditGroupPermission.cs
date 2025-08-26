using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class EditGroupPermission : Rest<Response.GroupPermission>
    {
        public EditGroupPermission(Credentials Client,
                                   SMSAPIClient  Proxy,
                                   String groupId,
                                   String username)
            : base(Client, Proxy)
        {
            GroupId  = groupId;
            Username = username;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

        protected override RequestMethods Method { get { return RequestMethods.PUT; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (Read  is not null) parameters.Add("read",  Convert.ToInt32(Read.Value).ToString());
                if (Write is not null) parameters.Add("write", Convert.ToInt32(Write.Value).ToString());
                if (Send  is not null) parameters.Add("send",  Convert.ToInt32(Send.Value).ToString());
                return parameters;
            }
        }

        public string GroupId  { get; }
        public string Username { get; }

        public bool? Read;
        public EditGroupPermission SetRead(bool? read)
        {
            Read = read;
            return this;
        }

        public bool? Write;
        public EditGroupPermission SetWrite(bool? write)
        {
            Write = write;
            return this;
        }

        public bool? Send;
        public EditGroupPermission SetSend(bool? send)
        {
            Send = send;
            return this;
        }
    }
}
