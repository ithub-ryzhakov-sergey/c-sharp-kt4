namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd;

public static class ArithmeticUtils
{
    // Сложение с управлением переполнением. Требуется реализовать 3 стратегии.
    public static int SafeAdd(int a, int b, OverflowStrategy strategy)
    {
        if(strategy == OverflowStrategy.Checked)
        {
            checked
            {
                return a + b;
            }
        }

        if (strategy == OverflowStrategy.UncheckedWrap)
        {
            unchecked
            {
                return a + b;
            }
        }

        if (strategy == OverflowStrategy.Saturate)
        {
            try
            {
                checked
                {
                    return a + b;
                }
            }
            catch (OverflowException)
            {

                if (a > 0 || b > 0)
                {
                    return int.MaxValue;
                }
                if (a < 0 || b < 0)
                {
                    return int.MinValue;
                }











            }
        }

        throw new NotImplementedException();
    }
}
