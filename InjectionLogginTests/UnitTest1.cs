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

        // Här finns alltså utkommenterade testfall som fungerar väl när man har en koppling till en lokal databas (förutsatt att man lägger in data
        // som överensstämmer med testfallen).
        // Det testfall som inte är utkommenterat fungerar utan koppling till databas
        // då användarnamnet filtreras bort innan kopplingen till databasen sker,
        // detta i en validering som inte tillåter " eller ' för att motverka injection-attacker. 

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