using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvitationTeachers
{
    class Permissions
    {
        public static bool 教師邀請函權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[教師邀請函].Executable;
            }
        }

        public static string 教師邀請函 = "InvitationTeachers-{DDCCC724-22BF-4FC3-9BD0-0D69E1259659}";
    }
}
