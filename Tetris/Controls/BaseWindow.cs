using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace Tetris.Controls
{
    
    public class BaseWindow : System.Windows.Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        public BaseWindow()
        {
            WindowStyle = WindowStyle.None;

            WindowChrome.SetWindowChrome(this,
         new WindowChrome
         {
             ResizeBorderThickness = new Thickness(6),
             CaptionHeight = 0,
             CornerRadius = new CornerRadius(0),
             GlassFrameThickness = new Thickness(0)
         });

            Opacity = 0;

            Loaded += (s, e) =>
            {
                DoubleAnimation fade = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(300)
                };

                BeginAnimation(OpacityProperty, fade);
            };
        }

        #region CornerRadius

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(BaseWindow),
                new PropertyMetadata(new CornerRadius(10)));

        #endregion

        #region IsDarkMode

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }
        public static readonly DependencyProperty DarkModeProperty =
            DependencyProperty.Register(
                nameof(DarkMode),
                typeof(bool),
                typeof(BaseWindow),
                new PropertyMetadata(false));

        #endregion

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState =
                    WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                DragMove();
            }
        }

    }
}
