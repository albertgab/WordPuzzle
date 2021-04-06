using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WordPuzzleData;

namespace WordPuzzleBusiness
{
    public class Game
    {
        public User User { get; set; }
        public Level Level { get; set; }
        public int Score { get; set; } = 0;
        public TimeSpan Time { get; set; }

        public string Login(string email, string password)
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where(u => u.Email == email).FirstOrDefault();
                if (userQuery is null) { return $"Couldn't find an account with the e-mail: {email}"; }
                if (userQuery.Password == password)
                {
                    User = userQuery;
                    //_mode = 1;
                    return "";
                }
                return "Wrong password!";
            }
        }

        public IEnumerable LoadUserHistory()
        {
            using (var db = new WordPuzzleContext())
            {
                var list = db.Histories.Where(h => h.UserId== User.UserId).ToList()
                    .OrderBy(h => h.DateTime).Reverse();
                var listStr = new List<String>();
                foreach(var item in list)
                {
                    listStr.Add(item.ToStringUser());
                }
                return listStr;
            }
        }
        public List<string> UserHistory()
        {
            using (var db = new WordPuzzleContext())
            {
                var his = db.Histories.ToList();
                var list = new List<string>();
                foreach (var item in his)
                {
                    var lvlName = db.Levels.Where(l => l.LevelId == item.LevelId).FirstOrDefault().Name;
                    list.Add($"{lvlName}  {item.Score}  {item.Time}  {item.DateTime}");
                }
                return list;
            }
        }

        public IEnumerable LoadLeaderboard()
        {
            using (var db = new WordPuzzleContext())
            {
                var list = db.Histories.Where(h => h.LevelId == Level.LevelId).ToList()
                    .OrderBy(h => h.Score).Reverse();
                return list;
            }
        }

        public string Register(string email, string username,
            string password, string passwordConf, string country)
        {
            if (country == "") { country = "Unknown"; }
            User = new User() { Email = email, Username = username, Password = password, Country = country, UserType = "M" };
            using (var db = new WordPuzzleContext())
            {
                if (password != passwordConf) { return "Passwords are not equal!"; }
                try
                {
                    db.Users.Add(User);
                    db.SaveChanges();
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
            }
            return "";
        }

        public List<Level> LoadLevelsList()
        {
            using (var db = new WordPuzzleContext())
            {
                var list = db.Levels.ToList();
                return list;
            }
        }
        public bool LoadLevel(int levelId)
        {
            using (var db = new WordPuzzleContext())
            {
                Level = db.Levels.Where(l => l.LevelId == levelId).FirstOrDefault();
                Level.Solutions = db.Solutions.Where(s => s.LevelId == levelId).ToList();
            }
            return !(Level is null);
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
            using (var db = new WordPuzzleContext())
            {
                db.Users.Where(u => u.UserId == User.UserId).FirstOrDefault().Score = User.Score;
                db.Histories.Add(newRec);
                db.SaveChanges();
            }
        }
        public void Logout()
        {
            User = null;
        }
    }
}
