using LightInject;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class CompostionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            //MainWindow
            // Alle ViewModels mit dem Typen INavigateViewModel aus der übergebenden Assambly registrieren
            //serviceRegistry.RegisterAssembly(typeof(IViewModelBase), (serviceType, implementigType) => serviceType.IsInstanceOfType(typeof(INavigateViewModel)));

            //Registriere die Services und Stores
            serviceRegistry.RegisterSingleton<INavigationStore, NavigationStore>();
            serviceRegistry.RegisterSingleton(typeof(INavigationService<>), typeof(NavigationService<>));
        }
    }
}