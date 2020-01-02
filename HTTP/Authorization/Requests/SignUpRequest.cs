﻿using InjectorGames.SharedLibrary.Credentials;
using System;
using System.Collections.Specialized;
using System.Net;

namespace InjectorGames.NetworkLibrary.HTTP.Authorization.Requests
{
    /// <summary>
    /// Sign up request class
    /// </summary>
    public class SignUpRequest : IHttpRequest
    {
        /// <summary>
        /// Request type string value
        /// </summary>
        public const string Type = "/api/sign-up";

        /// <summary>
        /// Request type string value
        /// </summary>
        public string RequestType => Type;

        /// <summary>
        /// Account name
        /// </summary>
        public Username name;
        /// <summary>
        /// Account passhash
        /// </summary>
        public Passhash passhash;
        /// <summary>
        /// Account email address
        /// </summary>
        public EmailAddress emailAddress;

        /// <summary>
        /// Creates a new sign up request class instance
        /// </summary>
        public SignUpRequest() { }
        /// <summary>
        /// Creates a new sign up request class instance
        /// </summary>
        public SignUpRequest(Username name, Passhash passhash, EmailAddress emailAddress)
        {
            this.name = name;
            this.passhash = passhash;
            this.emailAddress = emailAddress;
        }

        /// <summary>
        /// Creates a new sign up request class instance
        /// </summary>
        public SignUpRequest(NameValueCollection queryString)
        {
            if (queryString.Count != 3)
                throw new ArgumentException();

            name = new Username(queryString.Get(0));
            passhash = new Passhash(queryString.Get(1));
            emailAddress = new EmailAddress(queryString.Get(2));
        }

        /// <summary>
        /// Returns HTTP request URL
        /// </summary>
        public string ToURL(string address)
        {
            return $"{address}{Type}?n={name}&p={WebUtility.UrlEncode(passhash.ToBase64())}&e={WebUtility.UrlEncode(emailAddress)}";
        }
    }
}
