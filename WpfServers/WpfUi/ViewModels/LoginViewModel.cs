﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ServersApi;

namespace ServersUi.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly ILog _logger;

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }    
            set { password = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanLogin(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }
    
        public LoginViewModel(IWindowManager windowManager, ILog log)
        {
            _logger = log;
            _windowManager = windowManager;

            Password = "partyanimal";
            Username = "tesonet";
        }

        public async void Login(string username, string password)
        {
            ApiClient apiClient = new ApiClient("http://playground.tesonet.lt/v1/tokens");

            Dictionary<string, string> requestParams = new Dictionary<string, string> { { "username", Username }, { "password", Password } };

            string token = await apiClient.RetrieveToken(requestParams);
            
            if (!string.IsNullOrEmpty(token))
            {
                apiClient.ApiUrl = "http://playground.tesonet.lt/v1/servers";
                var response = await apiClient.RetrieveServers(token);
                var serversViewModel = IoC.Get<ServersViewModel>();
                serversViewModel.SetServers(response);

                var shellViewModel = IoC.Get<ShellViewModel>();
                shellViewModel.OpenServersView();
            }
            else
            {
                ErrorMessage = "Login failed. Please check username and password.";
                _logger.Error(new Exception($"Login failed. Please check username and password: {username} {password} was used."));
            }
        }
    }
}
