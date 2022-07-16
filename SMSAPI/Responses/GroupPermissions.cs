using System;
using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class GroupPermissions : BasicCollection<GroupPermission>
    {
        private GroupPermissions() : base() { }
    }
}
