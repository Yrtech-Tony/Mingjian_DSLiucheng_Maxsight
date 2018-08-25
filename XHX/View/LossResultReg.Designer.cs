namespace XHX.View
{
    partial class LossResultReg
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
            this.grcLossReg = new DevExpress.XtraGrid.GridControl();
            this.grvLossReg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLossCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLossName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.lblLossDesc = new DevExpress.XtraEditors.LabelControl();
            this.txtLossDesc = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcLossReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLossReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcLossReg
            // 
            this.grcLossReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcLossReg.Location = new System.Drawing.Point(5, 56);
            this.grcLossReg.MainView = this.grvLossReg;
            this.grcLossReg.Name = "grcLossReg";
            this.grcLossReg.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcLossReg.Size = new System.Drawing.Size(978, 603);
            this.grcLossReg.TabIndex = 17;
            this.grcLossReg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLossReg});
            // 
            // grvLossReg
            // 
            this.grvLossReg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLossCode,
            this.gcLossName,
            this.gcInUserID,
            this.gcInDateTime});
            this.grvLossReg.GridControl = this.grcLossReg;
            this.grvLossReg.Name = "grvLossReg";
            this.grvLossReg.OptionsView.ColumnAutoWidth = false;
            this.grvLossReg.OptionsView.ShowGroupPanel = false;
            this.grvLossReg.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvLossReg_CustomDrawCell);
            this.grvLossReg.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvLossReg_ShowingEditor);
            // 
            // gcLossCode
            // 
            this.gcLossCode.AppearanceCell.Options.UseTextOptions = true;
            this.gcLossCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLossCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLossCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLossCode.Caption = "失分代码";
            this.gcLossCode.FieldName = "LossCode";
            this.gcLossCode.Name = "gcLossCode";
            this.gcLossCode.Width = 88;
            // 
            // gcLossName
            // 
            this.gcLossName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLossName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLossName.Caption = "失分说明";
            this.gcLossName.FieldName = "LossName";
            this.gcLossName.Name = "gcLossName";
            this.gcLossName.Visible = true;
            this.gcLossName.VisibleIndex = 0;
            this.gcLossName.Width = 419;
            // 
            // gcInUserID
            // 
            this.gcInUserID.AppearanceCell.Options.UseTextOptions = true;
            this.gcInUserID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInUserID.Caption = "添加者";
            this.gcInUserID.FieldName = "InUserID";
            this.gcInUserID.Name = "gcInUserID";
            this.gcInUserID.Visible = true;
            this.gcInUserID.VisibleIndex = 1;
            this.gcInUserID.Width = 152;
            // 
            // gcInDateTime
            // 
            this.gcInDateTime.AppearanceCell.Options.UseTextOptions = true;
            this.gcInDateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInDateTime.Caption = "添加时间";
            this.gcInDateTime.FieldName = "InDateTime";
            this.gcInDateTime.Name = "gcInDateTime";
            this.gcInDateTime.Visible = true;
            this.gcInDateTime.VisibleIndex = 2;
            this.gcInDateTime.Width = 156;
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
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(5, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(978, 5);
            this.labelControl2.TabIndex = 19;
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.lblLossDesc);
            this.grdShop.Controls.Add(this.txtLossDesc);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(978, 46);
            this.grdShop.TabIndex = 18;
            // 
            // lblLossDesc
            // 
            this.lblLossDesc.Location = new System.Drawing.Point(30, 18);
            this.lblLossDesc.Name = "lblLossDesc";
            this.lblLossDesc.Size = new System.Drawing.Size(48, 13);
            this.lblLossDesc.TabIndex = 2;
            this.lblLossDesc.Text = "失分说明";
            // 
            // txtLossDesc
            // 
            this.txtLossDesc.Location = new System.Drawing.Point(84, 15);
            this.txtLossDesc.Name = "txtLossDesc";
            this.txtLossDesc.Size = new System.Drawing.Size(219, 20);
            this.txtLossDesc.TabIndex = 3;
            // 
            // LossResultReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcLossReg);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Name = "LossResultReg";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(988, 664);
            ((System.ComponentModel.ISupportInitialize)(this.grcLossReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLossReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossDesc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcLossReg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLossReg;
        private DevExpress.XtraGrid.Columns.GridColumn gcLossCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLossName;
        private DevExpress.XtraGrid.Columns.GridColumn gcInUserID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraGrid.Columns.GridColumn gcInDateTime;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl lblLossDesc;
        private DevExpress.XtraEditors.TextEdit txtLossDesc;
    }
}