using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Text;

namespace Demo.BenchmarkDotNet.StringManipulation
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class StringReverseBenchmarks
    {
        private const string Input = "abcdefgh";

        [Benchmark]
        public string Reverse1()
        {
            string result = string.Empty;

            for (int i = Input.Length - 1; i >= 0; i--)
            {
                result += Input[i];
            }

            return result;
        }

        [Benchmark]
        public string Reverse1WithStringBuilder()
        {
            StringBuilder result = new(); ;

            for (int i = Input.Length - 1; i >= 0; i--)
            {
                _ = result.Append(Input[i]);
            }

            return result.ToString();
        }

        [Benchmark]
        public string ReverseUsingArrayReverse()
        {
            char[] array = Input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        [Benchmark]
        public string Reverse2()
        {
            char[] result = new char[Input.Length];
            int i = Input.Length - 1;

            foreach (char c in Input)
            {
                result[i--] = c;
            }

            return new string(result);
        }
    }
}
