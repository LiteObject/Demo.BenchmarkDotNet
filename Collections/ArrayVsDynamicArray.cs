namespace Demo.BenchmarkDotNet.Collections
{
    using global::BenchmarkDotNet.Attributes;
    using global::BenchmarkDotNet.Order;

    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public  class ArrayVsDynamicArray
    {
        private const int N = 1000;
        private const int Lookup = 250;

        [Benchmark]
        public void AddToArray() {

            var a = new int[N];

            for (var i = 0; i < N; i++) 
            { 
                a[i] = i;
            }
        }

        [Benchmark]
        public void AddToDynamicArray()
        {
            int[] a = System.Array.Empty<int>();

            for (var i = 0; i < N; i++)
            {
                a[i] = i;
            }
        }
    }
}
