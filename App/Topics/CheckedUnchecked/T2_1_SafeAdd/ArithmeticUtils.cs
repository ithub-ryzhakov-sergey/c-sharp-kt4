namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd;

public static class ArithmeticUtils
{
    public static int SafeAdd(int a, int b, OverflowStrategy strategy)
    {
        return strategy switch
        {
            OverflowStrategy.Checked => checked(a + b),
            OverflowStrategy.UncheckedWrap => unchecked(a + b),
            OverflowStrategy.Saturate => AddWithSaturation(a, b),_ => throw new ArgumentException("неправильная стратегия:", nameof(strategy))
        };
    }

    private static int AddWithSaturation(int a, int b)
    {
        long result = (long)a + b;

        if (result > int.MaxValue) return int.MaxValue;
        if (result < int.MinValue) return int.MinValue;

        return (int)result;
    }
}