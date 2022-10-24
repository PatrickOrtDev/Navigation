using Navigation.ViewModels;

namespace Navigation.Interfaces
{
    /// <summary>
    /// Ein Service der zur modalen Navigation verwendet wird
    /// </summary>
    public interface IModalNavigationService
    {
        /// <summary>
        /// Öffnet das ViewModel <typeparamref name="TViewModel"/> als modale View
        /// </summary>
        /// <typeparam name="TViewModel">Das ViewModel das geöffnet werde soll</typeparam>
        void Open<TViewModel>() where TViewModel : ViewModelBase;

        /// <summary>
        /// Schließt die modale View
        /// </summary>
        void CloseModal();
    }
}
