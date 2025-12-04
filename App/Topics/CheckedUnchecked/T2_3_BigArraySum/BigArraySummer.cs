namespace App.Topics.CheckedUnchecked.T2_3_BigArraySum;

public static class BigArraySummer
{
    public static long Sum(int[] data, OverflowStrategy strategy)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        long total = 0;

        if (strategy == OverflowStrategy.Checked)
        {
            checked
            {
                for (int i = 0; i < data.Length; i++)
                {
                    total += data[i];
                }
            }
        }
        else if (strategy == OverflowStrategy.UncheckedWrap)
        {
            unchecked
            {
                int temp = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    temp += data[i];
                }
                total = temp;
            }
        }
        else
        {
            throw new ArgumentException();
        }

        return total;
    }
}