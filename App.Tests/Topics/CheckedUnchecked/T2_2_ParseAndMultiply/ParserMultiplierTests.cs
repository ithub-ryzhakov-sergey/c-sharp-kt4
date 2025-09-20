using App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply;
using NUnit.Framework;
using System;

namespace App.Tests.Topics.CheckedUnchecked.T2_2_ParseAndMultiply
{
    [TestFixture]
    public class ParserMultiplierTests
    {
        private ParseMultiplier _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ParseMultiplier();
        }

        [Test]
        public void ParseAndMultiply_ValidNumbers_Checked_ReturnsCorrectResult()
        {
            int result = _calculator.ParseAndMultiply("5", "6", true);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void ParseAndMultiply_ValidNumbers_Unchecked_ReturnsCorrectResult()
        {
            int result = _calculator.ParseAndMultiply("5", "6", false);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void ParseAndMultiply_CheckedOverflow_ThrowsException()
        {
            var ex = Assert.Throws<OverflowException>(() =>
                _calculator.ParseAndMultiply("1000000", "1000000", true));
            Assert.That(ex.Message, Does.Contain("causes overflow"));
        }

        [Test]
        public void ParseAndMultiply_NullFirstArgument_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.ParseAndMultiply(null, "5", true));
            Assert.That(ex.ParamName, Is.EqualTo("a"));
        }

        [Test]
        public void ParseAndMultiply_InvalidFormat_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                _calculator.ParseAndMultiply("abc", "5", true));
            Assert.That(ex.Message, Does.Contain("Cannot parse"));
        }
    }
}