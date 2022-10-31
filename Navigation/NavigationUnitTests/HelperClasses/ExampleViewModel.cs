using LightInject;
using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationUnitTests.HelperClasses
{
    internal class ExampleViewModel : IExampleViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="childService">Navigation von akteullem Store zu nem anderen ViewModel</param>
        /// <param name="navStore">Store von CildViewModel (eigener Bereich mit Nav) für jeden Bereich einen Store
        /// </param>
        public ExampleViewModel(INavigationStore navStore)
        {
            //Als Start (Main) hat er nur ViewModels unter sich und braucht keinen Service zum wechseln
            _navigationStore = navStore;
        }

        public INavigationService _childService { get; set; }

        public INavigateViewModel? ViewModel
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private INavigationStore _navigationStore;
    }
}