using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BenchmarkDotNet.LINQ
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LinqPerf
    {
        List<string> stringList = new List<string>
        {
            "One", "Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten",
        };

        [Benchmark]
        public void SearchUsingAnyWithCurrentOrdinalIgnoreCase()
        {
            var result = false;

            if (stringList.Any(s => s.Equals("one", StringComparison.OrdinalIgnoreCase)))
            {
                result = true;
            }
        }

        [Benchmark]
        public void SearchUsingFirstOrDefaultWithCurrentOrdinalIgnoreCase()
        {
            var result = stringList.FirstOrDefault(s => s.Equals("one", StringComparison.OrdinalIgnoreCase));

            if (result != null)
            {
            }
        }

        [Benchmark]
        public void SearchUsingAnyWithCurrentCultureIgnoreCase()
        {
            var result = false;

            if (stringList.Any(s => s.Equals("one", StringComparison.CurrentCultureIgnoreCase)))
            {
                result = true;
            }
        }

        [Benchmark]
        public void SearchUsingAnyWithToLower() 
        {
            var result = false;

            if (stringList.Any(s => s.ToLower() == "one")) 
            { 
                result = true;
            }
        }

    }
}
