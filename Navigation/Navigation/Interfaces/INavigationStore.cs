using System;

namespace Navigation.Interfaces
{
    /// <summary>
    /// Stores the active ViewModel for navigation
    /// </summary>
    public interface INavigationStore
    {
        /// <summary>
        /// Triggered if the current ViewModel changes
        /// </summary>
        public event Action CurrentViewModelChanged;

        /// <summary>
        /// The current ViewModel
        /// </summary>
        public INavigateViewModel? CurrentViewModel { get; set; }
    }
}