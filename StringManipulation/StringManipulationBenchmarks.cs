namespace CodePerfTesting.Misc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    /// <summary>
    /// The string manipulation benchmarks.
    /// </summary>
    [MemoryDiagnoser]
    public class StringManipulationBenchmarks
    {
        /// <summary>
        /// The string 1.
        /// </summary>
        private const string String1 = "Mohammed";

        /// <summary>
        /// The string 2.
        /// </summary>
        private const string String2 = "Hoque";

        /// <summary>
        /// The string manipulation.
        /// </summary>
        private static readonly StringManipulation StringManipulation = new StringManipulation();

        /// <summary>
        /// The join with string builder.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void JoinWithStringBuilder()
        {
            StringManipulation.JoinWithStringBuilder(String1, String2);
        }

        /// <summary>
        /// The join with string interpolation.
        /// </summary>
        [Benchmark]
        public void JoinWithStringInterpolation()
        {
            StringManipulation.JoinWithStringInterpolation(String1, String2);
        }
    }
}
