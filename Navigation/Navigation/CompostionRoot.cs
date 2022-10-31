using LightInject;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using System;

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
            //serviceRegistry.RegisterTransient(typeof(IViewModelFactory<>), typeof(ViewModelFactory<>));
            serviceRegistry.Register<Func<Type, INavigateViewModel>>((factory) => (type) => (INavigateViewModel)factory.GetInstance(type));

            serviceRegistry.RegisterSingleton<INavigationStore, NavigationStore>();
            serviceRegistry.RegisterSingleton<INavigationService>(factory => Facory(factory));
            serviceRegistry.RegisterSingleton<IModalNavigationStore, ModalNavigationStore>();
        }

        private NavigationService Facory(IServiceFactory factory)
        {
            var tes = factory.GetAllInstances<INavigateViewModel>();
            return new NavigationService
                (
                factory.GetInstance<INavigationStore>(),
                factory.GetInstance<IModalNavigationStore>(),
                factory.GetInstance<Func<Type, INavigateViewModel>>()
                ); ;
        }
    }
}