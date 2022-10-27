namespace Navigation.Interfaces
{
    /// <summary>
    /// A service used for modal navigation
    /// </summary>
    public interface IModalNavigationService
    {
        /// <summary>
        /// Closes the modal view
        /// </summary>
        public void CloseModal();

        /// <summary>
        /// Opens the ViewModel <typeparamref name="TViewModel"/> as a modal view.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel to open</typeparam>.
        public void Open<TViewModel>() where TViewModel : INavigateViewModel;
    }
}