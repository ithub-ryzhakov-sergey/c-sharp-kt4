using System.Security.Cryptography.X509Certificates;

namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd;

public static class ArithmeticUtils
{
    // Сложение с управлением переполнением. Требуется реализовать 3 стратегии.
    public static int SafeAdd(int a, int b, OverflowStrategy strategy)
    {
        long res = (long)a + b;
        switch (strategy)
        {
            case OverflowStrategy.Checked:
                if (res > int.MaxValue || res < int.MinValue)
                {
                    throw new OverflowException();
                }
                return (int)res;

            case OverflowStrategy.UncheckedWrap:
                return a + b;

            case OverflowStrategy.Saturate:
                if (res > int.MaxValue)
                {
                    return int.MaxValue;
                }
                else if (res < int.MinValue)
                {
                    return int.MinValue;
                }
                return (int)res;

            default:
                return (int)res;
        }
    }
}
