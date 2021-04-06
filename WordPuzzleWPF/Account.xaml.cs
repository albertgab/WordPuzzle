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
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        Game game = ((MainWindow)Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()).game;
        public Account()
        {
            InitializeComponent();
            textBlockScore.Text = $"Score: {game.User.Score}";
            textBlockUsername.Text = game.User.Username;
            listBox.ItemsSource = game.LoadUserHistory();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            try { Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Show(); }
            catch
            {
                MainWindow mainWin = new MainWindow();
                mainWin.Show();
            }
        }
    }
}

