using System;
using System.Runtime.InteropServices;

namespace App.Topics.CorruptedStateExceptions;

// Интерфейс логгера для задач CSE
public interface ICseLogger
{
    void LogStart(string scope);
    void LogEnd(string scope);
    void WillTerminateBecauseOfCse();
}

// Интерфейс очистки ресурсов при критических ошибках
public interface IReliableCleaner
{
    void Cleanup();
}

// Маркер для тестовой симуляции "как будто это CSE"
public interface IMarksAsCse { }

// Исключение-симулятор CSE (для тестов)
public class SimulatedCseException : Exception, IMarksAsCse
{
    public SimulatedCseException(string message) : base(message) { }
}

// За внешние ошибки будем использовать стандартное ExternalException
