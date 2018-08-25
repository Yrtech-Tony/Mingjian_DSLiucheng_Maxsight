namespace XHX.ViewLocalService
{
    partial class SpecialCaseSearch
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
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtSubjectCode = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grcSpecialCase = new DevExpress.XtraGrid.GridControl();
            this.grvSpecialCase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCheckPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApplyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApplyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFinalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConfirmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConfirmId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcApplyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFinalAdvice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNeedVICoConfirmChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVICoAdvice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSpecialCaseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSpecialCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSpecialCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProjects
            // 
            this.cboProjects.Location = new System.Drawing.Point(72, 14);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjects.Size = new System.Drawing.Size(100, 21);
            this.cboProjects.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "项目名";
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(357, 14);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(147, 21);
            this.txtShopName.TabIndex = 8;
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(251, 14);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(100, 21);
            this.btnShopCode.TabIndex = 7;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(209, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "经销商";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(944, 14);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 21);
            this.dateEnd.TabIndex = 13;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(824, 14);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.dateStart.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Size = new System.Drawing.Size(100, 21);
            this.dateStart.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(781, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "日 期";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(930, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(9, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "~";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.txtSubjectCode);
            this.panelControl2.Controls.Add(this.dateEnd);
            this.panelControl2.Controls.Add(this.dateStart);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.btnShopCode);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtShopName);
            this.panelControl2.Controls.Add(this.cboProjects);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1219, 42);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(543, 18);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 20;
            this.labelControl6.Text = "体系定位号";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Location = new System.Drawing.Point(613, 16);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(121, 21);
            this.txtSubjectCode.TabIndex = 21;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.grcSpecialCase);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(5, 47);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1219, 552);
            this.panelControl3.TabIndex = 2;
            // 
            // grcSpecialCase
            // 
            this.grcSpecialCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSpecialCase.Location = new System.Drawing.Point(2, 7);
            this.grcSpecialCase.MainView = this.grvSpecialCase;
            this.grcSpecialCase.Name = "grcSpecialCase";
            this.grcSpecialCase.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnView});
            this.grcSpecialCase.Size = new System.Drawing.Size(1215, 543);
            this.grcSpecialCase.TabIndex = 15;
            this.grcSpecialCase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSpecialCase});
            // 
            // grvSpecialCase
            // 
            this.grvSpecialCase.ActiveFilterEnabled = false;
            this.grvSpecialCase.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProjectCode,
            this.gcShopCode,
            this.gcShopName,
            this.gcSubjectCode,
            this.gcCheckPoint,
            this.gcTitle,
            this.gcApplyDate,
            this.gcApplyId,
            this.gcFinalStatus,
            this.gcConfirmDate,
            this.gcConfirmId,
            this.gcView,
            this.gcApplyDesc,
            this.gcFinalAdvice,
            this.gcNeedVICoConfirmChk,
            this.gcVICoAdvice,
            this.gcSpecialCaseCode});
            this.grvSpecialCase.GridControl = this.grcSpecialCase;
            this.grvSpecialCase.Name = "grvSpecialCase";
            this.grvSpecialCase.OptionsView.ShowGroupPanel = false;
            this.grvSpecialCase.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvSpecialCase_ShowingEditor);
            // 
            // gcProjectCode
            // 
            this.gcProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcProjectCode.Caption = "项目";
            this.gcProjectCode.FieldName = "ProjectCode";
            this.gcProjectCode.Name = "gcProjectCode";
            this.gcProjectCode.OptionsColumn.ReadOnly = true;
            this.gcProjectCode.Visible = true;
            this.gcProjectCode.VisibleIndex = 0;
            this.gcProjectCode.Width = 61;
            // 
            // gcShopCode
            // 
            this.gcShopCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopCode.Caption = "ShopCode";
            this.gcShopCode.FieldName = "ShopCode";
            this.gcShopCode.Name = "gcShopCode";
            this.gcShopCode.OptionsColumn.ReadOnly = true;
            this.gcShopCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcShopCode.Width = 151;
            // 
            // gcShopName
            // 
            this.gcShopName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopName.Caption = "经销商";
            this.gcShopName.FieldName = "ShopName";
            this.gcShopName.Name = "gcShopName";
            this.gcShopName.OptionsColumn.ReadOnly = true;
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 1;
            this.gcShopName.Width = 102;
            // 
            // gcSubjectCode
            // 
            this.gcSubjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectCode.Caption = "体系定位号";
            this.gcSubjectCode.FieldName = "SubjectCode";
            this.gcSubjectCode.Name = "gcSubjectCode";
            this.gcSubjectCode.OptionsColumn.ReadOnly = true;
            this.gcSubjectCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcSubjectCode.Visible = true;
            this.gcSubjectCode.VisibleIndex = 2;
            this.gcSubjectCode.Width = 76;
            // 
            // gcCheckPoint
            // 
            this.gcCheckPoint.Caption = "检查点";
            this.gcCheckPoint.FieldName = "CheckPoint";
            this.gcCheckPoint.Name = "gcCheckPoint";
            this.gcCheckPoint.Visible = true;
            this.gcCheckPoint.VisibleIndex = 3;
            this.gcCheckPoint.Width = 95;
            // 
            // gcTitle
            // 
            this.gcTitle.AppearanceHeader.Options.UseTextOptions = true;
            this.gcTitle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcTitle.Caption = "标题";
            this.gcTitle.FieldName = "Title";
            this.gcTitle.Name = "gcTitle";
            this.gcTitle.Visible = true;
            this.gcTitle.VisibleIndex = 4;
            this.gcTitle.Width = 131;
            // 
            // gcApplyDate
            // 
            this.gcApplyDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcApplyDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcApplyDate.Caption = "申请日期";
            this.gcApplyDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gcApplyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcApplyDate.FieldName = "ApplyDate";
            this.gcApplyDate.Name = "gcApplyDate";
            this.gcApplyDate.Width = 83;
            // 
            // gcApplyId
            // 
            this.gcApplyId.AppearanceHeader.Options.UseTextOptions = true;
            this.gcApplyId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcApplyId.Caption = "申请者";
            this.gcApplyId.FieldName = "ApplyId";
            this.gcApplyId.Name = "gcApplyId";
            this.gcApplyId.Visible = true;
            this.gcApplyId.VisibleIndex = 10;
            this.gcApplyId.Width = 56;
            // 
            // gcFinalStatus
            // 
            this.gcFinalStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.gcFinalStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFinalStatus.Caption = "处理状态";
            this.gcFinalStatus.FieldName = "FinalStatus";
            this.gcFinalStatus.Name = "gcFinalStatus";
            this.gcFinalStatus.Visible = true;
            this.gcFinalStatus.VisibleIndex = 6;
            this.gcFinalStatus.Width = 78;
            // 
            // gcConfirmDate
            // 
            this.gcConfirmDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcConfirmDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcConfirmDate.Caption = "确认日期";
            this.gcConfirmDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gcConfirmDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcConfirmDate.FieldName = "ConfirmDate";
            this.gcConfirmDate.Name = "gcConfirmDate";
            this.gcConfirmDate.Width = 82;
            // 
            // gcConfirmId
            // 
            this.gcConfirmId.AppearanceHeader.Options.UseTextOptions = true;
            this.gcConfirmId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcConfirmId.Caption = "确认者";
            this.gcConfirmId.FieldName = "ConfirmId";
            this.gcConfirmId.Name = "gcConfirmId";
            this.gcConfirmId.Visible = true;
            this.gcConfirmId.VisibleIndex = 11;
            this.gcConfirmId.Width = 53;
            // 
            // gcView
            // 
            this.gcView.AppearanceHeader.Options.UseTextOptions = true;
            this.gcView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcView.Caption = "详细信息";
            this.gcView.ColumnEdit = this.btnView;
            this.gcView.Name = "gcView";
            this.gcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcView.Visible = true;
            this.gcView.VisibleIndex = 12;
            this.gcView.Width = 65;
            // 
            // btnView
            // 
            this.btnView.AutoHeight = false;
            this.btnView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnView.Name = "btnView";
            this.btnView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnView.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnView_ButtonClick);
            // 
            // gcApplyDesc
            // 
            this.gcApplyDesc.Caption = "说明";
            this.gcApplyDesc.FieldName = "ApplyDesc";
            this.gcApplyDesc.Name = "gcApplyDesc";
            this.gcApplyDesc.Visible = true;
            this.gcApplyDesc.VisibleIndex = 5;
            this.gcApplyDesc.Width = 108;
            // 
            // gcFinalAdvice
            // 
            this.gcFinalAdvice.Caption = "最终意见";
            this.gcFinalAdvice.FieldName = "FinalAdvice";
            this.gcFinalAdvice.Name = "gcFinalAdvice";
            this.gcFinalAdvice.Visible = true;
            this.gcFinalAdvice.VisibleIndex = 7;
            this.gcFinalAdvice.Width = 130;
            // 
            // gcNeedVICoConfirmChk
            // 
            this.gcNeedVICoConfirmChk.Caption = "是否需要厂家确认";
            this.gcNeedVICoConfirmChk.FieldName = "NeedVICoConfirmChk";
            this.gcNeedVICoConfirmChk.Name = "gcNeedVICoConfirmChk";
            this.gcNeedVICoConfirmChk.Visible = true;
            this.gcNeedVICoConfirmChk.VisibleIndex = 8;
            this.gcNeedVICoConfirmChk.Width = 108;
            // 
            // gcVICoAdvice
            // 
            this.gcVICoAdvice.Caption = "厂家意见";
            this.gcVICoAdvice.FieldName = "VICoAdvice";
            this.gcVICoAdvice.Name = "gcVICoAdvice";
            this.gcVICoAdvice.Visible = true;
            this.gcVICoAdvice.VisibleIndex = 9;
            this.gcVICoAdvice.Width = 131;
            // 
            // gcSpecialCaseCode
            // 
            this.gcSpecialCaseCode.Caption = "SpecialCaseCode";
            this.gcSpecialCaseCode.FieldName = "SpecialCaseCode";
            this.gcSpecialCaseCode.Name = "gcSpecialCaseCode";
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl5.Location = new System.Drawing.Point(2, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(1215, 5);
            this.labelControl5.TabIndex = 14;
            // 
            // SpecialCaseSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "SpecialCaseSearch";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1229, 604);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSpecialCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSpecialCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grcSpecialCase;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSpecialCase;
        private DevExpress.XtraGrid.Columns.GridColumn gcProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gcApplyDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcApplyId;
        private DevExpress.XtraGrid.Columns.GridColumn gcFinalStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcConfirmDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcConfirmId;
        private DevExpress.XtraGrid.Columns.GridColumn gcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnView;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn gcCheckPoint;
        private DevExpress.XtraGrid.Columns.GridColumn gcApplyDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcFinalAdvice;
        private DevExpress.XtraGrid.Columns.GridColumn gcNeedVICoConfirmChk;
        private DevExpress.XtraGrid.Columns.GridColumn gcVICoAdvice;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpecialCaseCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSubjectCode;
    }
}