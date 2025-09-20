using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T2_1_SafeAdd;
using NUnit.Framework;
using System;

namespace App.Tests.Topics.CheckedUnchecked.T2_1_SafeAdd
{
    [TestFixture]
    public class ArithmeticUtilsTests
    {
        private ArithmeticUtils _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ArithmeticUtils();
        }

        [Test]
        public void SafeAdd_CheckedStrategy_OverflowThrowsException()
        {
            var ex = Assert.Throws<OverflowException>(() =>
                _calculator.SafeAdd(int.MaxValue, 1, OverflowStrategy.Checked));

            Assert.That(ex.Message, Does.Contain("causes overflow"));
        }

        [Test]
        public void SafeAdd_CheckedStrategy_NoOverflowReturnsCorrectResult()
        {
            int result = _calculator.SafeAdd(100, 200, OverflowStrategy.Checked);
            Assert.That(result, Is.EqualTo(300));
        }

        [Test]
        public void SafeAdd_UncheckedWrapStrategy_OverflowWrapsAround()
        {
            int result = _calculator.SafeAdd(int.MaxValue, 1, OverflowStrategy.UncheckedWrap);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void SafeAdd_SaturateStrategy_PositiveOverflowReturnsMaxValue()
        {
            int result = _calculator.SafeAdd(int.MaxValue, 1, OverflowStrategy.Saturate);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void SafeAdd_SaturateStrategy_NegativeOverflowReturnsMinValue()
        {
            int result = _calculator.SafeAdd(int.MinValue, -1, OverflowStrategy.Saturate);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }
    }
}