namespace App.Topics.ThrowFinally.T1_2_FinallyPitfalls;

// Дополнительная задача (*): продемонстрировать поведение finally при return
// Ожидаемая семантика описана в тестах: значение, вычисленное до return,
// копируется в стек вызова до выполнения finally; изменённые переменные в finally
// не влияют на возвращаемое значение примитивного типа.
public static class FinallyPitfalls
{
    public static int ReturnWithFinallyModification(int input)
    {
        try
        {
            return input;
        }
        finally
        {
            input += 1;
        }
    }
}