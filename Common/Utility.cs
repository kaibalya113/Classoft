using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

namespace ClassManager.Common
{
    public class Utility
    {
        static IDictionary<string, int> Month = new Dictionary<string, int>();
        static IDictionary<string, int> AcadMonth = new Dictionary<string, int>();


        private static string[] dayText = new string[]
        {
            "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth",
            "Nineth", "Tenth", "Eleventh", "Twelveth", "Thirteenth", "Fourteenth", "Fifteenth",
            "Sixteenth", "Seventeenth", "Eighteenth", "Nineteenth", "Twentieth", "Twenty first",
            "Twenty second", "Twenty third", "Twenty fourth", "Twenty fifth", "Twenty sixth",
            "Twenty seventh", "Twenty eighth", "Twenty nineth", "Thirtieth", "Thirty first"
        };

        public static string getMacAddress()
        {
            string macAddresses = "";



            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        public static string getHDDSerialNo()
        {
            throw new NotImplementedException();
        }


        public static string IntToRank(string No)
        {
            try
            {
                return dayText[Convert.ToInt32(No) - 1];
            }
            catch (Exception)
            {
                return No;
            }
        }



        public static string DateInWords(DateTime Date)
        {
            string strMonth = "";
            foreach (KeyValuePair<string, int> pair in Month)
            {
                if (pair.Value == Date.Month)
                    strMonth = pair.Key;
            }
            return dayText[Date.Day - 1] + " " + strMonth + " " + NumberToEnglish.changeNumericToWords(Date.Year.ToString().Substring(0, 2)) + " " + NumberToEnglish.changeNumericToWords(Date.Year.ToString().Substring(2, 2));
        }




        static Utility()
        {
            Month.Add("January", 1);
            Month.Add("February", 2);
            Month.Add("March", 3);
            Month.Add("April", 4);
            Month.Add("May", 5);
            Month.Add("June", 6);
            Month.Add("July", 7);
            Month.Add("August", 8);
            Month.Add("September", 9);
            Month.Add("October", 10);
            Month.Add("November", 11);
            Month.Add("December", 12);

            AcadMonth.Add("June", 1);
            AcadMonth.Add("July", 2);
            AcadMonth.Add("August", 3);
            AcadMonth.Add("September", 4);
            AcadMonth.Add("October", 5);
            AcadMonth.Add("November", 6);
            AcadMonth.Add("December", 7);
            AcadMonth.Add("January", 8);
            AcadMonth.Add("February", 9);
            AcadMonth.Add("March", 10);
            AcadMonth.Add("April", 11);
            AcadMonth.Add("May", 12);
        }

        public static int GetAge(DateTime Date)
        {
            if (DateTime.Now.DayOfYear > Date.DayOfYear)
                return DateTime.Now.Year - Date.Year + 1;
            else
                return DateTime.Now.Year - Date.Year;
        }

        public static char ToChar(object SrcValue) //For charactor conversion
        {
            if (SrcValue == DBNull.Value)
            {
                return Convert.ToChar(" ");
            }
            else if (SrcValue == null)
            {
                return Convert.ToChar(" ");
            }
            else
            {
                return Convert.ToChar(SrcValue);
            }
        }

        public static string ToString(object SrcValue) //For string conversion
        {
            if (SrcValue == DBNull.Value)
            {
                return string.Empty;
            }
            else if (SrcValue == null)
            {
                return string.Empty;
            }
            else
            {
                return SrcValue.ToString();
            }
        }

        public static int ToInt32(object SrcValue) //For Integer
        {
            try
            {
                if (SrcValue == DBNull.Value)
                {
                    return 0;
                }
                else if (SrcValue == null)
                {
                    return 0;
                }
                else if (Convert.ToString(SrcValue).Trim().Length == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(SrcValue);
                }
            }
            catch
            {
                return -1;
            }
        }

        public static double ToDouble(object SrcValue) //For Double
        {
            if (SrcValue == DBNull.Value)
            {
                return 0.00;
            }
            else if (SrcValue == null)
            {
                return 0.00;
            }
            else if (Convert.ToString(SrcValue).Trim().Length == 0)
            {
                return 0.00;
            }
            else
            {
                return Convert.ToDouble(SrcValue);
            }
        }


        public static float ToSingle(object SrcValue) //For Single
        {
            if (SrcValue == DBNull.Value)
            {
                return 0.00F;
            }
            else if (SrcValue.ToString() == "NA")
            {
                return -1;
            }
            else if (SrcValue == null)
            {
                return 0.00F;
            }
            else if (Convert.ToString(SrcValue).Trim().Length == 0)
            {
                return 0.00F;
            }
            else
            {
                return Convert.ToSingle(SrcValue);
            }
        }

        public static DateTime ToDateTime(object SrcValue) //For Datetime
        {
            if (SrcValue == DBNull.Value)
            {
                return Convert.ToDateTime(null);
            }
            else if (SrcValue == null)
            {
                return Convert.ToDateTime(null);
            }
            else if (Convert.ToString(SrcValue).Trim().Length == 0)
            {
                return Convert.ToDateTime(null);
            }
            else
            {
                return Convert.ToDateTime(SrcValue).Date;
            }
        }

        public static bool ToBoolean(object SrcValue) //For Boolean
        {
            if (SrcValue == DBNull.Value)
            {
                return false;
            }
            else if (SrcValue == null)
            {
                return false;
            }
            else if (Convert.ToString(SrcValue).Trim().Length == 0)
            {
                return false;
            }
            else if (SrcValue.ToString().Trim().Length == 0)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(SrcValue);
            }
        }

