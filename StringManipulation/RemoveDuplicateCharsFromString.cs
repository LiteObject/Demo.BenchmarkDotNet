using Demo.BenchmarkDotNet.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BenchmarkDotNet.StringManipulation
{
    public class RemoveDuplicateCharsFromString
    {
        public string RemoveUsingHashSet(string input)
        {
            char[] charArr = input.ToCharArray();
            StringBuilder sb = new();
            HashSet<char> set = new(charArr.Length);

            for (int i = 0; i < charArr.Length; i++)
            {
                char c = charArr[i];
                if (set.Add(c))
                {
                    _ = sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public string RemoveUsingLoops(string input)
        {
            char[] charArr = input.ToCharArray();

            // Used as index in the modified string
            int index = 0;

            // Traverse through all characters
            for (int i = 0; i < charArr.Length; i++)
            {

                // Check if input[i] is present before it
                int j;

                for (j = 0; j < i; j++)
                {
                    if (input[i] == input[j])
                    {
                        break;
                    }
                }

                // If not present, then add it to result.
                if (j == i)
                {
                    charArr[index++] = input[i];
                }
            }

            char[] ans = new char[index];
            Array.Copy(charArr, ans, index);
            return String.Join("", ans);
        }

        public string RemoveUsingIndexOf(string input)
        {
            int len = input.Length;
            string str = "";

            // loop to traverse the string and
            // check for repeating chars using
            // IndexOf() method
            for (int i = 0; i < len; i++)
            {
                // character at i'th index of s
                char c = input[i];

                // if c is present in str, it returns
                // the index of c, else it returns -1
                if (str.IndexOf(c) < 0)
                {
                    // adding c to str if -1 is returned
                    str += c;
                }
            }

            return str;
        }

        /// <summary>
        /// Least mem alloc
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string RemoveUsingIndexOfWithStringBuilder(string input)
        {
            int len = input.Length;
            StringBuilder stringBuilder = new();

            for (int i = 0; i < len; i++)
            {
                char c = input[i];

                if (stringBuilder.IndexOf(c) < 0)
                {
                    _ = stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public string RemoveUsingLinqDistinct(string input)
        {
            string result = new(input.Distinct().ToArray());
            return result;
        }

        public string RemoveUsingLinqGroupBy(string input)
        {
            string result = new(input
                .ToCharArray()
                .GroupBy(c => c)
                .Select(group => group.First())
                .ToArray());
            return result;
        }
    }
}
