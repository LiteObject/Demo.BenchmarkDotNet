using BenchmarkDotNet.Running;
using CodePerfTesting.Misc;
using Demo.BenchmarkDotNet.Collections;
using Demo.BenchmarkDotNet.HashFunctions;
using Demo.BenchmarkDotNet.Misc;
using System;

namespace Demo.BenchmarkDotNet
{
    /// <summary>
    /// https://benchmarkdotnet.org/articles/overview.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(Main)} has started.");
            // var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            // var summary = BenchmarkRunner.Run<NameParserBenchmarks>();            
            // var summary = BenchmarkRunner.Run<DateParserBenchmarks>();
            // var summary = BenchmarkRunner.Run<StringManipulationBenchmarks>();

            // var summary = BenchmarkRunner.Run<Md5VsSha256>();

            // var summary = BenchmarkRunner.Run<ListVsHashSet>();

            var summary = BenchmarkRunner.Run<Sleeps>();

            Console.WriteLine(summary);

            Console.WriteLine($"{nameof(Main)} is ending.");
            Console.ReadKey();
        }
    }
}
