using NUnit.Framework;
using System.Linq;
using WordPuzzleBusiness;
using WordPuzzleData;

namespace WordPuzzleTest
{
    class LogoutTests
    {
        Game _game;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }
        [Test]
        public void LogoutTest()
        {
            using (var db = new WordPuzzleContext())
            {
                var user = db.Users.FirstOrDefault();
                _game.Login(user.Email, user.Password);
                Assert.AreEqual(_game.User is null, false);
                _game.Logout();
                Assert.AreEqual(_game.User is null, true);
            }
        }
    }
}
