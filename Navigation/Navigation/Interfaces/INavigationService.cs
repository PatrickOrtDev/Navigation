﻿namespace Navigation.Interfaces
{
    /// <summary>
    /// Ein Service der zur Navigation verwendet wird
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Öffnet das ViewModel <typeparamref name="TViewModel"/> als View
        /// </summary>
        /// <typeparam name="TViewModel">Das ViewModel das geöffnet werde soll</typeparam>
        public void Open<TViewModel>() where TViewModel : INavigateViewModel;
    }
}
