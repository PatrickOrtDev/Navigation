using System;

namespace Navigation.Interfaces
{
    /// <summary>
    /// Stores the active modal navigation ViewModel
    /// </summary>
    public interface IModalNavigationStore
    {
        /// <summary>
        /// Triggered if the current ViewModel changes.
        /// </summary>
        public event Action CurrentViewModelChanged;

        /// <summary>
        /// The current ViewModel
        /// </summary>
        public INavigateViewModel? CurrentViewModel { get; set; }

        /// <summary>
        /// Indicates whether a modal view is open.
        /// </summary>
        public bool IsOpen { get; }

        /// <summary>
        /// Closes the modal view
        /// </summary>
        public void Close();
    }
}