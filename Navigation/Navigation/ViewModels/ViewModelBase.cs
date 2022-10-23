using Navigation.Interfaces;
using System.ComponentModel;

namespace Navigation.ViewModels
{
    public abstract class ViewModelBase : IViewModel
    {
        /// <inheritdoc/>>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Zum Auslösen des PropertyChanged Events
        /// </summary>
        /// <param name="propertyName">Der Name der Eigenschaft die sich ändert</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Die Dispose Methode des ViewModels
        /// </summary>
        public virtual void Dispose() { }
    }
}
