using System;

namespace App.Topics.CheckedUnchecked.T3_2_ParseAndMultiply;

public static class ParserMultiplier
{
    public static int ParseAndMultiply(string a, string b, bool useChecked)
    {
        // Валидация входных строк
        if (string.IsNullOrWhiteSpace(a))
            throw new ArgumentException("Первая строка не может быть пустой или null", nameof(a));

        if (string.IsNullOrWhiteSpace(b))
            throw new ArgumentException("Вторая строка не может быть пустой или null", nameof(b));

        // Парсинг строк в числа
        int numA = int.Parse(a);
        int numB = int.Parse(b);

        // Умножение с учетом флага useChecked
        if (useChecked)
        {
            checked
            {
                return numA * numB;
            }
        }
        else
        {
            unchecked
            {
                return numA * numB;
            }
        }
    }
}
