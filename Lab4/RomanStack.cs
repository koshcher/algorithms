using System.Diagnostics.CodeAnalysis;

namespace Lab4;

public class RomanStack<T>
{
    private readonly LinkedList<T> data = new();

    public void Push(T item)
    {
        data.AddLast(item);
    }

    public bool TryPop([NotNullWhen(true)] out T? value)
    {
        var last = data.Last;
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