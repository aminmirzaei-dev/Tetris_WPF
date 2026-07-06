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

namespace Tetris.Controls
{
    public class GameButton : System.Windows.Controls.Button
    {
        static GameButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameButton), new FrameworkPropertyMetadata(typeof(GameButton)));

            BackgroundProperty.OverrideMetadata(
        typeof(GameButton),
        new FrameworkPropertyMetadata(
            Brushes.LimeGreen,
            OnBackgroundChanged));



        }

        public GameButton()
        {
            this.Click += this.GameButton_Clicked;
            this.Loaded += GameButton_Loaded;
        }

        System.Windows.Window window;


        private void GameButton_Loaded(object sender, RoutedEventArgs e)
        {
            this.window = Window.GetWindow(this);
        }


        private void GameButton_Clicked(object sender, RoutedEventArgs e)
        {

            if (((Tetris.Controls.BaseWindow)this.window).SoundEnable == true)
                this.PlaySound();
        }

        private void PlaySound()
        {
            System.Windows.Resources.StreamResourceInfo splashSoundResource = Application.GetResourceStream(new Uri("Sounds/GameButtonSound.wav", UriKind.Relative));
            if (splashSoundResource != null)
            {
                SoundPlayer player = new SoundPlayer(splashSoundResource.Stream);
                player.Play();
            }
        }



        public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string),
            typeof(GameButton), new PropertyMetadata(""));
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register(nameof(IconSize), typeof(double),
                typeof(GameButton), new PropertyMetadata(14.0));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }


        private static Color Lighten(Color color, byte amount)
        {
            return Color.FromRgb(
                (byte)Math.Min(255, color.R + amount),
                (byte)Math.Min(255, color.G + amount),
                (byte)Math.Min(255, color.B + amount));
        }

        private static Color Darken(Color color, byte amount)
        {
            return Color.FromRgb(
                (byte)Math.Max(0, color.R - amount),
                (byte)Math.Max(0, color.G - amount),
                (byte)Math.Max(0, color.B - amount));
        }

        public Brush TopBrush
        {
            get => (Brush)GetValue(TopBrushProperty);
            private set => SetValue(TopBrushPropertyKey, value);
        }

        private static readonly DependencyPropertyKey TopBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(TopBrush),
                typeof(Brush),
                typeof(GameButton),
                new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty TopBrushProperty =
            TopBrushPropertyKey.DependencyProperty;


        public Brush BottomBrush
        {
            get => (Brush)GetValue(BottomBrushProperty);
            private set => SetValue(BottomBrushPropertyKey, value);
        }

        private static readonly DependencyPropertyKey BottomBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(BottomBrush),
                typeof(Brush),
                typeof(GameButton),
                new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty BottomBrushProperty =
            BottomBrushPropertyKey.DependencyProperty;


        private static void OnBackgroundChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
        {
            GameButton button = d as GameButton;
            if (button == null)
                return;

            SolidColorBrush brush = e.NewValue as SolidColorBrush;
            if (brush == null)
                return;

            Color color = brush.Color;

            button.TopBrush =
                new SolidColorBrush(Lighten(color, 35));

            button.BottomBrush =
                new SolidColorBrush(Darken(color, 25));
        }


    }
}
