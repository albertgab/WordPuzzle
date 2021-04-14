using NUnit.Framework;
using System.Linq;
using WordPuzzleBusiness;
using WordPuzzleData;

namespace WordPuzzleTest
{
    public class LoginTests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }
        [Test]
        public void LoginWithValidData()
        {
            using (var db = new WordPuzzleContext())
            {
                var user = db.Users.FirstOrDefault();
                game.Login(user.Email, user.Password);
                Assert.AreEqual(game.User is null, false);
            }
        }
        [TestCase("sparta@gmail.com", "wrongpass")]
        [TestCase("wrong email", "Sparta123" )]
        [TestCase("","")]
        public void LoginWithNonValidData(string email, string pass)
        {
            using (var db = new WordPuzzleContext())
            {
                game.Login(email, pass);
                Assert.AreEqual(game.User is null, true);
            }
        }
    }
}
