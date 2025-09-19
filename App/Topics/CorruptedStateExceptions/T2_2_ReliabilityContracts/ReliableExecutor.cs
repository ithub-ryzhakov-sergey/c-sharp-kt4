using System;

namespace App.Topics.CorruptedStateExceptions.T2_2_ReliabilityContracts;

using App.Topics.CorruptedStateExceptions;

// Задача: гарантировать вызов Cleanup() при любой ошибке, не "съедая" исключение.
public static class ReliableExecutor
{
    public static void Run(Action action, IReliableCleaner cleaner)
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }
}
