using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Sender
    {
        [DataMember(Name = "sender", IsRequired = true)]
        public readonly string Name;

        [DataMember(Name = "status", IsRequired = true)]
        public readonly string Status;

        [DataMember(Name = "default", IsRequired = true)]
        public readonly bool Default;
    }
}
