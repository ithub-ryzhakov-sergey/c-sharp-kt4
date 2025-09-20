using System;

namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd
{
    public class ArithmeticUtils
    {
        public int SafeAdd(int a, int b, OverflowStrategy strategy)
        {
            return strategy switch
            {
                OverflowStrategy.Checked => AddChecked(a, b),
                OverflowStrategy.UncheckedWrap => AddUnchecked(a, b),
                OverflowStrategy.Saturate => AddSaturated(a, b),
                _ => throw new ArgumentException("Unknown overflow strategy")
            };
        }

        private int AddChecked(int a, int b)
        {
            checked
            {
                try
                {
                    return a + b;
                }
                catch (OverflowException)
                {
                    throw new OverflowException($"Addition of {a} and {b} causes overflow.");
                }
            }
        }

        private int AddUnchecked(int a, int b)
        {
            unchecked
            {
                return a + b;
            }
        }

        private int AddSaturated(int a, int b)
        {
            long result = (long)a + b;

            if (result > int.MaxValue)
                return int.MaxValue;
            if (result < int.MinValue)
                return int.MinValue;

            return (int)result;
        }
    }
}