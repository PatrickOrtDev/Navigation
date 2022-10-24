using System.ComponentModel;

namespace Navigation.Interfaces
{
    /// <inheritdoc/>>
    public interface IViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Die Dispose Methode des ViewModels
        /// </summary>
        void Dispose();
    }
}
