using LightInject;
using Navigation.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Navigation.ContainerExtension
{
    public static class ServiceContainerNavigationExtension
    {
        /// <summary>
        /// An extension for the <see cref="ServiceContainer"/> with which you can register the MainWindow, the MainViewModel
        /// and all other ViewModels used for navigation.
        /// </summary>
        /// <typeparam name="TMainWindow">The MainWindow</typeparam>.
        /// <typeparam name="TMainViewModel">The MainViewModel</typeparam>.
        /// <param name="container">The ServiceContainer</param>.
        /// <returns>The ServiceContainer with the other services</returns>.
        /// <exception cref="InvalidOperationException">Triggered if the call occurs more than once</exception>.
        public static ServiceContainer RegisterNavigation<TMainWindow, TMainViewModel>(this ServiceContainer container)
            where TMainWindow : Window, new()
            where TMainViewModel : INavigateViewModel
        {
            if (_mainViewModelIsSet)
            {
                throw new InvalidOperationException("Navigation may only be registered once");
            }

            // Register all ViewModels with the type INavigateViewModel from the passing assembly of the MainViewModel.
            container.RegisterAssembly(typeof(TMainViewModel).Assembly, (serviceType, implementigType) => RegisterPattern((TypeInfo)serviceType, (TypeInfo)implementigType));

            //Default services
            container.RegisterFrom<CompostionRoot>();

            //MainViewModel
            container.RegisterSingleton(s => new TMainWindow()
            {
                DataContext = s.GetInstance<TMainViewModel>()
            }); ;

            _mainViewModelIsSet = true;
            return container;
        }

        private static bool _mainViewModelIsSet = false;

        private static bool RegisterPattern(TypeInfo serviceType, TypeInfo implementigType)
        {
            bool implementingTypeBool = implementigType.ImplementedInterfaces.Any(interFace => interFace.Name.Equals(nameof(INavigateViewModel))) &&
                implementigType.IsClass;

            bool serviceTypeBool = serviceType.ImplementedInterfaces.Any(interFace => interFace.Name.Equals(nameof(INavigateViewModel))) &&
                serviceType.IsInterface;

            return implementingTypeBool && serviceTypeBool;
        }
    }
}