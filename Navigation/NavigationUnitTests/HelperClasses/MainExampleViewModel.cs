using Navigation.Interfaces;
using System;

namespace NavigationUnitTests.HelperClasses
{
    internal class MainExampleViewModel : IMainExampleViewModel
    {
        public MainExampleViewModel(INavigationService navigationService, INavigationStore navigationStore, IModalNavigationStore modalNavigationStore)
        {
            //Als Start (Main) hat er nur ViewModels unter sich und braucht keinen Service zum wechseln
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

        private IModalNavigationStore _modalNavigationStore;
        private INavigationStore _navigationStore;
    }
}