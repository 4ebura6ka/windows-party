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
        private string login = "Serz";
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
