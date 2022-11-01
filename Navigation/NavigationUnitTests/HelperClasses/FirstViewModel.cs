using Navigation.Interfaces;

namespace NavigationUnitTests.HelperClasses
{
    internal class FirstViewModel : IFirstViewModel
    {
        public FirstViewModel(INavigationService navigationService)
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