using System.Collections.Generic;

namespace Universial.Core.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds the <paramref name="key"/> and the <paramref name="value"/> to the <paramref name="dictionary"/>.
        /// The <paramref name="key"/> will be created if it  does not exist in the <paramref name="dictionary"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return;
            }
            dictionary.Add(key, value);
        }

        /// <summary>
        /// Returns the mapped value to the passed <paramref name="key"/> of the <paramref name="dictionary"/>.
        /// Returns the default value of the <paramref name="key"/> if the <paramref name="key"/> does not exist in the <paramref name="dictionary"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(TValue);
        }
    }
}
