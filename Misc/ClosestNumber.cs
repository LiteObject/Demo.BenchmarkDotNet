using System;
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
        private readonly int[] _numbers = new int[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 52, 54};
        private const int TargetNumber = 55;

        public ClosestNumber()
        {
        }

        [Benchmark(Description = "Find closest (to target) from a list of numbers")]
        public int FindClosestWithSorting() => _numbers.OrderBy(item => Math.Abs(TargetNumber - item)).First();

        [Benchmark(Description = "Find closest (to target) from a list of numbers without sorting")]
        public int FindClosestWithoutSorting() => _numbers.Aggregate((x, y) => Math.Abs(x - TargetNumber) < Math.Abs(y - TargetNumber) ? x : y);
    }
}
