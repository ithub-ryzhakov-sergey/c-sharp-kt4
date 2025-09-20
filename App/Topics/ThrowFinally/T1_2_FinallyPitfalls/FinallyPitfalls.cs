using System;

namespace App.Topics.ThrowFinally.T1_2_FinallyPitfalls
{
    public class FinallyPitfalls
    {
        public int DemonstrateFinallyWithReturn()
        {
            int result = 10;
            try
            {
                result = 20;
                return result;
            }
            finally
            {
                result = 30;
            }
        }

        public int DemonstrateFinallyWithReturnAndOutParameter(out int outValue)
        {
            outValue = 100;
            try
            {
                outValue = 200;
                return 50;
            }
            finally
            {
                outValue = 300;
            }
        }

        public string DemonstrateFinallyWithException()
        {
            string message = "initial";
            try
            {
                message = "in try";
                throw new InvalidOperationException("Test exception");
            }
            catch
            {
                message = "in catch";
                throw;
            }
            finally
            {
                message = "in finally";
            }
        }
    }
}