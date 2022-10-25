﻿using Navigation.ViewModels;
using System;

namespace Navigation.Interfaces
{
    /// <summary>
    /// Managed die Navigation von Views
    /// </summary>
    public interface INavigationStore
    {
        /// <summary>
        /// Das aktuelle ViewModel
        /// </summary>
        public IViewModel? CurrentViewModel { get; set; }

        /// <summary>
        /// Wird ausgelößt, falls das aktuelle ViewModel sich ändert
        /// </summary>
        public event Action CurrentViewModelChanged;
    }
}
