using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Linq;

namespace MO2Helpers
{
    /// <summary>
    /// Add support methods for enumerators.
    /// </summary>
    public static class Enumerators
    {
        /// <summary>
        /// Determines whether a sequence contains a specified element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="sequence">Represents Collection<typeparamref name="TSource"/> of data.</param>
        /// <param name="value">The value to locate in the sequence</param>
        /// <returns>true if the value founded in a sequence; otherwise, false</returns>
        public static bool In<TSource>(
            this TSource value,
            IEnumerable<TSource> sequence) =>
            sequence.Contains(value);



        /// <summary>
        /// Filters a sequence of values based on a predicate only if the condition is meet.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="sequence">Represents Collection<typeparamref name="TSource"/> of data.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="condition">Control whether applying the predicate or not.</param>
        /// <returns>An IEnumerable<typeparamref name="TSource"/> that contains elements from the input <paramref name="sequence"/> that satisfy the condition specified by predicate.</returns>
        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> sequence,
            Func<TSource, bool> predicate,
            bool condition) =>
            condition ? sequence.Where(predicate) : sequence;



        /// <summary>
        /// Create a DataTable from an IEnumerable<typeparamref name="TSource"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="sequence">Represents Collection<typeparamref name="TSource"/> of data.</param>
        /// <returns>A DataTable constructed from a <paramref name="sequence"/>.</returns>
        public static DataTable ToDataTable<TSource>(
            this IEnumerable<TSource> sequence)
        {
            PropertyDescriptorCollection props = TypeDescriptor
                .GetProperties(typeof(TSource));
            var table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name,
                prop.PropertyType.Name.Contains(nameof(Nullable)) ?
                    typeof(string) : prop.PropertyType);
            }

            if (sequence.Any())
            {
                object[] values = new object[props.Count];
                foreach (TSource item in sequence)
                {
                    for (int i = 0; i < values.Length; i++)
                        values[i] = props[i].GetValue(item)!;
                    table.Rows.Add(values);
                }
            }
            return table;
        }


        /// <summary>
        /// Create a IEnumerable<typeparamref name="T"/> from a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">DataTable to be converted.</param>
        /// <returns>A IEnumerable<typeparamref name="T"/> constructed from a <paramref name="table"/>.</returns>
        public static IEnumerable<T> ToEnumerable<T>(
            this DataTable table)
        {
            foreach (DataRow row in table.Rows)
                yield return GetItem<T>(row);
        }

        internal static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj,
                            dr[column.ColumnName] == DBNull.Value ?
                            null : dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}

