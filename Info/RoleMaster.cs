using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    public class RoleMaster
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public static List<RoleMaster> getRole(DataTable roles)
        {
            List<RoleMaster> roleMsters = new List<RoleMaster>();
            foreach (DataRow role in roles.Rows)
            {
                roleMsters.Add(getRole(role));
            }
            return roleMsters;
        }

        enum ColumnName
        {
            RM_ID,
            RM_NAME,
            RM_DEPT,
            RM_CRTD_AT,
            RM_UPDT_AT,
            RM_DLTD_AT,
            RM_CRTD_BY,
            RM_UPDAT_BY,
            RM_DLTD_BY,
            RM_BRANCH_ID,
            ID

        }

        private static RoleMaster getRole(DataRow role)
        {
            try
            {
                RoleMaster roleMaster = new RoleMaster();


                //if (role.Table.Columns.Contains("RM_ID") && role["RM_ID"] != DBNull.Value)
                //{
                //    roleMaster.Id = Convert.ToInt32(role["RM_ID"]);
                //}
                roleMaster.Id = EntityManager.getValue<Int32>(role, ColumnName.RM_ID.ToString());
                //if (role.Table.Columns.Contains("RM_NAME") && role["RM_NAME"] != DBNull.Value)
                //{
                //    roleMaster.RoleName = Convert.ToString(role["RM_NAME"]);
                //}
                roleMaster.RoleName = EntityManager.getValue<string>(role, ColumnName.RM_NAME.ToString());
                return roleMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override string ToString()
        {
            return RoleName;
        }
    }

}

