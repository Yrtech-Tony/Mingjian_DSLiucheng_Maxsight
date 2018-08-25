namespace XHX.ViewLocalService
{
    partial class Shop_Popup
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.grcShop = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSaleSmall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSaleBig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAfterSmall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAfterBig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUseChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.txtShopCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtShop = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShop.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.panelControl1.Size = new System.Drawing.Size(691, 48);
            this.panelControl1.TabIndex = 8;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfirm.Location = new System.Drawing.Point(570, 16);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(106, 27);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(454, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 27);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grcShop
            // 
            this.grcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShop.Location = new System.Drawing.Point(0, 96);
            this.grcShop.MainView = this.gridView1;
            this.grcShop.Name = "grcShop";
            this.grcShop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcShop.Size = new System.Drawing.Size(691, 514);
            this.grcShop.TabIndex = 15;
            this.grcShop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcShopCode,
            this.gcShopName,
            this.gcSaleSmall,
            this.gcSaleBig,
            this.gcAfterSmall,
            this.gcAfterBig,
            this.gcUseChk});
            this.gridView1.GridControl = this.grcShop;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gcShopCode
            // 
            this.gcShopCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopCode.Caption = "经销商代码";
            this.gcShopCode.FieldName = "ShopCode";
            this.gcShopCode.Name = "gcShopCode";
            this.gcShopCode.OptionsColumn.AllowEdit = false;
            this.gcShopCode.OptionsColumn.AllowSize = false;
            this.gcShopCode.OptionsColumn.ReadOnly = true;
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
            this.gcShopName.OptionsColumn.AllowEdit = false;
            this.gcShopName.OptionsColumn.AllowSize = false;
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 1;
            // 
            // gcSaleSmall
            // 
            this.gcSaleSmall.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSaleSmall.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSaleSmall.Caption = "销售小区";
            this.gcSaleSmall.FieldName = "SaleSmall";
            this.gcSaleSmall.Name = "gcSaleSmall";
            this.gcSaleSmall.OptionsColumn.AllowEdit = false;
            this.gcSaleSmall.OptionsColumn.AllowSize = false;
            this.gcSaleSmall.Visible = true;
            this.gcSaleSmall.VisibleIndex = 2;
            // 
            // gcSaleBig
            // 
            this.gcSaleBig.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSaleBig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSaleBig.Caption = "销售大区";
            this.gcSaleBig.FieldName = "SaleBig";
            this.gcSaleBig.Name = "gcSaleBig";
            this.gcSaleBig.OptionsColumn.AllowEdit = false;
            this.gcSaleBig.Visible = true;
            this.gcSaleBig.VisibleIndex = 3;
            // 
            // gcAfterSmall
            // 
            this.gcAfterSmall.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAfterSmall.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAfterSmall.Caption = "售后小区";
            this.gcAfterSmall.FieldName = "AfterSmall";
            this.gcAfterSmall.Name = "gcAfterSmall";
            this.gcAfterSmall.OptionsColumn.AllowEdit = false;
            this.gcAfterSmall.Visible = true;
            this.gcAfterSmall.VisibleIndex = 4;
            // 
            // gcAfterBig
            // 
            this.gcAfterBig.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAfterBig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAfterBig.Caption = "售后大区";
            this.gcAfterBig.FieldName = "AfterBig";
            this.gcAfterBig.Name = "gcAfterBig";
            this.gcAfterBig.OptionsColumn.AllowEdit = false;
            this.gcAfterBig.Visible = true;
            this.gcAfterBig.VisibleIndex = 5;
            // 
            // gcUseChk
            // 
            this.gcUseChk.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUseChk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUseChk.Caption = "使用与否";
            this.gcUseChk.ColumnEdit = this.chkUseChk;
            this.gcUseChk.FieldName = "UseChk";
            this.gcUseChk.Name = "gcUseChk";
            this.gcUseChk.OptionsColumn.AllowEdit = false;
            this.gcUseChk.OptionsColumn.AllowSize = false;
            // 
            // chkUseChk
            // 
            this.chkUseChk.AutoHeight = false;
            this.chkUseChk.Name = "chkUseChk";
            // 
            // cboAreaCode
            // 
            this.cboAreaCode.AutoHeight = false;
            this.cboAreaCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreaCode.Name = "cboAreaCode";
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtShopCode);
            this.grdShop.Controls.Add(this.labelControl1);
            this.grdShop.Controls.Add(this.txtShop);
            this.grdShop.Controls.Add(this.labelControl4);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(0, 48);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(691, 48);
            this.grdShop.TabIndex = 14;
            // 
            // txtShopCode
            // 
            this.txtShopCode.Location = new System.Drawing.Point(88, 14);
            this.txtShopCode.Name = "txtShopCode";
            this.txtShopCode.Size = new System.Drawing.Size(151, 21);
            this.txtShopCode.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "经销商代码";
            // 
            // txtShop
            // 
            this.txtShop.Location = new System.Drawing.Point(328, 14);
            this.txtShop.Name = "txtShop";
            this.txtShop.Size = new System.Drawing.Size(255, 21);
            this.txtShop.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(262, 18);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "经销商名称";
            // 
            // Shop_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 610);
            this.Controls.Add(this.grcShop);
            this.Controls.Add(this.grdShop);
            this.Controls.Add(this.panelControl1);
            this.Name = "Shop_Popup";
            this.Text = "Shop_Popup";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShop.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleSmall;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcUseChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.TextEdit txtShop;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.TextEdit txtShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleBig;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterSmall;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterBig;


    }
}