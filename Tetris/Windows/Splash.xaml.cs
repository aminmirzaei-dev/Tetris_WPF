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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetris.Windows
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {

        private DispatcherTimer loadingTimer;


        public Splash()
        {
            InitializeComponent();

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
            this.Loaded += SplashWindow_Loaded;
        }

        private void SplashWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.loadingTimer = new DispatcherTimer();
            this.loadingTimer.Interval = TimeSpan.FromMilliseconds(20);
            this.PlaySound();

            if (Properties.Settings.Default.Language == "English")
            {
                this.backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Splash/TetrisSplashEN.png"));
                this.loadingProgress.IsReversed = false;
            }
            else
            {
                this.backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Splash/TetrisSplashFA.png"));
                this.loadingProgress.IsReversed = true;
            }

            this.loadingTimer.Tick += (s, args) =>
            {
                this.loadingProgress.Value += 1;

                if (this.loadingProgress.Value >= 100)
                {
                    this.loadingProgress.Value = 100;
                    this.loadingTimer.Stop();

                    Tetris.Windows.Main main = new Tetris.Windows.Main();
                    main.Show();
                    this.Close();

                }
            };

            this.loadingTimer.Start();
        }

        private void PlaySound()
        {
            System.Windows.Resources.StreamResourceInfo splashSoundResource = Application.GetResourceStream(new Uri("Sounds/SplashSound.wav", UriKind.Relative));
            if (splashSoundResource != null)
            {
                SoundPlayer player = new SoundPlayer(splashSoundResource.Stream);
                player.Play();
            }
        }


    }
}
