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
using System.Windows.Shapes;

namespace Tetris.Messages
{
    /// <summary>
    /// Interaction logic for ExitGame.xaml
    /// </summary>
    public partial class ExitGame : Tetris.Controls.BaseWindow
    {
        public ExitGame()
        {
            InitializeComponent();
            this.Loaded += ExitGame_Loaded;
        }

        private void ExitGame_Loaded(object sender, RoutedEventArgs e)
        {
            this.DarkMode = ((Tetris.Controls.BaseWindow)this.Owner).DarkMode;
            this.WindowLanguage = ((Tetris.Controls.BaseWindow)this.Owner).WindowLanguage;
            this.SoundEnable = ((Tetris.Controls.BaseWindow)this.Owner).SoundEnable;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void YetButton_Click(Object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
