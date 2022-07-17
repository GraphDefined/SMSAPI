using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Fields : BasicCollection<Field>
    {
        private Fields() : base() { }
    }
}
