using System;
using Microsoft.Extensions.DependencyInjection;
using Navigation.Interfaces;
using Navigation.ViewModels;

namespace Navigation.Services
{
    /// <inheritdoc/>
    public class ModalNavigationService : IModalNavigationService
    {
        private readonly IModalNavigationStore _navigationStore;
        private readonly IServiceProvider _service;

        /// <inheritdoc/>
        public ModalNavigationService(IModalNavigationStore navigationStore, IServiceProvider service)
        {
            _navigationStore = navigationStore;
            _service = service;

        }

        /// <inheritdoc/>
        public void Open<TViewModel>() where TViewModel : ViewModelBase
        {
            _navigationStore.CurrentViewModel = _service.GetRequiredService<CreateViewModel<TViewModel>>().Invoke();
        }

        /// <inheritdoc/>
        public void CloseModal()
        {
            _navigationStore.Close();
        }
    }
}
