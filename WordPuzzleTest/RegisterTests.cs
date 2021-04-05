using NUnit.Framework;
using System.Linq;
using WordPuzzleBusiness;
using WordPuzzleData;

namespace WordPuzzleTest
{
    public class Tests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u) => u.Email == "Testmail" || u.Email == "Testma" || u.Email == "Testm").ToList();
                if (userQuery is not null)
                {
                    db.Users.RemoveRange(userQuery);
                    db.SaveChanges();
                }
            }
        }



        [TestCase("Testmail", "username", "passwo", "wrongpass")]
        [TestCase("Testmail", "asdg", "passwo", "passwo")]
        [TestCase("Testm", "username", "passwo", "passwo")]
        [TestCase("Testmail", "username", "passw", "passw")]
        public void RegisterWithNotValidData(string email, string username,
            string password, string passwordConf)
        {
            using (var db = new WordPuzzleContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                game.Register(email, username, password, passwordConf, "");
                var numberOfUsersAfter = db.Users.Count();
                Assert.AreEqual(numberOfUsersBefore, numberOfUsersAfter);
            }
        }
        
        [Test]
        public void RegisterTwiceWithTheSameEmail()
        {
            using (var db = new WordPuzzleContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                game.Register("Testmail", "username", "passwo", "passwo", "");
                game.Register("Testmail", "username", "passwo", "passwo","");
                var numberOfUsersAfter = db.Users.Count();
                Assert.AreEqual(numberOfUsersBefore+1, numberOfUsersAfter);
            }
        }

        [TestCase("Testmail", "username", "passwo", "passwo")]
        [TestCase("Testmail", "asdgd", "passwo", "passwo")]
        [TestCase("Testma", "username", "passwo", "passwo")]
        public void RegisterWithValidData(string email, string username,
    string password, string passwordConf)
        {

            using (var db = new WordPuzzleContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                game.Register(email, username, password, passwordConf, "");
                var numberOfUsersAfter = db.Users.Count();
                Assert.AreEqual(numberOfUsersBefore +1, numberOfUsersAfter);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new WordPuzzleContext())
            {
                var userQuery = db.Users.Where((u) => u.Email == "Testmail" || u.Email == "Testma" || u.Email == "Testm").ToList();
                if (userQuery is not null)
                {
                    db.Users.RemoveRange(userQuery);
                    db.SaveChanges();
                }
            }
        }
    }
}


/*
[Test]
public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
{
    using (var db = new NorthwindContext())
    {
        _customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");

        _customerManager.Update("MAND", "Nish Mandal", "Birmingham", null, null);

        var updatedCustomer = db.Customers.Find("MAND");
        Assert.AreEqual("Birmingham", updatedCustomer.City);
    }
}


Microsoft.EntityFrameworkCore.SqlServer
Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = WordPuzzle; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False' -force
Scaffold -DbContext 'Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=WordPuzzle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' -force
    */