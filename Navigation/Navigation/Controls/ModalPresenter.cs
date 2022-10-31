using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Navigation.Controls
{
    /// <summary>
    /// Ein Control welches modal eine View anzeigt
    /// </summary>
    public class ModalPresenter : ContentControl
    {
        /// <summary>
        /// Bestimmt ob eine modale View angezeigt wird
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalPresenter),
               new PropertyMetadata(false));

        /// <summary>
        /// Ein Control welches modal eine View anzeigt
        /// </summary>
        static ModalPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(typeof(ModalPresenter)));
            BackgroundProperty.OverrideMetadata(typeof(ModalPresenter), new FrameworkPropertyMetadata(CreateDefaultBackground()));
        }

        /// <summary>
        /// Bestimmt ob eine modale View angezeigt wird
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