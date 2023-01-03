using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Demo.BenchmarkDotNet.NullChecks
{
    /// <summary>
    /// Original Article: https://medium.com/@martinstm/performance-wars-null-check-c-affdd096813e
    /// </summary>
    [RankColumn]
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    [SimpleJob()]
    public class StringNullCheck
    {
        private string str;
        private string message = "value is null";

        [Benchmark]
        public void Equal_Operator()
        {
            str = null;
            if (str == null)
            {
                str = message;
            }
        }

        [Benchmark(Description = "string.Equals()")]
        public void Equals_Method()
        {
            str = null;
            if (string.Equals(str, null))
            {
                str = message;
            }
        }

        [Benchmark(Description = "ReferenceEquals()")]
        public void ReferenceEquals_Method()
        {
            str = null;
            if (ReferenceEquals(null, str))
            {
                str = message;
            }
        }

        [Benchmark(Description = "str is null")]
        public void Is_Operator()
        {
            str = null;
            if (str is null)
            {
                str = message;
            }
        }

        [Benchmark(Description = "string.IsNullOrEmpty()")]
        public void NullOrEmpty_Method()
        {
            str = null;
            if (string.IsNullOrEmpty(str))
            {
                str = message;
            }
        }

        [Benchmark(Description = "str == default")]
        public void Default_Operator()
        {
            str = null;
            if (str == default)
            {
                str = message;
            }
        }

        [Benchmark(Description = "str ?? message")]
        public void Coalesce_Operator()
        {
            str = null;
            str = str ?? message;
        }

        [Benchmark(Description = "Ternary_Operator")]
        public void Ternary_Operator()
        {
            str = null;
            str = str == null ? message : str;
        }

        [Benchmark(Description = "str is not { }")]
        public void Is_Operator_Braces()
        {
            str = null;
            if (str is not { })
            {
                str = message;
            }
        }
    }
}
