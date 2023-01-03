using BenchmarkDotNet.Attributes;

namespace CodePerfTesting.Misc
{
    /// <summary>
    /// The string manipulation benchmarks.
    /// </summary>
    [MemoryDiagnoser]
    public class StringManipulationBenchmarks
    {
        /// <summary>
        /// The string 1.
        /// </summary>
        private const string String1 = "FirstName";

        /// <summary>
        /// The string 2.
        /// </summary>
        private const string String2 = "LastName";

        /// <summary>
        /// The string manipulation.
        /// </summary>
        private static readonly StringManipulation StringManipulation = new();

        /// <summary>
        /// The join with string builder.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void JoinWithStringBuilder()
        {
            _ = StringManipulation.JoinWithStringBuilder(String1, String2);
        }

        /// <summary>
        /// The join with string interpolation.
        /// </summary>
        [Benchmark]
        public void JoinWithStringInterpolation()
        {
            _ = StringManipulation.JoinWithStringInterpolation(String1, String2);
        }
    }
}
