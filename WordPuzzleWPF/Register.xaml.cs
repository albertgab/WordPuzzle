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
            //var message = game.Register(, passwordBox.Password);
            //if (message == "")
            //{
            //    textBlock.Foreground = Brushes.Green;
            //    textBlock.Text = "Successfully registerd new account!";
            //    MainWindow main = new MainWindow();
            //    main.Show();
            //    textBoxEmail.Text = "";
            //    passwordBox.Password = "";
            //}
            //else
            //{
            //    textBlock.Foreground = Brushes.Red;
            //    textBlock.Text = message;
            //    textBoxEmail.Text = "";
            //    passwordBox.Password = "";
            //}
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
