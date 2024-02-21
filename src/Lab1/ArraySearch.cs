using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

public static class ArraySearch
{
    public static int TraversingSearch(this int[] arr, int searchValue)
    {
        for (int i = 0; i < arr.Length; i += 1)
        {
            if (arr[i] == searchValue) { return i; }
        }
        return -1;
    }

    public static int BarrierSearch(this int[] nums, int searchValue)
    {
        if (nums.Length == 0) return -1;

        var lastIndex = nums.Length - 1;
        var last = nums[lastIndex];
        if (last == searchValue) return lastIndex;

        nums[lastIndex] = searchValue;

        int i = 0;
        while (nums[i] != searchValue)
        {
            i += 1;
        }

        nums[lastIndex] = last;
        return i < lastIndex ? i : -1;
    }

    public static int BinarySearch(this int[] nums, int searchValue)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == searchValue)
            {
                return mid; // Знайдено елемент, повертаємо індекс
            }
            else if (nums[mid] < searchValue)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1; // Елемент не знайдено
    }

    private const double goldenRatio = 1.618033988749895;

    public static int GoldenRatioBinarySearch(this int[] arr, int searchValue)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int m = (int)(right - (right - left) / goldenRatio);
            int midValue = arr[m];

            if (midValue == searchValue)
            {
                return m;
            }
            else if (midValue < searchValue)
            {
                left = m + 1;
            }
            else
            {
                right = m - 1;
            }
        }

        return -1;
    }
}