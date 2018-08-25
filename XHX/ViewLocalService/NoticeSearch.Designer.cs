namespace XHX.ViewLocalService
{
    partial class NoticeSearch
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
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grcNotice = new DevExpress.XtraGrid.GridControl();
            this.grvNotice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NoticeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNoticeTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFileExist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(69, 14);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.dateStart.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Size = new System.Drawing.Size(100, 21);
            this.dateStart.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "日 期";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(192, 14);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 21);
            this.dateEnd.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(178, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(9, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "~";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dateEnd);
            this.panelControl2.Controls.Add(this.dateStart);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(988, 42);
            this.panelControl2.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.grcNotice);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(5, 47);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(988, 561);
            this.panelControl3.TabIndex = 7;
            // 
            // grcNotice
            // 
            this.grcNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcNotice.Location = new System.Drawing.Point(2, 7);
            this.grcNotice.MainView = this.grvNotice;
            this.grcNotice.Name = "grcNotice";
            this.grcNotice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnView});
            this.grcNotice.Size = new System.Drawing.Size(984, 552);
            this.grcNotice.TabIndex = 31;
            this.grcNotice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNotice});
            // 
            // grvNotice
            // 
            this.grvNotice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NoticeID,
            this.gcNoticeTitle,
            this.gcFileExist,
            this.gcInDateTime,
            this.gcView});
            this.grvNotice.GridControl = this.grcNotice;
            this.grvNotice.Name = "grvNotice";
            this.grvNotice.OptionsView.ShowGroupPanel = false;
            this.grvNotice.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvNotice_ShowingEditor);
            // 
            // NoticeID
            // 
            this.NoticeID.AppearanceHeader.Options.UseTextOptions = true;
            this.NoticeID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoticeID.Caption = "gcNoticeID";
            this.NoticeID.FieldName = "NoticeID";
            this.NoticeID.Name = "NoticeID";
            this.NoticeID.OptionsColumn.ReadOnly = true;
            this.NoticeID.Width = 192;
            // 
            // gcNoticeTitle
            // 
            this.gcNoticeTitle.AppearanceHeader.Options.UseTextOptions = true;
            this.gcNoticeTitle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcNoticeTitle.Caption = "标题";
            this.gcNoticeTitle.FieldName = "NoticeTitle";
            this.gcNoticeTitle.Name = "gcNoticeTitle";
            this.gcNoticeTitle.OptionsColumn.ReadOnly = true;
            this.gcNoticeTitle.Visible = true;
            this.gcNoticeTitle.VisibleIndex = 0;
            this.gcNoticeTitle.Width = 578;
            // 
            // gcFileExist
            // 
            this.gcFileExist.AppearanceCell.Options.UseTextOptions = true;
            this.gcFileExist.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFileExist.AppearanceHeader.Options.UseTextOptions = true;
            this.gcFileExist.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFileExist.Caption = "有无附件";
            this.gcFileExist.FieldName = "FileExist";
            this.gcFileExist.Name = "gcFileExist";
            this.gcFileExist.OptionsColumn.ReadOnly = true;
            this.gcFileExist.Visible = true;
            this.gcFileExist.VisibleIndex = 1;
            this.gcFileExist.Width = 181;
            // 
            // gcInDateTime
            // 
            this.gcInDateTime.AppearanceCell.Options.UseTextOptions = true;
            this.gcInDateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInDateTime.Caption = "登记日";
            this.gcInDateTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gcInDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcInDateTime.FieldName = "InDateTime";
            this.gcInDateTime.Name = "gcInDateTime";
            this.gcInDateTime.OptionsColumn.ReadOnly = true;
            this.gcInDateTime.Visible = true;
            this.gcInDateTime.VisibleIndex = 2;
            this.gcInDateTime.Width = 124;
            // 
            // gcView
            // 
            this.gcView.AppearanceCell.Options.UseTextOptions = true;
            this.gcView.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcView.AppearanceHeader.Options.UseTextOptions = true;
            this.gcView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcView.Caption = "查看";
            this.gcView.ColumnEdit = this.btnView;
            this.gcView.Name = "gcView";
            this.gcView.OptionsColumn.ReadOnly = true;
            this.gcView.Visible = true;
            this.gcView.VisibleIndex = 3;
            this.gcView.Width = 90;
            // 
            // btnView
            // 
            this.btnView.AutoHeight = false;
            this.btnView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnView.Name = "btnView";
            this.btnView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnView.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnView_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(984, 5);
            this.labelControl2.TabIndex = 30;
            // 
            // NoticeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "NoticeSearch";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(998, 613);
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grcNotice;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNotice;
        private DevExpress.XtraGrid.Columns.GridColumn NoticeID;
        private DevExpress.XtraGrid.Columns.GridColumn gcNoticeTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gcFileExist;
        private DevExpress.XtraGrid.Columns.GridColumn gcInDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnView;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}