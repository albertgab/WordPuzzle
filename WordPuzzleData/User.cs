using System;
using System.Collections.Generic;

#nullable disable

namespace WordPuzzle
{
    public partial class User
    {
        public User()
        {
            Histories = new HashSet<History>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
