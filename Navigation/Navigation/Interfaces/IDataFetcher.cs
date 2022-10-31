using System;

namespace Navigation.Interfaces
{
    internal interface IDataFetcher<T>
        where T : INavigateViewModel
    {
        public T FetchData(Type typeOfViewModel);
    }
}