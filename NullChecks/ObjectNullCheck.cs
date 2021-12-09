using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [SimpleJob(targetCount: 50)]
    public class ObjectNullCheck
    {
        private User user;

        [Benchmark]
        public void Equal_Operator()
        {
            user = null;
            if (user == null)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Equals_Method()
        {
            user = null;
            if (Equals(user, null))
            {
                user = new User();
            }
        }

        [Benchmark]
        public void ReferenceEquals_Method()
        {
            user = null;
            if (ReferenceEquals(user, null))
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Is_Operator()
        {
            user = null;
            if (user is null)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Default_Operator()
        {
            user = null;
            if (user == default)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Coalesce_Operator()
        {
            user = null;
            user = user ?? new User();
        }

        [Benchmark]
        public void Ternary_Operator()
        {
            user = null;
            user = user == null ? new User() : user;
        }

        [Benchmark]
        public void Is_Operator_Braces()
        {
            user = null;
            if (user is not { })
            {
                user = new User();
            }
        }
    }

    public class User { }
}
