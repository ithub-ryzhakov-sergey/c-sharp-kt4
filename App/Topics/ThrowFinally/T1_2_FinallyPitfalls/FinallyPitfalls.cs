namespace App.Topics.ThrowFinally.T1_4_FinallyPitfalls;

public static class FinallyPitfalls
{
    public static int ReturnWithFinallyModification(int input)
    {
        int result = 0;
        try
        {
            result = input * 2;
            return result;        
        }
        finally
        {
            result = 100;        
        }
    }
}
