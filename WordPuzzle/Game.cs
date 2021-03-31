﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleBusiness
{
    public class Game
    {
        int _mode = 0; //0 - not specified, 1 - member user, 2 - guest, 3 - admin
        User _user;

        Level _level;

        public User User { get => _user; set => _user = value; }

        public string Login(string username, string password)
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u) => u.Username == username).FirstOrDefault();
                if(userQuery is null) { return $"Couldn't find an account with the username: {username}"; }
                if (userQuery.Password == password) {
                    User = userQuery;
                    _mode = 1;
                    return "";
                }
                return "Wrong password!";
            }
        }
        
        public bool LoadLevel(int levelId)
        {
            using (var db = new WordPuzzleContext())
            {
                _level = db.Levels.Where((l) => l.LevelId == levelId).FirstOrDefault();
            }
            return true;
        }

    }
}