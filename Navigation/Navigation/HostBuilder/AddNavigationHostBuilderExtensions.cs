using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Navigation.HostBuilder
{
    public static class AddNavigationHostBuilderExtensions
    {
        private static bool _mainViewModelIsSet;

        public static IHostBuilder AddNavigationDefaults(this IHostBuilder host)
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<IModalNavigationService, ModalNavigationService>();
            servicesCollection.AddSingleton<INavigationStore, NavigationStore>();
            servicesCollection.AddSingleton<IModalNavigationStore, ModalNavigationStore>();
            servicesCollection.AddSingleton<INavigationService, NavigationService>();
            host.ConfigureServices(services =>
            {
                services.Add(servicesCollection);
            });

            return host;
        }

        /// <summary>
        /// Registrirt das MainViewModel
        /// </summary>
        public static IHostBuilder RegisterMainViewModel<TViewModel, TMainWindow>(this IHostBuilder host) 
        where TViewModel : class, INavigateViewModel
            where TMainWindow : Window, new()
        {
            if (_mainViewModelIsSet)
            {
                throw new InvalidOperationException("You can't register two MainViewModels");
            }
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<TViewModel>();
            servicesCollection.AddSingleton(s => new TMainWindow()
            {
                DataContext = s.GetRequiredService<TViewModel>()
            });

            host.ConfigureServices(services =>
            {
                services.Add(servicesCollection);
            });

            return host;
        }

        /// <summary>
        /// Registrirt das MainViewModel
        /// </summary>
        public static IHostBuilder RegisterNavigationService<TViewModel>(this IHostBuilder host)
          where TViewModel : class, INavigateViewModel
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddTransient<TViewModel>();
            servicesCollection.AddSingleton
                (
                    s => new NavigationService
                    (
                        s.GetRequiredService<INavigationStore>(),
                        s
                    )
                );

            host.ConfigureServices(services =>
            {
                services.Add(servicesCollection);
            });

            return host;
        }

        /// <summary>
        /// Registrirt das MainViewModel
        /// </summary>
        public static IHostBuilder RegisterModalNavigationService<TViewModel>(this IHostBuilder host)
          where TViewModel : class, INavigateViewModel
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddTransient<TViewModel>();
            servicesCollection.AddSingleton
                (
                    s => new ModalNavigationService
                    (
                        s.GetRequiredService<IModalNavigationStore>(),
                        s
                    )
                );

            host.ConfigureServices(services =>
            {
                services.Add(servicesCollection);
            });

            return host;
        }
    }
}
