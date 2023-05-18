using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Helper
    {
        public const string PathImageuser = "/Images/Users/";
        public const string PathSaveImageuser = "Images/Users";


        public const string Success = "success";
        public const string Error = "error";

        public const string MsgType = "msgType";
        public const string Title = "title";
        public const string Msg = "msg";

        public const string Save = "Save";
        public const string Update = "Update";
        public const string Delete = "Delete";


        // Date Default User
        public const string Email = "xsuperadmin@domin.com";
        public const string UserName = "xsuperadmin@domin.com";
        public const string Name = "SuperAdmin";
        public const string Password = "superadmin@P@$$w0rd123";

        public const string Emailadmin = "admin@domin.com";
        public const string UserNameadmin = "admin@domin.com";
        public const string Nameadmin = "Admin";
        public const string Passwordadmin = "admin@P@$$w0rd123";

        public const string EmailBasic = "basicuser@domin.com";
        public const string UserNameBasic = "basicuser@domin.com";
        public const string NameBasic = "BasicUser";
        public const string PasswordBasic = "basicuser@P@$$w0rd123456";

        public const string Permission = "Permission";

        public enum eCurrentState
        {
            Active = 1,
            Delete =0
        }
        public enum Roles {
        SUPPERADMIN,
        Admin,
        Basic
        }
        public enum PermissionModuleName
        {
            Home,
            Accounts,
            Roles,
            Registers,
            AccountingManual,

        }
        public static string GetTypeName(string fullTypeName)
        {
            string retString = "";

            try
            {
                int lastIndex = fullTypeName.LastIndexOf('.') + 1;
                retString = fullTypeName.Substring(lastIndex, fullTypeName.Length - lastIndex);
            }
            catch
            {
                retString = fullTypeName;
            }

            retString = retString.Replace("]", "");

            return retString;
        }

    }
}
