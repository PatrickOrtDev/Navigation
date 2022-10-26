using Navigation.Interfaces;
using System;

namespace Navigation.Stores
{
    /// <inheritdoc/>
    public sealed class NavigationStore : INavigationStore
    {
        private INavigateViewModel? _currentViewModel;

        /// <inheritdoc/>
        public INavigateViewModel? CurrentViewModel
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
