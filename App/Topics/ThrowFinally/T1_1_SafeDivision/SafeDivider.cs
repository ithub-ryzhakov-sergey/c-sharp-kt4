namespace App.Topics.ThrowFinally.T1_1_SafeDivision;

// Задача: реализовать безопасное деление с корректной работой finally и повторным пробросом исключений.
// Подсказки:
// - Используйте try/finally. В finally инкрементируйте счетчик завершенных операций.
// - При делении на ноль бросайте DivideByZeroException с понятным сообщением.
// - Если нужно пробросить текущее исключение выше — используйте `throw;`, а не `throw ex;`.
public class SafeDivider
{
    // Этот счетчик должен увеличиваться ПОСЛЕ каждой попытки деления
    // (успешной или неуспешной). Тесты проверят, что finally отработал.
    public int CompletedOperationsCount { get; private set; }

    public int SafeDivide(int a, int b)
    {
        // Требуется реализация студентом.
        throw new System.NotImplementedException();
    }
}
