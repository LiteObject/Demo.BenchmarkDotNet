namespace CodePerfTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    /// <summary>
    /// The name parser benchmarks.
    /// </summary>
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        /// <summary>
        /// The full name.
        /// </summary>
        private const string FullName = "Mohammed Hoque";

        /// <summary>
        /// The parser.
        /// </summary>
        private static readonly NameParser Parser = new NameParser();

        /// <summary>
        /// The get last name.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            Parser.GetLastName(FullName);
        }
    }
}
