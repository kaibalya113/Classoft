using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace ClassManager.Common
{
    public  static class FileHandller
    {
       // string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        public static DataTable readFromExcel(string fileName)
        {            
            
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);

            var adapter = new OleDbDataAdapter("SELECT * FROM [Unique Authors Fv1 03.07.15]", connectionString);
            var objDataTable = new DataTable();

            adapter.Fill(objDataTable);
            return objDataTable;
        }

        public static DataTable readFromCSV(string sfilePath, char seperator = ',')
        {
            try
            {
                DataTable dtFileData = new DataTable();
                List<string> csvRows = System.IO.File.ReadAllLines(sfilePath).ToList<string>();

                if (seperator == 't')
                {
                    seperator = '\t';
                }


                List<string> lstHdr = new List<string>();
                lstHdr = csvRows[0].Split(seperator).ToList();

                foreach (string header in lstHdr)
                {
                    
                    dtFileData.Columns.Add(header);

                }
                //if ((dtFileData. == "Null")
              //  {
               // }
               //// else
                //{
                   // dtFileData.Columns["BirthDate"].DataType = typeof(DateTime);
            
                //}
                //string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
                int columnCount = dtFileData.Columns.Count;

                csvRows = csvRows.Where(row => row != csvRows[0]).ToList<string>();

                StringBuilder sbAuthorRow = new StringBuilder();
   
                List<string> csvData = new List<string>();
                List<string> previousCSVData = new List<string>();

                foreach (string csvRow in csvRows)
                {
                    if (csvRow != "")
                    {
                        csvData = csvRow.Split(seperator).ToList();
                        DataRow row = dtFileData.NewRow();
                        row.ItemArray = csvData.ToArray();
                        dtFileData.Rows.Add(row);
                    }
                }

                return dtFileData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static T DeserializeFromXml<T>(string inputFile)
        {
            BinaryFormatter frmtr = new BinaryFormatter();
            T deserializedObject = default(T);
            try
            {
               
                using (FileStream strm = new FileStream(inputFile, FileMode.OpenOrCreate))
                {
                    if (strm == null)
                    {
                        deserializedObject = default(T);
                    }
                    else
                    {
                        deserializedObject = (T)frmtr.Deserialize(strm);
                    }
                    
                    strm.Close();
                }
            }
            catch (Exception ex)
            {
                deserializedObject = default(T);
            }

            return deserializedObject;
        }

        public static void SerializeToXml<T>(T objToSerialize, string outputFile)
        {            
            if (Directory.Exists(Path.GetDirectoryName(outputFile)) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
            }

            BinaryFormatter frmtr = new BinaryFormatter();

            using (FileStream strm = new FileStream(outputFile,FileMode.OpenOrCreate))
            {
                frmtr.Serialize(strm, objToSerialize);
                strm.Close();
            }
        }

        public static string ToString<T>(this IList<T> list, string include = "", string exclude = "")
        {
            //Variables for build string
            string propStr = string.Empty;
            StringBuilder sb = new StringBuilder();

            //Get property collection and set selected property list
            PropertyInfo[] props = typeof(T).GetProperties();
            List<PropertyInfo> propList = GetSelectedProperties(props, include, exclude);

            //Add list name and total count
            string typeName = GetSimpleTypeName(list);
            sb.AppendLine(string.Format("{0} List - Total Count: {1}", typeName, list.Count.ToString()));

            //Iterate through data list collection
            foreach (var item in list)
            {
                sb.AppendLine("");
                //Iterate through property collection
                foreach (var prop in propList)
                {
                    //Construct property name and value string
                    propStr = prop.Name + ": " + prop.GetValue(item, null);
                    sb.AppendLine(propStr);
                }
            }
            return sb.ToString();
        }

        public static void ToCSV<T>(this IList<T> list, string path = "", string include = "", string exclude = "")
        {
            CreateCsvFile(list, path, include, exclude);
        }

        public static void ToExcelNoInterop<T>(this IList<T> list, string path = "", string include = "", string exclude = "")
        {
            if (path == "")
                path = Path.GetTempPath() + @"ListDataOutput.csv";
            var rtnPath = CreateCsvFile(list, path, include, exclude);

            //Open Excel from the file
            Process proc = new Process();
            //Quotes wrapped path for any space in folder/file names
            proc.StartInfo = new ProcessStartInfo("excel.exe", "\"" + rtnPath + "\"");
            proc.Start();
        }

        private static string CreateCsvFile<T>(IList<T> list, string path, string include, string exclude)
        {
            //Variables for build CSV string
            StringBuilder sb = new StringBuilder();
            List<string> propNames;
            List<string> propValues;
            bool isNameDone = false;

            //Get property collection and set selected property list
            PropertyInfo[] props = typeof(T).GetProperties();
            List<PropertyInfo> propList = GetSelectedProperties(props, include, exclude);

            //Add list name and total count
            string typeName = GetSimpleTypeName(list);
            sb.AppendLine(string.Format("{0} List - Total Count: {1}", typeName, list.Count.ToString()));

            //Iterate through data list collection
            foreach (var item in list)
            {
                sb.AppendLine("");
                propNames = new List<string>();
                propValues = new List<string>();

                //Iterate through property collection
                foreach (var prop in propList)
                {
                    //Construct property name string if not done in sb
                    if (!isNameDone) propNames.Add(prop.Name);

                    //Construct property value string with double quotes for issue of any comma in string type data
                    var val = prop.PropertyType == typeof(string) ? "\"{0}\"" : "{0}";
                    propValues.Add(string.Format(val, prop.GetValue(item, null)));
                }
                //Add line for Names
                string line = string.Empty;
                if (!isNameDone)
                {
                    line = string.Join(",", propNames);
                    sb.AppendLine(line);
                    isNameDone = true;
                }
                //Add line for the values
                line = string.Join(",", propValues);
                sb.Append(line);
            }
            if (!string.IsNullOrEmpty(sb.ToString()) && path != "")
            {
                File.WriteAllText(path, sb.ToString());
            }
            return path;
        }

        private static List<PropertyInfo> GetSelectedProperties(PropertyInfo[] props, string include, string exclude)
        {
            List<PropertyInfo> propList = new List<PropertyInfo>();
            if (include != "") //Do include first
            {
                var includeProps = include.ToLower().Split(',').ToList();
                foreach (var item in props)
                {
                    var propName = includeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
                    if (!string.IsNullOrEmpty(propName))
                        propList.Add(item);
                }
            }
            else if (exclude != "") //Then do exclude
            {
                var excludeProps = exclude.ToLower().Split(',');
                foreach (var item in props)
                {
                    var propName = excludeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
                    if (string.IsNullOrEmpty(propName))
                        propList.Add(item);
                }
            }
            else //Default
            {
                propList.AddRange(props.ToList());
            }
            return propList;
        }

        private static string GetSimpleTypeName<T>(IList<T> list)
        {
            string typeName = list.GetType().ToString();
            int pos = typeName.IndexOf("[") + 1;
            typeName = typeName.Substring(pos, typeName.LastIndexOf("]") - pos);
            typeName = typeName.Substring(typeName.LastIndexOf(".") + 1);
            return typeName;
        }

        public static bool ExportArrayToCSV(String filePath, float[,] multiDimensionalArray)
        {
            var enumerator = multiDimensionalArray.Cast<float>()
                            .Select((s, i) => (i + 1) % 3 == 0 ? string.Concat(s, Environment.NewLine) : string.Concat(s, ","));

            var item = String.Join("", enumerator.ToArray<string>());
            File.AppendAllText(filePath, item);

            return true;
        }

        public static bool SaveArrayAsCSV<T>(T[,] TwoDarray, string fileName)
        {
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }
            
            using (StreamWriter file = new StreamWriter(fileName))
            {
                for (int i = 0; i < TwoDarray.GetLength(0); i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < TwoDarray.GetLength(1); j++)
                    {
                        if (i == 0)
                        {
                            sb.Append(j + ",");
                        }
                        else if (j == 0)
                        {
                            sb.Append(i + ",");
                        }
                        else
                        {
                            sb.Append(TwoDarray[i, j] + ",");
                        }
                    }
                    file.WriteLine(sb.ToString());
                    
                }
            }

            return true;
        }
    }
}
