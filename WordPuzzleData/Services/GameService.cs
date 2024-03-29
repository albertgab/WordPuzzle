﻿using System.Collections.Generic;
using System.Linq;

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
        public Level GetLevelById(int levelId)
        {
            return _context.Levels.FirstOrDefault(l => l.LevelId == levelId);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
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

        public List<Level> GetLevels()
        {
            return _context.Levels.ToList();
        }
        public Level GetLevelByIdWithSolutions(int levelId)
        {
            var level = GetLevelById(levelId);
            level.Solutions = _context.Solutions.Where(s => s.LevelId == levelId).ToList();
            return level;
        }
        public void SaveGameResult(User user, History newRec)
        {
            //Discard unwanted changes
            //_context.Entry(GetLevelById(newRec.LevelId)).Reload();
            GetLevelById(newRec.LevelId).Solutions = _context.Solutions.Where(s => s.LevelId == newRec.LevelId).ToList();
            
            GetUserById(user.UserId).Score = user.Score;
            _context.Histories.Add(newRec);
            _context.SaveChanges();
        }
        public User GetFirstUser()
        {
            return _context.Users.FirstOrDefault();
        }
    }
}
