using Navigation.Interfaces;
using Navigation.ViewModels;

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
            _navigationStore.CurrentViewModel = _service.GetRequiredService<CreateViewModel<TViewModel>>().Invoke();
        }
    }
}
