using System;
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
        private string username = "Serz";
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

        public bool CanLogin(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        public async void Login(string username, string password)
        {
            ApiClient apiClient = new ApiClient("http://playground.tesonet.lt/v1/tokens");

            Dictionary<string, string> requestParams = new Dictionary<string, string> { { "username", "tesonet" }, { "password", "partyanimal" } };

            await apiClient.ApiCall(requestParams);
        }
    }
}
