using System;
using System.Runtime.Serialization;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;

namespace com.GraphDefined.SMSApi.API.Response
{

    [DataContract]
    public class MessageStatus
    {

        #region Properties

        [DataMember(Name = "id",     IsRequired = true)]
        public readonly String ID;

        [DataMember(Name = "points", IsRequired = true)]
        public readonly Double Points;

        [DataMember(Name = "number", IsRequired = true)]
        public readonly String Number;

        [DataMember(Name = "status", IsRequired = true)]
        public readonly String Status;

        [DataMember(Name = "error",  IsRequired = false)]
        public readonly String Error;

        [DataMember(Name = "idx",    IsRequired = false)]
        public readonly String IDx;

        #endregion

        #region Constructor(s)

        private MessageStatus()
        {
            this.ID      = "";
            this.Points  = 0;
            this.Number  = "";
            this.Status  = "UNKNOWN";
            this.Error   = null;
            this.IDx     = null;
        }

        #endregion


        #region IsError

        public Boolean IsError

            => ID        is null ||
               ID.Length == 0    ||
               Error     is not null;

        #endregion

        #region IsFinal

        public Boolean IsFinal
        {
            get
            {

                if (IsError)
                    return true;

                if (Status.Equals("QUEUE") ||
                    Status.Equals("SENT"))
                    return false;

                return true;

            }
        }

        #endregion


        #region ToJSON()

        /// <summary>
        /// Return a JSON representation.
        /// </summary>
        public JObject ToJSON()
        {

            var JSON = new JObject {
                new JProperty("id",      ID),
                new JProperty("points",  Points),
                new JProperty("number",  Number),
                new JProperty("status",  Status)
            };

            if (Error.IsNeitherNullNorEmpty())
                JSON.Add(new JProperty("error", Error));

            if (IDx.  IsNeitherNullNorEmpty())
                JSON.Add(new JProperty("idx",   IDx));

            return JSON;

        }

        #endregion

    }

}
