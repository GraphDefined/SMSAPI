using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SMSApi.Api.Action
{

    public class SMSSend : Send
    {

        public SMSSend(Credentials          Credentials,
                       HTTPClient           HTTPClient,
                       IEnumerable<String>  Recipients,
                       String               SMSText)

            : base(Credentials, HTTPClient)

        {
            this.To    = Recipients;
            this.Text  = SMSText;
        }

        protected override String Uri => "sms.do";

        protected override NameValueCollection Values()
        {

            var collection = new NameValueCollection {
                                 { "format",   "json" },
                                 { "username", Credentials.Username },
                                 { "password", Credentials.Password }
                             };

            if (Sender != null)
                collection.Add("from", Sender);

            if (To != null)
                collection.Add("to", String.Join(",", To));

            if (Group != null)
                collection.Add("group", Group);

            collection.Add("message", Text);

            collection.Add("single",    (Single    ? "1" : "0") );
            collection.Add("nounicode", (NoUnicode ? "1" : "0") );
            collection.Add("flash",     (Flash     ? "1" : "0") );
            collection.Add("fast",      (Fast      ? "1" : "0") );

            if (DataCoding != null)
                collection.Add("datacoding", DataCoding);

            if (MaxParts > 0)
                collection.Add("max_parts", MaxParts.ToString());

            if (DateSent != null)
                collection.Add("date", DateSent);

            if (DateExpire != null)
                collection.Add("expiration_date", DateExpire);

            if (Partner != null)
                collection.Add("partner_id", Partner);

            collection.Add("encoding", Encoding);

            if (Normalize == true)
                collection.Add("normalize", "1");

            if (Test == true)
                collection.Add("test", "1");

            if (Idx != null && Idx.Any())
            {
                collection.Add("check_idx", (IdxCheck ? "1" : "0"));
                collection.Add("idx", string.Join("|", Idx));
            }

            if (Details == true)
            {
                collection.Add("details", "1");
            }

            if (this.Params != null)
            {
                for (int i = 0; i < this.Params.Length; i++)
                {
                    if (this.Params[i] != null)
                    {
                        collection.Add("param" + ((i + 1).ToString()), this.Params[i]);
                    }
                }
            }

            return collection;
        }

        protected override void Validate()
        {

            if( To != null && Group != null )
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");

            if (Text == null)
                throw new ArgumentException("Cannot send message without text!");

        }

        protected String Text { get; }

        private string DateExpire;
        private string Sender;
        private bool Single = false;
        private bool NoUnicode = false;
        private string DataCoding;
        private string udh;
        private bool Flash = false;
        private string Encoding = "UTF-8";
        private bool Fast = false;
        private bool Normalize = false;
        private int MaxParts = 0;
        private string[] Params = null;
        private bool Details = true;

        //public SMSSend SetTo(string to)
        //{
        //    this.To = new string[] { to };
        //    return this;
        //}

        public SMSSend SetTo(string[] to)
        {
            this.To = to;
            return this;
        }

        public SMSSend SetGroup(string group)
        {
            this.Group = group;
            return this;
        }

        public SMSSend SetDateSent(string data)
        {
            this.DateSent = data;
            return this;
        }

        public SMSSend SetDateSent(DateTime data)
        {
            this.DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetIDx(string idx)
        {
            this.Idx = new string[] { idx };
            return this;
        }

        public SMSSend SetIDx(string[] idx)
        {
            this.Idx = idx;
            return this;
        }

        public SMSSend SetCheckIDx(bool check = true)
        {
            this.IdxCheck = check;
            return this;
        }

        public SMSSend SetPartner(string partner)
        {
            this.Partner = partner;
            return this;
        }

        //public SMSSend SetText(string text)
        //{
        //    this.Text = text;
        //    return this;
        //}

        public SMSSend SetDateExpire(string data)
        {
            this.DateExpire = data;
            return this;
        }

        public SMSSend SetDateExpire(DateTime data)
        {
            this.DateExpire = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetSender(string sender)
        {
            this.Sender = sender;
            return this;
        }

        public SMSSend SetSingle(bool single = true)
        {
            this.Single = single;
            return this;
        }

        public SMSSend SetNoUnicode(bool noUnicode = true)
        {
            this.NoUnicode = noUnicode;
            return this;
        }

        public SMSSend SetDataCoding(string dataCoding)
        {
            this.DataCoding = dataCoding;
            return this;
        }

        public SMSSend SetUdh(string udh)
        {
            this.udh = udh;
            return this;
        }

        public SMSSend SetFlash(bool flash = true)
        {
            this.Flash = flash;
            return this;
        }

/*
        public SMSSend SetEncoding(string encoding)
        {
            this.encoding = encoding;
            return this;
        }
*/

        public SMSSend SetFast(bool fast = true)
        {
            this.Fast = fast;
            return this;
        }

        public SMSSend SetTest(bool test = true)
        {
            this.Test = test;
            return this;
        }

        public SMSSend SetParam(int i, string[] text)
        {
            return this.SetParam(i, string.Join("|", text));
        }

        public SMSSend SetParam(int i, string text)
        {
            if (i > 3 || i < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.Params == null)
            {
                this.Params = new string[4];
            }

            this.Params[i] = text;

            return this;
        }

        public SMSSend SetNormalize(bool flag = true)
        {
            this.Normalize = flag;
            return this;
        }

    }

}
