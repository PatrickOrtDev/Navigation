using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Interfaces
{
    public interface IData
    {
        public TViewModel GetViewModel<TViewModel>()
        where TViewModel : INavigateViewModel;
    }
}