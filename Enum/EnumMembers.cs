namespace Demo.BenchmarkDotNet.Enum
{
    using global::BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    [MemoryDiagnoser]
    [RankColumn]
    public class EnumMembers
    {
        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        [Benchmark]
        public IEnumerable<T> GetValues1<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        [Benchmark]
        public IReadOnlyList<T> GetValues2<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
