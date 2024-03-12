using System.Diagnostics;

Console.WriteLine("Enter a string in which we will search (long one):");
var source = Console.ReadLine();

Console.WriteLine("Enter a string we need to search in previous string (short one)");
var search = Console.ReadLine();

if (source == null || search == null)
{
    Console.WriteLine("Input is invalid. Goodbye");
    return;
}
Console.WriteLine();

Console.WriteLine("Spead test all methods for inputed string");
SpeadTestAll(source, search);

var bigStr = GenerateBigString("roman");
Console.WriteLine("Big str:");
Console.WriteLine($"{bigStr}");
Console.WriteLine("Spead test all methods for big string with similar parts");
SpeadTestAll(bigStr, "roman");

Console.WriteLine("Spead test all methods for big string with not existing substring");
SpeadTestAll(bigStr, "ramadan");

static void SpeadTestAll(string source, string pattern)
{
    List<(string, Func<string, string, int>)> searches = [
        ("Straight", StraightSearch),
        ("KMP", KmpSearch),
        ("Built-in", BuiltInSearch)
    ];

    const int warmup = 100;

    for (int i = 0; i <= warmup; i++)
    {
        if (i == warmup)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        foreach (var (name, func) in searches)
        {
            SpeedTestSearch(name, func, source, pattern);
        }
        Console.WriteLine();

        if (i == warmup)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

static void SpeedTestSearch(string name, Func<string, string, int> search, string source, string pattern)
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    var index = search(source, pattern);
    stopwatch.Stop();
    Console.WriteLine($"{name} search found index in: {stopwatch.ElapsedTicks} ticks");
}

static string GenerateBigString(string pattern)
{
    var str = "";
    var piece = pattern[..3];
    for (int i = 0; i < 100000; i++)
    {
        str += piece;
    }
    str += pattern;
    return str;
}

static int BuiltInSearch(string source, string pattern)
{
    return source.IndexOf(pattern);
}

static int StraightSearch(string text, string pattern)
{
    for (int i = 0; i <= text.Length - pattern.Length; i++)
    {
        int j;
        for (j = 0; j < pattern.Length; j++)
        {
            if (text[i + j] != pattern[j])
            {
                break;
            }
        }

        if (j == pattern.Length)
        {
            return i;
        }
    }

    return -1;
}

static int[] ComputePrefixArray(string pattern)
{
    int[] lps = new int[pattern.Length];
    int length = 0;
    int i = 1;

    while (i < pattern.Length)
    {
        if (pattern[i] == pattern[length])
        {
            length += 1;
            lps[i] = length;
            i += 1;
        }
        else if (length != 0)
        {
            length = lps[length - 1];
        }
        else
        {
            lps[i] = 0;
            i += 1;
        }
    }

    return lps;
}

static int KmpSearch(string text, string pattern)
{
    var prefixArray = ComputePrefixArray(pattern);
    int i = 0;
    int j = 0;

    while (i < text.Length)
    {
        if (pattern[j] == text[i])
        {
            i += 1;
            j += 1;
        }

        if (j == pattern.Length)
        {
            return i - j;
        }
        else if (i < text.Length && pattern[j] != text[i])
        {
            if (j != 0)
            {
                j = prefixArray[j - 1];
            }
            else
            {
                i += 1;
            }
        }
    }

    return -1;
}