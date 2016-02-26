﻿using System;
using System.Configuration;
using System.Text;

namespace CoreValueContacts.API.Client.ApiContext
{
    public class ApiClientConfigurationExpression
    {
        private readonly ApiClientContext _apiClientContext;

        public ApiClientConfigurationExpression(ApiClientContext apiClientContext)
        {
            if(apiClientContext == null)
            {
                throw new ArgumentNullException("apiClientContext");
            }

            _apiClientContext = apiClientContext;
        }

        public ApiClientConfigurationExpression SetCredentialsFromAppSetting(string usernameAppSettingKey,
            string passwordAppSettingKey)
        {
            
            if (string.IsNullOrEmpty(usernameAppSettingKey))
            {

                throw new ArgumentException("The argument 'usernameAppSettingKey' is null or empty.", "usernameAppSettingKey");
            }

            if (string.IsNullOrEmpty(passwordAppSettingKey))
            {

                throw new ArgumentException("The argument 'passwordAppSettingKey' is null or empty.", "passwordAppSettingKey");
            }

            string username = ConfigurationManager.AppSettings[usernameAppSettingKey];
            string password = ConfigurationManager.AppSettings[passwordAppSettingKey];

            if (string.IsNullOrEmpty(username))
            {

                throw new ArgumentException(
                    string.Format("The application setting '{0}' does not exist or its value is null.", usernameAppSettingKey));
            }

            if (string.IsNullOrEmpty(password))
            {

                throw new ArgumentException(
                    string.Format("The application setting '{0}' does not exist or its value is null.", passwordAppSettingKey));
            }

            _apiClientContext.AuthorizationValue = EncodeToBase64(string.Format("{0}:{1}", username, password));

            return this;
        }

        public ApiClientConfigurationExpression ConnectTo(string baseUri)
        {
            if(string.IsNullOrEmpty(baseUri))
            {
                throw new ArgumentNullException("baseUri");
            }

            _apiClientContext.BaseUri = new Uri(baseUri);

            return this;
        }

        private static string EncodeToBase64(string value)
        {
            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
