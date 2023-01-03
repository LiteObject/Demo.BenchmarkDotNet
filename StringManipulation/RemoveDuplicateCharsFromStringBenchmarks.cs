namespace Demo.BenchmarkDotNet.StringManipulation
{
    using global::BenchmarkDotNet.Attributes;
    using global::BenchmarkDotNet.Order;

    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class RemoveDuplicateCharsFromStringBenchmarks
    {
        private const string InputString = "IInputSString";

        private readonly RemoveDuplicateCharsFromString RemoveDuplicateCharsFromString;

        public RemoveDuplicateCharsFromStringBenchmarks()
        {
            RemoveDuplicateCharsFromString = new RemoveDuplicateCharsFromString();
        }

        [Benchmark]
        public void RemoveUsingIndexOf()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingIndexOf(InputString);
        }

        [Benchmark]
        public void RemoveUsingIndexOfWithStringBuilder()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingIndexOfWithStringBuilder(InputString);
        }

        [Benchmark]
        public void RemoveUsingLoops()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingLoops(InputString);
        }

        [Benchmark]
        public void RemoveUsingLinqDistinct()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingLinqDistinct(InputString);
        }

        [Benchmark]
        public void RemoveUsingHashSet()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingHashSet(InputString);
        }

        [Benchmark]
        public void RemoveUsingLinqGroupBy()
        {
            _ = RemoveDuplicateCharsFromString.RemoveUsingLinqGroupBy(InputString);
        }
    }
}
