using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Navigation.HostBuilder;
using Navigation.Interfaces;
using Navigation.Services;
using Navigation.Stores;
using NUnit.Framework;

namespace NavigationUnitTests
{
    public class HostBuilderTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RegisterNavigationDefaultsDoesNotThrow()
        {
            IHost host = Host.CreateDefaultBuilder()
                .AddNavigationDefaults()
                .Build();
            host.Start();
            
            host.Services.GetRequiredService<IModalNavigationStore>();
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
    }
}