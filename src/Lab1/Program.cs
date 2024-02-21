using Lab1;
using System.Diagnostics;

int[] array = GenerateArray(100000);
var linkedList = new LinkedList<int>(array);

var search = array[new Random().Next(0, array.Length - 1)];

// warm up of runtime
for (int i = 0; i < 10000; i += 1)
{
    _ = array.TraversingSearch(search);
    _ = linkedList.TraversingSearch(search);
    _ = array.BarrierSearch(search);
    _ = linkedList.BarrierSearch(search);
}

MeasureSearchTime("Traversing search for array", () => array.TraversingSearch(search));

MeasureSearchTime("Traversing search for linked list", () => linkedList.TraversingSearch(search));

Console.WriteLine();

MeasureSearchTime("Barrier search for array", () => array.BarrierSearch(search));
MeasureSearchTime("Barrier search for linked list", () => linkedList.BarrierSearch(search));

Array.Sort(array);
linkedList = SortLinkedList(linkedList);
Console.WriteLine();

MeasureSearchTime("Binary search for array", () => array.BinarySearch(search));
MeasureSearchTime("Binary search for linked list", () => linkedList.BinarySearch(search));

Console.WriteLine();

MeasureSearchTime("Golden Ratio Binary search for array", () => array.GoldenRatioBinarySearch(search));
MeasureSearchTime("Golden Ratio Binary search for linked list", () => linkedList.GoldenRatioBinarySearch(search));

Console.WriteLine();

static int[] GenerateArray(int count)
{
    int[] arr = new int[count];
    for (int i = 0; i < count; i++)
    {
        arr[i] = new Random().Next();
    }
    return arr;
}

static void MeasureSearchTime(string message, Func<int> search)
{
    Stopwatch stopwatch = new();
    stopwatch.Start();
    var index = search();
    stopwatch.Stop();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{message}: index = {index} time = {stopwatch.ElapsedTicks} ticks");
    Console.ForegroundColor = ConsoleColor.White;
}

static void PrintEnumerable(IEnumerable<int> nums)
{
    foreach (var num in nums)
    {
        Console.Write(num);
        Console.Write(" ");
    }
    Console.WriteLine();
}

static LinkedList<int> SortLinkedList(LinkedList<int> linkedList)
{
    int[] array = new int[linkedList.Count];
    linkedList.CopyTo(array, 0);

    Array.Sort(array);

    return new LinkedList<int>(array);
}