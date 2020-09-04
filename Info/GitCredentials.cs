using System;
using System.IO;

namespace ClassManager.Info
{
    public class GitCredentials
    {
        public static string REPOPATH { get; set; }
        public static string USERNAME { get; set; }
        public static string PASSWORD { get; set; }
        public static string EMAIL { get; set; }
        public static string BRANCHNAME { get; set; }
        public static string REMOTEURL { get; set; }

        static GitCredentials()
        {
            REPOPATH = SysParam.getValue<string>(SysParam.Parameters.SYNC_REPOFOLDER);
            USERNAME = SysParam.getValue<string>(SysParam.Parameters.SYNC_USERNAME);
            PASSWORD = Common.EncryptionDecryption.Decrypt(SysParam.getValue<string>(SysParam.Parameters.SYNC_PASSWORD));
            EMAIL = SysParam.getValue<string>(SysParam.Parameters.SYNC_EMAIL);
            BRANCHNAME = SysParam.getValue<string>(SysParam.Parameters.SYNC_BRANCH);
            REMOTEURL = SysParam.getValue<string>(SysParam.Parameters.SYNC_REMOTE);

            if(! Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + REPOPATH))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + REPOPATH);
            }
        }
    }
}