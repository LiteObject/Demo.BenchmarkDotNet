using BenchmarkDotNet.Running;
using Demo.BenchmarkDotNet.Serialization;
using System;
using System.Diagnostics;

namespace Demo.BenchmarkDotNet
{
    /// <summary>
    /// https://benchmarkdotnet.org/articles/overview.html
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Stopwatch watch = new();
            watch.Start();

            Console.WriteLine($"{nameof(Main)} has started.\n\n");
            // var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            // var summary = BenchmarkRunner.Run<NameParserBenchmarks>();            
            // var summary = BenchmarkRunner.Run<DateParserBenchmarks>();
            // var summary = BenchmarkRunner.Run<StringManipulationBenchmarks>();
            // var summary = BenchmarkRunner.Run<Md5VsSha256>();
            // var summary = BenchmarkRunner.Run<Sleeps>();
            // var summary = BenchmarkRunner.Run<ListVsHashSet>();
            // var summary = BenchmarkRunner.Run<CollectionPerf>();
            // var summary = BenchmarkRunner.Run<ClosestNumber>();
            // var summary = BenchmarkRunner.Run<ReverseString>();
            // var summary = BenchmarkRunner.Run<PlayingWithArray>();
            // var summary = BenchmarkRunner.Run<SortingAlgorithmsBenchmarks>();
            // var summary = BenchmarkRunner.Run<ReverseInteger>();

            // var summary = BenchmarkRunner.Run<StringReverseBenchmarks>();
            // var summary = BenchmarkRunner.Run<HashSetToStringBenchmarks>();    


            global::BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<SerializationTest>();
            Console.WriteLine(summary);

            /* var inputString = "IInputSString";
            var dup = new RemoveDuplicateCharsFromString();
            Console.WriteLine($"RemoveUsingHashSet: {dup.RemoveUsingHashSet(inputString)}");
            Console.WriteLine($"RemoveUsingLinqDistinct: {dup.RemoveUsingLinqDistinct(inputString)}");
            Console.WriteLine($"RemoveUsingLoops: {dup.RemoveUsingLoops(inputString)}");
            Console.WriteLine($"RemoveUsingLinqGroupBy: {dup.RemoveUsingLinqGroupBy(inputString)}"); */

            watch.Stop();
            Console.WriteLine($"\n\n{nameof(Main)} is ending. Elapsed: {watch.Elapsed}");
        }
    }
}
