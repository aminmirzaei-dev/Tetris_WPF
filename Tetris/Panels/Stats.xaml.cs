using System.Windows;
using System.Windows.Controls;

namespace Tetris.Panels
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();
            this.Loaded += Stats_Loaded;
        }

        private void Stats_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (((Tetris.Controls.BaseWindow)window).WindowLanguage == Tetris.Controls.BaseWindow.WindowLanguages.English)
            {
                this.scoreTitle.Text = "SCORE";
                this.levelTitle.Text = "LEVEL";
            }
            else
            {
                this.scoreTitle.Text = "شمار";
                this.levelTitle.Text = "رده";
            }
        }

        public static readonly DependencyProperty DarkModeProperty =
   DependencyProperty.Register(nameof(DarkMode), typeof(bool),
       typeof(Stats), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }


    }
}
