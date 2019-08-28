using System.Collections.Generic;
using System.Runtime.Serialization;

namespace com.GraphDefined.SMSApi.API.Response
{
    [DataContract]
    public class Senders : Countable
    {
        private Senders() : base() { }

        [DataMember(Name = "list", IsRequired = false)]
        private List<Sender> list;

        public List<Sender> List
        {
            get
            {
                if (list == null)
                    list = new List<Sender>();

                return list;
            }

            set { }
        }
    }
}
