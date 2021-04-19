using NUnit.Framework;
using WordPuzzleBusiness;
using WordPuzzleData.Services;

namespace WordPuzzleTest
{
    public class LoginTests
    {
        private IGameService _service;
        Game _game;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
            _service = new GameService();
        }
        [Test]
        public void LoginWithValidData()
        {
            var user = _service.GetFirstUser();
            _game.Login(user.Email, user.Password);
            Assert.AreEqual(_game.User is null, false);
        }
        [TestCase("sparta@gmail.com", "wrongpass")]
        [TestCase("wrong email", "Sparta123" )]
        [TestCase("","")]
        public void LoginWithNonValidData(string email, string pass)
        {
            _game.Login(email, pass);
            Assert.AreEqual(_game.User is null, true);
        }
    }
}
