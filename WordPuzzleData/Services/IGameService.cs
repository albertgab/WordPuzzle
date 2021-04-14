using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleData.Services
{
    public interface IGameService
    {
        public Level GetLevelById(int levelId);
        public User GetUserById(int userId);
        public User GetUserByEmail(string email);
        public List<string> GetUserHistory(User user);
        public IEnumerable<History> GetLeaderboard(Level level);
        public void AddUser(User user);
        public List<Level> GetLevels();
        public Level GetLevelByIdWithSolutions(int levelId);
        public void SaveGameResult(User user, History newRec);
    }
}
