using Navigation.ViewModels;

namespace Navigation.ViewModels
{
    /// <summary>
    /// Erstellt ein ViewModel
    /// </summary>
    /// <typeparam name="TViewModel">Das ViewModel das erstellt wird</typeparam>
    /// <returns></returns>
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
}
