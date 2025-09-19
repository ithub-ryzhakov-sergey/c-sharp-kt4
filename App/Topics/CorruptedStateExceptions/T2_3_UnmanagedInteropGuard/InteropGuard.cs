using System;
using System.Runtime.InteropServices;

namespace App.Topics.CorruptedStateExceptions.T2_3_UnmanagedInteropGuard;

using App.Topics.CorruptedStateExceptions;

// Доп. задача (*): защитная оболочка вокруг потенциально небезопасного вызова
public static class InteropGuard
{
    public static void Call(Func<int> nativeCall, ICseLogger logger)
    {
        // Требуется реализация студентом.
        // Подсказка: логируйте начало/конец; IMarksAsCse — фиксировать WillTerminateBecauseOfCse и пробрасывать;
        // остальные исключения — завернуть в ExternalException.
        throw new NotImplementedException();
    }
}
