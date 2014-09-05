using System;
using System.Collections.Generic;

namespace dame.Utilities.Extensions
{
    public static class DictionaryExtensions
    {
        public static TVal GetElse<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key, TVal defaultValue = default(TVal))
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }
    }
}

