using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private const int LOOKUP = 250;

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
                _list.Add(i);
                _set.Add(i);
                _arr[i] = i;
            }
        }

        [Benchmark]
        public bool ListLookup() => _list.Contains(LOOKUP);

        [Benchmark]
        public bool SetLookup() => _set.Contains(LOOKUP);

        [Benchmark]
        public bool ArrFindLookup() => Array.Find(_arr, i => i == LOOKUP) > 0;

        [Benchmark]
        public bool ArrAnyLookup() => _arr.Any(i => i == LOOKUP);
    }
}
