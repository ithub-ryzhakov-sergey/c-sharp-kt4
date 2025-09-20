namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd;

public static class ArithmeticUtils
{
    // Сложение с управлением переполнением. Требуется реализовать 3 стратегии.
    public static int SafeAdd(int a, int b, OverflowStrategy strategy)
    {
        if (strategy == OverflowStrategy.Checked)
        {
            return checked(a + b);
        }

        if (strategy == OverflowStrategy.UncheckedWrap)
        {
            return unchecked(a + b);
        }

        if (strategy == OverflowStrategy.Saturate)
        {
            long result = (long)a + (long)b;

            if(result > int.MaxValue)
            {
                return int.MaxValue;
            }
            if (result < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)result;
        }

        throw new ArgumentException("Ошибка");
    }
}
