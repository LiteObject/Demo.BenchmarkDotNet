using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Demo.BenchmarkDotNet.Collections
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class CollectionPerf
    {
        /**********************************************************************************************************************************
         * If you have mission critical code, and the number of elements is KNOWN in advance, use an array
         * If you have mission critical code, and the number of elements is NOT KNOWN in advance, use a generic list
         * Avoid the classes in system.collections. They use boxing and are superseded by the generic classes in system.collections.generic
         **********************************************************************************************************************************/

        private const int N = 5000;
        private const int Lookup = 250;

        // IEnumerable -> ICollection -> IList
        private readonly IList _list;

        // IEnumerable -> ICollection -> IList
        private readonly ISet<int> _set;

        private readonly int[] _arr;

        // private readonly OrderedDictionary orderedDictionary = new OrderedDictionary();

        public CollectionPerf(IList list, ISet<int> set, int[] arr)
        {
            _list = list;
            _set = set;
            _arr = arr;

            for (int i = 0; i < N; i++)
            {
                _list.Add(i);
                _set.Add(i);
                _arr[i] = i;
            }
        }

        [Benchmark(Description = "List lookup using contains")]
        public bool ListLookup() => _list.Contains(Lookup);

        [Benchmark(Description = "Set lookup using contains")]
        public bool SetLookup() => _set.Contains(Lookup);

        [Benchmark(Description = "Array lookup using find")]
        public bool ArrFindLookup() => Array.Find(_arr, i => i == Lookup) > 0;

        [Benchmark(Description = "Array lookup using any")]
        public bool ArrAnyLookup() => _arr.Any(i => i == Lookup);
    }
}
