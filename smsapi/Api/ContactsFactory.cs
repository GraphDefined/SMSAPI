using System;

namespace SMSApi.Api
{

    public class ContactsFactory : Factory
    {

        public ContactsFactory(Client client)
            : base(client, new ProxyHTTP("http://api.smsapi.pl/"))
        {
            Proxy.BasicAuthentication(client);
        }

        public ContactsFactory(Client client, IProxy proxy)
            : base(client, proxy)
        {
            proxy.BasicAuthentication(client);
        }


        public Action.ListContacts ListContacts()
            => new Action.ListContacts(Client, Proxy);

        public Action.CreateContact CreateContact()
            => new Action.CreateContact(Client, Proxy);

        public Action.DeleteContact DeleteContact(string contactId)
            => new Action.DeleteContact(Client, Proxy, contactId);

        public Action.GetContact GetContact(string contactId)
            => new Action.GetContact(Client, Proxy, contactId);

        public Action.EditContact EditContact(string contactId)
            => new Action.EditContact(Client, Proxy, contactId);

        public Action.ListGroups ListGroups()
            => new Action.ListGroups(Client, Proxy);

        public Action.CreateGroup CreateGroup()
            => new Action.CreateGroup(Client, Proxy);

        public Action.DeleteGroup DeleteGroup(string groupId)
            => new Action.DeleteGroup(Client, Proxy, groupId);

        public Action.GetGroup GetGroup(string groupId)
            => new Action.GetGroup(Client, Proxy, groupId);

        public Action.EditGroup EditGroup(string groupId)
            => new Action.EditGroup(Client, Proxy, groupId);

        public Action.ListGroupPermissions ListGroupPermissions(string groupId)
            => new Action.ListGroupPermissions(Client, Proxy, groupId);

        public Action.ListFields ListFields()
            => new Action.ListFields(Client, Proxy);

        public Action.CreateField CreateField()
            => new Action.CreateField(Client, Proxy);

        public Action.DeleteField DeleteField(string fieldId)
            => new Action.DeleteField(Client, Proxy, fieldId);

        public Action.EditField EditField(string fieldId)
            => new Action.EditField(Client, Proxy, fieldId);

        public Action.ListFieldOptions ListFieldOptions(string fieldId)
            => new Action.ListFieldOptions(Client, Proxy, fieldId);

        public Action.BindContactToGroup BindContactToGroup(string contactId, string groupId)
            => new Action.BindContactToGroup(Client, Proxy, contactId, groupId);

        public Action.UnbindContactFromGroup UnbindContactFromGroup(string contactId, string groupId)
            => new Action.UnbindContactFromGroup(Client, Proxy, contactId, groupId);

        public Action.ListContactGroups ListContactGroups(string contactId)
            => new Action.ListContactGroups(Client, Proxy, contactId);

        public Action.GetContactGroup GetContactGroup(string contactId, string groupId)
            => new Action.GetContactGroup(Client, Proxy, contactId, groupId);

        public Action.CreateGroupPermission CreateGroupPermission(string groupId)
            => new Action.CreateGroupPermission(Client, Proxy, groupId);

        public Action.DeleteGroupPermission DeleteGroupPermission(string groupId, string username)
            => new Action.DeleteGroupPermission(Client, Proxy, groupId, username);

        public Action.GetGroupPermission GetGroupPermission(string groupId, string username)
            => new Action.GetGroupPermission(Client, Proxy, groupId, username);

        public Action.EditGroupPermission EditGroupPermission(string groupId, string username)
            => new Action.EditGroupPermission(Client, Proxy, groupId, username);

    }

}
