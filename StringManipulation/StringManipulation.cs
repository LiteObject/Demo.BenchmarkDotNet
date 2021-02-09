namespace CodePerfTesting.Misc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            var sb = new StringBuilder();
            sb.Append(string1);
            sb.Append(string2);

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
