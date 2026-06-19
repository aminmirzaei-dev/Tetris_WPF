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
            Loaded += SplashWindow_Loaded;
        }

        private void SplashWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.loadingTimer = new DispatcherTimer();
            this.loadingTimer.Interval = TimeSpan.FromMilliseconds(20);

            this.loadingTimer.Tick += (s, args) =>
            {
                this.LoadingProgress.Value += 1;

                if (this.LoadingProgress.Value >= 100)
                {
                    this.LoadingProgress.Value = 100;
                    this.loadingTimer.Stop();

                    Tetris.Windows.About about = new Tetris.Windows.About();
                    about.Show();
                    this.Close();

                }
            };

            this.loadingTimer.Start();
        }


    }
}
