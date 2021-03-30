using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WordPuzzleData;

namespace WordPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u)=> u.UserId == 1);
                var user = userQuery.First();
                var gomoko = new User() {Username = "gomoko", Password = "sdfsdf2134" };
                Console.WriteLine(gomoko.Username);

            }
        }
    }
}
