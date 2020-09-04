using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Reflection;

namespace ClassManager.Common
{
    public static class Extentions
    {
        //To get ColumnName by passing DataRow.Mohan(14-Aug-2017).
        public static string GetColumn(this DataRow Row, int Ordinal)
        {
            return Row.Table.Columns[Ordinal].ColumnName;
        }
        //Mohan(14-Aug-2017).


        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static T Clone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }


        public static DataTable ToDataTable<T>(this IList<T> items)
        {
            if (items == null)
            {
                return null;
            }
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            {
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(new DataColumn(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));


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
                        throw e;
                    }
                }
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
