using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris.Controls
{
    public class GameCheckBox : System.Windows.Controls.CheckBox
    {
        static GameCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameCheckBox), new FrameworkPropertyMetadata(typeof(GameCheckBox)));
        }

        public static readonly DependencyProperty IconOnProperty =
       DependencyProperty.Register(nameof(IconOn), typeof(ImageSource),
           typeof(GameCheckBox), new PropertyMetadata());
        public ImageSource IconOn
        {
            get => (ImageSource)GetValue(IconOnProperty);
            set => SetValue(IconOnProperty, value);
        }

        public static readonly DependencyProperty IconOffProperty =
       DependencyProperty.Register(nameof(IconOff), typeof(ImageSource),
           typeof(GameCheckBox), new PropertyMetadata());
        public ImageSource IconOff
        {
            get => (ImageSource)GetValue(IconOffProperty);
            set => SetValue(IconOffProperty, value);
        }

        public static readonly DependencyProperty BackColorOnProperty =
       DependencyProperty.Register(nameof(BackColorOn), typeof(Brush),
           typeof(GameCheckBox), new PropertyMetadata(Brushes.Black));
        public Brush BackColorOn
        {
            get => (Brush)GetValue(BackColorOnProperty);
            set => SetValue(BackColorOnProperty, value);
        }

        public static readonly DependencyProperty BackColorOffProperty =
      DependencyProperty.Register(nameof(BackColorOff), typeof(Brush),
          typeof(GameCheckBox), new PropertyMetadata(Brushes.White));
        public Brush BackColorOff
        {
            get => (Brush)GetValue(BackColorOffProperty);
            set => SetValue(BackColorOffProperty, value);
        }

        public static readonly DependencyProperty BorderColorOnProperty =
       DependencyProperty.Register(nameof(BorderColorOn), typeof(Brush),
           typeof(GameCheckBox), new PropertyMetadata(Brushes.Green));
        public Brush BorderColorOn
        {
            get => (Brush)GetValue(BorderColorOnProperty);
            set => SetValue(BorderColorOnProperty, value);
        }

        public static readonly DependencyProperty BorderColorOffProperty =
      DependencyProperty.Register(nameof(BorderColorOff), typeof(Brush),
          typeof(GameCheckBox), new PropertyMetadata(Brushes.DodgerBlue));
        public Brush BorderColorOff
        {
            get => (Brush)GetValue(BorderColorOffProperty);
            set => SetValue(BorderColorOffProperty, value);
        }
    }
}
