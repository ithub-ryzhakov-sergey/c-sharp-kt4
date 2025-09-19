using System;
using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T3_3_HashOverflowStrategy;
using NUnit.Framework;

namespace App.Tests.Topics.CheckedUnchecked.T3_3_HashOverflowStrategy;

public class HasherTests
{
    [Test]
    public void Compute_Checked_ThrowsOnOverflowForLargeInput()
    {
        // Сконструируем данные, провоцирующие переполнение при умножении на 31
        var data = new byte[1000];
        for (int i = 0; i < data.Length; i++) data[i] = 255;
        Assert.Throws<OverflowException>(() => Hasher.Compute(data, OverflowStrategy.Checked));
    }

    [Test]
    public void Compute_UncheckedWrap_MatchesManualUnchecked()
    {
        var data = new byte[] {1, 2, 3, 4, 5};
        int manual = 17;
        foreach (var b in data)
        {
            manual = unchecked(manual * 31 + b);
        }
        var res = Hasher.Compute(data, OverflowStrategy.UncheckedWrap);
        Assert.That(res, Is.EqualTo(manual));
    }
}
