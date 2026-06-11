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
    public class CaptionButton : System.Windows.Controls.Button
    {
        public enum Modes { None,Close,Maximize,Restore,Minimize}
        static CaptionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CaptionButton), new FrameworkPropertyMetadata(typeof(CaptionButton)));
        }

        public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string),
            typeof(CaptionButton), new PropertyMetadata(""));
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register(nameof(IconSize), typeof(double),
                typeof(CaptionButton), new PropertyMetadata(14.0));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly DependencyProperty DarkModeProperty =
           DependencyProperty.Register(nameof(DarkMode), typeof(bool),
               typeof(CaptionButton), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }
    }
}
