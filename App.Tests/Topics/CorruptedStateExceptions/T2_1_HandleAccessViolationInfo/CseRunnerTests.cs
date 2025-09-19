using System;
using App.Topics.CorruptedStateExceptions;
using App.Topics.CorruptedStateExceptions.T2_1_HandleAccessViolationInfo;
using NUnit.Framework;

namespace App.Tests.Topics.CorruptedStateExceptions.T2_1_HandleAccessViolationInfo;

public class CseRunnerTests
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

    [Test]
    public void NormalAction_NoLogsAboutCse()
    {
        var logger = new Logger();
        CseRunner.RunWithCseInfo(() => { /* ok */ }, logger);
        Assert.That(logger.WillTerminate, Is.EqualTo(0));
        Assert.That(logger.End, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void SimulatedCse_IsLoggedAndRethrown()
    {
        var logger = new Logger();
        Assert.Throws<SimulatedCseException>(() => CseRunner.RunWithCseInfo(() => throw new SimulatedCseException("boom"), logger));
        Assert.That(logger.WillTerminate, Is.EqualTo(1));
    }
}
