using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookContactEdit : BaseSimple<Response.Contact>
    {

        public PhonebookContactEdit(Credentials Client,
                                    SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string oldNumber;
        protected string newNumber;
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

            collection.Add("edit_contact", oldNumber);

            if (newNumber is not null)  collection.Add("new_number", newNumber);
            if (firstName is not null)  collection.Add("first_name", firstName);
            if (lastName is not null)   collection.Add("last_name", lastName);
            if (info is not null)       collection.Add("info", info);
            if (birthday != 0)      collection.Add("birthday", birthday.ToString());
            if (city is not null)       collection.Add("city", city);
            if (gender is not null)     collection.Add("gender", gender);
            if (groups is not null)     collection.Add("groups", string.Join(",", groups));

            return collection;
        }

        public PhonebookContactEdit Number(string number)
        {
            this.oldNumber = number;
            return this;
        }

        public PhonebookContactEdit SetNumber(string number)
        {
            this.newNumber = number;
            return this;
        }

        public PhonebookContactEdit SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactEdit SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactEdit SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookContactEdit SetBirthday(int birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public PhonebookContactEdit SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public PhonebookContactEdit SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactEdit SetGroup(string group)
        {
            this.groups = new string[] {group};
            return this;
        }

        public PhonebookContactEdit SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }
    }
}
