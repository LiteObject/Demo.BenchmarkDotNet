using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Demo.BenchmarkDotNet.Library;
using System;
using System.Collections.Generic;

namespace Demo.BenchmarkDotNet.Misc
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class PlayingWithArray
    {
        private int[] nums = new[] { 12, 13, 14, 15, 16, 17, 18, 19, 10, 9, 2, 11, 15, 7, 20, 30, 40, 5, 50, 65, 74, 88, 90 };
        private int target = 9;

        /*
         * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         * You can return the answer in any order.
         * 
         * CONSTRAINTS:
         * 2 <= nums.length <= 10^3
         * -10^9 <= nums[i] <= 10^9
         * -10^9 <= target <= 10^9
         * Only one valid answer exists.
         * There cannot be the same number more than once
         */
        [Benchmark]
        public int[] FindIndicesOfValuesMatchingTarget_1()
        {
            int[] arr = Util.GetACopyOf<int>(nums);
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                if (arr[i] >= target)
                {
                    continue;
                }

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] >= target)
                    {
                        continue;
                    }

                    if (arr[i] + arr[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return new[] { 0 };
        }

        [Benchmark]
        public int[] FindIndicesOfValuesMatchingTarget_2()
        {
            int[] arr = Util.GetACopyOf<int>(nums);
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return new[] { 0 };
        }

        [Benchmark]
        public int[] FindIndicesOfValuesMatchingTarget_3()
        {
            int[] arr = Util.GetACopyOf<int>(nums);
            Array.Sort(arr);

            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return new[] { 0 };
        }

        [Benchmark]
        public int[] FindIndicesOfValuesMatchingTarget_4()
        {
            int[] arr = Util.GetACopyOf<int>(nums);
            Array.Sort(arr);

            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                if (arr[i] >= target)
                {
                    continue;
                }

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] >= target)
                    {
                        continue;
                    }

                    if (arr[i] + arr[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return new[] { 0 };
        }

        [Benchmark]
        public int[] FindIndicesOfValuesMatchingTarget_Map()
        {
            int[] arr = Util.GetACopyOf<int>(nums);
            IDictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= target)
                {
                    continue;
                }

                int complement = target - arr[i];

                if (map.TryGetValue(complement, out int j))
                {
                    return new[] { i, j };
                }

                // If there's a cuplicate, it will throw exception.
                map.Add(arr[i], i);
            }

            return new[] { 0 };
        }

    }
}
