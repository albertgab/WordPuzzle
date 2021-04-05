using System;
using System.Collections.Generic;
using System.Diagnostics;
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
