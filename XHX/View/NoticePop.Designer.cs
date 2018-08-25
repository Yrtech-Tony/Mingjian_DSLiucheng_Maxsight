namespace XHX.View
{
    partial class NoticePop
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
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblChapter = new DevExpress.XtraEditors.LabelControl();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.grcAttachment = new DevExpress.XtraGrid.GridControl();
            this.grvAttachment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAttachName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelectFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelectFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcFileDown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcSeqNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteRow = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnInit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(110, 11);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(400, 20);
            this.txtTitle.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(74, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(24, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "标题";
            // 
            // lblChapter
            // 
            this.lblChapter.Location = new System.Drawing.Point(50, 49);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(48, 13);
            this.lblChapter.TabIndex = 10;
            this.lblChapter.Text = "公告内容";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(110, 46);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(400, 104);
            this.txtContent.TabIndex = 11;
            // 
            // grcAttachment
            // 
            this.grcAttachment.Location = new System.Drawing.Point(110, 51);
            this.grcAttachment.MainView = this.grvAttachment;
            this.grcAttachment.Name = "grcAttachment";
            this.grcAttachment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnSelectFile,
            this.btnDownFile});
            this.grcAttachment.Size = new System.Drawing.Size(401, 161);
            this.grcAttachment.TabIndex = 12;
            this.grcAttachment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAttachment});
            // 
            // grvAttachment
            // 
            this.grvAttachment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcAttachName,
            this.gcSelectFile,
            this.gcFileDown,
            this.gcSeqNO});
            this.grvAttachment.GridControl = this.grcAttachment;
            this.grvAttachment.Name = "grvAttachment";
            this.grvAttachment.OptionsView.ShowGroupPanel = false;
            this.grvAttachment.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvAttachment_ShowingEditor);
            // 
            // gcAttachName
            // 
            this.gcAttachName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAttachName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAttachName.Caption = "文件名";
            this.gcAttachName.FieldName = "AttachName";
            this.gcAttachName.Name = "gcAttachName";
            this.gcAttachName.OptionsColumn.ReadOnly = true;
            this.gcAttachName.Visible = true;
            this.gcAttachName.VisibleIndex = 0;
            this.gcAttachName.Width = 166;
            // 
            // gcSelectFile
            // 
            this.gcSelectFile.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSelectFile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSelectFile.Caption = "选择文件";
            this.gcSelectFile.ColumnEdit = this.btnSelectFile;
            this.gcSelectFile.FieldName = "FilePath";
            this.gcSelectFile.Name = "gcSelectFile";
            this.gcSelectFile.OptionsColumn.ReadOnly = true;
            this.gcSelectFile.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcSelectFile.Visible = true;
            this.gcSelectFile.VisibleIndex = 1;
            this.gcSelectFile.Width = 151;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.AutoHeight = false;
            this.btnSelectFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSelectFile_ButtonClick);
            // 
            // gcFileDown
            // 
            this.gcFileDown.AppearanceHeader.Options.UseTextOptions = true;
            this.gcFileDown.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFileDown.Caption = "下载";
            this.gcFileDown.ColumnEdit = this.btnDownFile;
            this.gcFileDown.Name = "gcFileDown";
            this.gcFileDown.OptionsColumn.ReadOnly = true;
            this.gcFileDown.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcFileDown.Visible = true;
            this.gcFileDown.VisibleIndex = 2;
            this.gcFileDown.Width = 69;
            // 
            // btnDownFile
            // 
            this.btnDownFile.AutoHeight = false;
            this.btnDownFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDownFile.Name = "btnDownFile";
            this.btnDownFile.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDownFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDownFile_ButtonClick);
            // 
            // gcSeqNO
            // 
            this.gcSeqNO.Caption = "SeqNO";
            this.gcSeqNO.FieldName = "SeqNO";
            this.gcSeqNO.Name = "gcSeqNO";
            this.gcSeqNO.OptionsColumn.ReadOnly = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(74, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "附件";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddRow.Location = new System.Drawing.Point(360, 13);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(70, 25);
            this.btnAddRow.TabIndex = 14;
            this.btnAddRow.Text = "添加行";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeleteRow.Location = new System.Drawing.Point(440, 12);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(70, 25);
            this.btnDeleteRow.TabIndex = 15;
            this.btnDeleteRow.Text = "删除行";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(440, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInit
            // 
            this.btnInit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInit.Location = new System.Drawing.Point(360, 15);
            this.btnInit.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(70, 25);
            this.btnInit.TabIndex = 17;
            this.btnInit.Text = "初始化";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnInit);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(589, 42);
            this.panelControl1.TabIndex = 18;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblChapter);
            this.panelControl2.Controls.Add(this.lblTitle);
            this.panelControl2.Controls.Add(this.txtTitle);
            this.panelControl2.Controls.Add(this.txtContent);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(589, 170);
            this.panelControl2.TabIndex = 19;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.grcAttachment);
            this.panelControl3.Controls.Add(this.btnAddRow);
            this.panelControl3.Controls.Add(this.btnDeleteRow);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 212);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(589, 267);
            this.panelControl3.TabIndex = 20;
            // 
            // NoticePop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 480);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "NoticePop";
            this.Text = "公告";
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblChapter;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private DevExpress.XtraGrid.GridControl grcAttachment;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAttachment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAddRow;
        private DevExpress.XtraEditors.SimpleButton btnDeleteRow;
        private DevExpress.XtraGrid.Columns.GridColumn gcAttachName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectFile;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelectFile;
        private DevExpress.XtraGrid.Columns.GridColumn gcFileDown;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownFile;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnInit;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeqNO;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}