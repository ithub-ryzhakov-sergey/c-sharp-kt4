public class FinallyPitfalls
{

    /**
     * Демонстрирует, что изменение переменной в finally не влияет на возвращаемое значение,
     * если return уже был выполнен в try.
     * @return всегда возвращает 10, несмотря на изменение переменной в finally
     */
    public static int demonstrateFinallyPitfall()
    {
        int result = 10;
        try
        {
            return result; // значение 10 запоминается как возвращаемое
        }
        finally
        {
            result = 20;   // изменяем переменную, но это НЕ повлияет на return!
            // Дополнительно: если бы здесь был return 20; — вернулось бы 20.
            // Но это плохая практика.
        }
    }

    /**
     * Демонстрация с объектом (изменение состояния объекта в finally — может повлиять!)
     * @return массив, который был изменён в finally
     */
    public static int[] demonstrateFinallyPitfallWithObject()
    {
        int[] arr = { 1, 2, 3 };
        try
        {
            return arr; // возвращается ссылка на объект
        }
        finally
        {
            arr[0] = 999; // состояние объекта изменяется — это повлияет на результат!
        }
    }
}