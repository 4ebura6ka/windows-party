﻿using Caliburn.Micro;

namespace ServersUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            OpenLoginView();
        }

        public void OpenLoginView()
        {
            var loginViewModel = IoC.Get<LoginViewModel>();
            ActivateItem(loginViewModel);
        }

        public void OpenServersView()
        {
            var serversViewModel = IoC.Get<ServersViewModel>();
            ActivateItem(serversViewModel);
        }
    }
}
