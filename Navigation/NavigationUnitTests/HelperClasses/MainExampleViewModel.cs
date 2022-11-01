using Navigation.Interfaces;
using System;

namespace NavigationUnitTests.HelperClasses
{
    internal class MainExampleViewModel : IMainExampleViewModel
    {
        public MainExampleViewModel(INavigationService navigationService, INavigationStore navigationStore, IModalNavigationStore modalNavigationStore)
        {
            NavigationService = navigationService;
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public INavigateViewModel? ModalViewModel => _modalNavigationStore.CurrentViewModel;
        public INavigationService NavigationService { get; set; }
        public INavigateViewModel? ViewModel => _navigationStore.CurrentViewModel;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private readonly IModalNavigationStore _modalNavigationStore;
        private readonly INavigationStore _navigationStore;
    }
}