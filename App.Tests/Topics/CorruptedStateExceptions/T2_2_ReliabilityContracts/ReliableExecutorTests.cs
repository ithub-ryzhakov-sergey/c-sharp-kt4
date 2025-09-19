using System;
using App.Topics.CorruptedStateExceptions;
using App.Topics.CorruptedStateExceptions.T2_2_ReliabilityContracts;
using NUnit.Framework;

namespace App.Tests.Topics.CorruptedStateExceptions.T2_2_ReliabilityContracts;

public class ReliableExecutorTests
{
    private class Cleaner : IReliableCleaner
    {
        public int Calls;
        public void Cleanup() => Calls++;
    }

    [Test]
    public void Cleanup_IsCalled_WhenActionSucceeds()
    {
        var cleaner = new Cleaner();
        ReliableExecutor.Run(() => { /* ok */ }, cleaner);
        Assert.That(cleaner.Calls, Is.EqualTo(1));
    }

    [Test]
    public void Cleanup_IsCalled_WhenActionThrows_AndExceptionIsNotSwallowed()
    {
        var cleaner = new Cleaner();
        Assert.Throws<InvalidOperationException>(() => ReliableExecutor.Run(() => throw new InvalidOperationException("fail"), cleaner));
        Assert.That(cleaner.Calls, Is.EqualTo(1));
    }
}
