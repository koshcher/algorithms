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

static void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}