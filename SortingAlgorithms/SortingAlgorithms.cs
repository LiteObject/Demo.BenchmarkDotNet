using System;

namespace Demo.BenchmarkDotNet.SortingAlgorithms
{
    /// <summary>
    /// Source: https://www.exchangecore.com/blog/c-sorting-algorithms-performance-comparison
    /// </summary>
    public class SortingAlgorithms
    {
        public delegate void SortMethod(int[] list);

        public void ShowSortingTimes(String methodName, SortMethod method, int[] list)
        {
            double sortTime;
            Console.WriteLine("{0} of {1} items:", methodName, list.Length);
            FillRandom(list, 10000);
            sortTime = GetSortingTime(method, list);
            Console.WriteLine("\t{0} seconds for a scrambled list", sortTime);
            sortTime = GetSortingTime(method, list);
            Console.WriteLine("\t{0} seconds for a sorted list\n", sortTime);
        }

        private double GetSortingTime(SortMethod method, int[] list)
        {
            int startTime, stopTime;
            startTime = Environment.TickCount;
            method(list);
            stopTime = Environment.TickCount;
            return (stopTime - startTime) / 1000.0;
        }

        Random rnd = new();

        private void FillRandom(int[] arr, int max)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(max + 1);
            }
        }

        private int FindMax(int[] arr, int last)
        {
            // find the index of the largest number in the array.
            int maxIndex = 0;
            for (int i = 1; i <= last; i++)
            {
                // if the number in location i is bigger than the largest #
                // we have seen before, remember i.
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static void Swap(int[] arr, int m, int n)
        {
            (arr[n], arr[m]) = (arr[m], arr[n]);
        }

        public void SelectionSort(int[] list)
        {
            int last = list.Length - 1;
            do
            {
                int biggest = FindMax(list, last);
                Swap(list, biggest, last);
                last--;
            } while (last > 0);

            return;
        }

        public void InsertionSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] < list[i - 1])
                {
                    int temp = list[i];
                    int j;
                    for (j = i; j > 0 && list[j - 1] > temp; j--)
                        list[j] = list[j - 1];
                    list[j] = temp;
                }
            }
        }

        public void BubbleSort(int[] list)
        {
            for (int i = list.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[j + 1])
                        Swap(list, j, j + 1);
                }
            }

        }

        public void QuickSort(int[] a)
        {
            QuickSortRecursive(a, 0, a.Length);
        }

        private void QuickSortRecursive(int[] a, int low, int high)
        {
            if (high - low <= 1) return;
            int pivot = a[high - 1];
            int split = low;
            for (int i = low; i < high - 1; i++)
                if (a[i] < pivot)
                    Swap(a, i, split++);
            Swap(a, high - 1, split);
            QuickSortRecursive(a, low, split);
            QuickSortRecursive(a, split + 1, high);
            return;
        }

        private int Partition(int[] arr, int x)
        {
            int lowMark = 0, highMark = arr.Length - 1;

            while (true)
            {
                // find the first item out of place from the start
                while (lowMark < arr.Length && arr[lowMark] <= x)
                    lowMark++;
                // first the first out of place from the end
                while (highMark >= 0 && arr[highMark] > x)
                    highMark--;
                if (lowMark > highMark)
                    return highMark;
                // swap those two items
                Swap(arr, lowMark, highMark);
            }
        }
    }
}
