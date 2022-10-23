using Navigation.Interfaces;
using Navigation.ViewModels;

namespace Navigation.Stores
{
    /// <inheritdoc/>
    public class NavigationStore : INavigationStore
    {
        private ViewModelBase _currentViewModel;

        /// <inheritdoc/>
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        /// <inheritdoc/>
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
