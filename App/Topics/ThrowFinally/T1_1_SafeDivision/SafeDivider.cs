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
                throw new DivideByZeroException("деление на ноль");
            }
            double res = a / b;
            return Convert.ToInt32(res);
            
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CompletedOperationsCount++;
        }
    }
    public SafeDivider()
    {
        this.CompletedOperationsCount = 0;
    }
}
