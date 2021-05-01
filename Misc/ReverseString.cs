using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Text;

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
        private char[] testArr;

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
            var arr = GetACopy();
            var n = arr.Length;

            for (var i = 0; i < n / 2; i++)
            {
                var j = n - 1 - i;
                swap(ref arr, i, j);
            }

            void swap(ref char[] ca, int i, int j)
            {
                char temp = ca[i];
                ca[i] = ca[j];
                ca[j] = temp;
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray11()
        {
            var arr = GetACopy();
            var n = arr.Length;
            var loopCount = n / 2;

            for (var i = 0; i < loopCount; i++)
            {
                var j = n - 1 - i;
                swap(ref arr, i, j);
            }

            void swap(ref char[] ca, int i, int j)
            {
                char temp = ca[i];
                ca[i] = ca[j];
                ca[j] = temp;
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray2()
        {
            var arr = GetACopy();
            var n = arr.Length;

            for (var i = 0; i < n / 2; i++)
            {
                var j = n - 1 - i;

                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray22()
        {
            var arr = GetACopy();
            var n = arr.Length;
            var loopCount = n / 2;

            for (var i = 0; i < loopCount; i++)
            {
                var j = n - 1 - i;

                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return new string(arr);
        }

        [Benchmark]
        public string ReverseStringArray222()
        {
            var arr = GetACopy();
            var n = arr.Length;
            var loopCount = n / 2;

            for (var i = 0; i < loopCount; i++)
            {
                var j = n - 1 - i;

                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return new string((ReadOnlySpan<char>)arr);
        }

        [Benchmark]
        public string ReverseStringWithTwoPointerTechnique()
        {
            var arr = GetACopy();
            var n = arr.Length;
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
            var arr = GetACopy();
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
