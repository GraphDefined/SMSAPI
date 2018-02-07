using System;
using System.Collections.Specialized;

/**
 * add_user * Nazwa dodawanego podużytkownika bez prefiksu użytkownika głównego
 * pass * Hasło do panelu klienta SMSAPI dodawanego podużytkownika zakodowane w md5
 * pass_api Hasło do interfejsu API dla podużytkownika zakodowane w md5, brak tego parametru spowoduje ustawienie jako hasła do API kopii hasła do panelu klienta
 * limit Limit punktów przydzielony podużytkownikowi
 * month_limit Ilość punktów która będzie przypisana do konta podużytkownika każdego pierwszego dnia 
 * senders Udostępnienie pól nadawców konta głównego (dostępne wartości: 1 – udostępniaj, 0 – nie udostępniaj, domyślnie wartość równa 0)
 * phonebook Udostępnienie grup książki telefonicznej konta głównego (dostępne wartości: 1 – udostępniaj, 0 – nie udostępniaj, domyślnie wartość równa 0). Po udostępnieniu 
 *      książki podużytkownik będzie mógł wysyłać do grup wiadomości nie będzie jednak widział poszczególnych kontaktów w książce telefonicznej.
 * active Aktywowanie konta podużytkownika (dostępne wartości: 1 – aktywne, 0 – nieaktywne, domyślnie wartość równa 0)
 * info Dodatkowy opis podużytkownika
 */
namespace SMSApi.Api.Action
{

    public class UserEdit : BaseSimple<Response.User>
    {

        #region Data

        const Int32 SENDERS_NOSHARE    = 0;
        const Int32 SENDERS_SHARE      = 1;

        const Int32 PHONEBOOK_NOSHARE  = 0;
        const Int32 PHONEBOOK_SHARE    = 1;

        #endregion

        protected String  Username        { get; }
        protected String  Password        { get; set; }
        protected String  PasswordApi     { get; set; }
        protected Double  Limit           { get; set; }
        protected Double  MonthLimit      { get; set; }
        protected Int32   Senders         { get; set; }
        protected Int32   Phonebook       { get; set; }
        protected Int32   Active          { get; set; }
        protected String  Info            { get; set; }
        protected Boolean WithoutPrefix   { get; set; }

        public UserEdit(Credentials  Credentials,
                        HTTPClient   HTTPClient,
                        String       Username)

            : base(Credentials, HTTPClient)

        {

            this.Username       = Username;
            this.Limit          = -1;
            this.MonthLimit     = -1;
            this.Active         = -1;
            this.Phonebook      = -1;
            this.Senders        = -1;
            this.WithoutPrefix  = false;

        }

        protected override String Uri => "user.do";

        protected override NameValueCollection Values()
        {

            var collection = new NameValueCollection {
                                 { "format",    "json" },
                                 { "username",  Credentials.Username },
                                 { "password",  Credentials.Password },
                                 { "set_user",  Username }
                             };

            if (Password    != null) collection.Add("pass",            Password);
            if (PasswordApi != null) collection.Add("pass_api",        PasswordApi);
            if (Limit       >= 0)    collection.Add("limit",           Limit.     ToString());
            if (MonthLimit  >= 0)    collection.Add("month_limit",     MonthLimit.ToString());
            if (Senders     >= 0)    collection.Add("senders",         Senders.   ToString());
            if (Phonebook   >= 0)    collection.Add("phonebook",       Phonebook. ToString());
            if (Active      >= 0)    collection.Add("active",          Active > 0 ? "1" : "0");
            if (Info        != null) collection.Add("info",            Info);
            if (WithoutPrefix)       collection.Add("without_prefix",  "1");

            return collection;

        }

    }

}
