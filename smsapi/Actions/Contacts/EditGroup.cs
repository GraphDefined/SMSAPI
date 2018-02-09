using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class EditGroup : Rest<Response.Group>
    {

        public EditGroup(Credentials Client,
                         HTTPClient  Proxy,
                         String groupId)
            : base(Client, Proxy)
        {
            GroupId = groupId;
        }

        protected override string Resource { get { return "contacts/groups/" + GroupId; } }

        protected override RequestMethods Method { get { return RequestMethods.PUT; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Name        != null) parameters.Add("name",       Name);
                if (Description != null) parameters.Add("desciption", Description);
                if (Idx         != null) parameters.Add("idx",        Idx);
                return parameters;
            }
        }

        public string GroupId { get; }

        public string Name;
        public EditGroup SetName(string name)
        {
            Name = name;
            return this;
        }

        public string Description;
        public EditGroup SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public string Idx;
        public EditGroup SetIdx(string idx)
        {
            Idx = idx;
            return this;
        }
    }
}
