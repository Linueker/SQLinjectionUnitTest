using InjectionInloggning;


namespace UserTests
{
    public class UserTests
    {
        private User user;

        public UserTests()
        {
            user = new User();
        }

        // H�r finns allts� utkommenterade testfall som fungerar v�l n�r man har en koppling till en lokal databas (f�rutsatt att man l�gger in data
        // som �verensst�mmer med testfallen).
        // Det testfall som inte �r utkommenterat fungerar utan koppling till databas
        // d� anv�ndarnamnet filtreras bort innan kopplingen till databasen sker,
        // detta i en validering som inte till�ter " eller ' f�r att motverka injection-attacker. 

        [Theory]
        //[InlineData("kalle", "ramstein", true)]
        //[InlineData("hej", "123", false)]
        [InlineData("hej'", "123", false)]
        //[InlineData("linus", "hej", true)]

        public void Test1(string userName, string password, bool expected)
        {
            Assert.Equal(user.Inloggning(userName, password), expected);
        }
    }
}