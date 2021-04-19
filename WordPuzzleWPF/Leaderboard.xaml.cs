using System.Linq;
using System.Windows;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Leaderboard.xaml
    public partial class Leaderboard : Window
    {
        readonly Game _game = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Game;
        public Leaderboard()
        {
            InitializeComponent();
            listBox.ItemsSource = _game.LoadLeaderboard();
        }
    }
}
