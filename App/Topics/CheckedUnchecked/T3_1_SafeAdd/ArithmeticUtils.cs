using System;

namespace App.Topics.CheckedUnchecked.T3_1_SafeAdd;

using App.Topics.CheckedUnchecked;

public static class ArithmeticUtils
{
    public static int SafeAdd(int a, int b, OverflowStrategy strategy)
    {
        switch (strategy)
        {
            case OverflowStrategy.Checked:
                checked
                {
                    return a + b;
                }

            case OverflowStrategy.UncheckedWrap:
                unchecked
                {
                    return a + b;
                }

            case OverflowStrategy.Saturate:
                long result = (long)a + b;

                if (result > int.MaxValue)
                    return int.MaxValue;

                if (result < int.MinValue)
                    return int.MinValue;

                return (int)result;

            default:
                throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null);
        }
    }
}