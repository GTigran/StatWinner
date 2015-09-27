using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StatWinner.CommonExtensions
{
    public static class StringEx
    {
        /// <summary>
        /// Is string null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Is string object null or empty.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool IsNullOrEmpty(this object o)
        {
            return string.IsNullOrEmpty(o.AsString());
        }

        /// <summary>
        /// Is string null or white space.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Is string object null or white space.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool IsNullOrWhiteSpace(this object o)
        {
            return string.IsNullOrWhiteSpace(o.AsString());
        }

        /// <summary>
        /// Get left substring.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Left(this string s, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Argument less then 0.", "Length");
            }

            if ((length == 0) || (s == null))
            {
                return "";
            }

            if (length >= s.Length)
            {
                return s;
            }
            return s.Substring(0, length);
        }

        /// <summary>
        /// Get right substring.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Right(this string s, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Argument less then 0.", "Length");
            }

            if ((length == 0) || (s == null))
            {
                return "";
            }

            int len = s.Length;
            if (length >= len)
            {
                return s;
            }
            return s.Substring(len - length, length);
        }

        /// <summary>
        /// Capitalizing all words in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string ToUpperFirstChars(this string s)
        {
            return s.ToUpperFirstChars(true);
        }

        /// <summary>
        /// Capitalizing all words in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lowercase">Convert to lowercase before capitalize.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string ToUpperFirstChars(this string s, bool lowercase)
        {
            if (lowercase)
            {
                s = s.ToLower();
            }

            char[] array = s.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        /// <summary>
        /// Truncate string to specified number of characters and add elipsis if necessary.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Truncate(this string s, int length)
        {
            if (length < 3 || s.Length <= length)
            {
                return s;
            }

            return string.Format("{0}...", s.Substring(0, length - 3));
        }
        /// <summary>
        /// Truncate string without putting dots after
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string TruncateWithoutDots(this string s, int length)
        {
            if (length < 3 || s.Length <= length)
            {
                return s;
            }

            return s.Substring(0, length);
        }

        /// <summary>
        /// Concatenate strings with comma.
        /// </summary>
        /// <param name="text">Main string.</param>
        /// <param name="item">String to add.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(ref string text, string item)
        {
            AddItemToString(ref text, item, ",", false);
        }

        /// <summary>
        /// Concatenate strings with specified delimiter.
        /// </summary>
        /// <param name="text">Main string.</param>
        /// <param name="item">String to add.</param>
        /// <param name="delim">Delimiter. By default comma.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(ref string text, string item, string delim)
        {
            AddItemToString(ref text, item, delim, false);
        }

        /// <summary>
        ///  Concatenate strings with specified delimiter.
        /// </summary>
        /// <param name="text">Main string.</param>
        /// <param name="item">String to add.</param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <param name="addIfNotEmpty">Concatenate if string to add is not null or empty. By default false.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(ref string text, string item, string delim, bool addIfNotEmpty)
        {
            if (addIfNotEmpty)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                text += delim;
            }

            text += item;
        }

        /// <summary>
        /// Add string to StringBulder with specified delimiter.
        /// </summary>
        /// <param name="sb">String Builder</param>
        /// <param name="item">String to add.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(StringBuilder sb, string item)
        {
            AddItemToString(sb, item, ",", false);
        }

        /// <summary>
        /// Add string to StringBulder with specified delimiter.
        /// </summary>
        /// <param name="sb">String Builder</param>
        /// <param name="item">String to add.</param>
        /// <param name="delim">Delimiter. By default comma.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(StringBuilder sb, string item, string delim)
        {
            AddItemToString(sb, item, delim, false);
        }

        /// <summary>
        /// Add string to StringBulder with specified delimiter.
        /// </summary>
        /// <param name="sb">String Builder</param>
        /// <param name="item">String to add.</param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <param name="addIfNotEmpty">Add if string to add is not null or empty. By default false.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        public static void AddItemToString(StringBuilder sb, string item, string delim, bool addIfNotEmpty)
        {
            if (addIfNotEmpty)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return;
                }
            }

            if (sb.Length != 0)
            {
                sb.Append(delim);
            }

            sb.Append(item);
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items)
        {
            return Merge(items, ",");
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items, string delim)
        {
            return Merge(items, delim, false);
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string. Add quotes for each array item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="quotes">Add quoates? By default false.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items, bool quotes)
        {
            return Merge(items, ",", quotes);
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string. Add quotes for each array item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <param name="quotes">Add quoates? By default false.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items, string delim, bool quotes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                string item = items[i];
                if (quotes)
                {
                    item = string.Format("'{0}'", item);
                }
                AddItemToString(sb, item, delim);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items, char delim)
        {
            return Merge(items, delim, false);
        }

        /// <summary>
        /// Merge string array with specified delimiter into a string. Add quotes for each array item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <param name="quotes">Add quoates? By default false.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this string[] items, char delim, bool quotes)
        {
            return Merge(items, delim.ToString(), quotes);
        }

        /// <summary>
        /// Merge integer array with specified delimiter into a string.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this int[] items)
        {
            return Merge(items, ",");
        }

        /// <summary>
        /// Merge integer array with specified delimiter into a string.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this int[] items, string delim)
        {
            return Merge(items, delim, false);
        }

        /// <summary>
        /// Merge integer array with specified delimiter into a string. Add quotes for each array item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="quotes">Add quoates? By default false.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this int[] items, bool quotes)
        {
            return Merge(items, ",", quotes);
        }

        /// <summary>
        /// Merge integer array with specified delimiter into a string. Add quotes for each array item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="delim">Delimiter. By default comma.</param>
        /// <param name="quotes">Add quoates? By default false.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string Merge(this int[] items, string delim, bool quotes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                string item = items[i].AsString();
                if (quotes)
                {
                    item = string.Format("'{0}'", item);
                }
                AddItemToString(sb, item, delim);
            }

            return sb.ToString();
        }

        /// <summary>
        /// If the 
        /// </summary>
        /// <param name="removePart"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string RemoveFromTheStart(this string str, string removePart)
        {
            if (str.StartsWith(removePart))
            {
                return str.Substring(removePart.Length);
            }
            return str;
        }

        /// <summary>
        /// Formats string for using as html text 
        /// </summary>
        /// <param name="removePart"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string AsHtml(this string str)
        {
            return str.AsString().Replace("  ", "&nbsp;&nbsp;").Replace("\n", "<BR />");
        }

        /// <summary>
        /// Checks whether string equals to any of given strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="stringsToCheck"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool In(this string str, params string[] stringsToCheck)
        {
            if (stringsToCheck == null)
            {
                return false;
            }

            foreach (var stringToCheck in stringsToCheck)
            {
                if (stringToCheck == str)
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// This function escapes ' char, preventing sql injection
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string AsSafeSqlString(this string str)
        {
            return str.AsString().Replace("'", "''");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string TrimHmtlSpaces(this string str)
        {
            Regex regex = new Regex(@"^(&nbsp;|\s)*|(&nbsp;|\s)*$");
            string result = regex.Replace(str, String.Empty);
            return result;
        }

    }
}
