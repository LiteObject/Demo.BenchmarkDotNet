using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

namespace Demo.BenchmarkDotNet.Misc
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class ReverseInteger
    {
        private int TestNumber = 123456789;

        public ReverseInteger(int number = default)
        {
            if (number != default)
            {
                this.TestNumber = number;
            }
        }

        // https://www.javatpoint.com/csharp-program-to-reverse-number
        [Benchmark]
        public int GetDigits2()
        {
            int reverse = 0;
            int remainder = 0;

            while (this.TestNumber > 0)
            {
                remainder = this.TestNumber % 10;
                reverse = (reverse * 10) + remainder;
                this.TestNumber /= 10;
            }

            return reverse;
        }

        public int Reverse()
        {
            long reverse = 0;

            while (this.TestNumber > 0)
            {
                Console.WriteLine($"TestNumber: {this.TestNumber}");

                int remainder = this.TestNumber % 10;
                this.TestNumber /= 10;
                reverse = (reverse * 10) + remainder;

                if (reverse > int.MaxValue || reverse < int.MinValue)
                {
                    reverse = 0;
                    break;
                }
            }

            if (reverse < 0)
            {
                // -Math.Abs(i)
                reverse *= -1;
            }

            return (int)reverse;
        }
    }
}
