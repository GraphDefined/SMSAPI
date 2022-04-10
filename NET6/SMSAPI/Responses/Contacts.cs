using System;
using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Contacts : BasicCollection<Contact>
    {
        [Obsolete("")]
        [DataMember(Name = "total", IsRequired = false)]
        public readonly int Total;
    }
}
