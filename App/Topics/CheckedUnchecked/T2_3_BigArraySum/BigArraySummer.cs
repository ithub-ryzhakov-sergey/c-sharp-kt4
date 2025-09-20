using System;

namespace App.Topics.CheckedUnchecked.T2_3_BigArraySum
{
    public class BigArraySummer
    {
        public long CalculateSum(int[] array, OverflowStrategy strategy)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            long sum = 0;

            foreach (int number in array)
            {
                switch (strategy)
                {
                    case OverflowStrategy.Checked:
                        sum = AddChecked(sum, number);
                        break;
                    case OverflowStrategy.UncheckedWrap:
                        sum = AddUnchecked(sum, number);
                        break;
                    case OverflowStrategy.Saturate:
                        sum = AddSaturated(sum, number);
                        break;
                    default:
                        throw new ArgumentException("Unknown overflow strategy");
                }
            }

            return sum;
        }

        private long AddChecked(long currentSum, int number)
        {
            checked
            {
                try
                {
                    return currentSum + number;
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Sum calculation overflowed");
                }
            }
        }

        private long AddUnchecked(long currentSum, int number)
        {
            unchecked
            {
                return currentSum + number;
            }
        }

        private long AddSaturated(long currentSum, int number)
        {
            try
            {
                checked
                {
                    return currentSum + number;
                }
            }
            catch (OverflowException)
            {
                if (currentSum > 0 && number > 0)
                    return long.MaxValue;
                else if (currentSum < 0 && number < 0)
                    return long.MinValue;
                else
                    return currentSum + number;
            }
        }
    }
}