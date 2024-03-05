namespace Lab2;

public class Sort
{
    private static readonly Random random = new();

    public static void QuickSortDesc(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(arr, low, high);

            QuickSortDesc(arr, low, partitionIndex - 1);
            QuickSortDesc(arr, partitionIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        bool allEqual = true;

        for (int j = low; j < high; j++)
        {
            var element = arr[j];
            if (element != pivot)
            {
                allEqual = false;
            }

            if (element >= pivot)
            {
                i += 1;
                Swap(ref arr[i], ref arr[j]);
            }
        }

        Swap(ref arr[i + 1], ref arr[high]);

        if (allEqual)
        {
            return (low + high) / 2;
        }

        return i + 1;
    }

    private static void Swap(ref int a, ref int b)
    {
        (b, a) = (a, b);
    }

    public static void RandomizedQuickSortDesc(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = RandomizedPartition(arr, low, high);

            RandomizedQuickSortDesc(arr, low, partitionIndex - 1);
            RandomizedQuickSortDesc(arr, partitionIndex + 1, high);
        }
    }

    private static int RandomizedPartition(int[] arr, int low, int high)
    {
        int randomIndex = random.Next(low, high + 1);

        Swap(ref arr[randomIndex], ref arr[high]);

        return Partition(arr, low, high);
    }
}