using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Tetris.Controls.BaseWindow
    {
        public About()
        {
            InitializeComponent();
            this.Loaded += About_Loaded;
        }

        private void About_Loaded(object sender, RoutedEventArgs e)
        {
            this.DarkMode = ((Tetris.Controls.BaseWindow)this.Owner).DarkMode;
        }

        private void GitHubBorder_Click(object sender, MouseButtonEventArgs e) 
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.github.com/aminmirzaei-dev",
                UseShellExecute = true
            });
        }

        private void InstagramBorder_Click(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/aminmirzaei.dev",
                UseShellExecute = true
            });
        }

        private void GmailBorder_Click(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "mailto:aminmirzaeidev@gmail.com",
                UseShellExecute = true
            });
        }

    }
}
