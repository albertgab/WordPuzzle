using System.Collections.Generic;

#nullable disable

namespace WordPuzzleData
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
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
