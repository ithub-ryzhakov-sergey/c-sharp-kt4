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

            checked
            {
                return a / b;
            }
        }
        catch (DivideByZeroException)
        {
            throw;
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("переполнение типа данных int", ex);
        }
        finally
        {
            CompletedOperationsCount++;
        }
    }
}