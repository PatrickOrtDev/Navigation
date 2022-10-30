using LightInject;
using Navigation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public sealed class NavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : INavigateViewModel
    {
        /// <inheritdoc/>
        public NavigationService(INavigationStore navigationStore, Func<TViewModel> viewModelFunc)
        {
            _navigationStore = navigationStore;
            _viewModelFunc = viewModelFunc;
        }

        /// <inheritdoc/>
        public void Open()
        {
            _navigationStore.CurrentViewModel = _viewModelFunc.Invoke();
        }

        private readonly INavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModelFunc;
    }
}