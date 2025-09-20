using App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply;

namespace App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply
{
    public static class ParserMultiplier
    {
        public static int ParseAndMultiply(string a, string b, bool useChecked)
        {
            if (string.IsNullOrWhiteSpace(a))
                throw new ArgumentException("Input string 'a' cannot be null or whitespace", nameof(a));

            if (string.IsNullOrWhiteSpace(b))
                throw new ArgumentException("Input string 'b' cannot be null or whitespace", nameof(b));

            if (!int.TryParse(a, out int numA))
                throw new FormatException($"Failed to parse '{a}' as integer");

            if (!int.TryParse(b, out int numB))
                throw new FormatException($"Failed to parse '{b}' as integer");

            if (useChecked)
            {
                try
                {
                    checked
                    {
                        return numA * numB;
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Multiplication resulted in overflow");
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
}