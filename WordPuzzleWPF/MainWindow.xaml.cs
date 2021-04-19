using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WordPuzzleBusiness;

namespace WordPuzzleWPF
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public Game Game = ((Login)Application.Current.MainWindow)?.Game;
        Brush _prevClr;
        readonly List<StackPanel> _stk = new List<StackPanel>();
        int _btnClkdX = -1;
        int _btnClkdY = -1;
        DateTime _startTime;
        readonly System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            listOfLevels.ItemsSource = Game.LoadLevelsList();
            buttonUsername.Content = Game.User.Username;
            _timer.Tick += timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Game.Time = _startTime == DateTime.MinValue ? new TimeSpan(0) : DateTime.Now - _startTime;
            textBlockTimer.Text = "Time: " + (Game.Time.TotalMinutes < 10 ? "0" : "") + (int)Game.Time.TotalMinutes
                + ":" + (Game.Time.Seconds < 10 ? "0" : "") + Game.Time.Seconds;
        }

        private void listOfLevels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game.Score = 0;
            var lvlIdList = listOfLevels.SelectedItem.ToString()[0..3].TakeWhile(char.IsDigit).ToList();
            var lvlId = "";
            foreach (var item in lvlIdList) { lvlId += item; }
            if (!Game.LoadLevel(Int32.Parse(lvlId))) { MessageBox.Show("Problem with loading the level!"); return; }
            _stk.Clear();
            var sizeInPcl = stackLvl.ActualHeight;
            var max_x = Game.Level.SizeX;
            var max_y = Game.Level.SizeY;
            stackLvl.Children.Clear();
            for (var y = 0; y < max_y; y++)
            {
                _stk.Add(new StackPanel() { Name = $"row_{y}", Orientation = Orientation.Horizontal, Height = sizeInPcl / max_y });
                for (var x = 0; x < max_x; x++)
                {
                    var button = new Button()
                    {
                        Name = $"b{x}x{y}",
                        Content = Game.Level.Letters[y * max_x + x],
                        Width = sizeInPcl / max_x,
                        Height = sizeInPcl / max_y,
                        Tag = (x < 10 ? "0" : "") + x + (y < 10 ? "0" : "") + y,
                        FontSize = max_x > 35 ? 10 : max_x > 15 ? 12 : 17
                    };
                    button.Click += ClickOnLetter;
                    _stk[y].Children.Add(button);
                }
                stackLvl.Children.Add(_stk[y]);
            }
            _startTime = DateTime.Now;
            _timer.Start();
            textBlockLeft.Text = Game.WordsLeft();
        }
        private void ClickOnLetter(object sender, RoutedEventArgs e)
        {
            var word = "";
            var button = (Button)sender;
            var x = Int32.Parse(button.Tag.ToString()[..2]);
            var y = Int32.Parse(button.Tag.ToString()[2..]);
            if (_btnClkdX < 0)
            {
                _btnClkdX = x;
                _btnClkdY = y;
                _prevClr = button.Background;
                button.Background = Brushes.Gray;

            }
            else
            {
                if (_btnClkdX == x || _btnClkdY == y)
                {
                    var btns = new List<Button>();
                    if (_btnClkdX == x)
                    {
                        for (var tmp_y = _btnClkdY; tmp_y <= y; tmp_y++)
                        {
                            btns.Add((Button)_stk[tmp_y].Children[_btnClkdX]);
                            word += btns.Last().Content;
                        }
                    }
                    else if (_btnClkdY == y)
                    {
                        for (var tmp_x = _btnClkdX; tmp_x <= x; tmp_x++)
                        {
                            btns.Add((Button)_stk[_btnClkdY].Children[tmp_x]);
                            word += btns.Last().Content;
                        }
                    }
                    //Word found
                    if (Game.Level.Solutions.Any(s => s.Word == word))
                    {
                        Game.Level.Solutions.Remove(Game.Level.Solutions.FirstOrDefault(s => s.Word == word));
                        textBlockLeft.Text = Game.WordsLeft();
                        Game.Score += 100;
                        foreach (var item in btns) item.Background = Brushes.Green;

                        //level finished
                        if (Game.Level.Solutions.Count == 0)
                        {
                            Game.Time = DateTime.Now - _startTime;
                            _timer.Stop();
                            Game.Score += (int)((1 - Game.Time.TotalMilliseconds / (_stk.Count * 60000)) * 500); //time bonus
                            var min = Game.Time.Minutes;
                            var sec = Game.Time.Seconds;
                            MessageBox.Show($"Congratulation!!!\nYour Score is: {Game.Score}\nYour time is: {(min < 10 ? "0" : "")}{min}:{(sec < 10 ? "0" : "")}{sec}");
                            Game.GameFinished(Game.Time);
                        }
                    }
                    //Wrong word
                    else
                    {
                        ((Button)_stk[_btnClkdY].Children[_btnClkdX]).Background = _prevClr;
                    }
                    _btnClkdX = -1;
                    _btnClkdY = -1;
                }
                else
                {
                    MessageBox.Show("You can select words only vertically or horizontally!");
                }
            }
        }
        private void buttonLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Level is null) return;
            var leaderboard = new Leaderboard();
            leaderboard.Show();
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((Login)Application.Current.MainWindow).textBlock.Text = "You've been logged out.";
            Game.Logout();
        }

        private void textBlockUsername_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account();
            account.Show();
        }
    }
}