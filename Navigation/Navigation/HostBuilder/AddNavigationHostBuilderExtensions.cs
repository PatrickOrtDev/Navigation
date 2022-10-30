using LightInject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Navigation.HostBuilder
{
    public static class AddNavigationHostBuilderExtensions
    {
        public static ServiceContainer RegisterNavigation<TMainWindow, TMainViewModel>(this ServiceContainer registry, Assembly viewModelAssembly)
            where TMainWindow : Window, new()
            where TMainViewModel : INavigateViewModel
        {
            if (_mainViewModelIsSet)
            {
                throw new InvalidOperationException("You can't register two MainViewModels");
            }

            // Alle ViewModels mit dem Typen INavigateViewModel aus der übergebenden Assambly registrieren
            registry.RegisterAssembly(viewModelAssembly, (serviceType, implementigType) => RegisterPattern((TypeInfo)serviceType, (TypeInfo)implementigType));

            //MainViewModel regestrieren
            registry.RegisterSingleton(s => new TMainWindow()
            {
                DataContext = s.GetInstance<TMainViewModel>()
            });

            _mainViewModelIsSet = true;
            return registry;
        }

        private static bool _mainViewModelIsSet = false;

        private static bool RegisterPattern(TypeInfo serviceType, TypeInfo implementigType)
        {
            bool implementingTypeBool = implementigType.ImplementedInterfaces.Any(interFace => interFace.Name.Equals(nameof(INavigateViewModel))) &&
                implementigType.IsClass;
            bool serviceTypeBool = serviceType.ImplementedInterfaces.Any(interFace => interFace.Name.Equals(nameof(INavigateViewModel)));

            return implementingTypeBool && serviceTypeBool;
        }
    }
}