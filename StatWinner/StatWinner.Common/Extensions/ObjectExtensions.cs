using System;
using System.Diagnostics;

namespace StatWinner.CommonExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert to integer.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static int AsInteger(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0;
            }

            try
            {
                if (o is string)
                {
                    return int.Parse((string) o);
                }
                return System.Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to long.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static long AsLong(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0;
            }

            try
            {
                if (o is string)
                {
                    return Int64.Parse((string)o);
                }
                return System.Convert.ToInt64(o);
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// Convert to nullable integer.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static int? AsNullableInteger(this object o)
        {
            return o.AsNullableInteger(true);
        }

        /// <summary>
        /// Convert to nullable integer.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0 to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static int? AsNullableInteger(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                int value = 0;
                if (o is string)
                {
                    value = int.Parse((string) o);
                }
                else
                {
                    value = System.Convert.ToInt32(o);
                }

                if (zeroToNull && value == 0)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Convert to nullable long.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static long? AsNullableLong(this object o)
        {
            return o.AsNullableInteger(true);
        }

        /// <summary>
        /// Convert to nullable long.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0 to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static int? AsNullableLong(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                int value = 0;
                if (o is string)
                {
                    value = int.Parse((string)o);
                }
                else
                {
                    value = System.Convert.ToInt32(o);
                }

                if (zeroToNull && value == 0)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Convert to unsigned integer.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static uint AsUInteger(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0;
            }

            try
            {
                if (o is string)
                {
                    return uint.Parse((string) o);
                }
                return System.Convert.ToUInt32(o);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to nullable unsigned integer.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static uint? AsNullableUInteger(this object o)
        {
            return o.AsNullableUInteger(true);
        }

        /// <summary>
        /// Convert to nullable unsigned integer.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0 to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static uint? AsNullableUInteger(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                uint value = 0;
                if (o is string)
                {
                    value = uint.Parse((string) o);
                }
                else
                {
                    value = System.Convert.ToUInt32(o);
                }

                if (zeroToNull && value == 0)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to decimal.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static decimal AsDecimal(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0.0m;
            }

            try
            {
                if (o is string)
                {
                    return decimal.Parse((string) o);
                }
                return Convert.ToDecimal(o);
            }
            catch
            {
                return 0.0m;
            }
        }

        /// <summary>
        /// Convert to nullable decimal.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static decimal? AsNullableDecimal(this object o)
        {
            return o.AsNullableDecimal(true);
        }

        /// <summary>
        /// Convert to nullable decimal.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0.0m to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static decimal? AsNullableDecimal(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                decimal value = 0;
                if (o is string)
                {
                    value = decimal.Parse((string) o);
                }
                else
                {
                    value = System.Convert.ToDecimal(o);
                }

                if (zeroToNull && value == 0.0m)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to double.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static double AsDouble(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0;
            }

            try
            {
                if (o is string)
                {
                    return double.Parse((string) o);
                }
                return System.Convert.ToDouble(o);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to nullable double.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static double? AsNullableDouble(this object o)
        {
            return o.AsNullableDouble(true);
        }

        /// <summary>
        /// Convert to nullable double.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0 to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static double? AsNullableDouble(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value || o.ToString() == String.Empty)
            {
                return null;
            }

            try
            {
                double value = 0;
                if (o is string)
                {
                    value = double.Parse((string) o);
                }
                else
                {
                    value = System.Convert.ToDouble(o);
                }

                if (zeroToNull && value == 0)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to float.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static float AsFloat(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0;
            }

            try
            {
                if (o is string)
                {
                    return float.Parse((string) o);
                }
                return System.Convert.ToSingle(o);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to nullable float.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static float? AsNullableFloat(this object o)
        {
            return o.AsNullableFloat(true);
        }

        /// <summary>
        /// Convert to nullable float.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="zeroToNull">Convert 0 to null? By default true.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static float? AsNullableFloat(this object o, bool zeroToNull)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                float value = 0;
                if (o is string)
                {
                    value = float.Parse((string) o);
                }
                else
                {
                    value = System.Convert.ToSingle(o);
                }

                if (zeroToNull && value == 0)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to boolean.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool AsBoolean(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return false;
            }

            try
            {
                var s1 = o as string;
                if (s1 != null)
                {
                    var s = s1;
                    if (s.Length > 0)
                    {
                        if (Char.IsDigit(s, 0))
                        {
                            return 0 != int.Parse(s);
                        }
                        return bool.Parse(s);
                    }
                    return false;
                }
                switch (Convert.GetTypeCode(o))
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Single:
                    case TypeCode.Decimal:
                    case TypeCode.Byte:
                    case TypeCode.Double:
                        return 0 != Convert.ToDecimal(o);
                }
                return (bool) o;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert to nullable boolean.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static bool? AsNullableBoolean(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                if (o is string)
                {
                    string s = (string) o;
                    if (s.Length > 0)
                    {
                        if (Char.IsDigit(s, 0))
                        {
                            return 0 != int.Parse(s);
                        }
                        else
                        {
                            return false != bool.Parse(s);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                switch (System.Convert.GetTypeCode(o))
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Single:
                    case TypeCode.Decimal:
                    case TypeCode.Byte:
                    case TypeCode.Double:
                        return 0 != Convert.ToDecimal(o);
                }
                return (bool) o;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string AsString(this object o,string format=null)
        {
            if (o == null || o == DBNull.Value)
            {
                return string.Empty;
            }

            try
            {
                return o.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts object to bool and returns "true" or "false"
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string AsJSString(this object o)
        {
            if (o.AsBoolean())
            {
                return "true";
            }
            return "false";
        }

        /// <summary>
        /// Convert to nullable string.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static string AsNullableString(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                return o.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Convert to DateTime.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime AsDateTime(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return DateTime.MinValue;
            }

            try
            {
                return DateTime.Parse(o.AsString());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Convert to DateTime. and swites to specified time zone
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime AsUserLocaleDateTime(this object o, int offsetHours, int offsetMinutes)
        {
            if (o == null || o == DBNull.Value)
            {
                return DateTime.MinValue;
            }

            try
            {
                var dt = DateTime.Parse(o.AsString());

                dt = dt.AddHours(offsetHours);
                if (offsetHours < 0)
                {
                    offsetMinutes = -offsetMinutes;
                }
                dt = dt.AddMinutes(offsetMinutes);
                return dt;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }


        /// <summary>
        /// Convert to DateTime. And swites to Utc time zone from spcicied time zone
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime AsUtcDateTime(this object o, int offsetHours, int offsetMinutes)
        {
            if (o == null || o == DBNull.Value)
            {
                return DateTime.MinValue;
            }

            try
            {
                var dt = DateTime.Parse(o.AsString());

                dt = dt.AddHours(offsetHours);
                if (offsetHours > 0)
                {
                    offsetMinutes = -offsetMinutes;
                }
                dt = dt.AddMinutes(offsetMinutes);
                return dt;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Convert to nullable DateTime.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime? AsNullableDateTime(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return null;
            }

            try
            {
                var dt = DateTime.Parse(o.AsString());
                if (dt != DateTime.MinValue)
                {
                    return dt;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        /// <summary>
        /// Converts time string time span
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static TimeSpan? TimeToNullableTimespan(this object o)
        {
            string sTime = o.AsString();
            var arrSplittedTime = sTime.Split(new char[] {' '});
            if (arrSplittedTime.Length != 2)
            {
                return null;
            } 

            var amOrPm = arrSplittedTime[1].ToLower();
            if (amOrPm != "am" && amOrPm != "pm")
            {
                return null;
            }

            arrSplittedTime = arrSplittedTime[0].Split(new char[] {':'});
            if (arrSplittedTime.Length != 2)
            {
                return null;
            }

            var hours = arrSplittedTime[0].AsInteger();
            var minutes = arrSplittedTime[1].AsInteger();

            if (hours == 12 && amOrPm == "am")
                hours = 0;
            else
                hours = hours + (amOrPm == "pm" ? 12 : 0);

            return new TimeSpan(hours, minutes, 0); 
        }   

        /// <summary>
        /// Converts object into nullable timespan
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static TimeSpan? AsNullableTimeSpan(this object o)
        {
            if (o != null)
            {
                try
                {
                    return (TimeSpan) o;
                }
                catch (Exception)
                {
                }    
            }
            return null;
        }

        /// <summary>
        /// Converts object into nullable timespan
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static TimeSpan AsTimeSpan(this object o)
        {
            if (o != null)
            {
                try
                {
                    return (TimeSpan)o;
                }
                catch (Exception)
                {
                }
            }
            return TimeSpan.Zero;
        }

        [DebuggerStepThrough]
        public static object AsDbObject(this object o)
        {
            if (o == null || o.IsNullOrEmpty())
            {
                return DBNull.Value;
            }
            return o;
        }

        [DebuggerStepThrough]
        public static object AsObjectFromDbNull(this object o)
        {
            if (o == DBNull.Value)
            {
                return null;
            }
            return o;
        }

        [DebuggerStepThrough]
        public static object AsNullableObject(this object o)
        {
            if (o == DBNull.Value)
            {
                return null;
            }
            return o;
        }

        [DebuggerStepThrough]
        public static string AsSqlBoolean(this object o)
        {
            return o.AsBoolean() ? "1" : "0";
        }
    }
}
