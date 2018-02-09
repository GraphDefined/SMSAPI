using System;

namespace SMSApi.Api
{

    public class ContactsFactory : ABaseAPI
    {

        public ContactsFactory(Credentials client)
            : base(client, new HTTPClient("http://api.smsapi.pl/"))
        {
            HTTPClient.BasicAuthentication = client;
        }

        public ContactsFactory(Credentials client, HTTPClient proxy)
            : base(client, proxy)
        {
            proxy.BasicAuthentication = client;
        }


        public Action.ListContacts ListContacts()
            => new Action.ListContacts(Credentials, HTTPClient);

        public Action.CreateContact CreateContact()
            => new Action.CreateContact(Credentials, HTTPClient);

        public Action.DeleteContact DeleteContact(String contactId)
            => new Action.DeleteContact(Credentials, HTTPClient, contactId);

        public Action.GetContact GetContact(String contactId)
            => new Action.GetContact(Credentials, HTTPClient, contactId);

        public Action.EditContact EditContact(String contactId)
            => new Action.EditContact(Credentials, HTTPClient, contactId);

        public Action.ListGroups ListGroups()
            => new Action.ListGroups(Credentials, HTTPClient);

        public Action.CreateGroup CreateGroup()
            => new Action.CreateGroup(Credentials, HTTPClient);

        public Action.DeleteGroup DeleteGroup(String groupId)
            => new Action.DeleteGroup(Credentials, HTTPClient, groupId);

        public Action.GetGroup GetGroup(String groupId)
            => new Action.GetGroup(Credentials, HTTPClient, groupId);

        public Action.EditGroup EditGroup(String groupId)
            => new Action.EditGroup(Credentials, HTTPClient, groupId);

        public Action.ListGroupPermissions ListGroupPermissions(String groupId)
            => new Action.ListGroupPermissions(Credentials, HTTPClient, groupId);

        public Action.ListFields ListFields()
            => new Action.ListFields(Credentials, HTTPClient);

        public Action.CreateField CreateField()
            => new Action.CreateField(Credentials, HTTPClient);

        public Action.DeleteField DeleteField(String fieldId)
            => new Action.DeleteField(Credentials, HTTPClient, fieldId);

        public Action.EditField EditField(String fieldId)
            => new Action.EditField(Credentials, HTTPClient, fieldId);

        public Action.ListFieldOptions ListFieldOptions(String fieldId)
            => new Action.ListFieldOptions(Credentials, HTTPClient, fieldId);

        public Action.BindContactToGroup BindContactToGroup(String contactId, String groupId)
            => new Action.BindContactToGroup(Credentials, HTTPClient, contactId, groupId);

        public Action.UnbindContactFromGroup UnbindContactFromGroup(String contactId, String groupId)
            => new Action.UnbindContactFromGroup(Credentials, HTTPClient, contactId, groupId);

        public Action.ListContactGroups ListContactGroups(String contactId)
            => new Action.ListContactGroups(Credentials, HTTPClient, contactId);

        public Action.GetContactGroup GetContactGroup(String contactId, String groupId)
            => new Action.GetContactGroup(Credentials, HTTPClient, contactId, groupId);

        public Action.CreateGroupPermission CreateGroupPermission(String groupId)
            => new Action.CreateGroupPermission(Credentials, HTTPClient, groupId);

        public Action.DeleteGroupPermission DeleteGroupPermission(String groupId, String username)
            => new Action.DeleteGroupPermission(Credentials, HTTPClient, groupId, username);

        public Action.GetGroupPermission GetGroupPermission(String groupId, String username)
            => new Action.GetGroupPermission(Credentials, HTTPClient, groupId, username);

        public Action.EditGroupPermission EditGroupPermission(String groupId, String username)
            => new Action.EditGroupPermission(Credentials, HTTPClient, groupId, username);

    }

}