        public static ArrayList getYear()//not
        {
            ArrayList arr = new ArrayList();

            for (int i = 1945; i < DateTime.Now.Year - 10; i++)
            {
                arr.Add(i);

            }
            return arr;
        }

        public static ArrayList getYear(int startYr, int diffFormCurrentYr) //not
        {
            ArrayList arr = new ArrayList();

            for (int i = startYr; i < DateTime.Now.Year - diffFormCurrentYr; i++)
            {
                arr.Add(i);

            }
            return arr;
        }



        public static ArrayList getDays(int yr, int mn) //not
        {
            ArrayList arr = new ArrayList();
            for (int i = 1; i < DateTime.DaysInMonth(yr, mn) + 1; i++)
            {
                arr.Add(i);
            }
            return arr;
        }

        public static ArrayList getDays() //not
        {

            ArrayList arr = new ArrayList();
            for (int i = 1; i < 32; i++)
            {

                arr.Add(i);

            }
            return arr;
        }

        public static Int64 ToInt64(object SrcValue) //For Integer
        {
            try
            {
                if (SrcValue == DBNull.Value)
                {
                    return 0;
                }
                else if (SrcValue == null)
                {
                    return 0;
                }
                else if (Convert.ToString(SrcValue).Trim().Length == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(SrcValue);
                }
            }
            catch
            {
                return -1;
            }
        }

        public static bool ConvertGender(String Gender)
        {
            string a = Gender.ToUpper();
            if (String.Equals("MALE", a))
            {
                return true;
            }
            else if (String.Equals("FEMALE", a))
            {
                return false;
            }
            else if (String.Equals("", a))
            {
                return true;
            }
            else if (String.Equals("F", a))
            {
                return false;
            }
            else if (String.Equals("M", a))
            {
                return false;
            }
            else
            {
                return false;
            }

        }

        public static DateTime GetDateValue(string sVal)
        {
            DateTime dtRet;
            try
            {
                int nAdd = 1900;
                if (Convert.ToInt32(sVal.Substring(0, 2)) < 80)
                    nAdd = 2000;

                if (sVal.Length == 6)
                {
                    //YYMMDD 
                    dtRet = new DateTime(nAdd + Convert.ToInt32(sVal.Substring(0, 2)), Convert.ToInt32(sVal.Substring(2, 2)), Convert.ToInt32(sVal.Substring(4, 2)), 0, 0, 0);
                    return dtRet;
                }
                if (sVal.Length == 8)
                {
                    if (sVal.IndexOf("-") > 0)
                    {
                        //YY-MM-DD 
                        dtRet = new DateTime(nAdd + Convert.ToInt32(sVal.Substring(0, 2)), Convert.ToInt32(sVal.Substring(3, 2)), Convert.ToInt32(sVal.Substring(6, 2)), 0, 0, 0);
                        return dtRet;
                    }

                    //YYYYMMDD 
                    dtRet = new DateTime(Convert.ToInt32(sVal.Substring(0, 4)), Convert.ToInt32(sVal.Substring(4, 2)), Convert.ToInt32(sVal.Substring(6, 2)), 0, 0, 0);
                    return dtRet;
                }
                if (sVal.Length == 10)
                {
                    //YYYY-MM-DD 
                    dtRet = new DateTime(Convert.ToInt32(sVal.Substring(0, 4)), Convert.ToInt32(sVal.Substring(5, 2)), Convert.ToInt32(sVal.Substring(8, 2)), 0, 0, 0);
                    return dtRet;
                }
                return Convert.ToDateTime(sVal);
            }
            catch (Exception)
            {
            }
            dtRet = new DateTime(1900, 01, 01, 0, 0, 0);
            return dtRet;
        }

        public static string GetNextMonth(string CurrentMonth)
        {
            int MonthNo = Month[CurrentMonth];
            MonthNo = (MonthNo + 1 > 12) ? 1 : MonthNo + 1;

            return Month.ElementAt(MonthNo).Key;
        }

