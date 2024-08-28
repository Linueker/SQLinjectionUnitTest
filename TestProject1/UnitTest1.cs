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

        [Theory]
        [InlineData("kalle", "ramstein", true)]
        public void Test1(string user, string password, bool expected)
        {
            Assert.Equal(User.Inloggning(user, password), expected);
        }
    }
}