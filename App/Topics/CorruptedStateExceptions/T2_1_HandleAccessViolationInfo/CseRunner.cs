using System;

namespace App.Topics.CorruptedStateExceptions.T2_1_HandleAccessViolationInfo;

using App.Topics.CorruptedStateExceptions;

// Задача: выполнить action и зафиксировать факт CSE, если она произошла.
// В этой учебной версии CSE симулируется исключениями, реализующими IMarksAsCse.
public static class CseRunner
{
    public static void RunWithCseInfo(Action action, ICseLogger logger)
    {
        // Требуется реализация студентом.
        // Подсказка: используйте try/catch (Exception ex) и finally.
        // - Если ex помечено как IMarksAsCse, вызовите logger.WillTerminateBecauseOfCse() и пробросьте исключение дальше.
        // - Иначе просто пробросьте исключение дальше.
        // - В finally можно сделать универсальное логирование завершения.
        throw new NotImplementedException();
    }
}
