using System.ComponentModel;

namespace Navigation.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event welches ausgelößt wird falls sich eine Eigenschaft ändert
        /// </summary>
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
