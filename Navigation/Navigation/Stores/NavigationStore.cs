using Navigation.Interfaces;
using System;

namespace Navigation.Stores
{
    /// <inheritdoc/>
    public sealed class NavigationStore : INavigationStore
    {
        /// <inheritdoc/>
        public event Action? CurrentViewModelChanged;

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

        private INavigateViewModel? _currentViewModel;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}