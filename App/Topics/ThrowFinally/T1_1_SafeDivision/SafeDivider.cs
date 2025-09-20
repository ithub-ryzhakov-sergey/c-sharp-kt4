namespace App.Topics.ThrowFinally.T1_1_SafeDivision;

public class SafeDivider
{
    public int CompletedOperationsCount { get; private set; }

    public int SafeDivide(int a, int b)
    {
        try
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Attempted to divide by zero.");
            }
            return a / b;
        }
        finally
        {
            CompletedOperationsCount++;
        }
    }
}
