using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleBusiness
{
    public class Admin : UserManager
    {
        string _username;
        string _password;
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public Admin(string username, string password) : base(username,password)//e-mail
        {
            Username = username;
            Password = password;
        }
    }
}
