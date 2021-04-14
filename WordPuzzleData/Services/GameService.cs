using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleData.Services
{
    public class GameService : IGameService
    {
        private readonly WordPuzzleContext _context;
        public GameService(WordPuzzleContext context)
        {
            _context = context;
        }
        public GameService()
        {
            _context = new WordPuzzleContext();
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public List<string> GetUserHistory(User user)
        {
            var listHis = new List<string>();
            _context.Histories.Where(h => h.UserId == user.UserId).ToList()
                .OrderBy(h => h.DateTime).Reverse().ToList()
                .ForEach(h => listHis.Add(h.ToStringUser()));
            return listHis;
        }
        public IEnumerable<History> GetLeaderboard(Level level)
        {
            return _context.Histories.Where(h => h.LevelId == level.LevelId)
                .ToList().OrderBy(h => h.Score).Reverse();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
