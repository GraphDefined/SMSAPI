using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Groups : BasicCollection<Group>
    {
        private Groups() : base() { }
    }
}
