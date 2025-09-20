using System;

namespace App.Topics.CorruptedStateExceptions.T2_1_HandleAccessViolationInfo;

using App.Topics.CorruptedStateExceptions;

public static class CseRunner
{
    public static void RunWithCseInfo(Action action, ICseLogger logger)
    {
        try
        {
            action();
        }
        catch (Exception ex) when (ex is IMarksAsCse)
        {
            logger.WillTerminateBecauseOfCse();
            throw;
        }
    }
}
