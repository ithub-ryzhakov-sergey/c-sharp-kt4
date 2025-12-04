namespace App.Topics.CheckedUnchecked.T2_3_BigArraySum;

public static class BigArraySummer
{
    public static long Sum(int[] data, OverflowStrategy strategy)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        if (strategy == OverflowStrategy.Checked)
        {
            checked
            {
                int sum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    sum += data[i];
                }
                return sum;
            }
        }
        else if (strategy == OverflowStrategy.UncheckedWrap)
        {
            unchecked
            {
                int sum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    sum += data[i];
                }
                return sum;
            }
        }
        else
        {
            throw new ArgumentException("Unknown strategy", nameof(strategy));
        }
    }
}