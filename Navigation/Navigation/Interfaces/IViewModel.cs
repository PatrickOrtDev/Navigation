using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Interfaces
{
    /// <inheritdoc/>>
    public interface IViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Die Dispose Methode des ViewModels
        /// </summary>
        public void Dispose();
    }
}
