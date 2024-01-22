using System.Collections.Generic;
using System.Data;
using static MO2Helpers.Enumerators;

namespace MO2Helpers
{
    /// <summary>
    /// Add support methods for DataTable.
    /// </summary>
    public static class Tables
    {
        /// <summary>
        /// Create a List<typeparamref name="T"/> from a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">DataTable to be converted.</param>
        /// <returns>A List<typeparamref name="T"/> constructed from a <paramref name="table"/>.</returns>
        public static List<T> ToList<T>(
            this DataTable table)
        {
            var data = new List<T>();
            foreach (DataRow row in table.Rows)
                data.Add(GetItem<T>(row));
            return data;
        }


        /// <summary>
        /// Create an Array<typeparamref name="T"/> from a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">DataTable to be converted.</param>
        /// <returns> An Array<typeparamref name="T"/> constructed from a <paramref name="table"/>.</returns>
        public static T[] ToArray<T>(
            this DataTable table)
        {
            var data = new List<T>();
            foreach (DataRow row in table.Rows)
                data.Add(GetItem<T>(row));
            return data.ToArray();
        }
    }
}
