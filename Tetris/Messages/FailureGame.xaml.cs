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
using System.Windows.Shapes;

namespace Tetris.Messages
{
    /// <summary>
    /// Interaction logic for FailureGame.xaml
    /// </summary>
    public partial class FailureGame : Tetris.Controls.BaseWindow
    {
        private Tetris.Panels.Board boardResetButton;
        public FailureGame(Tetris.Panels.Board board)
        {
            InitializeComponent();
            Loaded += FailureGame_Loaded;
            this.boardResetButton = board;
        }


        private void FailureGame_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlaySound();
            this.DarkMode = ((Tetris.Controls.BaseWindow)this.Owner).DarkMode;

        }

        private void PlaySound()
        {
            System.Windows.Resources.StreamResourceInfo splashSoundResource = Application.GetResourceStream(new Uri("Sounds/FailureGame.wav", UriKind.Relative));
            if (splashSoundResource != null)
            {
                SoundPlayer player = new SoundPlayer(splashSoundResource.Stream);
                player.Play();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.boardResetButton.StartStopButton_Click(sender,e);
            this.Close();
        }
    }
}
