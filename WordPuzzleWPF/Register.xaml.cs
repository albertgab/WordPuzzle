using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class Register : Window
    {
        Game game = ((Login)Application.Current.MainWindow).game;
        public Register()
        {
            InitializeComponent();
        }

        private void buttonRegister(object sender, RoutedEventArgs e)
        {
            var message = game.Register(textBoxEmail.Text, textBoxUsername.Text,
                passwordBox.Password, passwordBoxConf.Password, textBoxCountry.Text);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully registerd new account!";
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
                Debug.WriteLine(game.User.UserId.ToString() + game.User.Email + game.User.Username + game.User.Password + game.User.Country);
            }
            else
            {
                textBlock.Foreground = Brushes.Red;
                textBlock.Text = message;
            }
        }
    
        private void buttonBackToLogin(object sender, RoutedEventArgs e)
        {
            this.Close();
            try { Application.Current.MainWindow.Show(); }
            catch
            {
                Login loginWin = new Login();
                loginWin.Show();
            }
        }
    }
}
