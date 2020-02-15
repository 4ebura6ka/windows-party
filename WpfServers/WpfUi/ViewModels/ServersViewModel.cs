using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace WpfUi.ViewModels
{
    public class ServersViewModel : Screen
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
    }
}
