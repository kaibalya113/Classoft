using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    public class RolePrivilege
    {
       public int ID { get; set; }
       public int RoleId { get; set; }
       public int FunctionId { get; set; }
       public FunctionMaster FunctionName { get; set; }    
       public bool View { get; set; }
       public bool Modify { get; set; }
       public bool Delete { get; set; }
       public bool Create { get; set; }
       public bool AllBranches { get; set; }
       public int BranchId { get; set; }



       public static List<RolePrivilege> getPrivileges(DataTable dtUser)
        {

            try
            {
                List<RolePrivilege> lstPrivileges = new List<RolePrivilege>();

                foreach (DataRow dr in dtUser.Rows)
                {
                    lstPrivileges.Add(getPrivileges(dr));
                }

                return lstPrivileges;
            }
            catch (Exception)
            {                
                throw;
            }
           
        }

        enum ColumnName
        {
            RP_ID,
            RP_FM_ID,
            RP_RM_ID,
            RP_VIEW,
            RP_MODIFY,
            RP_DELETE,
            RP_CREATE,
            RP_ALL_BRANCHES,
            RP_BRANCH_ID,
            ROLP_CRTD_AT,
            ROLP_UPDT_AT,
            ROLP_DLTD_AT,
            ROLP_CRTD_BY,
            ROLP_UPDAT_BY,
            ROLP_DLTD_BY,
            ID

        }
        public static RolePrivilege getPrivileges(DataRow rolePrivileges)
        {
            RolePrivilege objPrivileges = new RolePrivilege();

            try
            {
                //if (rolePrivileges.Table.Columns.Contains("RP_ID") && rolePrivileges["RP_ID"] != DBNull.Value)
                //{
                //    objPrivileges.ID = Convert.ToInt32((rolePrivileges["RP_ID"]));
                //}
                objPrivileges.ID = EntityManager.getValue<Int32>(rolePrivileges, ColumnName.RP_ID.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_FM_ID") && rolePrivileges["RP_FM_ID"] != DBNull.Value)
                //{
                //    objPrivileges.FunctionId = Convert.ToInt32((rolePrivileges["RP_FM_ID"]));
                //}
                objPrivileges.FunctionId = EntityManager.getValue<Int32>(rolePrivileges, ColumnName.RP_FM_ID.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_RM_ID") && rolePrivileges["RP_RM_ID"] != DBNull.Value)
                //{
                //    objPrivileges.RoleId = Convert.ToInt32((rolePrivileges["RP_RM_ID"]));
                //}
                objPrivileges.RoleId = EntityManager.getValue<Int32>(rolePrivileges, ColumnName.RP_RM_ID.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_VIEW") && rolePrivileges["RP_VIEW"] != DBNull.Value)
                //{
                //    objPrivileges.View = Convert.ToBoolean(rolePrivileges["RP_VIEW"]);
                //}
                objPrivileges.View = EntityManager.getValue<bool>(rolePrivileges, ColumnName.RP_VIEW.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_MODIFY") && rolePrivileges["RP_MODIFY"] != DBNull.Value)
                //{
                //    objPrivileges.Modify = Convert.ToBoolean(rolePrivileges["RP_MODIFY"]);
                //}
                objPrivileges.Modify = EntityManager.getValue<bool>(rolePrivileges, ColumnName.RP_MODIFY.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_DELETE") && rolePrivileges["RP_DELETE"] != DBNull.Value)
                //{
                //    objPrivileges.Delete = Convert.ToBoolean(rolePrivileges["RP_DELETE"]);
                //}
                objPrivileges.Delete = EntityManager.getValue<bool>(rolePrivileges, ColumnName.RP_DELETE.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_CREATE") && rolePrivileges["RP_CREATE"] != DBNull.Value)
                //{
                //    objPrivileges.Create = Convert.ToBoolean(rolePrivileges["RP_CREATE"]);
                //}
                objPrivileges.Create = EntityManager.getValue<bool>(rolePrivileges, ColumnName.RP_CREATE.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_ALL_BRANCHES") && rolePrivileges["RP_ALL_BRANCHES"] != DBNull.Value)
                //{
                //    objPrivileges.AllBranches = Convert.ToBoolean(rolePrivileges["RP_ALL_BRANCHES"]);
                //}
                objPrivileges.AllBranches = EntityManager.getValue<bool>(rolePrivileges, ColumnName.RP_ALL_BRANCHES.ToString());
                //if (rolePrivileges.Table.Columns.Contains("RP_BRANCH_ID") && rolePrivileges["RP_BRANCH_ID"] != DBNull.Value)
                //{
                //    objPrivileges.BranchId = Convert.ToInt32(rolePrivileges["RP_BRANCH_ID"]);
                //}
                objPrivileges.BranchId = EntityManager.getValue<Int32>(rolePrivileges, ColumnName.RP_BRANCH_ID.ToString());
                objPrivileges.FunctionName = FunctionMaster.getFunctionMaster(rolePrivileges);                
                return objPrivileges;
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }

        public static List<RolePrivilege> mergePrivileges(List<RolePrivilege> priviligeList)
        {
            List<RolePrivilege> megreList = new List<RolePrivilege>();

            var privilegeGroup = priviligeList.GroupBy(p => p.RoleId).Select(grp => grp.ToList()).ToList();

            if (privilegeGroup != null && privilegeGroup.Count > 1)
            {

                foreach (List<RolePrivilege> lstPrivilege in privilegeGroup)
                {
                    RolePrivilege mergedPrivilage = lstPrivilege[0];

                    foreach (RolePrivilege objPrivilege in lstPrivilege)
                    {
                        mergePrivileges(mergedPrivilage, objPrivilege);
                    }

                    megreList.Add(mergedPrivilage);
                }

                return megreList;
            }
            else
            {
                return priviligeList;
            }
        }

        public static void mergePrivileges(RolePrivilege mergeWith, RolePrivilege merge)
        {   
            mergeWith.View = merge.View || mergeWith.View;
            mergeWith.Create = merge.Create || mergeWith.Create;
            mergeWith.Modify = merge.Modify || mergeWith.Modify;
            mergeWith.Delete = merge.Delete || mergeWith.Delete;
            mergeWith.AllBranches = merge.AllBranches || mergeWith.AllBranches;
        }
        /*internal void Update()
        {
         * TO be moved to userhandller
            BLL.UserHandler.updatePrivileges(this);
        }*/

        
    }
}
