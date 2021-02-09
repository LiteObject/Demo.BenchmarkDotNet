namespace Demo.BenchmarkDotNet.HashFunctions
{
    using global::BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    /*******************************************************************************************************************
     * You can check several environments at once. For example, you can compare performance of Full .NET Framework, 
     * .NET Core, Mono and CoreRT. Just add the ClrJob, MonoJob, CoreJob, CoreRtJob attributes before the class 
     * declaration (it requires a .NETCore project, installed CoreCLR and Mono)
     * 
     * [ClrJob, MonoJob, CoreJob, CoreRtJob]
     * public class Md5VsSha256 {}
     * 
     * ***********************************************************************************
     * A diagnoser can attach to your benchmark and get some useful info. The current Diagnosers are:
     * - GC and Memory Allocation (MemoryDiagnoser) which is cross platform, built-in and is NOT ENABLED BY DEFAULT anymore.
     * - JIT Inlining Events (InliningDiagnoser). You can find this diagnoser in a separated package with diagnosers for Windows (BenchmarkDotNet.Diagnostics.Windows)
     *******************************************************************************************************************/
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    [MemoryDiagnoser]
    public class Md5VsSha256
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public Md5VsSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
}
