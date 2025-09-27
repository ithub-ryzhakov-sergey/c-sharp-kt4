//using App.Topics.CheckedUnchecked;
//using App.Topics.CheckedUnchecked.T2_3_BigArraySum;

//namespace App.Tests.Topics.CheckedUnchecked.T2_3_BigArraySum;

//public class BigArraySummerTests
//{
//    [Test, Category("*")]
//    public void Sum_UncheckedWrap_AllowsIntOverflowButAccumulatesIntoLong()
//    {
//        var data = new[] { int.MaxValue, 10, 20 };
//        // При int-сложении с обёрткой: int.MaxValue + 10 -> overflow -> unchecked поведение
//        // Но итоговая сумма возвращается как long
//        var expectedLong = (long)unchecked(int.MaxValue + 10 + 20);
//        var res = BigArraySummer.Sum(data, OverflowStrategy.UncheckedWrap);
//        Assert.That(res, Is.EqualTo(expectedLong));
//    }

//    [Test, Category("*")]
//    public void Sum_Checked_ThrowsOnOverflow()
//    {
//        var data = new[] { int.MaxValue, 1 };
//        Assert.Throws<OverflowException>(() => BigArraySummer.Sum(data, OverflowStrategy.Checked));
//    }
//}
