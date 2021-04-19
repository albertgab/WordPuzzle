using System.Linq;
using System.Windows;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Account.xaml
    public partial class Account : Window
    {
        readonly Game _game = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Game;
        public Account()
        {
            InitializeComponent();
            textBlockScore.Text = $"Score: {_game.User.Score}";
            textBlockUsername.Text = _game.User.Username;
            listBox.ItemsSource = _game.LoadUserHistory();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            try { Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Show(); }
            catch
            {
                var mainWin = new MainWindow();
                mainWin.Show();
            }
        }
    }
}

