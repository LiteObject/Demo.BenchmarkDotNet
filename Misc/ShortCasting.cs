using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Demo.BenchmarkDotNet.Misc
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ShortCasting
    {
        private const int LoopCount = 100;

        [Benchmark]
        public void CompareIntVsInt()
        {
            int x = 0;
            int y = 123;

            for (int i = 0; i <= LoopCount; i++)
            {
                x = i;
                if (x == y)
                {
                    continue;
                }
            }
        }

        [Benchmark]
        public void CompareShortVsShort()
        {
            short x = 123;
            short y = 123;

            for (int i = 0; i <= LoopCount; i++)
            {
                if (x == y)
                {
                    continue;
                }
            }
        }

        [Benchmark]
        public void CompareAfterCastingOneSide()
        {
            int x = 123;
            short y = 123;

            for (int i = 0; i <= LoopCount; i++)
            {
                x = i;
                if ((short)x == y)
                {
                    continue;
                }
            }
        }

        [Benchmark]
        public void CompareAfterCastingBothSide()
        {
            int x = 123;
            int y = 123;

            for (int i = 0; i <= LoopCount; i++)
            {
                x = i;
                if ((short)x == (short)y)
                {
                    continue;
                }
            }
        }
    }
}
