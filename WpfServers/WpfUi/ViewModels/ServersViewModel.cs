using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ServersUi.Models;

namespace ServersUi.ViewModels
{
    public class ServersViewModel : Screen
    {
        public ServersViewModel()
        {
            Servers.Add(new ServerModel { ServerName = "Canada #10", Distance = 4073 });
            Servers.Add(new ServerModel { ServerName = "Lithuania #2", Distance = 874 });
            Servers.Add(new ServerModel { ServerName = "Latvia #2", Distance = 41 });
            Servers.Add(new ServerModel { ServerName = "France #3", Distance = 687 });
        }
        private BindableCollection<ServerModel> _servers = new BindableCollection<ServerModel>();

        public BindableCollection<ServerModel> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

    }
}
