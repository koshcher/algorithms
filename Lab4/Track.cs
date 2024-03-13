namespace Lab4;

public delegate bool RemoveDelegate<T>(out T value);

/// <summary>
/// Track addition and removing from stack/queue like methods.
/// </summary>
public static class Track
{
    public static void Add<T>(string message, Action<T> action, T value)
    {
        action(value);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}: {value}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Remove<T>(string message, RemoveDelegate<T> action)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (action(out var value))
        {
            Console.WriteLine($"{message}: {value}");
        }
        else
        {
            Console.WriteLine($"Nothing can be {message}");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}