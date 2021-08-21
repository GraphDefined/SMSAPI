/*
 * Copyright (c) 2017-2021, Achim Friedland <achim.friedland@graphdefined.com>
 * This file is part of GraphDefined SMSAPI <https://github.com/GraphDefined/SMSAPI>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Text;
using System.Security.Cryptography;

#endregion

namespace com.GraphDefined.SMSApi.API
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
        /// <param name="Password">The password.</param>
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
