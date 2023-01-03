using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Demo.BenchmarkDotNet.Library;
namespace Demo.BenchmarkDotNet.SortingAlgorithms
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class SortingAlgorithmsBenchmarks
    {
        private readonly int[] list = new int[2000];
        private readonly SortingAlgorithms algos;

        public SortingAlgorithmsBenchmarks()
        {
            algos = new SortingAlgorithms();
        }

        [Benchmark]
        public void SelectionSort()
        {
            _ = Util.GetACopyOf<int>(list);
            algos.SelectionSort(list);
        }

        [Benchmark]
        public void InsertionSort()
        {
            _ = Util.GetACopyOf<int>(list);
            algos.InsertionSort(list);
        }

        [Benchmark]
        public void BubbleSort()
        {
            _ = Util.GetACopyOf<int>(list);
            algos.BubbleSort(list);
        }

        [Benchmark]
        public void QuickSort()
        {
            _ = Util.GetACopyOf<int>(list);
            algos.QuickSort(list);
        }
    }
}
