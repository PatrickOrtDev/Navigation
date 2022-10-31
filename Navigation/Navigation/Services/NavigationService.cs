using LightInject;
using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public NavigationService(INavigationStore navigationStore, IModalNavigationStore modalNavigationStore, object v, (IServiceFactory, object) p)
        {
        }

        /// <inheritdoc/>
        public void Open<TViewModel>()
            where TViewModel : INavigateViewModel
        {
            var viewModel = _viewModelFactory(typeof(TViewModel));

            _navigationStore.CurrentViewModel = viewModel;
        }

        private readonly IModalNavigationStore _modalNavigationStore;
        private readonly INavigationStore _navigationStore;
        private readonly Func<Type, INavigateViewModel> _viewModelFactory;
    }
}