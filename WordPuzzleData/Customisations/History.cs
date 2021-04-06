using System.Linq;

namespace WordPuzzleData
{
    public partial class History
    {
        public override string ToString()
        {
            using (var db = new WordPuzzleContext())
                User = db.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            return $"{Score}   {User.Username}   {Time}   {DateTime}";
        }
    }
}
