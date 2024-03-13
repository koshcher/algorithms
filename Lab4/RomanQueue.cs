using System.Diagnostics.CodeAnalysis;

namespace Lab4;

public class RomanQueue<T>
{
    private readonly LinkedList<T> data = new();

    public void Enqueue(T item)
    {
        data.AddLast(item);
    }

    public bool TryDequeue([NotNullWhen(true)] out T? value)
    {
        var first = data.First;
        if (first == null || first.Value == null)
        {
            value = default;
            return false;
        }

        value = first.Value;
        data.RemoveFirst();
        return true;
    }
}