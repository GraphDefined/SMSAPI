using System;
using System.Text;
using System.Security.Cryptography;

namespace SMSApi.Api
{

    /// <summary>
    /// Credentials used for authentication at the SMS API.
    /// </summary>
    public class Credentials
    {

        #region Properties

        /// <summary>
        /// The username.
        /// </summary>
        public String  Username   { get; }

        /// <summary>
        /// The password.
        /// </summary>
        public String  Password   { get; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new credential.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The MD5-hashed password.</param>
        private Credentials(String Username,
                            String Password)
        {

            this.Username  = Username;
            this.Password  = Password;

        }

        #endregion


        #region (static) CreateMD5(Username, Password)

        /// <summary>
        /// Create a new credential based on the given username and password.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="PasswordHash">The password.</param>
        public static Credentials Create(String  Username,
                                         String  Password)
        {

            #region Initial checks

            if (!String.IsNullOrEmpty(Username))
                Username = Username.Trim();

            if (!String.IsNullOrEmpty(Password))
                Password = Password.Trim();

            if (String.IsNullOrEmpty(Username))
                throw new ArgumentNullException(nameof(Username),  "The given username must not be null or empty!");

            if (String.IsNullOrEmpty(Password))
                throw new ArgumentNullException(nameof(Password),  "The given password must not be null or empty!");

            #endregion

            var MD5HashString  = new StringBuilder();
            var MD5Hash        = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password));

            for (var i=0; i<MD5Hash.Length; i++)
                MD5HashString.Append(MD5Hash[i].ToString("x2"));

            return new Credentials(Username,
                                   MD5HashString.ToString());

        }

        #endregion

        #region (static) CreateMD5(Username, PasswordHashMD5)

        /// <summary>
        /// Create a new credential based on the given username and MD5-hashed password.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="PasswordHashMD5">The MD5-hashed password.</param>
        public static Credentials CreateMD5(String  Username,
                                            String  PasswordHashMD5)
        {

            #region Initial checks

            if (!String.IsNullOrEmpty(Username))
                Username         = Username.Trim();

            if (!String.IsNullOrEmpty(PasswordHashMD5))
                PasswordHashMD5  = PasswordHashMD5.Trim();

            if (String.IsNullOrEmpty(Username))
                throw new ArgumentNullException(nameof(Username),         "The given username must not be null or empty!");

            if (String.IsNullOrEmpty(PasswordHashMD5))
                throw new ArgumentNullException(nameof(PasswordHashMD5),  "The given MD5-hashed password must not be null or empty!");

            #endregion

            return new Credentials(Username,
                                   PasswordHashMD5);

        }

        #endregion


    }

}
