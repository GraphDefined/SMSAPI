using System;
using System.Text;
using System.Security.Cryptography;

namespace SMSApi.Api
{

    public class Credentials
    {

        public String Username { get; }
        public String Password { get; }


        private Credentials(String Username,
                            String Password)
        {
            this.Username  = Username;
            this.Password  = Password;
        }

        public static Credentials Create(String Username,
                                         String Password)
        {

            var hash     = new StringBuilder();
            var md5      = MD5.Create();
            var hashbin  = md5.ComputeHash(Encoding.UTF8.GetBytes(Password));

            for (int i = 0; i < hashbin.Length; i++)
                hash.Append(hashbin[i].ToString("x2"));

            return new Credentials(Username,
                                 hash.ToString());

        }

        public static Credentials CreateMD5(String Username,
                                            String Password)
            => new Credentials(Username,
                               Password);

    }

}
