using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace WordPuzzleBusiness
{
    public class Member : UserManager
    {
        string _username;
        string _password;
        int _score;
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; private set => _password = value; }
        public int Score { get => _score; set => _score = value; }

        public Member(string username, string password) : base(username,password) //e-mail
        {
            Score = 0;
        }
        public bool Login (string username, string password)
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u) => u.Username == username);
                if (userQuery.FirstOrDefault().Password == password){ }

                    

                return true;
            }
        }

    }
}
*/