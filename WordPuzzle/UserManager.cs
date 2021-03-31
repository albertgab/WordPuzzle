using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleBusiness
{
    public abstract class UserManager
    {
         string _username;
         string _password;
        public virtual string Username { get => _username; set => _username = value; }
        public virtual string Password { get => _password; set => _password = value; }
        public UserManager(string username, string password) //e-mail
        {
            Username = username;
            Password = password;
        }
    }
}
