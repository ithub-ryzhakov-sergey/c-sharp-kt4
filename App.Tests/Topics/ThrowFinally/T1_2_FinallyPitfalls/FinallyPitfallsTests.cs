using App.Topics.ThrowFinally.T1_2_FinallyPitfalls;
using NUnit.Framework;
using System;

namespace App.Tests.Topics.ThrowFinally.T1_2_FinallyPitfalls
{
    [TestFixture]
    public class FinallyPitfallsTests
    {
        [Test]
        public void DemonstrateFinallyWithReturn_ReturnsValueFromTryNotFinally()
        {
            var pitfalls = new FinallyPitfalls();
            int result = pitfalls.DemonstrateFinallyWithReturn();
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void DemonstrateFinallyWithReturnAndOutParameter_OutParameterChangedInFinally()
        {
            var pitfalls = new FinallyPitfalls();
            int result = pitfalls.DemonstrateFinallyWithReturnAndOutParameter(out int outValue);
            Assert.That(result, Is.EqualTo(50));
            Assert.That(outValue, Is.EqualTo(300));
        }

        [Test]
        public void DemonstrateFinallyWithException_FinallyExecutesButExceptionPropagates()
        {
            var pitfalls = new FinallyPitfalls();
            var ex = Assert.Throws<InvalidOperationException>(() =>
                pitfalls.DemonstrateFinallyWithException());
            Assert.That(ex.Message, Does.Contain("Test exception"));
        }
    }
}