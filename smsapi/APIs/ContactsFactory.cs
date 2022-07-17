/*
 * Copyright (c) 2017-2022, Achim Friedland <achim.friedland@graphdefined.com>
 * This file is part of GraphDefined SMSAPI <https://github.com/GraphDefined/SMSAPI>
 *   based on original work of SMSAPI!
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Net.Security;
using System.Security.Authentication;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

#endregion

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
        public ContactsFactory(URL?                                  RemoteURL                    = null,
                               HTTPHostname?                         VirtualHostname              = null,
                               String?                               Description                  = null,
                               RemoteCertificateValidationCallback?  RemoteCertificateValidator   = null,
                               SslProtocols?                         TLSProtocol                  = null,
                               Boolean?                              PreferIPv4                   = null,
                               String                                HTTPUserAgent                = DefaultHTTPUserAgent,
                               Credentials?                          BasicAuthentication          = null,
                               Credentials?                          Credentials                  = null,
                               TimeSpan?                             RequestTimeout               = null,
                               TransmissionRetryDelayDelegate?       TransmissionRetryDelay       = null,
                               UInt16?                               MaxNumberOfRetries           = DefaultMaxNumberOfRetries,
                               DNSClient?                            DNSClient                    = null)

            : base(RemoteURL,
                   VirtualHostname,
                   Description,
                   RemoteCertificateValidator,
                   TLSProtocol,
                   PreferIPv4,
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
            => new (Credentials, this);

        public Action.CreateContact CreateContact()
            => new (Credentials, this);

        public Action.DeleteContact DeleteContact(String contactId)
            => new (Credentials, this, contactId);

        public Action.GetContact GetContact(String contactId)
            => new (Credentials, this, contactId);

        public Action.EditContact EditContact(String contactId)
            => new (Credentials, this, contactId);

        public Action.ListGroups ListGroups()
            => new (Credentials, this);

        public Action.CreateGroup CreateGroup()
            => new (Credentials, this);

        public Action.DeleteGroup DeleteGroup(String groupId)
            => new (Credentials, this, groupId);

        public Action.GetGroup GetGroup(String groupId)
            => new (Credentials, this, groupId);

        public Action.EditGroup EditGroup(String groupId)
            => new (Credentials, this, groupId);

        public Action.ListGroupPermissions ListGroupPermissions(String groupId)
            => new (Credentials, this, groupId);

        public Action.ListFields ListFields()
            => new (Credentials, this);

        public Action.CreateField CreateField()
            => new (Credentials, this);

        public Action.DeleteField DeleteField(String fieldId)
            => new (Credentials, this, fieldId);

        public Action.EditField EditField(String fieldId)
            => new (Credentials, this, fieldId);

        public Action.ListFieldOptions ListFieldOptions(String fieldId)
            => new (Credentials, this, fieldId);

        public Action.BindContactToGroup BindContactToGroup(String contactId, String groupId)
            => new (Credentials, this, contactId, groupId);

        public Action.UnbindContactFromGroup UnbindContactFromGroup(String contactId, String groupId)
            => new (Credentials, this, contactId, groupId);

        public Action.ListContactGroups ListContactGroups(String contactId)
            => new (Credentials, this, contactId);

        public Action.GetContactGroup GetContactGroup(String contactId, String groupId)
            => new (Credentials, this, contactId, groupId);

        public Action.CreateGroupPermission CreateGroupPermission(String groupId)
            => new (Credentials, this, groupId);

        public Action.DeleteGroupPermission DeleteGroupPermission(String groupId, String username)
            => new (Credentials, this, groupId, username);

        public Action.GetGroupPermission GetGroupPermission(String groupId, String username)
            => new (Credentials, this, groupId, username);

        public Action.EditGroupPermission EditGroupPermission(String groupId, String username)
            => new (Credentials, this, groupId, username);

    }

}
