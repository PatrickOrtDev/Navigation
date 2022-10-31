using LightInject;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using System;
using System.Linq;
using System.Reflection;

namespace Navigation
{
    public class CompostionRoot : ICompositionRoot
    {
        //Registers default services of navigation
        public void Compose(IServiceRegistry serviceRegistry)
        {
            //Register function for getting Instance of INavigateViewModel
            serviceRegistry.Register<Func<Type, INavigateViewModel>>((factory) => (type) => (INavigateViewModel)factory.GetInstance(type));

            serviceRegistry.RegisterSingleton<INavigationStore, NavigationStore>();
            serviceRegistry.RegisterSingleton<INavigationService, NavigationService>();
            serviceRegistry.RegisterSingleton<IModalNavigationStore, ModalNavigationStore>();
        }
    }
}