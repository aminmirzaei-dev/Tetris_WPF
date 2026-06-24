using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace Tetris.Controls
{

    public class BaseWindow : System.Windows.Window
    {
        public enum WindowModes { Standard, Dialog }
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        private WindowChrome windowChrome;

        public BaseWindow()
        {
            WindowStyle = WindowStyle.None;

            this.windowChrome = new WindowChrome();
            this.windowChrome.ResizeBorderThickness = new Thickness(6);
            this.windowChrome.CaptionHeight = 0;
            this.windowChrome.CornerRadius = new CornerRadius(0);
            this.windowChrome.GlassFrameThickness = new Thickness(0);

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

        private Border titleBar;
        private Tetris.Controls.CaptionButton close, maximize, minimize;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.titleBar = GetTemplateChild("TitleBar") as Border;
            this.close = GetTemplateChild("CloseButton") as Tetris.Controls.CaptionButton;
            this.maximize = GetTemplateChild("MaximizeButton") as Tetris.Controls.CaptionButton;
            this.minimize = GetTemplateChild("MinimizeButton") as Tetris.Controls.CaptionButton;

            if (this.titleBar != null)
            {
                this.titleBar.MouseLeftButtonDown += this.TitleBar_MouseLeftButtonDown;
            }

            if (this.WindowMode == Tetris.Controls.BaseWindow.WindowModes.Standard)
            {
                close.Visibility = Visibility.Visible;
                maximize.Visibility = Visibility.Visible;
                minimize.Visibility = Visibility.Visible;
                WindowChrome.SetWindowChrome(this, this.windowChrome);
            }
            else
            {
                maximize.Visibility = Visibility.Hidden;
                minimize.Visibility = Visibility.Hidden;
            }
        }

        public Tetris.Controls.BaseWindow.WindowModes WindowMode
        {
            get => (Tetris.Controls.BaseWindow.WindowModes)GetValue(WindowModeProperty);
            set => SetValue(WindowModeProperty, value);
        }

        public static readonly DependencyProperty WindowModeProperty =
            DependencyProperty.Register(
                nameof(WindowMode),
                typeof(Tetris.Controls.BaseWindow.WindowModes),
                typeof(BaseWindow),
                new PropertyMetadata(Tetris.Controls.BaseWindow.WindowModes.Standard));

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
