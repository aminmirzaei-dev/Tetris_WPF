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
    /// Interaction logic for VictoryGame.xaml
    /// </summary>
    public partial class VictoryGame : Tetris.Controls.BaseWindow
    {
        public VictoryGame()
        {
            InitializeComponent();
            this.Loaded += VictoryGame_Loaded;
        }

        private void VictoryGame_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlaySound();
            this.DarkMode = ((Tetris.Controls.BaseWindow)this.Owner).DarkMode;
        }

        private void PlaySound()
        {
            System.Windows.Resources.StreamResourceInfo splashSoundResource = Application.GetResourceStream(new Uri("Sounds/VictoryGame.wav", UriKind.Relative));
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
    }
}
