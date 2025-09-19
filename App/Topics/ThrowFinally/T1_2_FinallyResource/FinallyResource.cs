using System;

namespace App.Topics.ThrowFinally.T1_2_FinallyResource;

// Задача: гарантировать закрытие ресурса в finally.
// Есть псевдо-ресурс, который нужно открыть, использовать, затем закрыть даже при ошибке.
// Реализуйте методы так, чтобы Use бросал, если ресурс не открыт, а Close был идемпотентен.
public class FinallyResource
{
    private bool _opened;
    private bool _closed;

    public void Open()
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }

    public void Use(Action? work = null)
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }

    public void Close()
    {
        // Требуется реализация студентом.
        throw new NotImplementedException();
    }

    // Вспомогательный шаблон: гарантированно закрыть ресурс после работы
    public void OpenUseClose(Action work)
    {
    }
}
