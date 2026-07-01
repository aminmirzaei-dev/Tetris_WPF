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
using System.Windows.Threading;

namespace Tetris.Windows
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Main : Tetris.Controls.BaseWindow
    {
        public Main()
        {
            this.InitializeComponent();
            this.GameBoard.ParentWindow = this;
            this.GameBoard.StartStopButton = this.btnStartGame;
            this.GameBoard.NextBlocPanel = this.NextBloc;
            this.GameBoard.StatsPanel = this.Stats;
        }


        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Tetris.Windows.About about = new About();
            about.ShowDialog();
        }

        private void ExitButton_Click(object sender , RoutedEventArgs e)
        {
            Tetris.Messages.ExitGame exitGameMessage = new Messages.ExitGame();
            exitGameMessage.Owner = this;
            exitGameMessage.ShowDialog();
        }
    }
}
