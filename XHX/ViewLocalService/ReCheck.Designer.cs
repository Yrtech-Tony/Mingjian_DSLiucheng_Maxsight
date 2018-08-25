namespace XHX.ViewLocalService
{
    partial class ReCheck
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
            this.grcReCheck = new DevExpress.XtraGrid.GridControl();
            this.grvReCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSubjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCheckPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReCheckChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcPicture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPicture = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.btnShopPopup = new DevExpress.XtraEditors.SimpleButton();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.txtShopCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcReCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcReCheck
            // 
            this.grcReCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcReCheck.Location = new System.Drawing.Point(5, 56);
            this.grcReCheck.MainView = this.grvReCheck;
            this.grcReCheck.Name = "grcReCheck";
            this.grcReCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkUseChk,
            this.btnPicture});
            this.grcReCheck.Size = new System.Drawing.Size(988, 603);
            this.grcReCheck.TabIndex = 17;
            this.grcReCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReCheck});
            // 
            // grvReCheck
            // 
            this.grvReCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSubjectCode,
            this.gcCheckPoint,
            this.gcScore,
            this.gcReCheckChk,
            this.gcPicture});
            this.grvReCheck.GridControl = this.grcReCheck;
            this.grvReCheck.Name = "grvReCheck";
            this.grvReCheck.OptionsView.ShowGroupPanel = false;
            // 
            // gcSubjectCode
            // 
            this.gcSubjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectCode.Caption = "题号";
            this.gcSubjectCode.FieldName = "SubjectCode";
            this.gcSubjectCode.Name = "gcSubjectCode";
            this.gcSubjectCode.OptionsColumn.AllowSize = false;
            this.gcSubjectCode.OptionsColumn.ReadOnly = true;
            this.gcSubjectCode.Visible = true;
            this.gcSubjectCode.VisibleIndex = 0;
            // 
            // gcCheckPoint
            // 
            this.gcCheckPoint.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCheckPoint.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCheckPoint.Caption = "题目";
            this.gcCheckPoint.FieldName = "CheckPoint";
            this.gcCheckPoint.Name = "gcCheckPoint";
            this.gcCheckPoint.OptionsColumn.AllowSize = false;
            this.gcCheckPoint.Visible = true;
            this.gcCheckPoint.VisibleIndex = 1;
            // 
            // gcScore
            // 
            this.gcScore.AppearanceHeader.Options.UseTextOptions = true;
            this.gcScore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcScore.Caption = "得分";
            this.gcScore.FieldName = "Score";
            this.gcScore.Name = "gcScore";
            this.gcScore.OptionsColumn.AllowSize = false;
            this.gcScore.Visible = true;
            this.gcScore.VisibleIndex = 2;
            // 
            // gcReCheckChk
            // 
            this.gcReCheckChk.AppearanceHeader.Options.UseTextOptions = true;
            this.gcReCheckChk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcReCheckChk.Caption = "复查与否";
            this.gcReCheckChk.ColumnEdit = this.chkUseChk;
            this.gcReCheckChk.FieldName = "ReCheckChk";
            this.gcReCheckChk.Name = "gcReCheckChk";
            this.gcReCheckChk.OptionsColumn.AllowSize = false;
            this.gcReCheckChk.Visible = true;
            this.gcReCheckChk.VisibleIndex = 3;
            // 
            // chkUseChk
            // 
            this.chkUseChk.AutoHeight = false;
            this.chkUseChk.Name = "chkUseChk";
            // 
            // gcPicture
            // 
            this.gcPicture.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPicture.Caption = "查看图片";
            this.gcPicture.ColumnEdit = this.btnPicture;
            this.gcPicture.Name = "gcPicture";
            this.gcPicture.Visible = true;
            this.gcPicture.VisibleIndex = 4;
            // 
            // btnPicture
            // 
            this.btnPicture.AutoHeight = false;
            this.btnPicture.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnPicture.Name = "btnPicture";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(5, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(988, 5);
            this.labelControl2.TabIndex = 16;
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.btnShopPopup);
            this.grdShop.Controls.Add(this.txtShopName);
            this.grdShop.Controls.Add(this.txtShopCode);
            this.grdShop.Controls.Add(this.labelControl4);
            this.grdShop.Controls.Add(this.cboProject);
            this.grdShop.Controls.Add(this.cboArea);
            this.grdShop.Controls.Add(this.labelControl5);
            this.grdShop.Controls.Add(this.labelControl3);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(988, 46);
            this.grdShop.TabIndex = 15;
            // 
            // btnShopPopup
            // 
            this.btnShopPopup.Location = new System.Drawing.Point(560, 15);
            this.btnShopPopup.Name = "btnShopPopup";
            this.btnShopPopup.Size = new System.Drawing.Size(23, 25);
            this.btnShopPopup.TabIndex = 4;
            this.btnShopPopup.Text = "...";
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(589, 15);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(116, 20);
            this.txtShopName.TabIndex = 3;
            // 
            // txtShopCode
            // 
            this.txtShopCode.Location = new System.Drawing.Point(438, 15);
            this.txtShopCode.Name = "txtShopCode";
            this.txtShopCode.Size = new System.Drawing.Size(116, 20);
            this.txtShopCode.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(376, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "经销商";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(60, 15);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Size = new System.Drawing.Size(100, 20);
            this.cboProject.TabIndex = 1;
            // 
            // cboArea
            // 
            this.cboArea.Location = new System.Drawing.Point(241, 15);
            this.cboArea.Name = "cboArea";
            this.cboArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArea.Size = new System.Drawing.Size(100, 20);
            this.cboArea.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "项目";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(195, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "大区";
            // 
            // ReCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grcReCheck);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdShop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReCheck";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(998, 664);
            ((System.ComponentModel.ISupportInitialize)(this.grcReCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcReCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckPoint;
        private DevExpress.XtraGrid.Columns.GridColumn gcScore;
        private DevExpress.XtraGrid.Columns.GridColumn gcReCheckChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.TextEdit txtShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboArea;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn gcPicture;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPicture;
        private DevExpress.XtraEditors.SimpleButton btnShopPopup;
        private DevExpress.XtraEditors.TextEdit txtShopName;

    }
}
