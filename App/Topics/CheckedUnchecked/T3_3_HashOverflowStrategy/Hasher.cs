using System;

namespace App.Topics.CheckedUnchecked.T3_3_HashOverflowStrategy;

using App.Topics.CheckedUnchecked;

public static class Hasher
{
    // Простой полиномиальный хэш с настраиваемой стратегией переполнения
    // hash = 17; foreach (var b in data) hash = hash * 31 + b;
    public static int Compute(byte[] data, OverflowStrategy strategy)
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }
}
