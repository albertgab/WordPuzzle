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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Game game = new Game();
        //MainWindow win;
        
        public Login()
        {
            InitializeComponent();
            //win = new MainWindow();


        }
        public void buttonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var message = game.Login(textBoxEmail.Text, passwordBox.Password);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                //Forms.Application.DoEvents();
                //LoginUC loginUC = new LoginUC();
                //frameMain.Content = loginUC;
                //stk.Children.Add(loginUC);
                //loginUC.textBox.Text = "sad";
                //loginUC.UserControlClicked;
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



/*
namespace WordPuzzleWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Game game = new Game();
        public Login()
        {

                InitializeComponent();

                var user = new User();
                using (var db = new WordPuzzleContext())
                {
                    user = db.Users.Where((u) => u.Email == "Spartacus").FirstOrDefault();
                }
            }

            private void buttonLogin_Clicked(object sender, RoutedEventArgs e)
            {
                var message = game.Login(textBoxEmail.Text, textBoxPassword.Text);
                if (message == "")
                {
                    textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                    //frameMain.Content = new HomeLogin();
                    //Application.Current.MainWindow. = new Login();


                }
                else
                {
                    textBlock.Text = message;
                    textBoxEmail.Text = "";
                    textBoxPassword.Text = "";
                }
                //textBlock.Text = game.User.Email + game.User.Password;
                //var win2 = new Window1();
                //win2.Show();
            }

            private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
            {

            }
        }
}
*/