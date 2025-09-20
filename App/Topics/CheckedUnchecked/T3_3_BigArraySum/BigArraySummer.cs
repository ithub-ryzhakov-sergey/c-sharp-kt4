using System;

namespace App.Topics.CheckedUnchecked.T3_3_BigArraySum;

public static class BigArraySummer
{
    public static long Sum(int[] data, OverflowStrategy strategy)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        int intermediateSum = 0;

        foreach (int number in data)
        {
            switch (strategy)
            {
                case OverflowStrategy.Checked:
                    checked
                    {
                        intermediateSum += number;
                    }
                    break;

                case OverflowStrategy.UncheckedWrap:
                    unchecked
                    {
                        intermediateSum += number;
                    }
                    break;

                case OverflowStrategy.Saturate:
                    long tempResult = (long)intermediateSum + number;

                    if (tempResult > int.MaxValue)
                    {
                        intermediateSum = int.MaxValue;
                    }
                    else if (tempResult < int.MinValue)
                    {
                        intermediateSum = int.MinValue;
                    }
                    else
                    {
                        intermediateSum = (int)tempResult;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null);
            }
        }

        return intermediateSum;
    }
}
