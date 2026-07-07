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

namespace Tetris.Panels
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        public Options()
        {
            InitializeComponent();
            this.Loaded += Options_Loaded;
        }

        System.Windows.Window window;

        private void Options_Loaded(object sender, RoutedEventArgs e)
        {
            this.window = Window.GetWindow(this);
            if (((Tetris.Controls.BaseWindow)this.window).WindowLanguage == Tetris.Controls.BaseWindow.WindowLanguages.English)
            {
                this.optionsTitle.Text = "OPTIONS";
                this.cbTheme.ToolTip = "Change Theme";
                this.cbSound.ToolTip = "Change Sound";
                this.cbLanguage.ToolTip = "Change Language";
            }
            else
            {
                this.optionsTitle.Text = "گزینه ها";
                this.cbTheme.ToolTip = "دگراندن پوسته بازی";
                this.cbSound.ToolTip = "دگراندن آوا بازی";
                this.cbLanguage.ToolTip = "دگراندن زبان بازی";
            }

            this.cbSound.IsChecked = !((Tetris.Controls.BaseWindow)this.window).SoundEnable;
            this.cbTheme.IsChecked = ((Tetris.Controls.BaseWindow)this.window).DarkMode;

            if (((Tetris.Controls.BaseWindow)this.window).WindowLanguage == Controls.BaseWindow.WindowLanguages.English)
            {
                this.cbLanguage.IsChecked = false;
            }
            else
            {
                this.cbLanguage.IsChecked = true;
            }

        }

        public static readonly DependencyProperty DarkModeProperty =
DependencyProperty.Register(nameof(DarkMode), typeof(bool),
    typeof(Options), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }

        private void cbTheme_Checked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).DarkMode = true;

        }

        private void cbTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).DarkMode = false;

        }

        private void cbLanguage_Checked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).WindowLanguage = Controls.BaseWindow.WindowLanguages.Persian;

        }

        private void cbLanguage_Unchecked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).WindowLanguage = Controls.BaseWindow.WindowLanguages.English;
        }

        private void cbSound_Checked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).SoundEnable = false;
        }

        private void cbSound_Unchecked(object sender, RoutedEventArgs e)
        {
            ((Tetris.Controls.BaseWindow)this.window).SoundEnable = true;
        }
    }
}
