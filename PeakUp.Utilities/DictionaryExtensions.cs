using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakUp.Utilities
{
    public static class DictionaryExtensions
    {
        public static TValue TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key) => self.ContainsKey(key) ? self[key] : default(TValue);

        /// <summary>
        /// Converts Dictionary<string, string> to query string.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string ToQueryString(this Dictionary<string, string> dictionary)
        {
            if (dictionary.Count == 0) return string.Empty;

            var buffer = new StringBuilder();
            int count = 0;
            bool end = false;

            foreach (var key in dictionary.Keys)
            {
                if (count == dictionary.Count - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}={1}", key, dictionary[key]);
                else
                    buffer.AppendFormat("{0}={1}&", key, dictionary[key]);

                count++;
            }

            return buffer.ToString();
        }
    }
}
