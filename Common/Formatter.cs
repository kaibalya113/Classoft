using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassManager.Common
{
    public class Formatter
    {
        public const string  PercentageFormat = "P2";
        public const string CurrencyFormat = "C";
        public const string Culture = "en-IN";
        public const string DateFormat = "dd-MMM-yy";
        public const string TimeFormat = "hh:mm";
        public const string DateTimeFormat = "dd-MMM-yy hh:mm tt";
        public static CultureInfo objCultureInfo;
        public static CultureInfo provider = CultureInfo.InvariantCulture;



        static Formatter()
        {
            objCultureInfo = new CultureInfo(Culture);
        }

        public static DateTime? parseExactDate(string date,string format)
        {
            try
            {
                return DateTime.Parse(date);//added by ashvini beacause date parseExact function not properly worked on 15-03-2019
                //return DateTime.ParseExact(date, format, provider);
            }
            catch (Exception ex)
            {
                Common.Log.LogError("Error parsing date " + date + " in format " + format + ".", ErrorLevel.ERROR);
                return null ;
            }
        }


        public static string FormatDate(DateTime date)
        {
            return date.ToString(DateFormat);
        }


        public static string FormatDateTime(DateTime date)
        {
            return date.ToString(DateTimeFormat);
        }

        public static string FormatCurrency(decimal amount)
        {
            //return String.Format(objCultureInfo, CurrencyFormat, amount);
            return string.Format(objCultureInfo, "{0 :C}", amount);    
        }

        public static string FormatPercentage(float percentage)
        {
            return String.Format(objCultureInfo, PercentageFormat, percentage);
        }

        public static string FormatPercentage(decimal percentage)
        {
            return String.Format(objCultureInfo, PercentageFormat, percentage);
        }

        public static string formatTime(string time)
        {
            time = time.Trim();
            if (!time.Contains(" "))
            {
                time = time.Replace("AM", " AM").Replace("am", " AM").Replace("PM", " PM").Replace("pm", " PM");
            }

            return time;

        }
    }   
}
