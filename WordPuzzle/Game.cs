using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (userQuery.Password == password) {
                    User = userQuery;
                    //_mode = 1;
                    return "";
                }
                return "Wrong password!";
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
                if(password != passwordConf) { return "Passwords are not equal!"; }
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
        public void GameFinished(TimeSpan time)
        {
            User.Score += Score;
            time = new TimeSpan (time.Hours,time.Minutes,time.Seconds);
            History newRec = new History() { UserId = User.UserId, LevelId = Level.LevelId, Score = Score, Time = time, DateTime = DateTime.Now };
            Score = 0;
            using (var db = new WordPuzzleContext())
            {
                db.Histories.Add(newRec);
                db.SaveChanges();
            }
        }
    }
}
