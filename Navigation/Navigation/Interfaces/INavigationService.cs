namespace Navigation.Interfaces
{
    /// <summary>
    /// A service that is used for navigation
    /// </summary>
    public interface INavigationService<TViewModel>
        where TViewModel : INavigateViewModel
    {
        /// <summary>
        /// Opens the ViewModel <typeparamref name="TViewModel"/> as a view.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel to be opened</typeparam>
        public void Open();
    }
}