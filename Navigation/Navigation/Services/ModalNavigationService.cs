using LightInject;
using Microsoft.Extensions.DependencyInjection;
using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public sealed class ModalNavigationService : IModalNavigationService
    {
        /// <inheritdoc/>
        public ModalNavigationService(IModalNavigationStore navigationStore, IEnumerable<Lazy<INavigateViewModel>> serviceProvider)
        {
            _navigationStore = navigationStore;
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public void CloseModal()
        {
            _navigationStore.Close();
        }

        /// <inheritdoc/>
        public void Open<TViewModel>() where TViewModel : INavigateViewModel
        {
            _navigationStore.CurrentViewModel = (INavigateViewModel?)_serviceProvider.Single(viewModel => viewModel.Value.GetType().Equals(typeof(TViewModel)));
        }

        private readonly IModalNavigationStore _navigationStore;
        private readonly IEnumerable<Lazy<INavigateViewModel>> _serviceProvider;
    }
}