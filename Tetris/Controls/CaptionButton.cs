using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Tetris.Controls
{
    public class CaptionButton : System.Windows.Controls.Button
    {
        public enum Modes { None, Close, Maximize, Restore, Minimize, AutoMaxRestore }
        static CaptionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CaptionButton), new FrameworkPropertyMetadata(typeof(CaptionButton)));
        }

        public CaptionButton()
        {
            Loaded += CaptionButton_Loaded;
        }

        private void CaptionButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Mode == Modes.AutoMaxRestore)
            {
                if(Window.GetWindow(this).WindowState == WindowState.Normal)
                {
                    this.Icon = "";
                }
                else if(Window.GetWindow(this).WindowState == WindowState.Maximized)
                {
                    this.Icon = "";
                }
            }

            
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

        public static readonly DependencyProperty ModeProperty =
        DependencyProperty.Register(nameof(Mode), typeof(Tetris.Controls.CaptionButton.Modes),
            typeof(CaptionButton), new PropertyMetadata(Tetris.Controls.CaptionButton.Modes.None));
        public Tetris.Controls.CaptionButton.Modes Mode
        {
            get { return (Modes)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            switch (this.Mode)
            {
                case Modes.Close:
                    Window.GetWindow(this).Close();
                    break;
                case Modes.Maximize:
                    Window.GetWindow(this).WindowState = WindowState.Maximized;
                    break;
                case Modes.Minimize:
                    Window.GetWindow(this).WindowState = WindowState.Minimized;
                    break;
                case Modes.Restore:
                    Window.GetWindow(this).WindowState = WindowState.Normal;
                    break;
                case Modes.AutoMaxRestore:
                    if (Window.GetWindow(this).WindowState == WindowState.Normal)
                    {
                        this.Icon = "";
                        Window.GetWindow(this).WindowState = WindowState.Maximized;
                    }
                    else if (Window.GetWindow(this).WindowState == WindowState.Maximized)
                    {
                        this.Icon = "";
                        Window.GetWindow(this).WindowState = WindowState.Normal;
                    }
                    break;
            }
        }
    }
}
