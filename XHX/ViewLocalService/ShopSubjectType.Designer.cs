namespace XHX.ViewLocalService
{
    partial class ShopSubjectType
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
            this.grcShop = new DevExpress.XtraGrid.GridControl();
            this.grvShop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubjectType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboSubjectTypeExam = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.gcCheckUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubjectTypeExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcShop
            // 
            this.grcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShop.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcShop.Location = new System.Drawing.Point(5, 57);
            this.grcShop.MainView = this.grvShop;
            this.grcShop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcShop.Name = "grcShop";
            this.grcShop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboSubjectTypeExam,
            this.repositoryItemDateEdit1});
            this.grcShop.Size = new System.Drawing.Size(1321, 704);
            this.grcShop.TabIndex = 14;
            this.grcShop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShop});
            // 
            // grvShop
            // 
            this.grvShop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcShopCode,
            this.gcShopName,
            this.gcSubjectType,
            this.gcCheckUserId,
            this.gcCheckDate});
            this.grvShop.GridControl = this.grcShop;
            this.grvShop.Name = "grvShop";
            this.grvShop.OptionsView.ColumnAutoWidth = false;
            this.grvShop.OptionsView.ShowGroupPanel = false;
            // 
            // gcShopCode
            // 
            this.gcShopCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopCode.Caption = "经销商代码";
            this.gcShopCode.FieldName = "ShopCode";
            this.gcShopCode.Name = "gcShopCode";
            this.gcShopCode.OptionsColumn.AllowFocus = false;
            this.gcShopCode.Visible = true;
            this.gcShopCode.VisibleIndex = 0;
            this.gcShopCode.Width = 220;
            // 
            // gcShopName
            // 
            this.gcShopName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopName.Caption = "经销商名称";
            this.gcShopName.FieldName = "ShopName";
            this.gcShopName.Name = "gcShopName";
            this.gcShopName.OptionsColumn.AllowFocus = false;
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 1;
            this.gcShopName.Width = 345;
            // 
            // gcSubjectType
            // 
            this.gcSubjectType.AppearanceCell.Options.UseTextOptions = true;
            this.gcSubjectType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectType.Caption = "A/B卷";
            this.gcSubjectType.ColumnEdit = this.cboSubjectTypeExam;
            this.gcSubjectType.FieldName = "ExamTypeCode";
            this.gcSubjectType.Name = "gcSubjectType";
            this.gcSubjectType.Visible = true;
            this.gcSubjectType.VisibleIndex = 2;
            this.gcSubjectType.Width = 162;
            // 
            // cboSubjectTypeExam
            // 
            this.cboSubjectTypeExam.AutoHeight = false;
            this.cboSubjectTypeExam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSubjectTypeExam.Name = "cboSubjectTypeExam";
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtShopName);
            this.grdShop.Controls.Add(this.btnShopCode);
            this.grdShop.Controls.Add(this.labelControl2);
            this.grdShop.Controls.Add(this.cboProject);
            this.grdShop.Controls.Add(this.lblProject);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(1321, 52);
            this.grdShop.TabIndex = 13;
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(500, 14);
            this.txtShopName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(317, 25);
            this.txtShopName.TabIndex = 6;
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(359, 14);
            this.btnShopCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(133, 25);
            this.btnShopCode.TabIndex = 5;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(303, 18);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "经销商";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(84, 14);
            this.cboProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(133, 25);
            this.cboProject.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(40, 18);
            this.lblProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(30, 18);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "项目";
            // 
            // gcCheckUserId
            // 
            this.gcCheckUserId.Caption = "审核组长";
            this.gcCheckUserId.FieldName = "CheckUserId";
            this.gcCheckUserId.Name = "gcCheckUserId";
            this.gcCheckUserId.Visible = true;
            this.gcCheckUserId.VisibleIndex = 3;
            this.gcCheckUserId.Width = 100;
            // 
            // gcCheckDate
            // 
            this.gcCheckDate.Caption = "审核开始日期";
            this.gcCheckDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.gcCheckDate.FieldName = "CheckDate";
            this.gcCheckDate.Name = "gcCheckDate";
            this.gcCheckDate.Visible = true;
            this.gcCheckDate.VisibleIndex = 4;
            this.gcCheckDate.Width = 150;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ShopSubjectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcShop);
            this.Controls.Add(this.grdShop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShopSubjectType";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Size = new System.Drawing.Size(1331, 766);
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubjectTypeExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShop;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboSubjectTypeExam;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubjectType;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckUserId;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;

    }
}