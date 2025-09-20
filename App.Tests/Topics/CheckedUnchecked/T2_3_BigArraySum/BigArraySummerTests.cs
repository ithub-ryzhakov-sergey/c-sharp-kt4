using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T2_3_BigArraySum;
using NUnit.Framework;
using System;

namespace App.Tests.Topics.CheckedUnchecked.T2_3_BigArraySum
{
    [TestFixture]
    public class BigArraySummerTests
    {
        private BigArraySummer _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new BigArraySummer();
        }

        [Test]
        public void CalculateSum_CheckedStrategy_OverflowThrowsException()
        {
            int[] largeArray = { int.MaxValue, 1 };
            var ex = Assert.Throws<OverflowException>(() =>
                _calculator.CalculateSum(largeArray, OverflowStrategy.Checked));
            Assert.That(ex.Message, Does.Contain("overflowed"));
        }

        [Test]
        public void CalculateSum_UncheckedWrapStrategy_OverflowWrapsAround()
        {
            int[] largeArray = { int.MaxValue, 1 };
            long result = _calculator.CalculateSum(largeArray, OverflowStrategy.UncheckedWrap);
            long expected = (long)int.MaxValue + 1;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateSum_EmptyArray_ReturnsZero()
        {
            int[] emptyArray = Array.Empty<int>();
            long result = _calculator.CalculateSum(emptyArray, OverflowStrategy.Checked);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSum_NullArray_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                _calculator.CalculateSum(null, OverflowStrategy.Checked));
            Assert.That(ex.ParamName, Is.EqualTo("array"));
        }
    }
}