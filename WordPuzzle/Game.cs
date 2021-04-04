using System;
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

        public string Login(string username, string password)
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u) => u.Username == username).FirstOrDefault();
                if(userQuery is null) { return $"Couldn't find an account with the username: {username}"; }
                if (userQuery.Password == password) {
                    User = userQuery;
                    //_mode = 1;
                    return "";
                }
                return "Wrong password!";
            }
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

    }
}
