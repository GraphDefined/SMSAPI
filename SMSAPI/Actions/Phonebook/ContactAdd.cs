using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookContactAdd : BaseSimple<Response.Contact>
    {

        public PhonebookContactAdd(Credentials Client,
                                   SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string number;
        protected string firstName;
        protected string lastName;
        protected string info;
        protected int birthday;
        protected string city;
        protected string gender;
        protected string[] groups;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

            collection.Add("add_contact", number);

            if (firstName is not null)  collection.Add("first_name", firstName);
            if (lastName is not null)   collection.Add("last_name", lastName);
            if (info is not null)       collection.Add("info", info);
            if (birthday != 0)      collection.Add("birthday", birthday.ToString());
            if (city is not null)       collection.Add("city", city);
            if (gender is not null)     collection.Add("gender", gender);
            if (groups is not null)     collection.Add("groups", string.Join(",", groups));

            return collection;
        }

        public PhonebookContactAdd SetNumber(string number)
        {
            this.number = number;
            return this;
        }

        public PhonebookContactAdd SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactAdd SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookContactAdd SetBirthday(int birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public PhonebookContactAdd SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public PhonebookContactAdd SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactAdd SetGroup(string group)
        {
            this.groups = new string[] {group};
            return this;
        }

        public PhonebookContactAdd SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }
    }
}
