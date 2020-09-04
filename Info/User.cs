using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ClassManager.Info
{
    [Serializable]
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set;} 
        public string Type { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Branch Branch { get; set; }
       
        public List<Info.RolePrivilege> privileges;

        enum ColumnName
        {
                LGN_REGID,
                LGN_USER_ID,
                LGN_PASSWORD,
                LGN_TYPE,
                LGN_BRANCH_ID,
                LGN_ID,
                LGN_CRTD_AT,
                LGN_UPDT_AT,
                LGN_DLTD_AT,
                LGN_CRTD_BY,
                LGN_UPDAT_BY,
                LGN_DLTD_BY,
                ID


        }

        public static User getUsersData(DataTable dtUser)
        {
            try
            {
                User objUser = new User();

                DataRow drUser = dtUser.Rows[0];

                //if (drUser.Table.Columns.Contains("userid") && drUser["userid"] != DBNull.Value)
                //{
                //    objUser.UserId = (drUser["userid"]).ToString();
                //}
                objUser.UserId = EntityManager.getValue<string>(drUser, ColumnName.LGN_USER_ID.ToString());
                //if (drUser.Table.Columns.Contains("password") && drUser["password"] != DBNull.Value)
                //{
                //    objUser.Password = drUser["password"].ToString();
                //}
                objUser.Password = EntityManager.getValue<string>(drUser, ColumnName.LGN_PASSWORD.ToString());
                //if (drUser.Table.Columns.Contains("Type") && drUser["Type"] != DBNull.Value)
                //{
                //    objUser.Type = (drUser["Type"].ToString());
                //}
                objUser.Type = EntityManager.getValue<string>(drUser, ColumnName.LGN_TYPE.ToString());
                //if (drUser.Table.Columns.Contains("Branch_Id") && drUser["Branch_Id"] != DBNull.Value)
                //{
                //    objUser.BranchId = Convert.ToInt32(drUser["Branch_Id"].ToString());
                //}

                objUser.BranchId = EntityManager.getValue<Int32>(drUser, ColumnName.LGN_BRANCH_ID.ToString());
                objUser.privileges = RolePrivilege.mergePrivileges(RolePrivilege.getPrivileges(dtUser));
                objUser.Branch = Branch.getBranch(drUser);

                return objUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
