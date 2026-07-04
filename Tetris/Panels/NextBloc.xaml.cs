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
    /// Interaction logic for NextBloc.xaml
    /// </summary>
    public partial class NextBloc : UserControl
    {
        public NextBloc()
        {
            InitializeComponent();
            this.Loaded += NextBloc_Loaded;
        }

        private void NextBloc_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (((Tetris.Controls.BaseWindow)window).WindowLanguage == Tetris.Controls.BaseWindow.WindowLanguages.English)
                this.nextTitle.Text = "NEXT";
            else
                this.nextTitle.Text = "پسین";
        }

        public static readonly DependencyProperty DarkModeProperty =
  DependencyProperty.Register(nameof(DarkMode), typeof(bool),
      typeof(NextBloc), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }

     

    }
}
