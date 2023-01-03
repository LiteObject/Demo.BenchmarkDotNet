using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Demo.BenchmarkDotNet.Library
{
    public static class StringExtensions
    {
        private static IEnumerable<string> GraphemeClusters(this string s)
        {
            TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(s);

            while (enumerator.MoveNext())
            {
                yield return (string)enumerator.Current;
            }
        }

        // reverses the string "Les Mise\u0301rables" to "selbare\u0301siM seL"
        private static string ReverseGraphemeClusters(this string s)
        {
            return string.Join("", s.GraphemeClusters().Reverse().ToArray());
        }

        public static int IndexOf(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            int index;
            int length = value.Length;
            int maxSearchLength = (sb.Length - length) + 1;

            if (ignoreCase)
            {
                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (Char.ToLower(sb[i]) == Char.ToLower(value[0]))
                    {
                        index = 1;
                        while ((index < length) && (Char.ToLower(sb[i + index]) == Char.ToLower(value[index])))
                            ++index;

                        if (index == length)
                            return i;
                    }
                }

                return -1;
            }

            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (sb[i] == value[0])
                {
                    index = 1;
                    while ((index < length) && (sb[i + index] == value[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }

            return -1;
        }

        public static int IndexOf(this StringBuilder sb, char c)
        {
            int pos = 0;
            foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
            {
                ReadOnlySpan<char> span = chunk.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] == c)
                    {
                        return pos + i;
                    }
                }

                pos += span.Length;
            }

            return -1;
        }
    }
}
