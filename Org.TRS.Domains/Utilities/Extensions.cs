using System;
using System.Collections.Generic;

namespace Org.TRS.Domains.Utilities
{
    public static class Extensions
    {
        public static bool AllEqual(this string source, string target)
        {
            return source == target || (source != null && source.Equals(target, StringComparison.InvariantCultureIgnoreCase));
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
