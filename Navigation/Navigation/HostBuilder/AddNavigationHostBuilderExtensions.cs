using LightInject;
using Navigation.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Navigation.HostBuilder
{
    public static class AddNavigationHostBuilderExtensions
    {
        /// <summary>
        /// Eine Extension für den <see cref="ServiceContainer"/> mit der man für die Navigation das MainWindow, das MainViewModel
        /// und alle weiteren ViewModels die für die Navigation genutzt wird regestriert werden.
        /// </summary>
        /// <typeparam name="TMainWindow">Das MainWindow</typeparam>
        /// <typeparam name="TMainViewModel">Das MainViewModel</typeparam>
        /// <param name="container">Der ServiceContainer</param>
        /// <param name="viewModelAssembly">Die Assembly mit den ViewModels die für die Navigation regestriert werden</param>
        /// <returns>Den ServiceContainer mit den weiteren Services</returns>
        /// <exception cref="InvalidOperationException">Falls der Aufruf öfter als ein mal stattfindet</exception>
        public static ServiceContainer RegisterNavigation<TMainWindow, TMainViewModel>(this ServiceContainer container, Assembly viewModelAssembly)
            where TMainWindow : Window, new()
            where TMainViewModel : INavigateViewModel
        {
            if (_mainViewModelIsSet)
            {
                throw new InvalidOperationException("You can't register two MainViewModels");
            }

            // Alle ViewModels mit dem Typen INavigateViewModel aus der übergebenden Assambly registrieren
            container.RegisterAssembly(viewModelAssembly, (serviceType, implementigType) => RegisterPattern((TypeInfo)serviceType, (TypeInfo)implementigType));

            //MainViewModel regestrieren
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