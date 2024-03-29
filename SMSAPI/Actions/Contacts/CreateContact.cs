using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class CreateContact : Rest<Response.Contact>
    {

        public CreateContact(Credentials Client,
                             SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts"; } }

        protected override RequestMethods Method { get { return RequestMethods.POST; } }

        protected override NameValueCollection Parameters
        {
            get
            {
                var parameters = base.Parameters;
                if (PhoneNumber  != null) parameters.Add("phone_number",  PhoneNumber);
                if (Email        != null) parameters.Add("email",         Email);
                if (FirstName    != null) parameters.Add("first_name",    FirstName);
                if (LastName     != null) parameters.Add("last_name",     LastName);
                if (Gender       != null) parameters.Add("gender",        Gender);
                if (BirthdayDate != null) parameters.Add("birthday_date", BirthdayDate.Value.ToString("Y-m-d"));
                if (Description  != null) parameters.Add("description",   Description);
                if (City         != null) parameters.Add("city",          City);
                if (Source       != null) parameters.Add("source",        Source);
                return parameters;
            }
        }

        public string PhoneNumber;
        public CreateContact SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public string Email;
        public CreateContact SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public string FirstName;
        public CreateContact SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public string LastName;
        public CreateContact SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public string Gender;
        public CreateContact SetGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public DateTime? BirthdayDate;
        public CreateContact SetBirthdayDate(DateTime? birthdayDate)
        {
            BirthdayDate = birthdayDate;
            return this;
        }

        public string Description;
        public CreateContact SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public string City;
        public CreateContact SetCity(string city)
        {
            City = city;
            return this;
        }

        public string Source;
        public CreateContact SetSource(string source)
        {
            Source = source;
            return this;
        }
    }
}
