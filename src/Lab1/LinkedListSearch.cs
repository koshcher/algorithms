using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

public static class LinkedListSearch
{
    public static int TraversingSearch(this LinkedList<int> list, int searchValue)
    {
        int index = -1;
        foreach (var num in list)
        {
            index += 1;
            if (num == searchValue) return index;
        }
        return -1;
    }

    public static int BarrierSearch(this LinkedList<int> nums, int searchValue)
    {
        if (nums.Count == 0) return -1;

        var last = nums.Last;
        var lastValue = last!.Value;
        if (lastValue == searchValue) return nums.Count - 1;

        last.Value = searchValue;
        int i = 0;
        var current = nums.First;
        while (current!.Value != searchValue)
        {
            current = current.Next;
            i += 1;
        }

        last.Value = lastValue;
        return i < nums.Count - 1 ? i : -1;
    }

    public static int BinarySearch(this LinkedList<int> sortedList, int searchValue)
    {
        int index = 0;

        int left = 0;
        int right = sortedList.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Move to the middle of the linked list
            LinkedListNode<int>? currentNode = MoveToIndex(sortedList, mid);

            if (currentNode.Value == searchValue)
            {
                return index + mid; // Found at current position
            }
            else if (currentNode.Value < searchValue)
            {
                // Adjust the search range to the right
                left = mid + 1;
            }
            else
            {
                // Adjust the search range to the left
                right = mid - 1;
            }
        }

        return -1; // Element not found
    }

    public static int GoldenRatioBinarySearch(this LinkedList<int> linkedList, int searchValue)
    {
        int left = 0;
        int right = linkedList.Count - 1;

        const double goldenRatio = 1.618033988749895;

        while (left <= right)
        {
            int m = (int)(right - (right - left) / goldenRatio);
            LinkedListNode<int> midNode = MoveToIndex(linkedList, m);
            int midValue = midNode.Value;

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

    private static LinkedListNode<T> MoveToIndex<T>(LinkedList<T> list, int index)
    {
        var currentNode = list.First;

        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }
}