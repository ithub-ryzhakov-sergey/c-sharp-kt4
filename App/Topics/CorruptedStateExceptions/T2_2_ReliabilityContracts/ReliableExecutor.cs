using System;

namespace App.Topics.CorruptedStateExceptions.T2_2_ReliabilityContracts;

using App.Topics.CorruptedStateExceptions;

public static class ReliableExecutor
{
    public static void Run(Action action, IReliableCleaner cleaner)
    {
        Exception? actionException = null;
        try
        {
            action();
        }
        catch (Exception ex)
        {
            actionException = ex;
        }
        finally
        {
            Exception? cleanupException = null;
            try
            {
                cleaner.Cleanup();
            }
            catch (Exception ex)
            {
                cleanupException = ex;
            }

            if (actionException != null && cleanupException != null)
            {
                throw new AggregateException(actionException, cleanupException);
            }
            else if (cleanupException != null)
            {
                throw cleanupException;
            }
        }

        if (actionException != null)
        {
            throw actionException;
        }
    }
}
