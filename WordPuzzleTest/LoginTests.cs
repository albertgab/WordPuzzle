using NUnit.Framework;
using System.Linq;
using WordPuzzleBusiness;
using WordPuzzleData;
using WordPuzzleData.Services;

namespace WordPuzzleTest
{
    public class LoginTests
    {
        private IGameService _service;
        Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
            _service = new GameService();
        }
        [Test]
        public void LoginWithValidData()
        {
            var user = _service.GetFirstUser();
            game.Login(user.Email, user.Password);
            Assert.AreEqual(game.User is null, false);
        }
        [TestCase("sparta@gmail.com", "wrongpass")]
        [TestCase("wrong email", "Sparta123" )]
        [TestCase("","")]
        public void LoginWithNonValidData(string email, string pass)
        {
            game.Login(email, pass);
            Assert.AreEqual(game.User is null, true);
        }
    }
}
