using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for Register.xaml
    public partial class Register : Window
    {
        Game _game = ((Login)Application.Current.MainWindow).Game;
        public Register()
        {
            InitializeComponent();
        }

        private void buttonRegister(object sender, RoutedEventArgs e)
        {
            var message = _game.Register(textBoxEmail.Text, textBoxUsername.Text,
                passwordBox.Password, passwordBoxConf.Password, textBoxCountry.Text);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully registerd new account!";
                var main = new MainWindow();
                main.Show();
                this.Close();
                Debug.WriteLine(_game.User.UserId.ToString() + _game.User.Email + _game.User.Username + _game.User.Password + _game.User.Country);
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
                var loginWin = new Login();
                loginWin.Show();
            }
        }
    }
}
