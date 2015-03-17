namespace InvitationTeachers
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lnkUpload = new System.Windows.Forms.LinkLabel();
            this.lnkView = new System.Windows.Forms.LinkLabel();
            this.lnkMergeFields = new System.Windows.Forms.LinkLabel();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(282, 59);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "說明：本功能將會列印教師代碼邀請函,方便\r\n教師們快速完成加入ischool app";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(222, 77);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(222, 106);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lnkUpload
            // 
            this.lnkUpload.AutoSize = true;
            this.lnkUpload.BackColor = System.Drawing.Color.Transparent;
            this.lnkUpload.Location = new System.Drawing.Point(16, 83);
            this.lnkUpload.Name = "lnkUpload";
            this.lnkUpload.Size = new System.Drawing.Size(60, 17);
            this.lnkUpload.TabIndex = 6;
            this.lnkUpload.TabStop = true;
            this.lnkUpload.Text = "上傳範本";
            this.lnkUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpload_LinkClicked);
            // 
            // lnkView
            // 
            this.lnkView.AutoSize = true;
            this.lnkView.BackColor = System.Drawing.Color.Transparent;
            this.lnkView.Location = new System.Drawing.Point(86, 83);
            this.lnkView.Name = "lnkView";
            this.lnkView.Size = new System.Drawing.Size(60, 17);
            this.lnkView.TabIndex = 7;
            this.lnkView.TabStop = true;
            this.lnkView.Text = "檢視範本";
            this.lnkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkView_LinkClicked);
            // 
            // lnkMergeFields
            // 
            this.lnkMergeFields.AutoSize = true;
            this.lnkMergeFields.BackColor = System.Drawing.Color.Transparent;
            this.lnkMergeFields.Location = new System.Drawing.Point(16, 112);
            this.lnkMergeFields.Name = "lnkMergeFields";
            this.lnkMergeFields.Size = new System.Drawing.Size(86, 17);
            this.lnkMergeFields.TabIndex = 9;
            this.lnkMergeFields.TabStop = true;
            this.lnkMergeFields.Text = "合併欄位總表";
            this.lnkMergeFields.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMergeFields_LinkClicked);
            // 
            // lnkClear
            // 
            this.lnkClear.AutoSize = true;
            this.lnkClear.BackColor = System.Drawing.Color.Transparent;
            this.lnkClear.Location = new System.Drawing.Point(156, 83);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(60, 17);
            this.lnkClear.TabIndex = 10;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "清除範本";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 144);
            this.Controls.Add(this.lnkClear);
            this.Controls.Add(this.lnkMergeFields);
            this.Controls.Add(this.lnkView);
            this.Controls.Add(this.lnkUpload);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "列印教師代碼邀請函";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.LinkLabel lnkUpload;
        private System.Windows.Forms.LinkLabel lnkView;
        private System.Windows.Forms.LinkLabel lnkMergeFields;
        private System.Windows.Forms.LinkLabel lnkClear;
    }
}