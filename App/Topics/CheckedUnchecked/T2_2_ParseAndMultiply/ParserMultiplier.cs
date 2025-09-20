using System.Linq.Expressions;

namespace App.Topics.CheckedUnchecked.T2_2_ParseAndMultiply;

public static class ParserMultiplier
{
    public static int ParseAndMultiply(string a, string b, bool useChecked)
    {
        if (string.IsNullOrWhiteSpace(a))
            throw new ArgumentException("Ошибка");
        if (string.IsNullOrWhiteSpace(b))
            throw new ArgumentException("Ошибка");

        int x = Convert.ToInt32(a);
        int y = Convert.ToInt32(b);
        if (useChecked)
        {
            checked
            {
                return x * y;
            }
        }
        else
        {
            unchecked
            {
                return x * y;
            }
        }              
    }
}
