using LightInject;
using Navigation;
using Navigation.ContainerExtension;
using Navigation.Interfaces;
using NavigationUnitTests.HelperClasses;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace NavigationUnitTests
{
    public class DIRegistrationTests
    {
        [Apartment(ApartmentState.STA)]
        [Test]
        public void RegisterAndResolveCompostionRootCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterFrom<CompostionRoot>();

            Assert.That(container, Is.Not.Null);
            Assert.That(container.AvailableServices, Is.Not.Null);
            Assert.That(container.AvailableServices.ToList(), Has.Count.EqualTo(4));

            Assert.DoesNotThrow(() => container.GetInstance<INavigationService>());
            Assert.DoesNotThrow(() => container.GetInstance<INavigationStore>());
            Assert.DoesNotThrow(() => container.GetInstance<IModalNavigationStore>());
        }

        [Test]
        public void RegisterAndResolveRegisterNavigationCorrectly()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterNavigation<MainExampleWindow, IMainExampleViewModel>();

            Assert.That(container, Is.Not.Null);
            Assert.That(container.AvailableServices, Is.Not.Null);
            Assert.That(container.AvailableServices.ToList(), Has.Count.EqualTo(8));

            Assert.DoesNotThrow(() => container.GetInstance<INavigationService>());
            Assert.DoesNotThrow(() => container.GetInstance<INavigationStore>());
            Assert.DoesNotThrow(() => container.GetInstance<IModalNavigationStore>());
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