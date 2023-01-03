namespace CodePerfTesting
{
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
        private static readonly NameParser Parser = new();

        /// <summary>
        /// The get last name.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            _ = Parser.GetLastName(FullName);
        }
    }
}
