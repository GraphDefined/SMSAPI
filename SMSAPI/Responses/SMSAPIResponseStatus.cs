using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;

namespace com.GraphDefined.SMSApi.API.Response
{

    [DataContract]
    public class SMSAPIResponseStatus : Countable
    {

        #region Properties

        [DataMember(Name = "message", IsRequired = false)]
        public readonly String Message;

        [DataMember(Name = "length",  IsRequired = false)]
        public readonly Int32? Length;

        [DataMember(Name = "parts",   IsRequired = false)]
        public readonly Int32? Parts;

        [DataMember(Name = "list",    IsRequired = false)]
        private List<MessageStatus> list;

        public List<MessageStatus> List
        {

            get
            {

                if (list == null)
                    list = new List<MessageStatus>();

                return list;
            }

            set { }

        }

        #endregion

        #region Constructor(s)

        private SMSAPIResponseStatus()
            : base()
        { }

        private SMSAPIResponseStatus(String Message)
            : this()
        {
            this.Message = Message;
        }

        #endregion


        #region (static) Failed(Message|Exception)

        public static SMSAPIResponseStatus Failed(String Message)
            => new SMSAPIResponseStatus(Message);

        public static SMSAPIResponseStatus Failed(Exception e)
            => new SMSAPIResponseStatus(e.Message);

        #endregion


        #region  ToJSON()

        /// <summary>
        /// Return a JSON representation.
        /// </summary>
        public JObject ToJSON()
        {

            var JSON = new JObject {
                new JProperty("message",  Message)
            };

            if (Length.HasValue)
                JSON.Add(new JProperty("length",  Length.Value));

            if (Parts. HasValue)
                JSON.Add(new JProperty("parts",   Parts. Value));

            if (list.SafeAny())
                JSON.Add(new JProperty("list",    new JArray(list.Select(messagestatus => messagestatus.ToJSON()))));

            return JSON;

        }

        #endregion

    }

}
