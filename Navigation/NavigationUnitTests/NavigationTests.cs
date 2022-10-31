using LightInject;
using Microsoft.Extensions.Hosting;
using Navigation;
using Navigation.ContainerExtension;
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
        public void NavigateToViewModelCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterNavigation<MainExampleWindow, IMainExampleViewModel>();

            var mainViewModel = (MainExampleViewModel)container.GetInstance<MainExampleWindow>().DataContext;

            mainViewModel.NavigationService.Open<IFirstViewModel>();
            Assert.IsInstanceOf<FirstViewModel>(mainViewModel.ViewModel);

            mainViewModel.NavigationService.Open<ISecondViewModel>();
            Assert.IsInstanceOf<SecondViewModel>(mainViewModel.ViewModel);

            mainViewModel.NavigationService.Open<IFirstViewModel>();
            Assert.IsInstanceOf<FirstViewModel>(mainViewModel.ViewModel);
        }

        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterAndResolveMainViewModelAndWindwoCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterNavigation<MainExampleWindow, IMainExampleViewModel>();

            Assert.IsInstanceOf<MainExampleWindow>(container.GetInstance<MainExampleWindow>());
            Assert.IsInstanceOf<MainExampleViewModel>(container.GetInstance<MainExampleWindow>().DataContext);
            Assert.DoesNotThrow(() => container.GetInstance<MainExampleWindow>().Show());
        }
    }
}