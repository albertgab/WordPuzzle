using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WordPuzzleData;
using WordPuzzleData.Services;

namespace WordPuzzleBusiness
{
    public class Game
    {
        public static void Main() {}
        public User User { get; set; }
        public Level Level { get; set; }
        public int Score { get; set; } = 0;
        public TimeSpan Time { get; set; }
        private IGameService _service;
        public Game(IGameService service)
        {
            _service = service;
        }
        public Game()
        {
            _service = new GameService();
        }
        public string Login(string email, string password)
        {
            var userQuery = _service.GetUserByEmail(email);

            if (userQuery is null) { return $"Couldn't find an account with the e-mail: {email}"; }
            if (userQuery.Password == password)
            {
                User = userQuery;
                return "";
            }
            return "Wrong password!";
        }
        public IEnumerable LoadUserHistory()
        {
            return _service.GetUserHistory(User);
        }

        public IEnumerable LoadLeaderboard()
        {
                return _service.GetLeaderboard(Level);
        }

        public string Register(string email, string username,
            string password, string passwordConf, string country)
        {
            if (country == "") { country = "Unknown"; }
            User = new User() { Email = email, Username = username, Password = password, Country = country, UserType = "M" };
            if (password != passwordConf) { return "Passwords are not equal!"; }
            try
            {
                _service.AddUser(User);
            }
            catch (Exception ex)
            {
                var exM = (ex.InnerException is not null) ? ex.InnerException.Message : "";
                if (exM.Contains("CHECK"))
                {
                    return $"{exM[(exM.IndexOf("column '") + 8)..exM.LastIndexOf("'")]} is too short!";
                }
                if (exM.Contains("UNIQUE"))
                {
                    return "This e-mail is already in use!";
                }
                return "Unknown error during registration!";
            }
            return "";
        }
        public List<Level> LoadLevelsList()
        {
            return _service.GetLevels();
        }
        public bool LoadLevel(int levelId)
        {
            Level = _service.GetLevelByIdWithSolutions(levelId);
            return Level is not null;
        }
        public string WordsLeft()
        {
            return Level.Solutions.Count() != 1 ? $"{Level.Solutions.Count()} words left" : "1 word left";
        }
        public void GameFinished(TimeSpan time)
        {
            User.Score += Score;
            time = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            History newRec = new History() { UserId = User.UserId, LevelId = Level.LevelId, Score = Score, Time = time, DateTime = DateTime.Now };
            Score = 0;
            _service.SaveGameResult(User, newRec);
        }
        public void Logout()
        {
            User = null;
        }
    }
}
