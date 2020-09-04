using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class Stream
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Branch Branch { get; set; }

        public static List<Stream> getStreams(DataTable dtStreams)
        {
            try
            {
                List<Stream> lstStreams = new List<Stream>();

                foreach (DataRow drStreams in dtStreams.Rows)
                {
                    lstStreams.Add(getStream(drStreams));
                }

                return lstStreams;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        enum ColumnName
        {
            STRM_ID,
            STRM_NAME,
            STRM_BRANCH_ID,
            STRM_CRTD_AT,
            STRM_UPDT_AT,
            STRM_DLTD_AT,
            STRM_CRTD_BY,
            STRM_UPDAT_BY,
            STRM_DLTD_BY,
            ID

        }

        public static Stream getStream(DataRow drStream)
        {
            try
            {
                Stream objStream = new Stream();
                //if (drStream.Table.Columns.Contains("STRM_ID") && drStream["STRM_ID"] != DBNull.Value)
                //{
                //    objStream.Streamid = Convert.ToInt32(drStream["STRM_ID"]);
                //}
                objStream.ID = EntityManager.getValue<Int32>(drStream, ColumnName.STRM_ID.ToString());
                //if (drStream.Table.Columns.Contains("STRM_NAME") && drStream["STRM_NAME"] != DBNull.Value)
                //{
                //    objStream.StreamName = drStream["STRM_NAME"].ToString();
                //}
                objStream.Name = EntityManager.getValue<string>(drStream, ColumnName.STRM_NAME.ToString());


                return objStream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }

    
}



