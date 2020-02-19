using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

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

        public void Login (string username, string password)
        {
            
        }
    }
}
