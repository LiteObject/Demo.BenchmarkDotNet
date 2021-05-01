using BenchmarkDotNet.Running;
using CodePerfTesting.DateTimeParser;
using CodePerfTesting.Misc;
using Demo.BenchmarkDotNet.Collections;
using Demo.BenchmarkDotNet.HashFunctions;
using Demo.BenchmarkDotNet.Misc;
using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Demo.BenchmarkDotNet
{
    /// <summary>
    /// https://benchmarkdotnet.org/articles/overview.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
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

            var summary = BenchmarkRunner.Run<ReverseString>();
            Console.WriteLine(summary);

            watch.Stop();
            Console.WriteLine($"\n\n{nameof(Main)} is ending. Elapsed: {watch.Elapsed}");
            Console.ReadKey();
        }
    }
}
