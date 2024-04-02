namespace Lab4;

public class RomanLinkedListNode<T>(T value)
{
    public T Value { get; set; } = value;

    public RomanLinkedListNode<T>? Previous { get; set; } = null;
    public RomanLinkedListNode<T>? Next { get; set; } = null;
}

public class RomanLinkedList<T>
{
    private RomanLinkedListNode<T>? head = null;
    private RomanLinkedListNode<T>? tail = null;

    public RomanLinkedListNode<T>? GetLast()
    {
        if (tail != null)
        {
            return tail;
        }
        return head;
    }

    public RomanLinkedListNode<T>? GetFirst()
    {
        return head;
    }

    public void AddLast(T value)
    {
        var newNode = new RomanLinkedListNode<T>(value);
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
    }

    public void RemoveFirst()
    {
        if (head == null) return;

        if (head.Next != null)
        {
            head.Next.Previous = null;
        }

        head = head.Next;
    }

    public void RemoveLast()
    {
        if (tail == null) return;
        if (tail.Previous != null)
        {
            tail.Previous.Next = null;
        }
        tail = tail.Previous;
    }
}