using NUnit.Framework;
using System.Linq;
using WordPuzzleBusiness;
using WordPuzzleData;

namespace WordPuzzleTest
{
    class LogoutTests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }
        [Test]
        public void LogoutTest()
        {
            using (var db = new WordPuzzleContext())
            {
                var user = db.Users.FirstOrDefault();
                game.Login(user.Email, user.Password);
                Assert.AreEqual(game.User is null, false);
                game.Logout();
                Assert.AreEqual(game.User is null, true);
            }
        }
    }
}
