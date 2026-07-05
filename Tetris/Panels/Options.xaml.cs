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

        private void Options_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (((Tetris.Controls.BaseWindow)window).WindowLanguage == Tetris.Controls.BaseWindow.WindowLanguages.English)
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
        }

        public static readonly DependencyProperty DarkModeProperty =
DependencyProperty.Register(nameof(DarkMode), typeof(bool),
    typeof(Options), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }

    }
}
