using System;
using System.IO;

namespace App.Topics.ThrowFinally.T1_3_RethrowAndWrapping;

// В реальном .NET существует System.Configuration.ConfigurationErrorsException, но чтобы не тянуть лишние пакеты,
// мы вводим локальную версию исключения с тем же смыслом. Тесты опираются на этот тип из текущего namespace.
public class ConfigurationErrorsException : Exception
{
    public ConfigurationErrorsException(string message, Exception inner) : base(message, inner) { }
}

public static class ConfigLoader
{
    // Задача: корректно валидировать путь, оборачивать FileNotFoundException, а прочие исключения пробрасывать как есть (throw;)
    public static string LoadConfig(string path)
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }
}
