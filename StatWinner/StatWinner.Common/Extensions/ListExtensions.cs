using System;
using System.Collections.Generic;

namespace StatWinner.CommonExtensions
{
    /// <summary>
    /// Extension methods for lists
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Converts byte array to list of integers.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<int> ToIntList(this byte[] source)
        {
            var result = new List<int>();
            for (int i = 0; i < source.Length; i += 4)
                result.Add(BitConverter.ToInt32(source, i));
            return result;
        }

        /// <summary>
        /// Converts byte array to list of doubles.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<double> ToDoubleList(this byte[] source)
        {
            var result = new List<double>();
            for (int i = 0; i < source.Length; i += 8)
                result.Add(BitConverter.ToDouble(source, i));
            return result;
        }

        /// <summary>
        /// Converts List to comma delimited string
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string AsCommaDelimatedListString(this List<long> lst)
        {
            return string.Join(",", lst.ToArray());
        }
    }
}
