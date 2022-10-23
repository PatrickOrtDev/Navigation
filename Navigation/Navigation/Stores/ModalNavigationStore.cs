using Navigation.Interfaces;
using Navigation.ViewModels;

namespace Navigation.Stores
{
    /// <inheritdoc/>
    public sealed class ModalNavigationStore : IModalNavigationStore
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
        public bool IsOpen => CurrentViewModel != null;

        /// <inheritdoc/>
        public event Action CurrentViewModelChanged;

        /// <inheritdoc/>
        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
