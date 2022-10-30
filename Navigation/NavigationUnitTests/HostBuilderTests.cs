using LightInject;
using Navigation.HostBuilder;
using Navigation.Interfaces;
using Navigation.Services;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System;
using System.Threading;

namespace NavigationUnitTests
{
    public class HostBuilderTests
    {
        #region NavigationDefaults

        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterMainViewModelAndResolveCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly);

            Assert.DoesNotThrow(() => container.GetInstance<ExampleWindow>());
            Assert.IsInstanceOf<ExampleWindow>(container.GetInstance<ExampleWindow>());
        }

        //[STAThread]
        [Test]
        public void RegisterMultipleMainViewModelDoesThrow()
        {
            Thread thread = new Thread(() =>
            {
                ServiceContainer container = new ServiceContainer();
                container.RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly);

                Assert.Throws<InvalidOperationException>(() => container.RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly));
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterNavigationAndResolveCorrectly()
        {
            ServiceContainer container = new ServiceContainer().RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly);
            container.RegisterAssembly(typeof(INavigateViewModel).Assembly);

            Assert.IsInstanceOf<NavigationService<IExampleViewModel>>(container.GetInstance<INavigationService<IExampleViewModel>>());
        }

        [Test]
        public void RegisterNavigationDefaultsDoesNotThrow()
        {
            Thread thread = new Thread(() =>
            {
                ServiceContainer container = new ServiceContainer().RegisterNavigation<ExampleWindow, IExampleViewModel>(typeof(ExampleWindow).Assembly);
                container.RegisterAssembly(typeof(INavigateViewModel).Assembly);

                Assert.DoesNotThrow(() => container.GetInstance<INavigationService<IExampleViewModel>>());
                Assert.DoesNotThrow(() => container.GetInstance<INavigationStore>());
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //#endregion NavigationDefaults

        //#region MainViewModel
        //#endregion MainViewModel

        //#region NavigationService

        //[Test]
        //public void RegisterNavigationServiceDoesNotThrow()
        //{
        //    IHost host = Host.CreateDefaultBuilder()
        //        .AddNavigationDefaults()
        //        .RegisterNavigationService<ExampleViewModel>()
        //        .Build();
        //    host.Start();

        //    Assert.DoesNotThrow(() => host.Services.GetRequiredService<ExampleViewModel>());
        //}

        //[Test]
        //public void RegisterNavigationServiceResolveCorrectly()
        //{
        //    IHost host = Host.CreateDefaultBuilder()
        //        .AddNavigationDefaults()
        //        .RegisterNavigationService<ExampleViewModel>()
        //        .Build();
        //    host.Start();

        //    var exampleViewModel = host.Services.GetRequiredService<ExampleViewModel>();

        //    Assert.IsInstanceOf<ExampleViewModel>(exampleViewModel);
        //}

        //#endregion NavigationService

        //#region ModalNavigationService

        //[Test]
        //public void RegisterModalNavigationServiceDoesNotThrow()
        //{
        //    IHost host = Host.CreateDefaultBuilder()
        //        .AddNavigationDefaults()
        //        .RegisterNavigationService<ExampleViewModel>()
        //        .Build();
        //    host.Start();

        //    Assert.DoesNotThrow(() => host.Services.GetRequiredService<ExampleViewModel>());
        //}

        //[Test]
        //public void RegisterModalNavigationServiceResolveCorrectly()
        //{
        //    IHost host = Host.CreateDefaultBuilder()
        //        .AddNavigationDefaults()
        //        .RegisterNavigationService<ExampleViewModel>()
        //        .Build();
        //    host.Start();

        //    var exampleViewModel = host.Services.GetRequiredService<ExampleViewModel>();

        //    Assert.IsInstanceOf<ExampleViewModel>(exampleViewModel);
        //}

        #endregion NavigationDefaults
    }
}