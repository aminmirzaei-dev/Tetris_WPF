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
using Tetris.Controls;

namespace Tetris.Panels
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DarkModeProperty =
   DependencyProperty.Register(nameof(DarkMode), typeof(bool),
       typeof(Stats), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }

        public static readonly DependencyProperty ScoreValueProperty =
   DependencyProperty.Register(nameof(ScoreValue), typeof(string),
       typeof(Stats), new PropertyMetadata("12,300"));

        public string ScoreValue
        {
            get => (string)GetValue(ScoreValueProperty);
            set => SetValue(ScoreValueProperty, value);
        }

        public static readonly DependencyProperty LevelValueProperty =
  DependencyProperty.Register(nameof(LevelValue), typeof(string),
      typeof(Stats), new PropertyMetadata("7"));

        public string LevelValue
        {
            get => (string)GetValue(LevelValueProperty);
            set => SetValue(LevelValueProperty, value);
        }

        public static readonly DependencyProperty LineValueProperty =
  DependencyProperty.Register(nameof(LineValue), typeof(string),
      typeof(Stats), new PropertyMetadata("12,300"));

        public string LineValue
        {
            get => (string)GetValue(LineValueProperty);
            set => SetValue(LineValueProperty, value);
        }


    }
}
