using System;
using System.Runtime.InteropServices;
using App.Topics.CorruptedStateExceptions;
using App.Topics.CorruptedStateExceptions.T2_3_UnmanagedInteropGuard;
using NUnit.Framework;

namespace App.Tests.Topics.CorruptedStateExceptions.T2_3_UnmanagedInteropGuard;

public class InteropGuardTests
{
    private class Logger : ICseLogger
    {
        public int Start;
        public int End;
        public int WillTerminate;
        public void LogStart(string scope) => Start++;
        public void LogEnd(string scope) => End++;
        public void WillTerminateBecauseOfCse() => WillTerminate++;
    }

    [Test, Category("*")]
    public void SimulatedCse_IsLoggedAndRethrown()
    {
        var logger = new Logger();
        Assert.Throws<SimulatedCseException>(() => InteropGuard.Call(() => throw new SimulatedCseException("boom"), logger));
        Assert.That(logger.WillTerminate, Is.EqualTo(1));
        Assert.That(logger.Start, Is.EqualTo(1));
        Assert.That(logger.End, Is.EqualTo(1));
    }

    [Test, Category("*")]
    public void NormalException_IsWrappedInExternalException()
    {
        var logger = new Logger();
        var ex = Assert.Throws<ExternalException>(() => InteropGuard.Call(() => throw new InvalidOperationException("oops"), logger));
        Assert.That(ex!.InnerException, Is.TypeOf<InvalidOperationException>());
        Assert.That(logger.WillTerminate, Is.EqualTo(0));
    }
}
