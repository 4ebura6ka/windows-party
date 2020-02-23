using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using ServersUi.ViewModels;

namespace ServersUi
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.RegisterSingleton(typeof(LoginViewModel), "loginViewModel", typeof(LoginViewModel));
            _container.RegisterSingleton(typeof(ServersViewModel), "serversViewModel", typeof(ServersViewModel));
            _container.RegisterSingleton(typeof(ShellViewModel), "shellViewModel", typeof(ShellViewModel));

            _container.RegisterInstance(typeof(ILog), "Logger", new DebugLogger(LogManager.GetLog.GetType()));
            _container.RegisterInstance(typeof(IWindowManager), "WindowManager", new WindowManager());
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
