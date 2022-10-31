using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationUnitTests.HelperClasses
{
    internal class SecondViewModel : ISecondViewModel
    {
        public SecondViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; set; }

        public void Dispose()
        {
            return;
        }
    }
}