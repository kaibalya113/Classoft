using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    class EntityManager
    {
        public static T getValue<T>(DataRow entityRow, String columnName)
        {
            if (entityRow.Table.Columns.Contains(columnName) && entityRow[columnName] != DBNull.Value)
            {
                if (typeof(T) == typeof(bool))
                {
                    bool boolValue;
                    if (bool.TryParse(entityRow[columnName].ToString(), out boolValue))
                    {
                        return (T)Convert.ChangeType(boolValue, typeof(T));
                    }
                    else
                    {
                        int intValue;
                        if (int.TryParse(entityRow[columnName].ToString(), out intValue))
                        {
                            return (T)Convert.ChangeType(intValue, typeof(T));
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
                else if (typeof(T) == typeof(PackageType))
                {
                    return (T)Convert.ChangeType((Info.PackageType)Enum.Parse(typeof(Info.PackageType), entityRow[columnName].ToString()), typeof(T));
                }
                else if (typeof(T) == typeof(Cheque.ChequeStatus))
                {
                    return (T)Convert.ChangeType((Info.Cheque.ChequeStatus)Enum.Parse(typeof(Info.Cheque.ChequeStatus), entityRow[columnName].ToString()), typeof(T));
                }
                else if(typeof(T) == typeof(DateTime?))
                {
                    return (T)Convert.ChangeType((DateTime?) DateTime.Parse(entityRow[columnName].ToString()),typeof(T));
                }
                else
                {
                    return (T)Convert.ChangeType(entityRow[columnName].ToString(), typeof(T));
                }
            }
            else
            {
                return default(T);
            }
        }

        public static void setValue<T>(DataRow entityRow, String columnName,out DateTime? dateTimeValue)
        {
            dateTimeValue = null;
            if (entityRow.Table.Columns.Contains(columnName) && entityRow[columnName] != DBNull.Value)
            {
                    dateTimeValue = (DateTime?)DateTime.Parse(entityRow[columnName].ToString());
            }
        }

        internal static T getTime<T>(DataRow entityRow, String columnName)
        {
            try
            {
                if (entityRow.Table.Columns.Contains(columnName) && entityRow[columnName] != DBNull.Value)
                {
                    return (T)Convert.ChangeType(DateTime.Now.Date + TimeSpan.Parse(entityRow[columnName].ToString()), typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        //public static T getDate<T>(DataRow entityRow, String columnName)
        //{
        //    try
        //    {
        //        DateTime date =
        //        if (entityRow.Table.Columns.Contains(columnName) && entityRow[columnName] != DBNull.Value)
        //        {
        //            return (T)Convert.ChangeType(date.ToShortDateString(), typeof(T));
        //        }
        //        else
        //        {
        //            return default(T);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
