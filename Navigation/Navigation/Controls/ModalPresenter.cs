using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Navigation.Controls
{
    /// <summary>
    /// A control that modally displays a view
    /// </summary>
    public class ModalPresenter : ContentControl
    {
        /// <summary>
        /// Determines whether a modal view is displayed
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalPresenter),
               new PropertyMetadata(false));

        /// <summary>
        /// A control that modally presents a view.
        /// </summary>
        static ModalPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(typeof(ModalPresenter)));
            BackgroundProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(CreateDefaultBackground()));
        }

        /// <summary>
        /// Determines whether a modal view is displayed.
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
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