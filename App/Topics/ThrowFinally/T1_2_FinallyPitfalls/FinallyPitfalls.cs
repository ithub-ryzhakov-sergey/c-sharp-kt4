namespace App.Topics.ThrowFinally.T1_2_FinallyPitfalls;

public static class FinallyPitfalls
{
    public static int ReturnWithFinallyModification(int input)
    {
        int result = 0;
        try
        {
            result = 0 + input;
            return result;
        }
        finally
        {
            result++;
        }
    }
}