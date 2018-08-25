namespace XHX.ViewLocalService
{
    partial class ChapterPop
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
            this.grcChapter = new DevExpress.XtraGrid.GridControl();
            this.grvChapter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcChapterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChapterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grcChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcChapter
            // 
            this.grcChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcChapter.Location = new System.Drawing.Point(0, 90);
            this.grcChapter.MainView = this.grvChapter;
            this.grcChapter.Name = "grcChapter";
            this.grcChapter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcChapter.Size = new System.Drawing.Size(592, 476);
            this.grcChapter.TabIndex = 18;
            this.grcChapter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChapter});
            // 
            // grvChapter
            // 
            this.grvChapter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcChapterCode,
            this.gcChapterName});
            this.grvChapter.GridControl = this.grcChapter;
            this.grvChapter.Name = "grvChapter";
            this.grvChapter.OptionsView.ShowGroupPanel = false;
            this.grvChapter.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvChapter_CustomDrawCell);
            this.grvChapter.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvChapter_ShowingEditor);
            // 
            // gcChapterCode
            // 
            this.gcChapterCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcChapterCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcChapterCode.Caption = "章节代码";
            this.gcChapterCode.FieldName = "CharterCode";
            this.gcChapterCode.Name = "gcChapterCode";
            this.gcChapterCode.OptionsColumn.AllowEdit = false;
            this.gcChapterCode.OptionsColumn.AllowSize = false;
            this.gcChapterCode.OptionsColumn.ReadOnly = true;
            this.gcChapterCode.Visible = true;
            this.gcChapterCode.VisibleIndex = 0;
            // 
            // gcChapterName
            // 
            this.gcChapterName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcChapterName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcChapterName.Caption = "章节";
            this.gcChapterName.FieldName = "CharterName";
            this.gcChapterName.Name = "gcChapterName";
            this.gcChapterName.OptionsColumn.AllowEdit = false;
            this.gcChapterName.OptionsColumn.AllowSize = false;
            this.gcChapterName.Visible = true;
            this.gcChapterName.VisibleIndex = 1;
            // 
            // cboAreaCode
            // 
            this.cboAreaCode.AutoHeight = false;
            this.cboAreaCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreaCode.Name = "cboAreaCode";
            // 
            // chkUseChk
            // 
            this.chkUseChk.AutoHeight = false;
            this.chkUseChk.Name = "chkUseChk";
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.cboProject);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(0, 45);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(592, 45);
            this.grdShop.TabIndex = 17;
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(72, 14);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(100, 20);
            this.cboProject.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "项目";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnConfirm);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl1.Size = new System.Drawing.Size(592, 45);
            this.panelControl1.TabIndex = 16;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfirm.Location = new System.Drawing.Point(482, 15);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 25);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(381, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ChapterPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 566);
            this.Controls.Add(this.grcChapter);
            this.Controls.Add(this.grdShop);
            this.Controls.Add(this.panelControl1);
            this.Name = "ChapterPop";
            this.Text = "ChapterPop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChapterPop_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grcChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcChapter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChapter;
        private DevExpress.XtraGrid.Columns.GridColumn gcChapterCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcChapterName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
    }
}