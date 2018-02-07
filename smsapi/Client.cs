using System;
using System.Text;
using System.Security.Cryptography;

namespace SMSApi.Api
{

    public class Client
    {

        public String Username { get; }
        public String Password { get; }


        private Client(String Username,
                      String Password)
        {
            this.Username  = Username;
            this.Password  = Password;
        }

        public static Client Create(String Username,
                                    String Password)
        {

            var hash     = new StringBuilder();
            var md5      = MD5.Create();
            var hashbin  = md5.ComputeHash(Encoding.UTF8.GetBytes(Password));

            for (int i = 0; i < hashbin.Length; i++)
                hash.Append(hashbin[i].ToString("x2"));

            return new Client(Username,
                              hash.ToString());

        }

        public static Client CreateMD5(String Username,
                                       String Password)
            => new Client(Username,
                          Password);

    }

}
