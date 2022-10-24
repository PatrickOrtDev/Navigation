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
        ViewModelBase CurrentViewModel { get; set; }

        /// <summary>
        /// Gibt an ob eine modale View geöffnet ist
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Schließt die modale View
        /// </summary>
        void Close();

        /// <summary>
        /// Wird ausgelößt, falls das aktuelle ViewModel sich ändert
        /// </summary>
        event Action CurrentViewModelChanged;
    }
}