        public static int GetMonthlyFine(int Fine, string LastMonth, int FineDate)
        {
            if (DateTime.Now.Month == 5 && LastMonth == "May")
                return 12 * Fine;



            int Monthno = Month[LastMonth];

            if (AcadMonth[LastMonth] >= AcadMonth[DateTime.Now.ToString("MMMM")])
            {
                return 0;
            }

            //if (Monthno > DateTime.Now.Month && Monthno < 5)
            //    return 0;
            else
            {
                int year = (Monthno > DateTime.Now.Month) ? DateTime.Now.Year - 1 : DateTime.Now.Year;
                DateCalculator dc = new DateCalculator(new DateTime(year, Monthno, FineDate), DateTime.Now);
                dc.CalculateDateDifference();
                return dc.Months * Fine;
            }

        }

        public static string GetSection(string standard)
        {
            if (standard == "")
            {
                return standard;
            }
            else if (standard == "Jr.Kg" || standard == "Sr.Kg")
            {
                return "KG";
            }
            else if (standard == "Nursery")
            {
                return "Nursery";
            }
            else if (Convert.ToInt32(standard) >= 1 && Convert.ToInt32(standard) <= 7)
            {
                return "Primary";
            }
            else if (Convert.ToInt32(standard) >= 8 && Convert.ToInt32(standard) <= 10)
            {
                return "Secondary";
            }
            else if (Convert.ToInt32(standard) >= 11 && Convert.ToInt32(standard) <= 12)
            {
                return "Jr Clg";
            }
            return "";
        }

        public static string[] GetStandards(string Section)
        {
            if (Section == "KG")
            {
                return new string[] { "Jr.Kg", "Sr.Kg" };
            }
            else if (Section == "Nursery")
            {
                return new string[] { "Nursery" };
            }
            else if (Section == "Primary")
            {
                return new string[] { "1", "2", "3", "4", "5", "6", "7" };
            }
            else if (Section == "Secondary")
            {
                return new string[] { "8", "9", "10" };
            }
            else if (Section == "Jr Clg")
            {
                return new string[] { "11", "12" };
            }
            return new string[0];


        }

        public static int GetCurrentAcademicYear()
        {
            return (DateTime.Now.Month < 6) ? (DateTime.Now.Year - 1) : DateTime.Now.Year;
        }




        public static int getAcadMonthDiff(string FromMonth, string ToMonth)
        {
            return AcadMonth[ToMonth] - AcadMonth[FromMonth];
        }

        public static string[] GetNextStandardsInSection(string standard)
        {

            string[] standards = GetStandards(GetSection(standard));
            List<string> list = standards.ToList();
            int i = 0;
            while (list[i] != standard)
            {
                list.RemoveAt(0);
            }
            return list.ToArray();

        }

        public static object getCurrentQuarter()
        {
            if (DateTime.Now.Date.Month >= 4 && DateTime.Now.Date.Month <= 6)
                return 1;
            else if (DateTime.Now.Date.Month >= 7 && DateTime.Now.Date.Month <= 9)
                return 2;
            else if (DateTime.Now.Date.Month >= 10 && DateTime.Now.Date.Month <= 12)
                return 3;
            else
                return 4;
        }



        public static String currencyInWords(decimal numbers, Boolean paisaconversion = false)
        {
            var pointindex = numbers.ToString().IndexOf(".");
            var paisaamt = 0;
            if (pointindex > 0)
                paisaamt = Convert.ToInt32(numbers.ToString().Substring(pointindex + 1, 2));

            int number = Convert.ToInt32(numbers);

            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            if (paisaamt == 0 && paisaconversion == false)
            {
                sb.Append("rupees only");
            }
            else if (paisaamt > 0)
            {
                var paisatext = currencyInWords(paisaamt, true);
                sb.AppendFormat("rupees {0} paise only", paisatext);
            }
            return sb.ToString().TrimEnd();
        }


        //Converts the DataGridView to DataTable
        public static DataTable DataGridViewTODataTable(DataGridView dgv, String tblName, int minRow = 0)
        {

            DataTable dt = new DataTable(tblName);

            // Header columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }

            // Data cells
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            // Related to the bug arround min size when using ExcelLibrary for export
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = "  ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            {
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names                
                    dataTable.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));


                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    try
                    {
                        dataTable.Rows.Add(values);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("fdds");
                    }
                }
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Following function will be used when a function is to return a bool value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool retBoolStatus(bool value)
        {
            if (value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static List<KeyValuePair<string, string>> addkeyvaluePair(string key, string value, int count)
        //{
        //    try
        //    {
        //        KeyValuePair<string, string> item = new KeyValuePair<string, string>(key, value);
        //        List<KeyValuePair<string, string>> smsData;
        //        if (count == 0)
        //        {
        //            smsData = new List<KeyValuePair<string, string>>();
        //        }
        //        if (!smsData.Contains(item))
        //        {
        //            smsData.Add(item);
        //        }
        //        return smsData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

