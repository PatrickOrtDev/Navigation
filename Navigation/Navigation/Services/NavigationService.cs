using Navigation.Interfaces;
using System;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public sealed class NavigationService : INavigationService
    {
        /// <inheritdoc/>
        public NavigationService(INavigationStore navigationStore, IModalNavigationStore modalNavigationStore, Func<Type, INavigateViewModel> viewModelFactory)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            _viewModelFactory = viewModelFactory;
        }

        /// <inheritdoc/>
        public void Open<TViewModel>()
            where TViewModel : INavigateViewModel
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            _navigationStore.CurrentViewModel = viewModel;
        }

        public void OpenModal<TViewModel>()
            where TViewModel : INavigateViewModel
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            _modalNavigationStore.CurrentViewModel = viewModel;
        }

        private readonly IModalNavigationStore _modalNavigationStore;
        private readonly INavigationStore _navigationStore;
        private readonly Func<Type, INavigateViewModel> _viewModelFactory;
    }
}