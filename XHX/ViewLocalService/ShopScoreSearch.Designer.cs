namespace XHX.ViewLocalService
{
    partial class ShopScoreSearch
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkRecheck = new System.Windows.Forms.CheckBox();
            this.chkLoss = new System.Windows.Forms.CheckBox();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grcShopScore = new DevExpress.XtraGrid.GridControl();
            this.grvShopScore = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcSubjectCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcOrderNO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcCheckPoint = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.详细 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShopScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShopScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.chkAll);
            this.grdShop.Controls.Add(this.chkRecheck);
            this.grdShop.Controls.Add(this.chkLoss);
            this.grdShop.Controls.Add(this.txtShopName);
            this.grdShop.Controls.Add(this.btnShopCode);
            this.grdShop.Controls.Add(this.labelControl4);
            this.grdShop.Controls.Add(this.cboProject);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(980, 42);
            this.grdShop.TabIndex = 20;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(894, 14);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(42, 16);
            this.chkAll.TabIndex = 9;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkRecheck
            // 
            this.chkRecheck.AutoSize = true;
            this.chkRecheck.Location = new System.Drawing.Point(786, 14);
            this.chkRecheck.Name = "chkRecheck";
            this.chkRecheck.Size = new System.Drawing.Size(102, 16);
            this.chkRecheck.TabIndex = 8;
            this.chkRecheck.Text = "失分说明+复核";
            this.chkRecheck.UseVisualStyleBackColor = true;
            // 
            // chkLoss
            // 
            this.chkLoss.AutoSize = true;
            this.chkLoss.Location = new System.Drawing.Point(695, 14);
            this.chkLoss.Name = "chkLoss";
            this.chkLoss.Size = new System.Drawing.Size(72, 16);
            this.chkLoss.TabIndex = 7;
            this.chkLoss.Text = "失分说明";
            this.chkLoss.UseVisualStyleBackColor = true;
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(422, 14);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(238, 21);
            this.txtShopName.TabIndex = 6;
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(316, 14);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(100, 21);
            this.btnShopCode.TabIndex = 5;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(274, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "经销商";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(72, 14);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(100, 21);
            this.cboProject.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "项目";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(5, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(980, 5);
            this.labelControl2.TabIndex = 21;
            // 
            // grcShopScore
            // 
            this.grcShopScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShopScore.Location = new System.Drawing.Point(5, 52);
            this.grcShopScore.MainView = this.grvShopScore;
            this.grcShopScore.Name = "grcShopScore";
            this.grcShopScore.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk,
            this.repositoryItemButtonEdit1});
            this.grcShopScore.Size = new System.Drawing.Size(980, 525);
            this.grcShopScore.TabIndex = 22;
            this.grcShopScore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShopScore});
            // 
            // grvShopScore
            // 
            this.grvShopScore.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand3,
            this.gridBand2,
            this.gridBand4});
            this.grvShopScore.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gcSubjectCode,
            this.gcCheckPoint,
            this.gcOrderNO,
            this.详细});
            this.grvShopScore.GridControl = this.grcShopScore;
            this.grvShopScore.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvShopScore.Name = "grvShopScore";
            this.grvShopScore.OptionsView.ColumnAutoWidth = false;
            this.grvShopScore.OptionsView.ShowGroupPanel = false;
            this.grvShopScore.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvShopScore_CustomDrawCell);
            this.grvShopScore.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvShopScore_ShowingEditor);
            this.grvShopScore.DoubleClick += new System.EventHandler(this.grvShopScore_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand1.Caption = "题号";
            this.gridBand1.Columns.Add(this.gcSubjectCode);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 75;
            // 
            // gcSubjectCode
            // 
            this.gcSubjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectCode.FieldName = "SubjectCode";
            this.gcSubjectCode.Name = "gcSubjectCode";
            this.gcSubjectCode.OptionsColumn.AllowSize = false;
            this.gcSubjectCode.OptionsColumn.ShowCaption = false;
            this.gcSubjectCode.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "执行序号";
            this.gridBand3.Columns.Add(this.gcOrderNO);
            this.gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 75;
            // 
            // gcOrderNO
            // 
            this.gcOrderNO.FieldName = "SubjectOrderNO";
            this.gcOrderNO.Name = "gcOrderNO";
            this.gcOrderNO.OptionsColumn.ShowCaption = false;
            this.gcOrderNO.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "检查点";
            this.gridBand2.Columns.Add(this.gcCheckPoint);
            this.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowSize = false;
            this.gridBand2.Width = 150;
            // 
            // gcCheckPoint
            // 
            this.gcCheckPoint.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCheckPoint.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCheckPoint.Caption = "\"\"";
            this.gcCheckPoint.FieldName = "CheckPoint";
            this.gcCheckPoint.Name = "gcCheckPoint";
            this.gcCheckPoint.OptionsColumn.AllowSize = false;
            this.gcCheckPoint.OptionsColumn.ShowCaption = false;
            this.gcCheckPoint.Visible = true;
            this.gcCheckPoint.Width = 150;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "详细";
            this.gridBand4.Columns.Add(this.详细);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            this.gridBand4.Width = 75;
            // 
            // 详细
            // 
            this.详细.AppearanceHeader.Options.UseTextOptions = true;
            this.详细.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.详细.Caption = "详细";
            this.详细.ColumnEdit = this.repositoryItemButtonEdit1;
            this.详细.Name = "详细";
            this.详细.Visible = true;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
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
            // ShopScoreSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcShopScore);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Name = "ShopScoreSearch";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(990, 582);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShopScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShopScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grcShopScore;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvShopScore;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSubjectCode;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcCheckPoint;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.CheckBox chkRecheck;
        private System.Windows.Forms.CheckBox chkLoss;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcOrderNO;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 详细;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private System.Windows.Forms.CheckBox chkAll;

    }
}