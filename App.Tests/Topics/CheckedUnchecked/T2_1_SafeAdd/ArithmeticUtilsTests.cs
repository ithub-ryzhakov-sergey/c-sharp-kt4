using System;
using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T3_1_SafeAdd;
using NUnit.Framework;

namespace App.Tests.Topics.CheckedUnchecked.T3_1_SafeAdd;

public class ArithmeticUtilsTests
{
    [Test]
    public void CheckedStrategy_ThrowsOnOverflow()
    {
        Assert.Throws<OverflowException>(() => ArithmeticUtils.SafeAdd(int.MaxValue, 1, OverflowStrategy.Checked));
        Assert.Throws<OverflowException>(() => ArithmeticUtils.SafeAdd(int.MinValue, -1, OverflowStrategy.Checked));
    }

    [Test]
    public void UncheckedWrapStrategy_WrapsLikeClr()
    {
        var result = ArithmeticUtils.SafeAdd(int.MaxValue, 1, OverflowStrategy.UncheckedWrap);
        Assert.That(result, Is.EqualTo(unchecked(int.MaxValue + 1)));
    }

    [Test]
    public void SaturateStrategy_ClampsToBounds()
    {
        var up = ArithmeticUtils.SafeAdd(int.MaxValue, 10, OverflowStrategy.Saturate);
        var down = ArithmeticUtils.SafeAdd(int.MinValue, -10, OverflowStrategy.Saturate);
        Assert.That(up, Is.EqualTo(int.MaxValue));
        Assert.That(down, Is.EqualTo(int.MinValue));
    }
}
