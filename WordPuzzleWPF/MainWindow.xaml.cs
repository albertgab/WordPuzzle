using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public Game game = ((Login)Application.Current.MainWindow).game;
        Brush prevClr;
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        List<StackPanel> stk = new List<StackPanel>();
        int btnClkd_x = -1;
        int btnClkd_y = -1;
        DateTime startTime;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            listOfLevels.ItemsSource = game.LoadLevelsList();
            textBlockUsername.Text = game.User.Username;
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            game.Time = startTime == DateTime.MinValue ? new TimeSpan(0) : DateTime.Now - startTime;
            textBlockTimer.Text = "Time: " + (game.Time.TotalMinutes < 10 ? "0" : "") + (int)game.Time.TotalMinutes
                + ":" + (game.Time.Seconds < 10 ? "0" : "") + game.Time.Seconds;
        }

        private void listOfLevels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            game.Score = 0;
            var lvlIdList = listOfLevels.SelectedItem.ToString()[0..3].TakeWhile(c => Char.IsDigit(c)).ToList();
            var lvlId = "";
            foreach (var item in lvlIdList) { lvlId += item; }
            if (!game.LoadLevel(Int32.Parse(lvlId))) { MessageBox.Show("Problem with loading the level!"); return; }
            stk.Clear();
            var sizeInPcl = stackLvl.ActualHeight;
            var max_x = game.Level.SizeX;
            var max_y = game.Level.SizeY;
            stackLvl.Children.Clear();
            for (int y = 0; y < max_y; y++)
            {
                stk.Add(new StackPanel() { Name = $"row_{y}", Orientation = Orientation.Horizontal, Height = sizeInPcl / max_y });
                for (int x = 0; x < max_x; x++)
                {
                    var button = new Button()
                    {
                        Name = $"b{x}x{y}",
                        Content = game.Level.Letters[y * max_x + x],
                        Width = sizeInPcl / max_x,
                        Height = sizeInPcl / max_y,
                        Tag = (x < 10 ? "0" : "") + x + (y < 10 ? "0" : "") + y
                    };
                    button.Click += ClickOnLetter;
                    stk[y].Children.Add(button);
                }
                stackLvl.Children.Add(stk[y]);
            }
            startTime = DateTime.Now;
            timer.Start();
            textBlockLeft.Text = game.WordsLeft();
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
                if (btnClkd_x == x || btnClkd_y == y)
                {
                    var btns = new List<Button>();
                    if (btnClkd_x == x)
                    {
                        for (int tmp_y = btnClkd_y; tmp_y <= y; tmp_y++)
                        {
                            btns.Add((Button)stk[tmp_y].Children[btnClkd_x]);
                            word += btns.Last().Content;
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
                    //Word found
                    if (game.Level.Solutions.Any(s => s.Word == word))
                    {
                        game.Level.Solutions.Remove(game.Level.Solutions.Where(s => s.Word == word).FirstOrDefault());
                        textBlockLeft.Text = game.WordsLeft();
                        game.Score += 100;
                        Debug.WriteLine(stk.Count);
                        foreach (var item in btns) item.Background = Brushes.Green;
                        Debug.WriteLine($"Found {word}");

                        //level finished
                        if (game.Level.Solutions.Count == 0)
                        {
                            game.Time = DateTime.Now - startTime;
                            timer.Stop();
                            game.Score += (int)((1 - game.Time.TotalMilliseconds / (stk.Count * 60000)) * 500); //time bonus
                            MessageBox.Show($"Congratulation!!!\nYour Score is: {game.Score}\nYour time is: {(int)game.Time.TotalMinutes}:{game.Time.Seconds}:{game.Time.Milliseconds / 100}");
                            game.GameFinished(game.Time);
                        }
                    }
                    //Wrong word
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
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Show();
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((Login)Application.Current.MainWindow).textBlock.Text = "You've been logged out.";
            game.Logout();
        }
    }
}