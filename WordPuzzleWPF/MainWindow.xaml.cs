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
        public event EventHandler UserControlClicked;
        Game game = new Game();
        StackPanel stk;

        public event Action<string> onUserCodeFetched;
        public MainWindow()
        {
            InitializeComponent();
            //frameMain.Content = new Login();
            listOfLevels.ItemsSource = game.LoadLevelsList();
        }

        public void buttonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var message = game.Login(textBoxUsername.Text, passwordBox.Password);
            if (message == "")
            {
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                //LoginUC loginUC = new LoginUC();
                //frameMain.Content = loginUC;
                //stk.Children.Add(loginUC);
                //loginUC.textBox.Text = "sad";
                //loginUC.UserControlClicked;
                lvl.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock.Text = message;
                textBoxUsername.Text = "";
                passwordBox.Password = "";
            }
            //textBlock.Text = game.User.Username + game.User.Password;
            //var win2 = new Window1();
            //win2.Show();
        }

        private void textBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listOfLevels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var size = 400;
            var x = 10;
            var y = 10;
            //StackPanel stk;
            for (int i = 0; i < y; i++)
            {
                stk = new StackPanel() { Name = $"row_{i}", Orientation = Orientation.Horizontal, Height = size / y };
                this.stackLvl.Children.Add(stk);
                for (int j = 0; j < x; j++)
                {
                    this.stk.Children.Add(new Button() { Name = $"b{i}x{j}", Width = size / x, Height = size / y });
                }
            }
        }
    }
}