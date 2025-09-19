using System;
using App.Topics.ThrowFinally.T1_1_SafeDivision;
using NUnit.Framework;

namespace App.Tests.Topics.ThrowFinally.T1_1_SafeDivision;

public class SafeDividerTests
{
    [Test]
    public void DividesNormally_AndFinallyIncrementsCounter()
    {
        var d = new SafeDivider();
        var result = d.SafeDivide(10, 2);
        Assert.That(result, Is.EqualTo(5));
        Assert.That(d.CompletedOperationsCount, Is.EqualTo(1), "finally должен инкрементировать счётчик");
    }

    [Test]
    public void DivideByZero_Throws_DivideByZeroException_AndFinallyRuns()
    {
        var d = new SafeDivider();
        var ex = Assert.Throws<DivideByZeroException>(() => d.SafeDivide(1, 0));
        Assert.That(ex!.Message, Does.Contain("деление на ноль").IgnoreCase);
        Assert.That(d.CompletedOperationsCount, Is.EqualTo(1), "finally должен вызываться и при ошибке");
    }

    [Test]
    public void CheckedOverflow_ThrowsOverflowException()
    {
        var d = new SafeDivider();
        // int.MinValue / -1 вызывает переполнение в checked-контексте
        Assert.Throws<OverflowException>(() => d.SafeDivide(int.MinValue, -1));
        Assert.That(d.CompletedOperationsCount, Is.EqualTo(1));
    }
}
