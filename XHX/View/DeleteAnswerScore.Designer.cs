namespace XHX.View
{
    partial class DeleteAnswerScore
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grcSubject = new DevExpress.XtraGrid.GridControl();
            this.grvSubject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcChapter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCheckPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grcShop = new DevExpress.XtraGrid.GridControl();
            this.grvShop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSaleBigArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboSaleBigAreaInGrid = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcSaleSmallArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAfterBigArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAfterBigAreaInGrid = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcAfterSmall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUseChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigAreaInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigAreaInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grcSubject);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grcShop);
            this.splitContainer1.Size = new System.Drawing.Size(992, 607);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 0;
            // 
            // grcSubject
            // 
            this.grcSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSubject.Location = new System.Drawing.Point(0, 60);
            this.grcSubject.MainView = this.grvSubject;
            this.grcSubject.Name = "grcSubject";
            this.grcSubject.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcSubject.Size = new System.Drawing.Size(504, 547);
            this.grcSubject.TabIndex = 29;
            this.grcSubject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSubject});
            // 
            // grvSubject
            // 
            this.grvSubject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcChapter,
            this.gcSubjectCode,
            this.gcLinkName,
            this.gcCheckPoint});
            this.grvSubject.GridControl = this.grcSubject;
            this.grvSubject.Name = "grvSubject";
            this.grvSubject.OptionsView.ShowGroupPanel = false;
            // 
            // gcChapter
            // 
            this.gcChapter.AppearanceHeader.Options.UseTextOptions = true;
            this.gcChapter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcChapter.Caption = "章节";
            this.gcChapter.FieldName = "ChapterName";
            this.gcChapter.Name = "gcChapter";
            // 
            // gcSubjectCode
            // 
            this.gcSubjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectCode.Caption = "执行文件代码";
            this.gcSubjectCode.FieldName = "SubjectCode";
            this.gcSubjectCode.Name = "gcSubjectCode";
            this.gcSubjectCode.OptionsColumn.AllowEdit = false;
            this.gcSubjectCode.OptionsColumn.AllowSize = false;
            this.gcSubjectCode.OptionsColumn.ReadOnly = true;
            this.gcSubjectCode.Visible = true;
            this.gcSubjectCode.VisibleIndex = 0;
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
            // 
            // gcCheckPoint
            // 
            this.gcCheckPoint.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCheckPoint.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCheckPoint.Caption = "检查点";
            this.gcCheckPoint.FieldName = "CheckPoint";
            this.gcCheckPoint.Name = "gcCheckPoint";
            this.gcCheckPoint.Visible = true;
            this.gcCheckPoint.VisibleIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cboProject);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(504, 60);
            this.panel1.TabIndex = 28;
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(54, 24);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(100, 21);
            this.cboProject.TabIndex = 3;
            this.cboProject.SelectedIndexChanged += new System.EventHandler(this.cboProject_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "项目";
            // 
            // grcShop
            // 
            this.grcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShop.Location = new System.Drawing.Point(0, 0);
            this.grcShop.MainView = this.grvShop;
            this.grcShop.Name = "grcShop";
            this.grcShop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboSaleBigAreaInGrid,
            this.repositoryItemCheckEdit1,
            this.cboAfterBigAreaInGrid});
            this.grcShop.Size = new System.Drawing.Size(484, 607);
            this.grcShop.TabIndex = 13;
            this.grcShop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShop});
            // 
            // grvShop
            // 
            this.grvShop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcShopCode,
            this.gcShopName,
            this.gcSaleBigArea,
            this.gcSaleSmallArea,
            this.gcAfterBigArea,
            this.gcAfterSmall,
            this.gcUseChk});
            this.grvShop.GridControl = this.grcShop;
            this.grvShop.Name = "grvShop";
            this.grvShop.OptionsView.ShowGroupPanel = false;
            // 
            // gcShopCode
            // 
            this.gcShopCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopCode.Caption = "经销商代码";
            this.gcShopCode.FieldName = "ShopCode";
            this.gcShopCode.Name = "gcShopCode";
            this.gcShopCode.Visible = true;
            this.gcShopCode.VisibleIndex = 0;
            // 
            // gcShopName
            // 
            this.gcShopName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopName.Caption = "经销商名称";
            this.gcShopName.FieldName = "ShopName";
            this.gcShopName.Name = "gcShopName";
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 1;
            // 
            // gcSaleBigArea
            // 
            this.gcSaleBigArea.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSaleBigArea.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSaleBigArea.Caption = "销售大区";
            this.gcSaleBigArea.ColumnEdit = this.cboSaleBigAreaInGrid;
            this.gcSaleBigArea.FieldName = "SaleBig";
            this.gcSaleBigArea.Name = "gcSaleBigArea";
            // 
            // cboSaleBigAreaInGrid
            // 
            this.cboSaleBigAreaInGrid.AutoHeight = false;
            this.cboSaleBigAreaInGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSaleBigAreaInGrid.Name = "cboSaleBigAreaInGrid";
            // 
            // gcSaleSmallArea
            // 
            this.gcSaleSmallArea.Caption = "销售小区";
            this.gcSaleSmallArea.FieldName = "SaleSmall";
            this.gcSaleSmallArea.Name = "gcSaleSmallArea";
            // 
            // gcAfterBigArea
            // 
            this.gcAfterBigArea.Caption = "售后大区";
            this.gcAfterBigArea.ColumnEdit = this.cboAfterBigAreaInGrid;
            this.gcAfterBigArea.FieldName = "AfterBig";
            this.gcAfterBigArea.Name = "gcAfterBigArea";
            // 
            // cboAfterBigAreaInGrid
            // 
            this.cboAfterBigAreaInGrid.AutoHeight = false;
            this.cboAfterBigAreaInGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAfterBigAreaInGrid.Name = "cboAfterBigAreaInGrid";
            // 
            // gcAfterSmall
            // 
            this.gcAfterSmall.Caption = "售后小区";
            this.gcAfterSmall.FieldName = "AfterSmall";
            this.gcAfterSmall.Name = "gcAfterSmall";
            // 
            // gcUseChk
            // 
            this.gcUseChk.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUseChk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUseChk.Caption = "使用与否";
            this.gcUseChk.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gcUseChk.FieldName = "UseChk";
            this.gcUseChk.Name = "gcUseChk";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(206, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "删除复审状态";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DeleteAnswerScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DeleteAnswerScore";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(998, 613);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigAreaInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigAreaInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShop;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleBigArea;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboSaleBigAreaInGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleSmallArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterBigArea;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAfterBigAreaInGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterSmall;
        private DevExpress.XtraGrid.Columns.GridColumn gcUseChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grcSubject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSubject;
        private DevExpress.XtraGrid.Columns.GridColumn gcChapter;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLinkName;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckPoint;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}