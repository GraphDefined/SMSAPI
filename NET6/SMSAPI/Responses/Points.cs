using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Credits : Base
    {
        private Credits() : base() { }

        [DataMember(Name = "points", IsRequired = true)]
        public readonly double Points;

        [DataMember(Name = "proCount", IsRequired = false)]
        public readonly int ProCount;
        [DataMember(Name = "ecoCount", IsRequired = false)]
        public readonly int EcoCount;
        
    }
}
