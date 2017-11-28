using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library.Tests
{
    [TestFixture]
    public class ApplicationTest
    {

        [TestCase("1hlo")]
        [TestCase("hello")]
        [TestCase("*")]
        [TestCase("")]
        [TestCase(" ")]
        [Test]
        public void InputChecker_OnInputString_ReturnFalse(string input)
        {
            var application = new Application();
            bool result = application.IsOptionValid(input);
            Assert.AreEqual(false, result);
        }

    
        [TestCase("-1")]
        [TestCase("2")]
        [Test]
        public void InputChecker_OnInputNumericButOutOfRange_ReturnFalse(string input)
        {
            var application = new Application();
            bool result = application.IsOptionValid(input);
            Assert.AreEqual(false, result);
        }


        [TestCase("0")]
        [TestCase("1")]
        [Test]
        public void InputChecker_OnInputNumericButInRange_ReturnTrue(string input)
        {
            var application = new Application();
            bool result = application.IsOptionValid(input);
            Assert.AreEqual(true, result);
        }
       
    }
}
