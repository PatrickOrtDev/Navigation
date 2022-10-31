using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationUnitTests.HelperClasses
{
    internal class ExampleViewModelChild : IExampleViewModelChild
    {
        //ViewModel ist unterste Instanc und kann nur den Stor in der Sie sich befindet steuern
        public ExampleViewModelChild(INavigationService parentService)
        {
            //Als ende nur Service zum Navigieren von sich selbst n
            _parentService = parentService;
        }

        public INavigationService _parentService { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}