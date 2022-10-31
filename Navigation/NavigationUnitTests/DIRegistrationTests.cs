using LightInject;
using Navigation;
using Navigation.ContainerExtension;
using Navigation.Interfaces;
using Navigation.Services;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace NavigationUnitTests
{
    [SingleThreadedAttribute]
    public class DIRegistrationTests
    {
        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterAndResolveCompostionRootCorrectly()
        {
            using (ServiceContainer container = new ServiceContainer())
            {
                container.RegisterFrom<CompostionRoot>();

                Assert.That(container, Is.Not.Null);
                Assert.That(container.AvailableServices, Is.Not.Null);
                Assert.That(container.AvailableServices.ToList(), Has.Count.EqualTo(4));

                Assert.DoesNotThrow(() => container.GetInstance<INavigationService>());
                Assert.DoesNotThrow(() => container.GetInstance<INavigationStore>());
                Assert.DoesNotThrow(() => container.GetInstance<IModalNavigationStore>());
            }
        }

        [STAThread]
        [Test]
        public void RegisterAndResolveRegisterNavigationCorrectly()
        {
            using (ServiceContainer container = new ServiceContainer())
            {
                container.RegisterNavigation<MainExampleWindow, IMainExampleViewModel>();

                Assert.That(container, Is.Not.Null);
                Assert.That(container.AvailableServices, Is.Not.Null);
                Assert.That(container.AvailableServices.ToList(), Has.Count.EqualTo(8));

                Assert.DoesNotThrow(() => container.GetInstance<INavigationService>());
                Assert.DoesNotThrow(() => container.GetInstance<INavigationStore>());
                Assert.DoesNotThrow(() => container.GetInstance<IModalNavigationStore>());
            }
        }
    }
}