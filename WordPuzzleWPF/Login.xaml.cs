using System.Windows;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Login.xaml
    public partial class Login : Window
    {
        public Game game = new Game();
        public Login()
        {
            InitializeComponent();
        }
        public void buttonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var message = game.Login(textBoxEmail.Text, passwordBox.Password);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                MainWindow main = new MainWindow();
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
            Register register = new Register();
            register.Show();
        }
    }
}