namespace Demo.BenchmarkDotNet.StringManipulation
{
    using System.Collections.Generic;
    using global::BenchmarkDotNet.Attributes;
    using global::BenchmarkDotNet.Order;

    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class HashSetToStringBenchmarks
    {
        private readonly HashSet<char> hashSet;

        private readonly HashSetToString HashSetToString;

        public HashSetToStringBenchmarks()
        {
            char[] array = new[] { 'a', 'a', 'b', 'c', 'c' };
            hashSet = new HashSet<char>(array);
            HashSetToString = new HashSetToString();
        }

        [Benchmark]
        public void MethodUsingStringJoin()
        {
            _ = HashSetToString.MethodUsingStringJoin(hashSet);
        }

        [Benchmark]
        public void MethodMethodUsingStringBuilder()
        {
            _ = HashSetToString.MethodUsingStringBuilder(hashSet);
        }
    }
}
