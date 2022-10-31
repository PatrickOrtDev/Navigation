using LightInject;
using Microsoft.Extensions.Hosting;
using Navigation;
using Navigation.HostBuilder;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace NavigationUnitTests
{
    public class NavigationTests
    {
        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterMainViewModelAndResolveCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            //default from Assembly
            container.RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly);
            container.RegisterSingleton<INavigationStore, NavigationStore>();
            container.RegisterSingleton<INavigationService, Navigation.Services.NavigationService>();
            container.RegisterSingleton<IModalNavigationStore, ModalNavigationStore>();
            //container.RegisterSingleton(typeof(IViewModelFactory<>), typeof(ViewModelFactory<>));

            ExampleViewModel exampleViewModel;

            exampleViewModel = (ExampleViewModel)container.GetInstance<ExampleWindow>().DataContext;

            exampleViewModel._childService.Open<IExampleViewModelChild>();

            Assert.IsInstanceOf<ExampleViewModelChild>(exampleViewModel.ViewModel);
        }
    }
}