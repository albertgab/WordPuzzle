using System.Windows;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Login.xaml
    public partial class Login : Window
    {
        public Game Game = new Game();
        public Login()
        {
            InitializeComponent();
        }
        public void buttonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var message = Game.Login(textBoxEmail.Text, passwordBox.Password);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                var main = new MainWindow();
                main.Show();
                textBoxEmail.Text = "";
                passwordBox.Password = "";
            }
            else
            {
                textBlock.Foreground = Brushes.Red;
                textBlock.Text = message;
            }
        }

        private void buttonSignIn_Clicked(object sender, RoutedEventArgs e)
        {
            var register = new Register();
            register.Show();
        }
    }
}