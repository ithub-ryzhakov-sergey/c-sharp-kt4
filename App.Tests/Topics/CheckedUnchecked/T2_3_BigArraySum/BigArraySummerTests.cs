using App.Topics.CheckedUnchecked;
using App.Topics.CheckedUnchecked.T2_3_BigArraySum;

namespace App.Topics.CheckedUnchecked.T2_3_BigArraySum
{
    public enum OverflowStrategy
    {
        UncheckedWrap,
        Checked
    }

    public static class BigArraySummer
    {
        public static long Sum(int[] data, OverflowStrategy strategy)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (data.Length == 0)
                return 0L;

            long total = 0L;

            switch (strategy)
            {
                case OverflowStrategy.UncheckedWrap:
                    return SumUnchecked(data, total);

                case OverflowStrategy.Checked:
                    return SumChecked(data, total);

                default:
                    throw new ArgumentException($"Unknown overflow strategy: {strategy}", nameof(strategy));
            }
        }

        private static long SumUnchecked(int[] data, long total)
        {
            unchecked
            {
                int intermediateSum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    intermediateSum += data[i];
                }
                total = intermediateSum;
                return total;
            }
        }

        private static long SumChecked(int[] data, long total)
        {
            checked
            {
                int intermediateSum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    intermediateSum += data[i];
                }
                total = intermediateSum;
                return total;
            }
        }
    }
}