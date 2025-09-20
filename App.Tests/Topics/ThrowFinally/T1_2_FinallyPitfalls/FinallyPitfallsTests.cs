using App.Topics.ThrowFinally.T1_2_FinallyPitfalls;

namespace App.Tests.Topics.ThrowFinally.T1_2_FinallyPitfalls;

public class FinallyPitfallsTests
{
    [Test, Category("*")]
    public void ReturnValue_IsNotAffectedByFinallyModification()
    {
        // Ожидаемое поведение: вернётся значение, вычисленное до finally
        var result = FinallyPitfalls.ReturnWithFinallyModification(5);
        // Тест ожидает конкретное значение, описанное в комментариях к задаче
        // Например, если в try было return x (x=5), а в finally x++ — метод всё равно возвращает 5
        Assert.That(result, Is.EqualTo(5));
    }
}
