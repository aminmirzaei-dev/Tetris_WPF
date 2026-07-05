using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris.Controls
{
    public class GameCheckBox : System.Windows.Controls.CheckBox
    {
        static GameCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameCheckBox), new FrameworkPropertyMetadata(typeof(GameCheckBox)));
        }

        public static readonly DependencyProperty IconOnProperty =
       DependencyProperty.Register(nameof(IconOn), typeof(ImageBrush),
           typeof(GameCheckBox), new PropertyMetadata());
        public ImageBrush IconOn
        {
            get => (ImageBrush)GetValue(IconOnProperty);
            set => SetValue(IconOnProperty, value);
        }

        public static readonly DependencyProperty IconOffProperty =
       DependencyProperty.Register(nameof(IconOff), typeof(ImageBrush),
           typeof(GameCheckBox), new PropertyMetadata());
        public ImageBrush IconOff
        {
            get => (ImageBrush)GetValue(IconOffProperty);
            set => SetValue(IconOffProperty, value);
        }

        public static readonly DependencyProperty BackColorOnProperty =
       DependencyProperty.Register(nameof(BackColorOn), typeof(Brush),
           typeof(GameCheckBox), new PropertyMetadata());
        public Brush BackColorOn
        {
            get => (Brush)GetValue(BackColorOnProperty);
            set => SetValue(BackColorOnProperty, value);
        }

        public static readonly DependencyProperty BackColorOffProperty =
      DependencyProperty.Register(nameof(BackColorOff), typeof(Brush),
          typeof(GameCheckBox), new PropertyMetadata());
        public Brush BackColorOff
        {
            get => (Brush)GetValue(BackColorOffProperty);
            set => SetValue(BackColorOffProperty, value);
        }
    }
}
