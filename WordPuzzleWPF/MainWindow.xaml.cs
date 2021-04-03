using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordPuzzleBusiness;
using WordPuzzleData;
//using System.Windows.Forms;

namespace WordPuzzleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public event EventHandler UserControlClicked;
        Game game = new Game();
        Brush prevClr;
        List<StackPanel> stk = new List<StackPanel>();
        List<List<Button>> puzzle = new List<List<Button>>();
        List<Button> puzzleRow = new List<Button>();
        int btnClkd_x = -1;
        int btnClkd_y = -1;

        public event Action<string> onUserCodeFetched;
        public MainWindow()
        {
            InitializeComponent();
            //frameMain.Content = new Login();
            listOfLevels.ItemsSource = game.LoadLevelsList();
            var b1 = new Button { Content = "b1" };
            b1.Click += ClickOnLetter;
        }

        public void buttonLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var message = game.Login(textBoxUsername.Text, passwordBox.Password);
            if (message == "")
            {
                textBlock.Foreground = Brushes.Green;
                textBlock.Text = "Successfully logged in to your WordPuzzle account!";
                //Forms.Application.DoEvents();
                //Thread.Sleep(3000);
                //LoginUC loginUC = new LoginUC();
                //frameMain.Content = loginUC;
                //stk.Children.Add(loginUC);
                //loginUC.textBox.Text = "sad";
                //loginUC.UserControlClicked;
                lvl.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock.Foreground = Brushes.Red;
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
            var size = stackLvl.ActualHeight;
            var max_x = 10;
            var max_y = 10;
            stk.Clear();
            //puzzle =  new List<Button>[x, y];
            //StackPanel stk;
            Debug.WriteLine("debug " + listOfLevels.SelectedItem.ToString()[0]);
            if (!game.LoadLevel(listOfLevels.SelectedItem.ToString()[0]-'0')) { MessageBox.Show("Problem with loading the level!"); return; }
            stackLvl.Children.Clear();
            for (int y = 0; y < max_y; y++)
            {
                stk.Add(new StackPanel() { Name = $"row_{y}", Orientation = Orientation.Horizontal, Height = size / max_y });

                for (int x = 0; x < max_x; x++)
                {
                    var button = new Button() { Name = $"b{x}x{y}", Content = game.Level.Letters[y * max_x + x],
                        Width = size / max_x, Height = size / max_y, Tag = (x < 10 ? "0" : "") + x + (y < 10 ? "0":"") + y };
                    button.Click += ClickOnLetter;
                    //puzzle[i].Add(new Button());
                    //puzzleRow.Add(new Button() { Name = $"b{i}x{j}", Content = game.Level.Letters[i * x + j], Width = size / x, Height = size / y});
                    stk[y].Children.Add(button);
                }
                stackLvl.Children.Add(stk[y]);
                //this.stk.Children.Add(puzzle[i][j]);
                //puzzle.Add(puzzleRow);
                
            }
            Debug.WriteLine(stk[5].Children[4]);
            var s = this.stackLvl.Children[1];
            //Debug.WriteLine();
            // Debug.WriteLine(s);
        }
        private void ClickOnLetter(object sender, RoutedEventArgs e)
        {
            var word = "";
            
            Button button = (Button)sender;
            var x = Int32.Parse(button.Tag.ToString()[..2]);
            var y = Int32.Parse(button.Tag.ToString()[2..]);
            if (btnClkd_x < 0)
            {
                btnClkd_x = x;
                btnClkd_y = y;
                prevClr = button.Background;
                button.Background = Brushes.Gray;
            }
            else
            {
                if(btnClkd_x == x || btnClkd_y == y)
                {
                    var btns = new List<Button>();
                    if (btnClkd_x == x) {
                        for (int tmp_y = btnClkd_y; tmp_y <= y; tmp_y++)
                        {
                            btns.Add((Button)stk[tmp_y].Children[btnClkd_x]);
                            word += btns.Last().Content;
                            //word += ((Button)stk[tmp_y].Children[btnClkd_x]).Content;
                        }
                    }
                    else if (btnClkd_y == y)
                    {
                        for (int tmp_x = btnClkd_x; tmp_x <= x; tmp_x++)
                        {
                            btns.Add((Button)stk[btnClkd_y].Children[tmp_x]);
                            word += btns.Last().Content;
                        }
                    }
                    Debug.WriteLine(game.Level.Solutions);
                    if (game.Level.Solutions.Any(s => s.Word == word)){
                        game.Level.Solutions.Remove(game.Level.Solutions.Where(s => s.Word == word).FirstOrDefault());
                        foreach (var item in btns) item.Background = Brushes.Green;
                        if(game.Level.Solutions.Count == 0)
                        {
                            Debug.WriteLine("WIN!!!");
                        }
                        Debug.WriteLine($"Found {word}");
                    }
                    else
                    {
                        ((Button)stk[btnClkd_y].Children[btnClkd_x]).Background = prevClr;
                    }
                    btnClkd_x = -1;
                    btnClkd_y = -1;
                }
                else
                {
                    MessageBox.Show("You can select words only vertically or horizontally!");
                }
            }

            Debug.WriteLine($"{word}");


        }
     
    }
}