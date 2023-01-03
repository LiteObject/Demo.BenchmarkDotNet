using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.BenchmarkDotNet.Collections
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ListVsHashSet
    {
        private const int N = 1000;
        private const int Lookup = 250;

        private readonly IList _list;
        private readonly ISet<int> _set;
        private readonly int[] _arr;

        public ListVsHashSet()
        {
            _list = new List<int>();
            _set = new HashSet<int>();
            _arr = new int[N];

            for (int i = 0; i < N; i++)
            {
                _ = _list.Add(i);
                _ = _set.Add(i);
                _arr[i] = i;
            }
        }

        // Best
        [Benchmark(Description = "Set lookup using contains")]
        public bool SetLookup()
        {
            return _set.Contains(Lookup);
        }

        // #2
        [Benchmark(Description = "List lookup using contains")]
        public bool ListLookup()
        {
            return _list.Contains(Lookup);
        }

        // #3
        [Benchmark(Description = "Array lookup using find")]
        public bool ArrFindLookup()
        {
            return Array.Find(_arr, i => i == Lookup) > 0;
        }

        // Worst
        [Benchmark(Description = "Array lookup using any")]
        public bool ArrAnyLookup()
        {
            return _arr.Any(i => i == Lookup);
        }
    }
}
