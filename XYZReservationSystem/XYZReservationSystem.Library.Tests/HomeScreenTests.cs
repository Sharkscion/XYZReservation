using NUnit.Framework;

namespace XYZReservationSystem.Library.Tests
{
    [TestFixture]
    public class HomeScreenTests
    {
        [TestCase("1hlo")]
        [TestCase("hello")]
        [TestCase("*")]
        [TestCase("")]
        [TestCase(" ")]
        [Test]
        public void InputChecker_OnInputString_ReturnFalse(string input)
        {
            var screen = new HomeScreen();
            bool result = screen.IsOptionValid(input);
            Assert.AreEqual(false, result);
        }
    
        [TestCase("-1")]
        [TestCase("2")]
        [Test]
        public void InputChecker_OnInputNumericButOutOfRange_ReturnFalse(string input)
        {
            var screen = new HomeScreen();
            bool result = screen.IsOptionValid(input);
            Assert.AreEqual(false, result);
        }

        [TestCase("0")]
        [TestCase("1")]
        [Test]
        public void InputChecker_OnInputNumericButInRange_ReturnTrue(string input)
        {
            var screen = new HomeScreen();
            bool result = screen.IsOptionValid(input);
            Assert.AreEqual(true, result);
        }
       
    }
}
