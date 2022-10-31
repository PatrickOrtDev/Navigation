namespace Navigation.Interfaces
{
    public interface IData
    {
        public TViewModel GetViewModel<TViewModel>()
        where TViewModel : INavigateViewModel;
    }
}