using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WordPuzzleData;

namespace WordPuzzleBusiness
{

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u)=> u.UserId == 1);
                var user = userQuery.First();
                //var gomoko = new UserManager() {Username = "gomoko", Password = "sdfsdf2134" };
                //Console.WriteLine(gomoko.Username);

            }
        }
    }
}
