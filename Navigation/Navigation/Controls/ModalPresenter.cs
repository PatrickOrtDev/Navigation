using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Navigation.Controls
{
    public  class ModalPresenter : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalPresenter),
               new PropertyMetadata(false));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        static ModalPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(typeof(ModalPresenter)));
            BackgroundProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(CreateDefaultBackground()));
        }

        private static object CreateDefaultBackground()
        {
            return new SolidColorBrush(Colors.Black)
            {
                Opacity = 0.3
            };
        }
    }
}
