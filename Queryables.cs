using System.Linq;
using System;
using System.Linq.Expressions;

namespace MO2Helpers
{
    public static class Queryables
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate only if the condition is meet.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="condition">Control whether applying the predicate or not.</param>
        /// <returns>
        /// An IQueryable<out T> that contains elements from the input sequence that satisfy the condtion specified by predicate.
        /// </returns>
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> queryable,
            Expression<Func<TSource, bool>> predicate,
            bool condition) =>
            condition ? queryable.Where(predicate) : queryable;
    }

}
