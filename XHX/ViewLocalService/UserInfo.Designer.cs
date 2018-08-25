namespace XHX.ViewLocalService
{
    partial class UserInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.cboRoleType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grcUserInfo = new DevExpress.XtraGrid.GridControl();
            this.grvUserInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPSW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPSW = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboRoleTypeInGrid = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcRoleTypeProgramID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboProgram = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleTypeInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.txtUserID);
            this.grdShop.Controls.Add(this.cboRoleType);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Controls.Add(this.labelControl5);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(728, 42);
            this.grdShop.TabIndex = 26;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(71, 14);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 2;
            // 
            // cboRoleType
            // 
            this.cboRoleType.Location = new System.Drawing.Point(236, 14);
            this.cboRoleType.Name = "cboRoleType";
            this.cboRoleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoleType.Size = new System.Drawing.Size(100, 21);
            this.cboRoleType.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(206, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "权限";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 17);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "用户ID";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(5, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(728, 5);
            this.labelControl1.TabIndex = 29;
            // 
            // grcUserInfo
            // 
            this.grcUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcUserInfo.Location = new System.Drawing.Point(5, 52);
            this.grcUserInfo.MainView = this.grvUserInfo;
            this.grcUserInfo.Name = "grcUserInfo";
            this.grcUserInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboProgram,
            this.cboRoleTypeInGrid,
            this.txtPSW});
            this.grcUserInfo.Size = new System.Drawing.Size(728, 395);
            this.grcUserInfo.TabIndex = 30;
            this.grcUserInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserInfo});
            // 
            // grvUserInfo
            // 
            this.grvUserInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcUserID,
            this.gcPSW,
            this.gcRoleType,
            this.gcRoleTypeProgramID,
            this.gridColumn1,
            this.gridColumn2});
            this.grvUserInfo.GridControl = this.grcUserInfo;
            this.grvUserInfo.Name = "grvUserInfo";
            this.grvUserInfo.OptionsView.ColumnAutoWidth = false;
            this.grvUserInfo.OptionsView.ShowGroupPanel = false;
            // 
            // gcUserID
            // 
            this.gcUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUserID.Caption = "用户ID";
            this.gcUserID.FieldName = "UserID";
            this.gcUserID.Name = "gcUserID";
            this.gcUserID.OptionsColumn.AllowSize = false;
            this.gcUserID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcUserID.Visible = true;
            this.gcUserID.VisibleIndex = 0;
            this.gcUserID.Width = 131;
            // 
            // gcPSW
            // 
            this.gcPSW.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPSW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPSW.Caption = "密码";
            this.gcPSW.ColumnEdit = this.txtPSW;
            this.gcPSW.FieldName = "PSW";
            this.gcPSW.Name = "gcPSW";
            this.gcPSW.Visible = true;
            this.gcPSW.VisibleIndex = 1;
            this.gcPSW.Width = 121;
            // 
            // txtPSW
            // 
            this.txtPSW.AutoHeight = false;
            this.txtPSW.Mask.EditMask = "[a-z0-9~!@#$%^&*]{0,20}";
            this.txtPSW.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPSW.Mask.ShowPlaceHolders = false;
            this.txtPSW.Name = "txtPSW";
            // 
            // gcRoleType
            // 
            this.gcRoleType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcRoleType.Caption = "权限";
            this.gcRoleType.ColumnEdit = this.cboRoleTypeInGrid;
            this.gcRoleType.FieldName = "RoleType";
            this.gcRoleType.Name = "gcRoleType";
            this.gcRoleType.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcRoleType.Visible = true;
            this.gcRoleType.VisibleIndex = 2;
            this.gcRoleType.Width = 120;
            // 
            // cboRoleTypeInGrid
            // 
            this.cboRoleTypeInGrid.AutoHeight = false;
            this.cboRoleTypeInGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoleTypeInGrid.Name = "cboRoleTypeInGrid";
            // 
            // gcRoleTypeProgramID
            // 
            this.gcRoleTypeProgramID.Caption = "gridColumn2";
            this.gcRoleTypeProgramID.FieldName = "RoleTypeProgramID";
            this.gcRoleTypeProgramID.Name = "gcRoleTypeProgramID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "用户姓名";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // cboProgram
            // 
            this.cboProgram.AutoHeight = false;
            this.cboProgram.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProgram.Name = "cboProgram";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mac 地址";
            this.gridColumn2.FieldName = "MacAddress";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcUserInfo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdShop);
            this.Name = "UserInfo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(738, 452);
            this.Load += new System.EventHandler(this.UserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleTypeInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProgram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoleType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grcUserInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserID;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoleType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboRoleTypeInGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoleTypeProgramID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboProgram;
        private DevExpress.XtraGrid.Columns.GridColumn gcPSW;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtPSW;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
