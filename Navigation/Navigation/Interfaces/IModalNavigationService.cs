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
        public void Open<TViewModel>() where TViewModel : INavigateViewModel;

        /// <summary>
        /// Schließt die modale View
        /// </summary>
        public void CloseModal();
    }
}
