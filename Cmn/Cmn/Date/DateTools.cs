using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Date
{
    public class DateTools
    {
        private const string dateFormat = "yyyy/MM/dd";
        private const string fullYear = "1300";

        public static string Now
        {
            get
            {
                return FromDateTime(DateTime.Now);
            }
        }
        public static string NowDateTime
        {
            get
            {
                return FromDateTime(DateTime.Now, "yyyy/MM/dd HH:mm");
            }
        }

        public static string FromDateTime(DateTime date, string format = "yyyy/MM/dd")
        {
            return date.ToFaString(format);

        }

        public static DateTime ToDateTime(string date)
        {
            var parts = date.Split('/'); //ex. 1391/1/19
            if (parts.Length != 3)
                return new DateTime();
            int year, month, day;
            var index = getIndexes(dateFormat);

            if (int.TryParse(parts[index.Year], out year) && int.TryParse(parts[index.Month], out month) && int.TryParse(parts[index.Day], out day))
                return new DateTime(year, month, day, new System.Globalization.PersianCalendar());
            return new DateTime();
        }

        public static string Normalize(string date)
        {
            if (string.IsNullOrEmpty(date))
                return date;
            var parts = date.Split('/'); //ex. 1391/1/19
            if (parts.Length != 3)
                return "";
            var index = getIndexes(dateFormat);
            if (parts[index.Year].Length == 4 && parts[index.Month].Length == 2 && parts[index.Day].Length == 2)
                return date;

            if (parts[index.Year].Length > 4 || parts[index.Month].Length > 2 || parts[index.Day].Length > 2 || parts[index.Year].Length == 0 || parts[index.Month].Length == 0 || parts[index.Day].Length == 0)
                return "";

            string result = "{0}/{1}/{2}";
            string yearPart = fullYear.Substring(0, 4 - parts[index.Year].Length) + parts[index.Year];
            string monthPart = (parts[index.Month].Length == 1 ? "0" : "") + parts[index.Month];
            string dayPart = (parts[index.Day].Length == 1 ? "0" : "") + parts[index.Day];

            result = result.Replace("{" + index.Year + "}", yearPart);
            result = result.Replace("{" + index.Month + "}", monthPart);
            result = result.Replace("{" + index.Day + "}", dayPart);
            return result;
        }

        private static Index getIndexes(string date)
        {
            var formatParts = date.Split('/').ToList();
            var yearFormat = formatParts.First(x => x.ToLower().IndexOf('y') != -1);
            var monthFormat = formatParts.First(x => x.ToLower().IndexOf('m') != -1);
            var dayFormat = formatParts.First(x => x.ToLower().IndexOf('d') != -1);
            return new Index()
            {
                Year = formatParts.IndexOf(yearFormat),
                Month = formatParts.IndexOf(monthFormat),
                Day = formatParts.IndexOf(dayFormat)
            };
        }

        public static string MiladiToShamsi(DateTime miladiDateTime)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                string month = pc.GetMonth(miladiDateTime) > 9 ? pc.GetMonth(miladiDateTime) + "" : "0" + pc.GetMonth(miladiDateTime);
                string day = pc.GetDayOfMonth(miladiDateTime) > 9 ? pc.GetDayOfMonth(miladiDateTime) + "" : "0" + pc.GetDayOfMonth(miladiDateTime);
                return string.Format("{0}/{1}/{2}", pc.GetYear(miladiDateTime), month, day);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime ShamsiToMiladi(string shamsiDateTime)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                int year = int.Parse(shamsiDateTime.Substring(0, 4));
                int month = int.Parse(shamsiDateTime.Substring(5, 2));
                int day = int.Parse(shamsiDateTime.Substring(8, 2));
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DateTime SabteAhvalShamsiToMiladi(string shamsiDateTime)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                int year = int.Parse(shamsiDateTime.Substring(0, 4));
                int month = int.Parse(shamsiDateTime.Substring(4, 2));
                int day = int.Parse(shamsiDateTime.Substring(6, 2));
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ShamsiToSabteAhvalType(string shamsiDateTime)
        {
            try
            {
                return shamsiDateTime.Replace("/", string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string MiladiToSabteAhvalType(DateTime miladiDateTime)
        {
            try
            {
                string shamsiDateTime = MiladiToShamsi(miladiDateTime);
                return shamsiDateTime.Replace("/", string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime? GetFirstHourOfDay(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 0, 0, 0);
            else
                return null;
        }

        public static DateTime? GetLastHourOfDay(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 23, 59, 59);
            else
                return null;
        }

        /// <summary>
        /// تفاوت دو تاریخ میلادی
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static int TwoMiladiDateDiffrence(DateTime dt1, DateTime dt2)
        {
            try
            {
                if (dt1 > dt2) throw new Exception("تاریخ به درستی ثبت نشده است");
                else
                {
                    TimeSpan ts = dt2 - dt1;
                    return Convert.ToInt32(ts.TotalDays);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        class Index
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }
    }
}
