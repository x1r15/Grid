using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Extensions
{
    public static class IEnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }
        
        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            return source.Where(predicate).Shuffle().Take(count);
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        public static IEnumerable<T> MinBy<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            var enumerable = source as T[] ?? source.ToArray();
            var minValue = enumerable.Min(selector);
            return enumerable.Where(c => selector(c) == minValue);
        }
        
        public static IEnumerable<T> MaxBy<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            var enumerable = source as T[] ?? source.ToArray();
            var maxValue = enumerable.Max(selector);
            return enumerable.Where(c => selector(c) == maxValue);
        }
    }
}
