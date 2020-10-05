using System;
using System.Collections.Generic;

namespace No_Sense_Task
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ThisDoesntMakeAnySense<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<IEnumerable<T>, IEnumerable<T>> func)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            foreach (T item in source)
            {
                if (predicate(item)) { return default; }
            }

            return func(source);
        }

        public static bool IsNumbers(this IEnumerable<string> source)
        {
            foreach (string item in source)
            {
                if (!Int32.TryParse(item.Trim(), out _)) { return false; }
            }

            return true;
        }
    }
}
