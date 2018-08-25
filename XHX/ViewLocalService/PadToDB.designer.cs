namespace XHX.ViewLocalService
{
    partial class PadToDB
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbnSQLitePathForUpdate = new DevExpress.XtraEditors.ButtonEdit();
            this.pbrProgressForUpdate = new System.Windows.Forms.ProgressBar();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnDownloadDataForUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbnSQLitePath = new DevExpress.XtraEditors.ButtonEdit();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnDownloadData = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnDataPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboExamType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnUploadData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.pbrProgressForUpload = new System.Windows.Forms.ProgressBar();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbnSQLitePathForUpdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbnSQLitePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDataPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExamType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl3);
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.panelControl2.Size = new System.Drawing.Size(886, 602);
            this.panelControl2.TabIndex = 6;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.tbnSQLitePathForUpdate);
            this.groupControl3.Controls.Add(this.pbrProgressForUpdate);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Controls.Add(this.btnDownloadDataForUpdate);
            this.groupControl3.Location = new System.Drawing.Point(13, 289);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(802, 109);
            this.groupControl3.TabIndex = 92;
            this.groupControl3.Text = "从服务器下载[更新数据](只生成readonly.db一个文件)";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.Location = new System.Drawing.Point(5, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "数据路径";
            // 
            // tbnSQLitePathForUpdate
            // 
            this.tbnSQLitePathForUpdate.EditValue = "";
            this.tbnSQLitePathForUpdate.Location = new System.Drawing.Point(64, 23);
            this.tbnSQLitePathForUpdate.Name = "tbnSQLitePathForUpdate";
            this.tbnSQLitePathForUpdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbnSQLitePathForUpdate.Size = new System.Drawing.Size(512, 20);
            this.tbnSQLitePathForUpdate.TabIndex = 1;
            this.tbnSQLitePathForUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.tbnSQLitePathForUpdate_ButtonClick);
            // 
            // pbrProgressForUpdate
            // 
            this.pbrProgressForUpdate.Location = new System.Drawing.Point(64, 59);
            this.pbrProgressForUpdate.Name = "pbrProgressForUpdate";
            this.pbrProgressForUpdate.Size = new System.Drawing.Size(391, 25);
            this.pbrProgressForUpdate.TabIndex = 89;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.Location = new System.Drawing.Point(5, 63);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "下载进度";
            // 
            // btnDownloadDataForUpdate
            // 
            this.btnDownloadDataForUpdate.Location = new System.Drawing.Point(461, 52);
            this.btnDownloadDataForUpdate.Name = "btnDownloadDataForUpdate";
            this.btnDownloadDataForUpdate.Size = new System.Drawing.Size(115, 49);
            this.btnDownloadDataForUpdate.TabIndex = 88;
            this.btnDownloadDataForUpdate.Text = "下载数据到本地";
            this.btnDownloadDataForUpdate.Click += new System.EventHandler(this.btnDownloadDataForUpdate_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.tbnSQLitePath);
            this.groupControl2.Controls.Add(this.pbrProgress);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.btnDownloadData);
            this.groupControl2.Location = new System.Drawing.Point(13, 14);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(802, 109);
            this.groupControl2.TabIndex = 91;
            this.groupControl2.Text = "从服务器下载[数据](会生成readonly.db和writeable.db两个文件)";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Location = new System.Drawing.Point(5, 26);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "数据路径";
            // 
            // tbnSQLitePath
            // 
            this.tbnSQLitePath.EditValue = "";
            this.tbnSQLitePath.Location = new System.Drawing.Point(64, 23);
            this.tbnSQLitePath.Name = "tbnSQLitePath";
            this.tbnSQLitePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbnSQLitePath.Size = new System.Drawing.Size(512, 20);
            this.tbnSQLitePath.TabIndex = 1;
            this.tbnSQLitePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.tbnSQLitePath_ButtonClick);
            // 
            // pbrProgress
            // 
            this.pbrProgress.Location = new System.Drawing.Point(64, 59);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(391, 25);
            this.pbrProgress.TabIndex = 89;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Location = new System.Drawing.Point(5, 63);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "下载进度";
            // 
            // btnDownloadData
            // 
            this.btnDownloadData.Location = new System.Drawing.Point(461, 52);
            this.btnDownloadData.Name = "btnDownloadData";
            this.btnDownloadData.Size = new System.Drawing.Size(115, 49);
            this.btnDownloadData.TabIndex = 88;
            this.btnDownloadData.Text = "下载数据到本地";
            this.btnDownloadData.Click += new System.EventHandler(this.btnDownloadData_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.pbrProgressForUpload);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnDataPath);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboExamType);
            this.groupControl1.Controls.Add(this.btnUploadData);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboProjects);
            this.groupControl1.Controls.Add(this.btnShopCode);
            this.groupControl1.Controls.Add(this.txtShopName);
            this.groupControl1.Location = new System.Drawing.Point(13, 130);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(802, 153);
            this.groupControl1.TabIndex = 90;
            this.groupControl1.Text = "向服务器上传[数据和图片](将writeable.db中的数据上传到服务器)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Location = new System.Drawing.Point(17, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "项目名";
            // 
            // btnDataPath
            // 
            this.btnDataPath.EditValue = "";
            this.btnDataPath.Location = new System.Drawing.Point(64, 66);
            this.btnDataPath.Name = "btnDataPath";
            this.btnDataPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDataPath.Size = new System.Drawing.Size(512, 20);
            this.btnDataPath.TabIndex = 1;
            this.btnDataPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDataPath_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Location = new System.Drawing.Point(5, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "数据路径";
            // 
            // cboExamType
            // 
            this.cboExamType.Enabled = false;
            this.cboExamType.Location = new System.Drawing.Point(638, 23);
            this.cboExamType.Name = "cboExamType";
            this.cboExamType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboExamType.Size = new System.Drawing.Size(80, 20);
            this.cboExamType.TabIndex = 87;
            // 
            // btnUploadData
            // 
            this.btnUploadData.Location = new System.Drawing.Point(461, 95);
            this.btnUploadData.Name = "btnUploadData";
            this.btnUploadData.Size = new System.Drawing.Size(115, 49);
            this.btnUploadData.TabIndex = 5;
            this.btnUploadData.Text = "上传数据到服务器";
            this.btnUploadData.Click += new System.EventHandler(this.btnUploadData_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(591, 26);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 15);
            this.labelControl7.TabIndex = 86;
            this.labelControl7.Text = "类型";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(190, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "经销商";
            // 
            // cboProjects
            // 
            this.cboProjects.Location = new System.Drawing.Point(64, 23);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjects.Size = new System.Drawing.Size(100, 20);
            this.cboProjects.TabIndex = 10;
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(232, 23);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(100, 20);
            this.btnShopCode.TabIndex = 7;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(338, 23);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(238, 20);
            this.txtShopName.TabIndex = 8;
            // 
            // pbrProgressForUpload
            // 
            this.pbrProgressForUpload.Location = new System.Drawing.Point(64, 104);
            this.pbrProgressForUpload.Name = "pbrProgressForUpload";
            this.pbrProgressForUpload.Size = new System.Drawing.Size(391, 25);
            this.pbrProgressForUpload.TabIndex = 91;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.Location = new System.Drawing.Point(5, 108);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 13);
            this.labelControl9.TabIndex = 90;
            this.labelControl9.Text = "上传进度";
            // 
            // PadToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "PadToDB";
            this.Size = new System.Drawing.Size(886, 602);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbnSQLitePathForUpdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbnSQLitePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDataPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExamType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit btnDataPath;
        private DevExpress.XtraEditors.SimpleButton btnUploadData;
        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboExamType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnDownloadData;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit tbnSQLitePath;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ButtonEdit tbnSQLitePathForUpdate;
        private System.Windows.Forms.ProgressBar pbrProgressForUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnDownloadDataForUpdate;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ProgressBar pbrProgressForUpload;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}