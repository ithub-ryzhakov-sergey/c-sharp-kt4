using System;

namespace App.Topics.ThrowFinally.T1_1_SafeDivision
{
    public class SafeDivider
    {
        public int OperationsCount { get; private set; }

        public double SafeDivide(int a, int b, out bool operationCompleted)
        {
            // Инициализируем out параметр сразу
            operationCompleted = false;

            try
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }

                if (a == int.MinValue && b == -1)
                {
                    throw new OverflowException("Division of int.MinValue by -1 causes overflow.");
                }

                return (double)a / b;
            }
            finally
            {
                OperationsCount++;
                operationCompleted = true; // Гарантированно выполнится
            }
        }
    }
}