using System;
using NUnit.Framework;
using App.Topics.CheckedUnchecked.T3_2_ParseAndMultiply;

namespace App.Tests.Topics.CheckedUnchecked.T3_2_ParseAndMultiply;

public class ParserMultiplierTests
{
    [Test]
    public void InvalidInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ParserMultiplier.ParseAndMultiply(null!, "2", true));
        Assert.Throws<ArgumentException>(() => ParserMultiplier.ParseAndMultiply(" ", "2", false));
        Assert.Throws<FormatException>(() => ParserMultiplier.ParseAndMultiply("abc", "2", false));
    }

    [Test]
    public void MultipliesNormally_Unchecked()
    {
        var res = ParserMultiplier.ParseAndMultiply("3", "7", false);
        Assert.That(res, Is.EqualTo(21));
    }

    [Test]
    public void CheckedOverflow_Throws()
    {
        Assert.Throws<OverflowException>(() => ParserMultiplier.ParseAndMultiply(int.MaxValue.ToString(), "2", true));
    }
}
