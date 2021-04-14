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
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Leaderboard.xaml
    public partial class Leaderboard : Window
    {
        Game game = ((MainWindow)Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()).game;
        public Leaderboard()
        {
            InitializeComponent();
            listBox.ItemsSource = game.LoadLeaderboard();
        }
    }
}
