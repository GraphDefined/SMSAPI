using System;
using System.Net.Security;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{

    public class ContactsFactory : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new ContactsFactory HTTP client.
        /// </summary>
        /// <param name="RemoteURL">The remote URL of the OICP HTTP endpoint to connect to.</param>
        /// <param name="VirtualHostname">An optional HTTP virtual hostname.</param>
        /// <param name="Description">An optional description of this CPO client.</param>
        /// <param name="RemoteCertificateValidator">The remote SSL/TLS certificate validator.</param>
        /// <param name="HTTPUserAgent">The HTTP user agent identification.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        /// <param name="RequestTimeout">An optional request timeout.</param>
        /// <param name="TransmissionRetryDelay">The delay between transmission retries.</param>
        /// <param name="MaxNumberOfRetries">The maximum number of transmission retries for HTTP request.</param>
        /// <param name="DNSClient">The DNS client to use.</param>
        public ContactsFactory(URL?                                 RemoteURL                    = null,
                               HTTPHostname?                        VirtualHostname              = null,
                               String                               Description                  = null,
                               RemoteCertificateValidationCallback  RemoteCertificateValidator   = null,
                               String                               HTTPUserAgent                = DefaultHTTPUserAgent,
                               Credentials                          BasicAuthentication          = null,
                               Credentials                          Credentials                  = null,
                               TimeSpan?                            RequestTimeout               = null,
                               TransmissionRetryDelayDelegate       TransmissionRetryDelay       = null,
                               UInt16?                              MaxNumberOfRetries           = DefaultMaxNumberOfRetries,
                               DNSClient                            DNSClient                    = null)

            : base(RemoteURL,
                   VirtualHostname,
                   Description,
                   RemoteCertificateValidator,
                   HTTPUserAgent,
                   BasicAuthentication,
                   Credentials,
                   RequestTimeout,
                   TransmissionRetryDelay,
                   MaxNumberOfRetries,
                   DNSClient)

        { }

        #endregion


        public Action.ListContacts ListContacts()
            => new Action.ListContacts(Credentials, this);

        public Action.CreateContact CreateContact()
            => new Action.CreateContact(Credentials, this);

        public Action.DeleteContact DeleteContact(String contactId)
            => new Action.DeleteContact(Credentials, this, contactId);

        public Action.GetContact GetContact(String contactId)
            => new Action.GetContact(Credentials, this, contactId);

        public Action.EditContact EditContact(String contactId)
            => new Action.EditContact(Credentials, this, contactId);

        public Action.ListGroups ListGroups()
            => new Action.ListGroups(Credentials, this);

        public Action.CreateGroup CreateGroup()
            => new Action.CreateGroup(Credentials, this);

        public Action.DeleteGroup DeleteGroup(String groupId)
            => new Action.DeleteGroup(Credentials, this, groupId);

        public Action.GetGroup GetGroup(String groupId)
            => new Action.GetGroup(Credentials, this, groupId);

        public Action.EditGroup EditGroup(String groupId)
            => new Action.EditGroup(Credentials, this, groupId);

        public Action.ListGroupPermissions ListGroupPermissions(String groupId)
            => new Action.ListGroupPermissions(Credentials, this, groupId);

        public Action.ListFields ListFields()
            => new Action.ListFields(Credentials, this);

        public Action.CreateField CreateField()
            => new Action.CreateField(Credentials, this);

        public Action.DeleteField DeleteField(String fieldId)
            => new Action.DeleteField(Credentials, this, fieldId);

        public Action.EditField EditField(String fieldId)
            => new Action.EditField(Credentials, this, fieldId);

        public Action.ListFieldOptions ListFieldOptions(String fieldId)
            => new Action.ListFieldOptions(Credentials, this, fieldId);

        public Action.BindContactToGroup BindContactToGroup(String contactId, String groupId)
            => new Action.BindContactToGroup(Credentials, this, contactId, groupId);

        public Action.UnbindContactFromGroup UnbindContactFromGroup(String contactId, String groupId)
            => new Action.UnbindContactFromGroup(Credentials, this, contactId, groupId);

        public Action.ListContactGroups ListContactGroups(String contactId)
            => new Action.ListContactGroups(Credentials, this, contactId);

        public Action.GetContactGroup GetContactGroup(String contactId, String groupId)
            => new Action.GetContactGroup(Credentials, this, contactId, groupId);

        public Action.CreateGroupPermission CreateGroupPermission(String groupId)
            => new Action.CreateGroupPermission(Credentials, this, groupId);

        public Action.DeleteGroupPermission DeleteGroupPermission(String groupId, String username)
            => new Action.DeleteGroupPermission(Credentials, this, groupId, username);

        public Action.GetGroupPermission GetGroupPermission(String groupId, String username)
            => new Action.GetGroupPermission(Credentials, this, groupId, username);

        public Action.EditGroupPermission EditGroupPermission(String groupId, String username)
            => new Action.EditGroupPermission(Credentials, this, groupId, username);

    }

}
