using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class EditContact : Rest<Response.Contact>
    {

        public EditContact(Credentials Client,
                           SMSAPIClient  Proxy,
                           String contactId)

            : base(Client, Proxy)

        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId; } }

        protected override RequestMethods Method { get { return RequestMethods.PUT; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (PhoneNumber  is not null) parameters.Add("phone_number",  PhoneNumber);
                if (Email        is not null) parameters.Add("email",         Email);
                if (FirstName    is not null) parameters.Add("first_name",    FirstName);
                if (LastName     is not null) parameters.Add("last_name",     LastName);
                if (Gender       is not null) parameters.Add("gender",        Gender);
                if (BirthdayDate is not null) parameters.Add("birthday_date", BirthdayDate.Value.ToString("Y-m-d"));
                if (Description  is not null) parameters.Add("description",   Description);
                if (City         is not null) parameters.Add("city",          City);
                if (Source       is not null) parameters.Add("source",        Source);
                return parameters;
            }
        }

        public string ContactId { get; }

        public string PhoneNumber;
        public EditContact SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public string Email;
        public EditContact SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public string FirstName;
        public EditContact SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public string LastName;
        public EditContact SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public string Gender;
        public EditContact SetGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public DateTime? BirthdayDate;
        public EditContact SetBirthdayDate(DateTime? birthdayDate)
        {
            BirthdayDate = birthdayDate;
            return this;
        }

        public string Description;
        public EditContact SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public string City;
        public EditContact SetCity(string city)
        {
            City = city;
            return this;
        }

        public string Source;
        public EditContact SetSource(string source)
        {
            Source = source;
            return this;
        }
    }
}
