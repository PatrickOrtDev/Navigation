using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Interfaces
{
    internal interface IDataFetcher<T>
        where T : INavigateViewModel
    {
        public T FetchData(Type typeOfViewModel);
    }
}