﻿using LightInject;
using Navigation.ContainerExtension;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System.Threading;

namespace NavigationUnitTests
{
    [SingleThreadedAttribute]
    public class ModalNavigationTests
    {
        [Apartment(ApartmentState.STA)]
        [Test]
        public void NavigateToViewModelCorrectly()
        {
            using (ServiceContainer container = new ServiceContainer())
            {
                container.RegisterNavigation<MainExampleWindow, IMainExampleViewModel>();

                var mainViewModel = (MainExampleViewModel)container.GetInstance<MainExampleWindow>().DataContext;

                mainViewModel.NavigationService.OpenModal<IFirstViewModel>();
                Assert.IsInstanceOf<FirstViewModel>(mainViewModel.ModalViewModel);

                mainViewModel.NavigationService.OpenModal<ISecondViewModel>();
                Assert.IsInstanceOf<SecondViewModel>(mainViewModel.ModalViewModel);

                mainViewModel.NavigationService.OpenModal<IFirstViewModel>();
                Assert.IsInstanceOf<FirstViewModel>(mainViewModel.ModalViewModel);
            }
        }
    }
}