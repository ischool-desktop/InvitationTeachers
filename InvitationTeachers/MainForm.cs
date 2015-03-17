using Aspose.BarCode;
using Aspose.Words;
using Aspose.Words.Reporting;
using Campus.Report;
using FISCA.Data;
using FISCA.Presentation.Controls;
using K12.Data;
using SmartSchool.ePaper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InvitationTeachers
{
    public partial class MainForm : BaseForm
    {
        Program.PrintType _PrintType;
        BackgroundWorker _BW;
        string _SchoolName,_DSNSName;

        List<string> _SelectedTeachers;

        ReportConfiguration _RC;

        public MainForm(Program.PrintType type)
        {
            InitializeComponent();

            _PrintType = type;

            _RC = new ReportConfiguration(Program.ReportName);

            _BW = new BackgroundWorker();
            _BW.DoWork += new DoWorkEventHandler(BW_DoWork);
            _BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_Completed);
        }

        private void BW_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            SetForm(true);

            if (e.Error != null)
            {
                MsgBox.Show(e.Error.Message);
                return;
            }

            Document doc = e.Result as Document;

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "另存新檔";
            save.FileName = Program.ReportName;
            save.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    doc.Save(save.FileName, SaveFormat.Doc);
                    System.Diagnostics.Process.Start(save.FileName);
                }
                catch
                {
                    MsgBox.Show("檔案儲存失敗");
                }
            }
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            _SchoolName = K12.Data.School.ChineseName;
            _DSNSName = FISCA.Authentication.DSAServices.AccessPoint;

            string str_id = string.Join("','", _SelectedTeachers);
            str_id = "'" + str_id + "'";

            QueryHelper q = new QueryHelper();

            string sql_cmd = string.Format("SELECT id,teacher_name,teacher_code FROM teacher WHERE id in ({0})", str_id);

            DataTable dt = q.Select(sql_cmd);
            dt.Columns.Add("school_name");
            dt.Columns.Add("teacher_qrcode");

            foreach (DataRow row in dt.Rows)
            {
                string teacher_code = row["teacher_code"] + "";
                row["teacher_qrcode"] = teacher_code + "@" + _DSNSName;

                row["school_name"] = _SchoolName;
            }

            Document doc;

            if(_RC.Template == null)
                doc = new Document(new MemoryStream(Properties.Resources.Template));
            else
                doc = new Document(new MemoryStream(_RC.Template.ToBinary()));

            doc.MailMerge.FieldMergingCallback = new MergeCallBack();
            doc.MailMerge.Execute(dt);

            e.Result = doc;
        }

        class MergeCallBack : IFieldMergingCallback
        {
            public void FieldMerging(FieldMergingArgs args)
            {
                if (args.FieldName == "teacher_qrcode")
                {
                    string value = args.FieldValue + "";
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        DocumentBuilder builder = new DocumentBuilder(args.Document);
                        builder.MoveToField(args.Field, true);
                        args.Field.Remove();

                        BarCodeBuilder bb = new BarCodeBuilder(value, Symbology.QR);
                        bb.GraphicsUnit = GraphicsUnit.Millimeter;
                        bb.AutoSize = false;
                        //QRcode size
                        bb.xDimension = 1.2f;
                        bb.yDimension = 1.2f;
                        //Image size
                        bb.ImageWidth = 42f;
                        bb.ImageHeight = 31.5f;

                        MemoryStream stream = new MemoryStream();
                        bb.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        builder.InsertImage(stream);
                    }
                }
            }

            public void ImageFieldMerging(ImageFieldMergingArgs args)
            {
                //do nothing...
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_PrintType == Program.PrintType.教師)
                _SelectedTeachers = K12.Presentation.NLDPanels.Teacher.SelectedSource;
            else
            {
                List<ClassRecord> cls = K12.Data.Class.SelectByIDs(K12.Presentation.NLDPanels.Class.SelectedSource);
                _SelectedTeachers = cls.FindAll(x => !string.IsNullOrWhiteSpace(x.RefTeacherID)).Select(x => x.RefTeacherID).ToList();
            }

            if (_SelectedTeachers.Count == 0)
            {
                MsgBox.Show("您選擇的班級沒有班導師");
                return;
            }

            if (_BW.IsBusy)
                return;
            else
            {
                SetForm(false);
                _BW.RunWorkerAsync();
            }
        }

        private void SetForm(bool b)
        {
            btnConfirm.Enabled = b;
            lnkClear.Enabled = b;
            lnkMergeFields.Enabled = b;
            lnkUpload.Enabled = b;
            lnkView.Enabled = b;
        }

        private void lnkUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Word (*.doc)|*.doc";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openDialog.FileName);
                TemplateType type = TemplateType.Word;

                ReportTemplate template = new ReportTemplate(fileInfo, type);

                _RC.Template = template;
                _RC.Save();

                MsgBox.Show("上傳完成!");
            }
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_RC.Template == null)
            {
                MsgBox.Show("目前沒有任何範本，請重新上傳。");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = Program.ReportName + "_範本";
            saveDialog.Filter = "Word (*.doc)|*.doc";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(new MemoryStream(_RC.Template.ToBinary()));

                try
                {
                    doc.Save(saveDialog.FileName, Aspose.Words.SaveFormat.Doc);
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch
                {
                    MsgBox.Show("路徑無法存取，請確認檔案是否未正確關閉。");
                }
            }
        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RC.Template = null;
            _RC.Save();

            MsgBox.Show("範本已刪除。");
        }

        private void lnkMergeFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = Program.ReportName + "_合併欄位總表";
            saveDialog.Filter = "Word (*.doc)|*.doc";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(new MemoryStream(Properties.Resources.MergeFields));

                try
                {
                    doc.Save(saveDialog.FileName, Aspose.Words.SaveFormat.Doc);
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch
                {
                    MsgBox.Show("路徑無法存取，請確認檔案是否未正確關閉。");
                }
            }
        }
    }
}
