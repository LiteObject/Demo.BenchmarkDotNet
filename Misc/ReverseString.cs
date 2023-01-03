using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

namespace Demo.BenchmarkDotNet.Misc
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ReverseString
    {
        /*****************************************************************
         *  Do not allocate extra space for another array. You must do this 
         *  by modifying the input array in-place with O(1) extra memory.
         * 
         * Constraints:
         * 1 <= s.length <= 105
         * s[i] is a printable ascii character.
         * 
         * Example Input Array:
         * string[] array = new[] {"H","a","n","n","a","h"};
         *****************************************************************/
        private readonly char[] testArr;

        public ReverseString()
        {
            testArr = new[] { 'o', 'l', 'l', 'e', 'h' };
        }

        public ReverseString(char[] charArr)
        {
            testArr = charArr;
        }

        [Benchmark]
        public string ReverseStringArray1()
        {
            char[] arr = GetACopy();
            int n = arr.Length;

            for (int i = 0; i < n / 2; i++)
            {
                int j = n - 1 - i;
                swap(ref arr, i, j);
            }

            static void swap(ref char[] ca, int i, int j)
            {
                (ca[j], ca[i]) = (ca[i], ca[j]);
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray11()
        {
            char[] arr = GetACopy();
            int n = arr.Length;
            int loopCount = n / 2;

            for (int i = 0; i < loopCount; i++)
            {
                int j = n - 1 - i;
                swap(ref arr, i, j);
            }

            static void swap(ref char[] ca, int i, int j)
            {
                (ca[j], ca[i]) = (ca[i], ca[j]);
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray2()
        {
            char[] arr = GetACopy();
            int n = arr.Length;

            for (int i = 0; i < n / 2; i++)
            {
                int j = n - 1 - i;

                (arr[j], arr[i]) = (arr[i], arr[j]);
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray22()
        {
            char[] arr = GetACopy();
            int n = arr.Length;
            int loopCount = n / 2;

            for (int i = 0; i < loopCount; i++)
            {
                int j = n - 1 - i;

                (arr[j], arr[i]) = (arr[i], arr[j]);
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray222()
        {
            char[] arr = GetACopy();
            int n = arr.Length;
            int loopCount = n / 2;

            for (int i = 0; i < loopCount; i++)
            {
                int j = n - 1 - i;

                (arr[j], arr[i]) = (arr[i], arr[j]);
            }

            return new string((ReadOnlySpan<char>)arr);
        }

        [Benchmark]
        public string ReverseStringWithTwoPointerTechnique()
        {
            char[] arr = GetACopy();
            _ = arr.Length;
            int i = 0, j = arr.Length - 1;

            while (i < j)
            {
                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;

                i++;
                j--;
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringWithArrayReverse()
        {
            char[] arr = GetACopy();
            Array.Reverse(arr);
            return new string(arr);
        }

        private char[] GetACopy()
        {
            char[] tempArray = (char[])Array.CreateInstance(typeof(char), testArr.Length);
            Array.Copy(testArr, tempArray, testArr.Length);
            return tempArray;
        }
    }
}
