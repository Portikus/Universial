using System;

namespace Universial.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the <paramref name="toCheck"/> string is in the <paramref name="source"/> string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
