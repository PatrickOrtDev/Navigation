using LightInject;
using Navigation.ContainerExtension;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System.Reflection;
using System.Threading;

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

        [TearDown]
        public void TearDown()
        {
            FieldInfo? field = typeof(ServiceContainerNavigationExtension).GetField("_mainViewModelIsSet",
                            BindingFlags.Static |
                            BindingFlags.NonPublic);

            field?.SetValue(null, false);
        }
    }
}