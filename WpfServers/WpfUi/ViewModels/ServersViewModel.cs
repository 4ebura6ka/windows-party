using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ServersApi;
using ServersUi.Models;

namespace ServersUi.ViewModels
{
    public class ServersViewModel : Conductor<object>
    {
        public ServersViewModel()
        {
#if DEBUG
            Servers.Add(new ServerModel { ServerName = "Canada #10", Distance = "4073" });
            Servers.Add(new ServerModel { ServerName = "Lithuania #2", Distance = "874" });
            Servers.Add(new ServerModel { ServerName = "Latvia #2", Distance = "41" });
            Servers.Add(new ServerModel { ServerName = "France #3", Distance = "687" });
#endif
        }
        private BindableCollection<ServerModel> _servers = new BindableCollection<ServerModel>();

        public BindableCollection<ServerModel> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

        public void Logout()
        {
            Servers = new BindableCollection<ServerModel>();

            var loginViewModel = IoC.Get<LoginViewModel>();
            loginViewModel.Username = string.Empty;
            loginViewModel.Password = string.Empty;

            ActivateItem(loginViewModel);
            Console.WriteLine("logged out");
        }
        public void SetServers(ICollection<ServersResponse> ServersData)
        {
            Servers = new BindableCollection<ServerModel>();
            foreach (var serverData in ServersData)
            {
                ServerModel serverModel = new ServerModel();

                serverModel.Distance = serverData.Distance + " km";
                serverModel.ServerName = serverData.ServerName;

                Servers.Add(serverModel);
            }
        }
    }
}
