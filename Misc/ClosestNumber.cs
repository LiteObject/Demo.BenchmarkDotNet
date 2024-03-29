﻿using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Demo.BenchmarkDotNet.Misc
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ClosestNumber
    {
        // IEnumerable -> ICollection -> IList
        private readonly int[] _numbers = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 52, 54 };
        private const int TargetNumber = 55;

        public ClosestNumber()
        {
        }

        [Benchmark(Description = "Find closest without sorting")]
        public int FindClosestWithoutSorting()
        {
            return _numbers.Aggregate((x, y) => Math.Abs(x - TargetNumber) < Math.Abs(y - TargetNumber) ? x : y);
        }

        [Benchmark(Description = "Find closest")]
        public int FindClosestWithSorting()
        {
            return _numbers.OrderBy(item => Math.Abs(TargetNumber - item)).First();
        }

        [Benchmark(Description = "Find closest without sorting, min")]
        public int FindClosestWithoutSortingUsingMin()
        {
            return _numbers.Min(i => (Math.Abs(TargetNumber - i), i)).i;
        }
    }
}
