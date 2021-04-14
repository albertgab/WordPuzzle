using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleData.Services
{
    public interface IGameService
    {
        public User GetUserByEmail(string email);
        public List<string> GetUserHistory(User user);
        public IEnumerable<History> GetLeaderboard(Level level);
        public void AddUser(User user);
    }
}
