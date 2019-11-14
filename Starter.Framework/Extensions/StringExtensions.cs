using System;

namespace Starter.Framework.Extensions
{
    /// <summary>
    /// Extension methods to the String type
    /// </summary>
    public static class StringExtensions
    {
        //public static IDbDataParameter Add(this string name, object value)
        //{
        //    var list = new List<Dictionary<string, object>> { new Dictionary<string, object> { { nameof(name), value } } };
        //}

        /// <summary>
        /// Compares two strings for equality, ignoring case
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string first, string second)
        {
            return string.Compare(first, second, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        /// <summary>
        /// Check if string is empty, null or white space
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string first)
        {
            return string.IsNullOrEmpty(first) || string.IsNullOrWhiteSpace(first);
        }
    }
}