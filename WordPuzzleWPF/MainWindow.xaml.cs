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
using WordPuzzleBusiness;
using WordPuzzleData;

namespace WordPuzzleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();

            var user = new User();
            using (var db = new WordPuzzleContext())
            {
                user = db.Users.Where((u) => u.Username == "Spartacus").FirstOrDefault();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var message = game.Login(textBoxUsername.Text, textBoxPassword.Text);
            if (message == "")
            {
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";



            }
            else
            {
                textBlock.Text = message;
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
            //textBlock.Text = game.User.Username + game.User.Password;
            //var win2 = new Window1();
            //win2.Show();
        }

        private void textBoxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
