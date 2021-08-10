using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Demo.BenchmarkDotNet.Misc
{
    /// <summary>
    /// Original Source: https://stackoverflow.com/questions/2594013/int-short-byte-performance-in-back-to-back-for-loops
    /// </summary>
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ShortVsInt
    {
        [Benchmark]
        public void TestShortLoop()
        {
            short x = 0;

            for (short s = 0; s < 255; s++)
            {
                ++x;
            }
        }

        [Benchmark]
        public void TestIntLoop()
        {
            int x = 0;

            for (int i = 0; i < 255; i++)
            {
                ++x;
            }
        }
    }
}
