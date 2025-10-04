using System;

namespace App.Tasks
{
    public static class T1_1_SafeDivision
    {
        // Счётчик завершённых операций
        public static int OperationCompletedCount = 0;


        public static int SafeDivide(int a, int b)
        {
            try
            {
                // Проверка деления на ноль
                if (b == 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                }

                // Выполняем деление в checked-контексте для отлова переполнения
                checked
                {
                    return a / b;
                }
            }
            catch (DivideByZeroException)
            {
                // Перебрасываем исключение без потери стека
                throw;
            }
            catch (OverflowException ex)
            {
                // Например, int.MinValue / -1 вызывает переполнение
                throw new OverflowException("Результат деления вызывает переполнение.", ex);
            }
            finally
            {
                // В любом случае увеличиваем счётчик завершённых операций
                OperationCompletedCount++;
            }
        }
    }
}