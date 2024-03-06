using Lab2;

int[] initialArray = [5, 2, 9, 1, 5, 6];
Console.WriteLine("Original array:");
PrintArray(initialArray);

int[] array = initialArray;
Sort.QuickSortDesc(array, 0, array.Length - 1);
Console.WriteLine("\nSorted array in non-decreasing order:");
PrintArray(array);

array = initialArray;
Sort.RandomizedQuickSortDesc(array, 0, array.Length - 1);
Console.WriteLine("\nRandomized quick soct descending:");
PrintArray(array);

var optimal = Oil.OptimalMainCanal(Oil.TestWells);
Console.WriteLine($"\nOptimal vertical coodinates for main oil canal: {optimal}");

static void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}