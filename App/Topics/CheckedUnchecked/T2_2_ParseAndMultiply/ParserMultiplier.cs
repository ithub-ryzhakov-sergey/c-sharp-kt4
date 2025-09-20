using System;

namespace App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply
{
    public class ParseMultiplier
    {
        public int ParseAndMultiply(string a, string b, bool useChecked)
        {
            if (string.IsNullOrWhiteSpace(a))
                throw new ArgumentException("First argument cannot be null or whitespace", nameof(a));

            if (string.IsNullOrWhiteSpace(b))
                throw new ArgumentException("Second argument cannot be null or whitespace", nameof(b));

            if (!int.TryParse(a, out int numA))
                throw new FormatException($"Cannot parse '{a}' as integer");

            if (!int.TryParse(b, out int numB))
                throw new FormatException($"Cannot parse '{b}' as integer");

            if (useChecked)
            {
                checked
                {
                    try
                    {
                        return numA * numB;
                    }
                    catch (OverflowException)
                    {
                        throw new OverflowException($"Multiplication of {numA} and {numB} causes overflow.");
                    }
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