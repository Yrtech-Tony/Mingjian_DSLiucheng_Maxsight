namespace XHX.ViewLocalService
{
    partial class Shop
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
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAfterSmallArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboAfterBigArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboSaleSmallArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboSaleBigArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
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
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUseChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterSmallArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleSmallArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigAreaInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigAreaInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtShopName);
            this.grdShop.Controls.Add(this.labelControl4);
            this.grdShop.Controls.Add(this.cboAfterSmallArea);
            this.grdShop.Controls.Add(this.cboAfterBigArea);
            this.grdShop.Controls.Add(this.labelControl1);
            this.grdShop.Controls.Add(this.cboSaleSmallArea);
            this.grdShop.Controls.Add(this.cboSaleBigArea);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(988, 42);
            this.grdShop.TabIndex = 10;
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(731, 14);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(219, 21);
            this.txtShopName.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(660, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "经销商名称";
            // 
            // cboAfterSmallArea
            // 
            this.cboAfterSmallArea.Location = new System.Drawing.Point(532, 14);
            this.cboAfterSmallArea.Name = "cboAfterSmallArea";
            this.cboAfterSmallArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAfterSmallArea.Size = new System.Drawing.Size(100, 21);
            this.cboAfterSmallArea.TabIndex = 1;
            // 
            // cboAfterBigArea
            // 
            this.cboAfterBigArea.Location = new System.Drawing.Point(426, 14);
            this.cboAfterBigArea.Name = "cboAfterBigArea";
            this.cboAfterBigArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAfterBigArea.Size = new System.Drawing.Size(100, 21);
            this.cboAfterBigArea.TabIndex = 1;
            this.cboAfterBigArea.SelectedIndexChanged += new System.EventHandler(this.cboAfterBigArea_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(343, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "售后大区/小区";
            // 
            // cboSaleSmallArea
            // 
            this.cboSaleSmallArea.Location = new System.Drawing.Point(219, 14);
            this.cboSaleSmallArea.Name = "cboSaleSmallArea";
            this.cboSaleSmallArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSaleSmallArea.Size = new System.Drawing.Size(100, 21);
            this.cboSaleSmallArea.TabIndex = 1;
            // 
            // cboSaleBigArea
            // 
            this.cboSaleBigArea.Location = new System.Drawing.Point(113, 14);
            this.cboSaleBigArea.Name = "cboSaleBigArea";
            this.cboSaleBigArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSaleBigArea.Size = new System.Drawing.Size(100, 21);
            this.cboSaleBigArea.TabIndex = 1;
            this.cboSaleBigArea.SelectedIndexChanged += new System.EventHandler(this.cboSaleBigArea_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "销售大区/小区";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(5, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(988, 5);
            this.labelControl2.TabIndex = 11;
            // 
            // grcShop
            // 
            this.grcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShop.Location = new System.Drawing.Point(5, 52);
            this.grcShop.MainView = this.grvShop;
            this.grcShop.Name = "grcShop";
            this.grcShop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboSaleBigAreaInGrid,
            this.chkUseChk,
            this.cboAfterBigAreaInGrid});
            this.grcShop.Size = new System.Drawing.Size(988, 556);
            this.grcShop.TabIndex = 12;
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
            this.gridColumn2,
            this.gridColumn1,
            this.gcUseChk});
            this.grvShop.GridControl = this.grcShop;
            this.grvShop.Name = "grvShop";
            this.grvShop.OptionsView.ShowGroupPanel = false;
            this.grvShop.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvShop_CustomRowCellEdit);
            this.grvShop.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.grvShop.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
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
            this.gcSaleBigArea.Visible = true;
            this.gcSaleBigArea.VisibleIndex = 2;
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
            this.gcSaleSmallArea.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSaleSmallArea.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSaleSmallArea.Caption = "销售小区";
            this.gcSaleSmallArea.FieldName = "SaleSmall";
            this.gcSaleSmallArea.Name = "gcSaleSmallArea";
            this.gcSaleSmallArea.Visible = true;
            this.gcSaleSmallArea.VisibleIndex = 3;
            // 
            // gcAfterBigArea
            // 
            this.gcAfterBigArea.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAfterBigArea.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAfterBigArea.Caption = "售后大区";
            this.gcAfterBigArea.ColumnEdit = this.cboAfterBigAreaInGrid;
            this.gcAfterBigArea.FieldName = "AfterBig";
            this.gcAfterBigArea.Name = "gcAfterBigArea";
            this.gcAfterBigArea.Visible = true;
            this.gcAfterBigArea.VisibleIndex = 4;
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
            this.gcAfterSmall.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAfterSmall.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAfterSmall.Caption = "售后小区";
            this.gcAfterSmall.FieldName = "AfterSmall";
            this.gcAfterSmall.Name = "gcAfterSmall";
            this.gcAfterSmall.Visible = true;
            this.gcAfterSmall.VisibleIndex = 5;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "省份";
            this.gridColumn2.FieldName = "Province";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "城市";
            this.gridColumn1.FieldName = "City";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            // 
            // gcUseChk
            // 
            this.gcUseChk.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUseChk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUseChk.Caption = "使用与否";
            this.gcUseChk.ColumnEdit = this.chkUseChk;
            this.gcUseChk.FieldName = "UseChk";
            this.gcUseChk.Name = "gcUseChk";
            // 
            // chkUseChk
            // 
            this.chkUseChk.AutoHeight = false;
            this.chkUseChk.Name = "chkUseChk";
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grcShop);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Shop";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(998, 613);
            this.Load += new System.EventHandler(this.Shop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterSmallArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleSmallArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleBigAreaInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAfterBigAreaInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboSaleBigArea;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboSaleBigAreaInGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShop;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleBigArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUseChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.ComboBoxEdit cboAfterBigArea;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboSaleSmallArea;
        private DevExpress.XtraEditors.ComboBoxEdit cboAfterSmallArea;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAfterBigAreaInGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaleSmallArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterBigArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcAfterSmall;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;


    }
}