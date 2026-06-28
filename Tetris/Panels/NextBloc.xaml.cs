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
