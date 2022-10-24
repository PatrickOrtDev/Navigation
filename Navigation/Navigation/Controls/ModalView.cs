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
    public  class ModalView : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalView),
               new PropertyMetadata(false));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        static ModalView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalView), new FrameworkPropertyMetadata(typeof(ModalView)));
            BackgroundProperty.OverrideMetadata(typeof(ModalView), new FrameworkPropertyMetadata(CreateDefaultBackground()));
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
