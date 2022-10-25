using Navigation.ViewModels;
using System;

namespace Navigation.Interfaces
{
    /// <summary>
    /// Managed die modale Navigation von Views
    /// </summary>
    public interface IModalNavigationStore
    {
        /// <summary>
        /// Das aktuelle ViewModel
        /// </summary>
        public ViewModelBase CurrentViewModel { get; set; }

        /// <summary>
        /// Gibt an ob eine modale View geöffnet ist
        /// </summary>
        public bool IsOpen { get; }

        /// <summary>
        /// Schließt die modale View
        /// </summary>
        public void Close();

        /// <summary>
        /// Wird ausgelößt, falls das aktuelle ViewModel sich ändert
        /// </summary>
        public event Action CurrentViewModelChanged;
    }
}
