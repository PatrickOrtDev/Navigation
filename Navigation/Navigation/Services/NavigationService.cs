using Microsoft.Extensions.DependencyInjection;
using Navigation.Interfaces;
using Navigation.ViewModels;
using System;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public class NavigationService : INavigationService
    {
        private readonly INavigationStore _navigationStore;
        private readonly IServiceProvider _service;

        /// <inheritdoc/>
        public NavigationService(INavigationStore navigationStore, IServiceProvider service)
        {
            _navigationStore = navigationStore;
            _service = service;

        }

        /// <inheritdoc/>
        public void Open<TViewModel>() where TViewModel : ViewModelBase
        {
            _navigationStore.CurrentViewModel = _service.GetRequiredService<TViewModel>();
        }
    }
}
