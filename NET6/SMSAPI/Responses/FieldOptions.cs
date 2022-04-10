using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class FieldOptions : BasicCollection<FieldOption>
    {
        private FieldOptions() : base() { }
    }
}
