using App.Topics.ThrowFinally.T1_1_SafeDivision;
using NUnit.Framework;
using System;

namespace App.Tests.Topics.ThrowFinally.T1_1_SafeDivision
{
    [TestFixture]
    public class SafeDividerTests
    {
        [Test]
        public void SafeDivide_DivisionByZero_ThrowsDivideByZeroException()
        {
            var divider = new SafeDivider();

            // Явно инициализируем переменную
            bool operationCompleted = false;
            var ex = Assert.Throws<DivideByZeroException>(() =>
                divider.SafeDivide(10, 0, out operationCompleted));

            Assert.That(ex.Message, Does.Contain("Division by zero"));
            Assert.That(operationCompleted, Is.True);
            Assert.That(divider.OperationsCount, Is.EqualTo(1));
        }

        [Test]
        public void SafeDivide_NormalDivision_ReturnsCorrectResult()
        {
            var divider = new SafeDivider();
            bool operationCompleted = false;

            double result = divider.SafeDivide(10, 2, out operationCompleted);

            Assert.That(result, Is.EqualTo(5.0));
            Assert.That(operationCompleted, Is.True);
            Assert.That(divider.OperationsCount, Is.EqualTo(1));
        }

        [Test]
        public void SafeDivide_MinValueByMinusOne_ThrowsOverflowException()
        {
            var divider = new SafeDivider();
            bool operationCompleted = false;

            var ex = Assert.Throws<OverflowException>(() =>
                divider.SafeDivide(int.MinValue, -1, out operationCompleted));

            Assert.That(ex.Message, Does.Contain("int.MinValue"));
            Assert.That(operationCompleted, Is.True);
        }

        [Test]
        public void SafeDivide_MultipleOperations_IncrementsCounter()
        {
            var divider = new SafeDivider();
            bool operationCompleted = false;

            divider.SafeDivide(10, 2, out operationCompleted);
            divider.SafeDivide(20, 4, out operationCompleted);

            Assert.That(divider.OperationsCount, Is.EqualTo(2));
        }
    }
}