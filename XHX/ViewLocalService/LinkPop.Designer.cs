namespace XHX.ViewLocalService
{
    partial class LinkPop
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
            this.grcLink = new DevExpress.XtraGrid.GridControl();
            this.grvLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcChapter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLinkCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.txtChapter = new DevExpress.XtraEditors.TextEdit();
            this.cboChapter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblChapter = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grcLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcLink
            // 
            this.grcLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcLink.Location = new System.Drawing.Point(0, 90);
            this.grcLink.MainView = this.grvLink;
            this.grcLink.Name = "grcLink";
            this.grcLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcLink.Size = new System.Drawing.Size(592, 476);
            this.grcLink.TabIndex = 21;
            this.grcLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLink});
            // 
            // grvLink
            // 
            this.grvLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcChapter,
            this.gcLinkCode,
            this.gcLinkName});
            this.grvLink.GridControl = this.grcLink;
            this.grvLink.Name = "grvLink";
            this.grvLink.OptionsView.ShowGroupPanel = false;
            // 
            // gcChapter
            // 
            this.gcChapter.AppearanceHeader.Options.UseTextOptions = true;
            this.gcChapter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcChapter.Caption = "章节";
            this.gcChapter.FieldName = "CharterName";
            this.gcChapter.Name = "gcChapter";
            this.gcChapter.Visible = true;
            this.gcChapter.VisibleIndex = 0;
            // 
            // gcLinkCode
            // 
            this.gcLinkCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLinkCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLinkCode.Caption = "环节代码";
            this.gcLinkCode.FieldName = "LinkCode";
            this.gcLinkCode.Name = "gcLinkCode";
            this.gcLinkCode.OptionsColumn.AllowEdit = false;
            this.gcLinkCode.OptionsColumn.AllowSize = false;
            this.gcLinkCode.OptionsColumn.ReadOnly = true;
            this.gcLinkCode.Visible = true;
            this.gcLinkCode.VisibleIndex = 1;
            // 
            // gcLinkName
            // 
            this.gcLinkName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLinkName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLinkName.Caption = "环节";
            this.gcLinkName.FieldName = "LinkName";
            this.gcLinkName.Name = "gcLinkName";
            this.gcLinkName.OptionsColumn.AllowEdit = false;
            this.gcLinkName.OptionsColumn.AllowSize = false;
            this.gcLinkName.Visible = true;
            this.gcLinkName.VisibleIndex = 2;
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
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(72, 14);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(100, 20);
            this.cboProject.TabIndex = 1;
            this.cboProject.SelectedIndexChanged += new System.EventHandler(this.cboProject_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "项目";
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtChapter);
            this.grdShop.Controls.Add(this.cboChapter);
            this.grdShop.Controls.Add(this.lblChapter);
            this.grdShop.Controls.Add(this.cboProject);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(0, 45);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(592, 45);
            this.grdShop.TabIndex = 20;
            // 
            // txtChapter
            // 
            this.txtChapter.Enabled = false;
            this.txtChapter.Location = new System.Drawing.Point(351, 15);
            this.txtChapter.Name = "txtChapter";
            this.txtChapter.Size = new System.Drawing.Size(229, 20);
            this.txtChapter.TabIndex = 7;
            // 
            // cboChapter
            // 
            this.cboChapter.Location = new System.Drawing.Point(231, 15);
            this.cboChapter.Name = "cboChapter";
            this.cboChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChapter.Size = new System.Drawing.Size(100, 20);
            this.cboChapter.TabIndex = 3;
            // 
            // lblChapter
            // 
            this.lblChapter.Location = new System.Drawing.Point(189, 17);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(24, 13);
            this.lblChapter.TabIndex = 2;
            this.lblChapter.Text = "章节";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfirm.Location = new System.Drawing.Point(478, 15);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 25);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            this.panelControl1.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(367, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // LinkPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 566);
            this.Controls.Add(this.grcLink);
            this.Controls.Add(this.grdShop);
            this.Controls.Add(this.panelControl1);
            this.Name = "LinkPop";
            this.Text = "LinkPop";
            ((System.ComponentModel.ISupportInitialize)(this.grcLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcLink;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcLinkCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLinkName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboChapter;
        private DevExpress.XtraEditors.LabelControl lblChapter;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gcChapter;
        private DevExpress.XtraEditors.TextEdit txtChapter;
    }
}