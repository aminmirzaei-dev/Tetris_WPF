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

namespace Tetris.Windows
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Main : Tetris.Controls.BaseWindow
    {
        public Main()
        {
            InitializeComponent();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Tetris.Windows.About about = new About();
            about.ShowDialog();
        }

        private void ExitButton_Click(object sender , RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
