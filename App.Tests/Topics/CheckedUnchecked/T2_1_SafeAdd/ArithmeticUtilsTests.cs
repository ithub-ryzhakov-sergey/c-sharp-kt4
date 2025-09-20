using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T2_1_SafeAdd;
using System;

namespace App.Topics.CheckedUnchecked.T2_1_SafeAdd
{
    public enum OverflowStrategy
    {
        Checked,
        UncheckedWrap,
        Saturate
    }

    public static class ArithmeticUtils
    {
        public static int SafeAdd(int a, int b, OverflowStrategy strategy)
        {
            return strategy switch
            {
                OverflowStrategy.Checked => SafeAddChecked(a, b),
                OverflowStrategy.UncheckedWrap => SafeAddUncheckedWrap(a, b),
                OverflowStrategy.Saturate => SafeAddSaturate(a, b),
                _ => throw new ArgumentException("Неизвестная стратегия обработки переполнения", nameof(strategy))
            };
        }

        private static int SafeAddChecked(int a, int b)
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
                throw new OverflowException("Арифметическое переполнение произошло при сложении");
            }
        }

        private static int SafeAddUncheckedWrap(int a, int b)
        {
            unchecked
            {
                return a + b;
            }
        }

        private static int SafeAddSaturate(int a, int b)
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
                if (a > 0 && b > 0) 
                    return int.MaxValue;
                else if (a < 0 && b < 0) 
                    return int.MinValue;
                else
                    return unchecked(a + b);
            }
        }
    }
}