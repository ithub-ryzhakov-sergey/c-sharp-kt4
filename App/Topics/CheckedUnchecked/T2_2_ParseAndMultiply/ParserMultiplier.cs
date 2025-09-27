namespace App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply;

public static class ParserMultiplier
{
    public static int ParseAndMultiply(string a, string b, bool useChecked)
    {
        if (string.IsNullOrWhiteSpace(a))
            throw new ArgumentException("первая строка не может быть пустой или null", nameof(a));

        if (string.IsNullOrWhiteSpace(b))
            throw new ArgumentException("вторая строка не может быть null или пусто", nameof(b));

        if (!int.TryParse(a, out int numA))
            throw new FormatException($"нельзя преобразовать первую строку в число: '{a}'");

        if (!int.TryParse(b, out int numB))
            throw new FormatException($"нельзя вторую строку в число: '{b}'");

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