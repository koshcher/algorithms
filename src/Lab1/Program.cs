// See https://aka.ms/new-console-template for more information
using Lab1;
using System.Diagnostics;

int[] array = [5, 6, 8, 4, 10, -4, -3, -7, 3, 1, 2, -8, -15, 17, 80, 20, 90, -100];
var linkedList = new LinkedList<int>(array);

// warm up of runtime
//for (int i = 0; i < 10000; i += 1)
//{
//    _ = array.TraversingSearch(-7);
//    _ = linkedList.TraversingSearch(-7);
//    _ = array.BarrierSearch(-7);
//    _ = linkedList.BarrierSearch(-7);
//}

PrintEnumerable(array);
PrintEnumerable(linkedList);

MeasureSearchTime("Traversing search for array", () => array.TraversingSearch(-7));
MeasureSearchTime("Traversing search for linked list", () => linkedList.TraversingSearch(-7));

PrintEnumerable(array);
PrintEnumerable(linkedList);

MeasureSearchTime("Barrier search for array", () => array.BarrierSearch(-7));
MeasureSearchTime("Barrier search for linked list", () => linkedList.BarrierSearch(-7));

PrintEnumerable(array);
PrintEnumerable(linkedList);

Array.Sort(array);
linkedList = SortLinkedList(linkedList);

PrintEnumerable(array);
PrintEnumerable(linkedList);

MeasureSearchTime("Binary search for array", () => array.BinarySearch(-7));
MeasureSearchTime("Binary search for linked list", () => linkedList.BinarySearch(-7));

PrintEnumerable(array);
PrintEnumerable(linkedList);

MeasureSearchTime("Golden Ratio Binary search for array", () => array.GoldenRatioBinarySearch(-7));
MeasureSearchTime("Golden Ratio Binary search for linked list", () => linkedList.GoldenRatioBinarySearch(-7));

PrintEnumerable(array);
PrintEnumerable(linkedList);
static void MeasureSearchTime(string message, Func<int> search)
{
    Stopwatch stopwatch = new();
    stopwatch.Start();
    var index = search();
    stopwatch.Stop();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{message}: index={index} time={stopwatch.ElapsedTicks} ticks");
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