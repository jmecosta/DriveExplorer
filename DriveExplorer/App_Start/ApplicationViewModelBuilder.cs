﻿using System.Windows;
using Microsoft.Practices.ServiceLocation;
using DriveExplorer.Application.LifeCycleHook;
using DriveExplorer.Application.Navigation;
using DriveExplorer.Application.WindowServices;
using DriveExplorer.ViewModel;
using Neutronium.WPF.ViewModel;

namespace DriveExplorer {
    public class ApplicationViewModelBuilder {
        public ApplicationViewModel ApplicationViewModel { get; }
        private readonly LifeCycleEventsRegistror _LifeCycleEventsRegistror;

        public ApplicationViewModelBuilder(Window wpfWindow) {
            var window = new WindowViewModel(wpfWindow);
            var routeSolver = RoutingConfiguration.Register();
            var serviceLocatorBuilder = new DependencyInjectionConfiguration();
            var serviceLocatorLazy = serviceLocatorBuilder.GetServiceLocator();

            var navigation = NavigationViewModel.Create(serviceLocatorLazy, routeSolver);

            serviceLocatorBuilder.Register<IWindowViewModel>(window);
            serviceLocatorBuilder.Register<INavigator>(navigation);
            serviceLocatorBuilder.Register(navigation);

            ApplicationViewModel = new ApplicationViewModel(window, navigation);
            serviceLocatorBuilder.Register<IMessageBox>(ApplicationViewModel);
            serviceLocatorBuilder.Register<INotificationSender>(ApplicationViewModel);

            var serviceLocator = serviceLocatorLazy.Value;
            _LifeCycleEventsRegistror = RegisterLifeCycleEvents(serviceLocator);
        }

        private static LifeCycleEventsRegistror RegisterLifeCycleEvents(IServiceLocator serviceLocator) {
            var registor = serviceLocator.GetInstance<LifeCycleEventsRegistror>();
            return registor.Register();
        }
    }
}
