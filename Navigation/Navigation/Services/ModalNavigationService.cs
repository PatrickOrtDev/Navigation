using Microsoft.Extensions.DependencyInjection;
using Navigation.Interfaces;
using System;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public sealed class ModalNavigationService : IModalNavigationService
    {
        private readonly IModalNavigationStore _navigationStore;
        private readonly IServiceProvider _serviceProvider;

        /// <inheritdoc/>
        public ModalNavigationService(IModalNavigationStore navigationStore, IServiceProvider serviceProvider)
        {
            _navigationStore = navigationStore;
            _serviceProvider = serviceProvider;

        }

        /// <inheritdoc/>
        public void Open<TViewModel>() where TViewModel : INavigateViewModel
        {
            _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        }

        /// <inheritdoc/>
        public void CloseModal()
        {
            _navigationStore.Close();
        }
    }
}
