namespace CodePerfTesting.DateTimeParser
{
    using System;

    /// <summary>
    /// The date parser.
    /// </summary>
    public class DateParser
    {
        /// <summary>
        /// The get year from date time.
        /// </summary>
        /// <param name="dateTimeString">
        /// The date time string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetYearFromDateTime(string dateTimeString)
        {
            DateTime dateTime = DateTime.Parse(dateTimeString);
            return dateTime.Year;
        }

        /// <summary>
        /// The get year from split.
        /// </summary>
        /// <param name="dateTimeString">
        /// The date time string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetYearFromSplit(string dateTimeString)
        {
            string[] splitOnHyphen = dateTimeString.Split('-');
            return int.Parse(splitOnHyphen[0]);
        }

        /// <summary>
        /// The get year from substring.
        /// </summary>
        /// <param name="dateTimeString">
        /// The date time string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetYearFromSubstring(string dateTimeString)
        {
            int indexOfHyphen = dateTimeString.IndexOf('-');
            return int.Parse(dateTimeString.Substring(0, indexOfHyphen));
        }

        /// <summary>
        /// The get year from span.
        /// </summary>
        /// <param name="dateTimeString">
        /// The date time string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetYearFromSpan(ReadOnlySpan<char> dateTimeString)
        {
            int indexOfHyphen = dateTimeString.IndexOf('-');
            return int.Parse(dateTimeString.Slice(0, indexOfHyphen));
        }

        /// <summary>
        /// The get year from span with manual conversion.
        /// </summary>
        /// <param name="dateTimeString">
        /// The date time string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /*public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateTimeString)
        {
            var indexOfHyphen = dateTimeString.IndexOf('-');
            var yearAsSpan = dateTimeString.Slice(0, indexOfHyphen);

            var temp = 0;

            for (var i = 0; i < yearAsSpan.Length; i++)
            {
                temp = (temp * 10) + (yearAsSpan[i] - '0');
            }

            return temp;
        }*/
    }
}
