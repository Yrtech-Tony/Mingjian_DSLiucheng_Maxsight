namespace XHX.View
{
    partial class Area
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
            this.txtAreaName = new DevExpress.XtraEditors.TextEdit();
            this.lblAreaName = new DevExpress.XtraEditors.LabelControl();
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAreaCode = new DevExpress.XtraEditors.LabelControl();
            this.cboAreaType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblAreaType = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grcArea = new DevExpress.XtraGrid.GridControl();
            this.grvArea = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAreaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaTypeInGrid = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcAreaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpperArea = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaTypeInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtAreaName);
            this.grdShop.Controls.Add(this.lblAreaName);
            this.grdShop.Controls.Add(this.txtAreaCode);
            this.grdShop.Controls.Add(this.lblAreaCode);
            this.grdShop.Controls.Add(this.cboAreaType);
            this.grdShop.Controls.Add(this.lblAreaType);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(988, 42);
            this.grdShop.TabIndex = 10;
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(440, 14);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(91, 21);
            this.txtAreaName.TabIndex = 5;
            this.txtAreaName.Visible = false;
            // 
            // lblAreaName
            // 
            this.lblAreaName.Location = new System.Drawing.Point(386, 17);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(48, 14);
            this.lblAreaName.TabIndex = 4;
            this.lblAreaName.Text = "区域名称";
            this.lblAreaName.Visible = false;
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(264, 14);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(91, 21);
            this.txtAreaCode.TabIndex = 3;
            this.txtAreaCode.Visible = false;
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.Location = new System.Drawing.Point(210, 17);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(48, 14);
            this.lblAreaCode.TabIndex = 2;
            this.lblAreaCode.Text = "区域代码";
            this.lblAreaCode.Visible = false;
            // 
            // cboAreaType
            // 
            this.cboAreaType.Location = new System.Drawing.Point(84, 14);
            this.cboAreaType.Name = "cboAreaType";
            this.cboAreaType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreaType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAreaType.Size = new System.Drawing.Size(100, 21);
            this.cboAreaType.TabIndex = 1;
            // 
            // lblAreaType
            // 
            this.lblAreaType.Location = new System.Drawing.Point(30, 17);
            this.lblAreaType.Name = "lblAreaType";
            this.lblAreaType.Size = new System.Drawing.Size(48, 14);
            this.lblAreaType.TabIndex = 0;
            this.lblAreaType.Text = "区域类型";
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
            // grcArea
            // 
            this.grcArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcArea.Location = new System.Drawing.Point(5, 52);
            this.grcArea.MainView = this.grvArea;
            this.grcArea.Name = "grcArea";
            this.grcArea.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaTypeInGrid,
            this.repositoryItemTextEdit1});
            this.grcArea.Size = new System.Drawing.Size(988, 556);
            this.grcArea.TabIndex = 12;
            this.grcArea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArea});
            // 
            // grvArea
            // 
            this.grvArea.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcAreaType,
            this.gcAreaCode,
            this.gcAreaName,
            this.gcUpperArea});
            this.grvArea.GridControl = this.grcArea;
            this.grvArea.Name = "grvArea";
            this.grvArea.OptionsView.ShowGroupPanel = false;
            this.grvArea.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvArea_CustomRowCellEdit);
            // 
            // gcAreaType
            // 
            this.gcAreaType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAreaType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAreaType.Caption = "区域类型";
            this.gcAreaType.ColumnEdit = this.cboAreaTypeInGrid;
            this.gcAreaType.FieldName = "AreaTypeCode";
            this.gcAreaType.Name = "gcAreaType";
            this.gcAreaType.Visible = true;
            this.gcAreaType.VisibleIndex = 0;
            this.gcAreaType.Width = 160;
            // 
            // cboAreaTypeInGrid
            // 
            this.cboAreaTypeInGrid.AutoHeight = false;
            this.cboAreaTypeInGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreaTypeInGrid.Name = "cboAreaTypeInGrid";
            // 
            // gcAreaCode
            // 
            this.gcAreaCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAreaCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAreaCode.Caption = "区域代码";
            this.gcAreaCode.ColumnEdit = this.repositoryItemTextEdit1;
            this.gcAreaCode.FieldName = "AreaCode";
            this.gcAreaCode.Name = "gcAreaCode";
            this.gcAreaCode.Visible = true;
            this.gcAreaCode.VisibleIndex = 1;
            this.gcAreaCode.Width = 241;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "[a-zA-Z0-9]{2}";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit1.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit1.MaxLength = 2;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gcAreaName
            // 
            this.gcAreaName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAreaName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAreaName.Caption = "区域名称";
            this.gcAreaName.FieldName = "AreaName";
            this.gcAreaName.Name = "gcAreaName";
            this.gcAreaName.Visible = true;
            this.gcAreaName.VisibleIndex = 2;
            this.gcAreaName.Width = 277;
            // 
            // gcUpperArea
            // 
            this.gcUpperArea.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUpperArea.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUpperArea.Caption = "上级区域";
            this.gcUpperArea.FieldName = "UpperAreaCode";
            this.gcUpperArea.Name = "gcUpperArea";
            this.gcUpperArea.Visible = true;
            this.gcUpperArea.VisibleIndex = 3;
            this.gcUpperArea.Width = 289;
            // 
            // Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grcArea);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Area";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(998, 613);
            this.Load += new System.EventHandler(this.Shop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaTypeInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl lblAreaType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grcArea;
        private DevExpress.XtraEditors.ComboBoxEdit cboAreaType;
        private DevExpress.XtraEditors.LabelControl lblAreaCode;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaType;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaName;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpperArea;
        private DevExpress.XtraEditors.TextEdit txtAreaName;
        private DevExpress.XtraEditors.LabelControl lblAreaName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaTypeInGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;


    }
}