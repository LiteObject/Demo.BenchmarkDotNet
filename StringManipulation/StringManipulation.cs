﻿namespace CodePerfTesting.Misc
{
    using System.Text;

    /// <summary>
    /// The string manipulation.
    /// </summary>
    public class StringManipulation
    {
        /// <summary>
        /// The join with string builder.
        /// </summary>
        /// <param name="string1">
        /// The string 1.
        /// </param>
        /// <param name="string2">
        /// The string 2.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string JoinWithStringBuilder(string string1, string string2)
        {
            StringBuilder sb = new();
            _ = sb.Append(string1);
            _ = sb.Append(string2);

            return sb.ToString();
        }

        /// <summary>
        /// The join with string interpolation.
        /// </summary>
        /// <param name="string1">
        /// The string 1.
        /// </param>
        /// <param name="string2">
        /// The string 2.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string JoinWithStringInterpolation(string string1, string string2)
        {
            return $"{string1} {string2}";
        }
    }
}
