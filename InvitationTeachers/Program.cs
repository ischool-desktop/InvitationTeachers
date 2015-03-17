using FISCA.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationTeachers
{
    public class Program
    {
        [FISCA.MainMethod]
        public static void Main()
        {
            //教師頁面
            FISCA.Presentation.RibbonBarItem item1_teacher = FISCA.Presentation.MotherForm.RibbonBarItems["教師", "資料統計"];
            item1_teacher["報表"].Image = Properties.Resources.Report;
            item1_teacher["報表"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Large;
            item1_teacher["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Enable = false;
            item1_teacher["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Click += delegate
            {
                new MainForm(PrintType.教師).ShowDialog();
            };

            K12.Presentation.NLDPanels.Teacher.SelectedSourceChanged += delegate
            {
                item1_teacher["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Enable = K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0 && Permissions.教師邀請函權限;
            };

            //班級頁面
            FISCA.Presentation.RibbonBarItem item_class = FISCA.Presentation.MotherForm.RibbonBarItems["班級", "資料統計"];
            item_class["報表"].Image = Properties.Resources.Report;
            item_class["報表"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Large;
            item_class["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Enable = false;
            item_class["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Click += delegate
            {
                new MainForm(PrintType.班級).ShowDialog();
            };

            K12.Presentation.NLDPanels.Class.SelectedSourceChanged += delegate
            {
                item_class["報表"]["代碼相關報表"]["教師代碼邀請函 for App"].Enable = K12.Presentation.NLDPanels.Class.SelectedSource.Count > 0 && Permissions.教師邀請函權限;
            };

            //權限設定
            Catalog permission = RoleAclSource.Instance["教師"]["功能按鈕"];
            permission.Add(new RibbonFeature(Permissions.教師邀請函, "教師代碼邀請函 for App"));
        }

        public static string ReportName = "教師代碼邀請函 for App";

        public enum PrintType { 教師, 班級 };
    }
}
