using Navigation.Interfaces;

namespace NavigationUnitTests.HelperClasses
{
    internal class SecondViewModel : ISecondViewModel
    {
        public SecondViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; set; }

        public void Dispose()
        {
            return;
        }
    }
}