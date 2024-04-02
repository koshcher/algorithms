using System.Diagnostics.CodeAnalysis;

namespace Lab4;

public class RomanStack<T>
{
    private readonly RomanLinkedList<T> data = new();

    public void Push(T item)
    {
        data.AddLast(item);
    }

    public bool TryPop([NotNullWhen(true)] out T? value)
    {
        var last = data.GetLast();
        if (last == null || last.Value == null)
        {
            value = default;
            return false;
        }

        value = last.Value;
        data.RemoveLast();
        return true;
    }
}