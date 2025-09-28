namespace App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply;

public static class ParserMultiplier
{
    // Парсит две строки и перемножает. При useChecked=true переполнение должно приводить к OverflowException
    public static int ParseAndMultiply(string a, string b, bool useChecked)
    {
        if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b) || a.Trim()== "" || b.Trim()== "")
        {
            throw new ArgumentException();
        }
        int _a;
        int _b;
        if (!int.TryParse(a, out _a) || !int.TryParse(b, out _b))
        {
            throw new FormatException();
        }
        if ((long)_a * _b > int.MaxValue  && useChecked)
        {
            throw new OverflowException();
        }
        return _a * _b;
    }
}
