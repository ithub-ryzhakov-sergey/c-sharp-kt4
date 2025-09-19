using System;
using App.Topics.ThrowFinally.T1_2_FinallyResource;
using NUnit.Framework;

namespace App.Tests.Topics.ThrowFinally.T1_2_FinallyResource;

public class FinallyResourceTests
{
    [Test]
    public void Use_WithoutOpen_Throws()
    {
        var res = new FinallyResource();
        Assert.Throws<InvalidOperationException>(() => res.Use());
    }

    [Test]
    public void OpenUseClose_ClosesEvenIfWorkThrows_AndCloseIsIdempotent()
    {
        var res = new FinallyResource();
        Assert.Throws<ApplicationException>(() => res.OpenUseClose(() => throw new ApplicationException("fail")));
        // Повторный Close не должен падать
        Assert.DoesNotThrow(() => res.Close());
        // После закрытия ресурс нельзя использовать
        Assert.Throws<InvalidOperationException>(() => res.Use());
    }
}
