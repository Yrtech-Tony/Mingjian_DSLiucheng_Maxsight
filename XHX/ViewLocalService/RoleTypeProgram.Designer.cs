namespace XHX.ViewLocalService
{
    partial class RoleTypeProgram
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
            this.cboRoleType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grcRoleTypeProgram = new DevExpress.XtraGrid.GridControl();
            this.grvRoleTypeProgram = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboRoleTypeInGrid = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboProgram = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRoleTypeProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRoleTypeProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleTypeInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.cboRoleType);
            this.grdShop.Controls.Add(this.labelControl5);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(728, 46);
            this.grdShop.TabIndex = 26;
            // 
            // cboRoleType
            // 
            this.cboRoleType.Location = new System.Drawing.Point(60, 15);
            this.cboRoleType.Name = "cboRoleType";
            this.cboRoleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoleType.Size = new System.Drawing.Size(100, 20);
            this.cboRoleType.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "权限";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(5, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(728, 5);
            this.labelControl2.TabIndex = 30;
            // 
            // grcRoleTypeProgram
            // 
            this.grcRoleTypeProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcRoleTypeProgram.Location = new System.Drawing.Point(5, 56);
            this.grcRoleTypeProgram.MainView = this.grvRoleTypeProgram;
            this.grcRoleTypeProgram.Name = "grcRoleTypeProgram";
            this.grcRoleTypeProgram.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboProgram,
            this.cboRoleTypeInGrid});
            this.grcRoleTypeProgram.Size = new System.Drawing.Size(728, 429);
            this.grcRoleTypeProgram.TabIndex = 32;
            this.grcRoleTypeProgram.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRoleTypeProgram});
            // 
            // grvRoleTypeProgram
            // 
            this.grvRoleTypeProgram.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2});
            this.grvRoleTypeProgram.GridControl = this.grcRoleTypeProgram;
            this.grvRoleTypeProgram.Name = "grvRoleTypeProgram";
            this.grvRoleTypeProgram.OptionsView.ColumnAutoWidth = false;
            this.grvRoleTypeProgram.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "权限";
            this.gridColumn5.ColumnEdit = this.cboRoleTypeInGrid;
            this.gridColumn5.FieldName = "RoleTypeCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 120;
            // 
            // cboRoleTypeInGrid
            // 
            this.cboRoleTypeInGrid.AutoHeight = false;
            this.cboRoleTypeInGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoleTypeInGrid.Name = "cboRoleTypeInGrid";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "页面";
            this.gridColumn1.ColumnEdit = this.cboProgram;
            this.gridColumn1.FieldName = "ProgramCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 131;
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
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "RoleTypeProgramID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // RoleTypeProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcRoleTypeProgram);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Name = "RoleTypeProgram";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(738, 490);
            this.Load += new System.EventHandler(this.RoleTypeProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRoleTypeProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRoleTypeProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleTypeInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProgram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoleType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grcRoleTypeProgram;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRoleTypeProgram;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboRoleTypeInGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboProgram;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
