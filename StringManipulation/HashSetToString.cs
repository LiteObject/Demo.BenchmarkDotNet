using System.Collections.Generic;
using System.Text;

namespace Demo.BenchmarkDotNet.StringManipulation
{
    public class HashSetToString
    {
        public string MethodUsingStringJoin(HashSet<char> hashSet)
        {
            return string.Join("", hashSet);
        }

        public string MethodUsingStringBuilder(HashSet<char> hashSet)
        {
            StringBuilder sb = new();

            foreach (char c in hashSet)
            {
                _ = sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
