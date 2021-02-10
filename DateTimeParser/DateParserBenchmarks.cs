namespace CodePerfTesting.DateTimeParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;

    /// <summary>
    /// The date parser benchmarks.
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmarks
    {
        /// <summary>
        /// The date-time string that will be used in benchmarking.
        /// </summary>
        private const string DateTime = "2020-11-20T15:48:00Z";

        /// <summary>
        /// The parser.
        /// </summary>
        private static readonly DateParser Parser = new DateParser();

        /// <summary>
        /// This is where we benchmark "GetYearFromDateTime" method.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void GetYearFromDateTime()
        {
            Parser.GetYearFromDateTime(DateTime);
        }

        /// <summary>
        /// The get year from split.
        /// </summary>
        [Benchmark]
        public void GetYearFromSplit()
        {
            Parser.GetYearFromSplit(DateTime);
        }

        /// <summary>
        /// The get year from substring.
        /// </summary>
        [Benchmark]
        public void GetYearFromSubstring()
        {
            Parser.GetYearFromSubstring(DateTime);
        }

        /// <summary>
        /// The get year from span.
        /// </summary>
        [Benchmark]
        public void GetYearFromSpan()
        {
            Parser.GetYearFromSubstring(DateTime);
        }

        /*// <summary>
        /// The get year from span with manual conversion.
        /// </summary>
        [Benchmark]
        public void GetYearFromSpanWithManualConversion()
        {
            Parser.GetYearFromSpanWithManualConversion(DateTime);
        }*/
    }
}
