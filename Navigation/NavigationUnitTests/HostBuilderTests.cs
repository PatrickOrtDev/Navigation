using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Navigation.HostBuilder;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System;
using System.Threading;

namespace NavigationUnitTests
{
    public class HostBuilderTests
    {
        #region NavigationDefaults

        [Test]
        public void RegisterNavigationDefaultsDoesNotThrow()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .Build();
            host.Start();

            Assert.DoesNotThrow(() => host.Services.GetRequiredService<INavigationService>());
            Assert.DoesNotThrow(() => host.Services.GetRequiredService<IModalNavigationService>());
            Assert.DoesNotThrow(() => host.Services.GetRequiredService<INavigationStore>());
            Assert.DoesNotThrow(() => host.Services.GetRequiredService<IModalNavigationStore>());
        }

        [Test]
        public void RegisterNavigationDefaultsResolveCorrectly()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .Build();
            host.Start();

            var navigationService = host.Services.GetRequiredService<INavigationService>();
            var modalNavigationService = host.Services.GetRequiredService<IModalNavigationService>();
            var navigationStore = host.Services.GetRequiredService<INavigationStore>();
            var modalNavigationStore = host.Services.GetRequiredService<IModalNavigationStore>();

            Assert.IsInstanceOf<NavigationService>(navigationService);
            Assert.IsInstanceOf<ModalNavigationService>(modalNavigationService);
            Assert.IsInstanceOf<NavigationStore>(navigationStore);
            Assert.IsInstanceOf<ModalNavigationStore>(modalNavigationStore);
        }

        #endregion NavigationDefaults

        #region MainViewModel

        [Test]
        [STAThread]
        public void RegisterMainViewModelDoesNotThrow()
        {
            Thread thread = new Thread(() =>
            {
                IHost host = Host.CreateDefaultBuilder()
                    .RegisterMainViewModel<ExampleViewModel, ExampleWindow>()
                    .Build();
                host.Start();

                Assert.DoesNotThrow(() => host.Services.GetRequiredService<ExampleWindow>());
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        [STAThread]
        [Test]
        public void RegisterMainViewModelResolveCorrectly()
        {
            Thread thread = new Thread(() =>
            {
                IHost host = Host.CreateDefaultBuilder()
                .RegisterMainViewModel<ExampleViewModel, ExampleWindow>()
                .Build();
                host.Start();

                var navigationService = host.Services.GetRequiredService<ExampleWindow>();

                Assert.IsInstanceOf<NavigationService>(navigationService);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        [STAThread]
        [Test]
        public void RegisterMultipleMainViewModelDoesThrow()
        {
            Thread thread = new Thread(() =>
            {
                IHostBuilder host = Host.CreateDefaultBuilder()
                .RegisterMainViewModel<ExampleViewModel, ExampleWindow>();

                Assert.Throws<InvalidOperationException>(() => host.RegisterMainViewModel<ExampleViewModel, ExampleWindow>());
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion MainViewModel

        #region NavigationService

        [Test]
        public void RegisterNavigationServiceDoesNotThrow()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .RegisterNavigationService<ExampleViewModel>()
                .Build();
            host.Start();

            Assert.DoesNotThrow(() => host.Services.GetRequiredService<ExampleViewModel>());
        }

        [Test]
        public void RegisterNavigationServiceResolveCorrectly()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .RegisterNavigationService<ExampleViewModel>()
                .Build();
            host.Start();

            var exampleViewModel = host.Services.GetRequiredService<ExampleViewModel>();

            Assert.IsInstanceOf<ExampleViewModel>(exampleViewModel);
        }

        #endregion NavigationService

        #region ModalNavigationService

        [Test]
        public void RegisterModalNavigationServiceDoesNotThrow()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .RegisterNavigationService<ExampleViewModel>()
                .Build();
            host.Start();

            Assert.DoesNotThrow(() => host.Services.GetRequiredService<ExampleViewModel>());
        }

        [Test]
        public void RegisterModalNavigationServiceResolveCorrectly()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .RegisterNavigationService<ExampleViewModel>()
                .Build();
            host.Start();

            var exampleViewModel = host.Services.GetRequiredService<ExampleViewModel>();

            Assert.IsInstanceOf<ExampleViewModel>(exampleViewModel);
        }

        #endregion ModalNavigationService
    }
}