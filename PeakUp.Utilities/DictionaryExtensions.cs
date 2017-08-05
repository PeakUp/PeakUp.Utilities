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
    }
}
