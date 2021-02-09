namespace CodePerfTesting
{
    using System.Linq;

    /// <summary>
    /// The name parser.
    /// SOURCE: https://www.stevejgordon.co.uk/introduction-to-benchmarking-csharp-code-with-benchmark-dot-net
    /// </summary>
    public class NameParser
    {
        /// <summary>
        /// The get last name from a full name string.
        /// For the purposes of this demo, it assumes the last word, after any spaces represents the last name.
        /// </summary>
        /// <param name="fullName">
        /// The full name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetLastName(string fullName)
        {
            var names = fullName.Split(" ");
            var lastName = names.LastOrDefault();
            return lastName ?? string.Empty;
        }
    }
}
