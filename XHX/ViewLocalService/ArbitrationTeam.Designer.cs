namespace XHX.ViewLocalService
{
    partial class ArbitrationTeam
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
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grcArbitrationTeamAlter = new DevExpress.XtraGrid.GridControl();
            this.grvArbitrationTeamAlter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrgScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReCheckType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReCheckTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPassReCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReCheckContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgreeCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAgreeCheck = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcAgreeReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAgreeReason = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcNewScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLastConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboArbitrationTeamAdvise = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcConfirmReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtConfirmReason = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcViewPic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnViewPic = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcArbitrationTeamAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArbitrationTeamAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgreeCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreeReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArbitrationTeamAdvise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(793, 14);
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
            this.dateStart.Location = new System.Drawing.Point(666, 14);
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
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(200, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "经销商";
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(244, 14);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(100, 21);
            this.btnShopCode.TabIndex = 7;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(627, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "日 期";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(775, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(9, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "~";
            // 
            // panelControl2
            // 
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
            this.panelControl2.Size = new System.Drawing.Size(1290, 42);
            this.panelControl2.TabIndex = 6;
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(350, 14);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(238, 21);
            this.txtShopName.TabIndex = 8;
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
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.grcArbitrationTeamAlter);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(5, 47);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1290, 474);
            this.panelControl3.TabIndex = 7;
            // 
            // grcArbitrationTeamAlter
            // 
            this.grcArbitrationTeamAlter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcArbitrationTeamAlter.Location = new System.Drawing.Point(2, 2);
            this.grcArbitrationTeamAlter.MainView = this.grvArbitrationTeamAlter;
            this.grcArbitrationTeamAlter.Name = "grcArbitrationTeamAlter";
            this.grcArbitrationTeamAlter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnView,
            this.cboAgreeCheck,
            this.txtAgreeReason,
            this.btnViewPic,
            this.cboArbitrationTeamAdvise,
            this.txtConfirmReason});
            this.grcArbitrationTeamAlter.Size = new System.Drawing.Size(1286, 470);
            this.grcArbitrationTeamAlter.TabIndex = 15;
            this.grcArbitrationTeamAlter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArbitrationTeamAlter});
            // 
            // grvArbitrationTeamAlter
            // 
            this.grvArbitrationTeamAlter.ActiveFilterEnabled = false;
            this.grvArbitrationTeamAlter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProjectCode,
            this.gcShopCode,
            this.gcShopName,
            this.gcSubjectCode,
            this.gcOrgScore,
            this.gcReCheckType,
            this.gcReCheckTypeCode,
            this.gcPassReCheck,
            this.gcReCheckContent,
            this.gcAgreeCheck,
            this.gcAgreeReason,
            this.gcNewScore,
            this.gcLastConfirm,
            this.gcConfirmReason,
            this.gridColumn1,
            this.gcViewPic,
            this.gcView,
            this.gcStatusCode});
            this.grvArbitrationTeamAlter.GridControl = this.grcArbitrationTeamAlter;
            this.grvArbitrationTeamAlter.Name = "grvArbitrationTeamAlter";
            this.grvArbitrationTeamAlter.OptionsView.ShowGroupPanel = false;
            this.grvArbitrationTeamAlter.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvArbitrationTeamAlter_ShowingEditor);
            // 
            // gcProjectCode
            // 
            this.gcProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcProjectCode.Caption = "项目";
            this.gcProjectCode.FieldName = "ProjectCode";
            this.gcProjectCode.Name = "gcProjectCode";
            this.gcProjectCode.OptionsColumn.ReadOnly = true;
            this.gcProjectCode.Width = 92;
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
            this.gcShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 0;
            this.gcShopName.Width = 120;
            // 
            // gcSubjectCode
            // 
            this.gcSubjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSubjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSubjectCode.Caption = "执行文件";
            this.gcSubjectCode.FieldName = "SubjectCode";
            this.gcSubjectCode.Name = "gcSubjectCode";
            this.gcSubjectCode.OptionsColumn.ReadOnly = true;
            this.gcSubjectCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcSubjectCode.Visible = true;
            this.gcSubjectCode.VisibleIndex = 1;
            this.gcSubjectCode.Width = 90;
            // 
            // gcOrgScore
            // 
            this.gcOrgScore.AppearanceCell.Options.UseTextOptions = true;
            this.gcOrgScore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcOrgScore.AppearanceHeader.Options.UseTextOptions = true;
            this.gcOrgScore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcOrgScore.Caption = "分数";
            this.gcOrgScore.FieldName = "OrgScore";
            this.gcOrgScore.Name = "gcOrgScore";
            this.gcOrgScore.Visible = true;
            this.gcOrgScore.VisibleIndex = 2;
            this.gcOrgScore.Width = 62;
            // 
            // gcReCheckType
            // 
            this.gcReCheckType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcReCheckType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcReCheckType.Caption = "审核区分";
            this.gcReCheckType.FieldName = "ReCheckType";
            this.gcReCheckType.Name = "gcReCheckType";
            this.gcReCheckType.Visible = true;
            this.gcReCheckType.VisibleIndex = 4;
            this.gcReCheckType.Width = 74;
            // 
            // gcReCheckTypeCode
            // 
            this.gcReCheckTypeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcReCheckTypeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcReCheckTypeCode.Caption = "ReCheckTypeCode";
            this.gcReCheckTypeCode.FieldName = "ReCheckTypeCode";
            this.gcReCheckTypeCode.Name = "gcReCheckTypeCode";
            this.gcReCheckTypeCode.Width = 138;
            // 
            // gcPassReCheck
            // 
            this.gcPassReCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPassReCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPassReCheck.Caption = "是否通过审核";
            this.gcPassReCheck.FieldName = "PassReCheck";
            this.gcPassReCheck.Name = "gcPassReCheck";
            this.gcPassReCheck.Visible = true;
            this.gcPassReCheck.VisibleIndex = 5;
            this.gcPassReCheck.Width = 83;
            // 
            // gcReCheckContent
            // 
            this.gcReCheckContent.AppearanceHeader.Options.UseTextOptions = true;
            this.gcReCheckContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcReCheckContent.Caption = "审核意见";
            this.gcReCheckContent.FieldName = "ReCheckContent";
            this.gcReCheckContent.Name = "gcReCheckContent";
            this.gcReCheckContent.Visible = true;
            this.gcReCheckContent.VisibleIndex = 6;
            this.gcReCheckContent.Width = 170;
            // 
            // gcAgreeCheck
            // 
            this.gcAgreeCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAgreeCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAgreeCheck.Caption = "执行组是否同意";
            this.gcAgreeCheck.ColumnEdit = this.cboAgreeCheck;
            this.gcAgreeCheck.FieldName = "AgreeCheck";
            this.gcAgreeCheck.Name = "gcAgreeCheck";
            this.gcAgreeCheck.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcAgreeCheck.Visible = true;
            this.gcAgreeCheck.VisibleIndex = 7;
            this.gcAgreeCheck.Width = 99;
            // 
            // cboAgreeCheck
            // 
            this.cboAgreeCheck.AutoHeight = false;
            this.cboAgreeCheck.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAgreeCheck.Name = "cboAgreeCheck";
            // 
            // gcAgreeReason
            // 
            this.gcAgreeReason.AppearanceHeader.Options.UseTextOptions = true;
            this.gcAgreeReason.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAgreeReason.Caption = "执行组理由";
            this.gcAgreeReason.ColumnEdit = this.txtAgreeReason;
            this.gcAgreeReason.FieldName = "AgreeReason";
            this.gcAgreeReason.Name = "gcAgreeReason";
            this.gcAgreeReason.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcAgreeReason.Visible = true;
            this.gcAgreeReason.VisibleIndex = 8;
            this.gcAgreeReason.Width = 120;
            // 
            // txtAgreeReason
            // 
            this.txtAgreeReason.Name = "txtAgreeReason";
            // 
            // gcNewScore
            // 
            this.gcNewScore.AppearanceCell.Options.UseTextOptions = true;
            this.gcNewScore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcNewScore.AppearanceHeader.Options.UseTextOptions = true;
            this.gcNewScore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcNewScore.Caption = "新分数";
            this.gcNewScore.FieldName = "NewScore";
            this.gcNewScore.Name = "gcNewScore";
            this.gcNewScore.Visible = true;
            this.gcNewScore.VisibleIndex = 3;
            this.gcNewScore.Width = 67;
            // 
            // gcLastConfirm
            // 
            this.gcLastConfirm.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLastConfirm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLastConfirm.Caption = "仲裁组意见";
            this.gcLastConfirm.ColumnEdit = this.cboArbitrationTeamAdvise;
            this.gcLastConfirm.FieldName = "LastConfirm";
            this.gcLastConfirm.Name = "gcLastConfirm";
            this.gcLastConfirm.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcLastConfirm.Visible = true;
            this.gcLastConfirm.VisibleIndex = 9;
            this.gcLastConfirm.Width = 76;
            // 
            // cboArbitrationTeamAdvise
            // 
            this.cboArbitrationTeamAdvise.AutoHeight = false;
            this.cboArbitrationTeamAdvise.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArbitrationTeamAdvise.Name = "cboArbitrationTeamAdvise";
            // 
            // gcConfirmReason
            // 
            this.gcConfirmReason.AppearanceHeader.Options.UseTextOptions = true;
            this.gcConfirmReason.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcConfirmReason.Caption = "仲裁组描述";
            this.gcConfirmReason.ColumnEdit = this.txtConfirmReason;
            this.gcConfirmReason.FieldName = "ConfirmReason";
            this.gcConfirmReason.Name = "gcConfirmReason";
            this.gcConfirmReason.Visible = true;
            this.gcConfirmReason.VisibleIndex = 10;
            this.gcConfirmReason.Width = 187;
            // 
            // txtConfirmReason
            // 
            this.txtConfirmReason.AutoHeight = false;
            this.txtConfirmReason.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtConfirmReason.Name = "txtConfirmReason";
            this.txtConfirmReason.ShowIcon = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "仲裁日期";
            this.gridColumn1.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "ConfirmDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 11;
            // 
            // gcViewPic
            // 
            this.gcViewPic.AppearanceHeader.Options.UseTextOptions = true;
            this.gcViewPic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcViewPic.Caption = "查看图片";
            this.gcViewPic.ColumnEdit = this.btnViewPic;
            this.gcViewPic.Name = "gcViewPic";
            this.gcViewPic.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gcViewPic.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcViewPic.Visible = true;
            this.gcViewPic.VisibleIndex = 12;
            this.gcViewPic.Width = 66;
            // 
            // btnViewPic
            // 
            this.btnViewPic.AutoHeight = false;
            this.btnViewPic.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnViewPic.Name = "btnViewPic";
            this.btnViewPic.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnViewPic.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnViewPic_ButtonClick);
            // 
            // gcView
            // 
            this.gcView.AppearanceHeader.Options.UseTextOptions = true;
            this.gcView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcView.Caption = "查看";
            this.gcView.ColumnEdit = this.btnView;
            this.gcView.Name = "gcView";
            this.gcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcView.Width = 61;
            // 
            // btnView
            // 
            this.btnView.AutoHeight = false;
            this.btnView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnView.Name = "btnView";
            this.btnView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gcStatusCode
            // 
            this.gcStatusCode.Caption = "StatusCode";
            this.gcStatusCode.FieldName = "StatusCode";
            this.gcStatusCode.Name = "gcStatusCode";
            // 
            // ArbitrationTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "ArbitrationTeam";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1300, 526);
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcArbitrationTeamAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArbitrationTeamAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgreeCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreeReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArbitrationTeamAdvise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grcArbitrationTeamAlter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArbitrationTeamAlter;
        private DevExpress.XtraGrid.Columns.GridColumn gcProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrgScore;
        private DevExpress.XtraGrid.Columns.GridColumn gcReCheckType;
        private DevExpress.XtraGrid.Columns.GridColumn gcReCheckTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPassReCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gcReCheckContent;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgreeCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAgreeCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgreeReason;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit txtAgreeReason;
        private DevExpress.XtraGrid.Columns.GridColumn gcNewScore;
        private DevExpress.XtraGrid.Columns.GridColumn gcLastConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn gcConfirmReason;
        private DevExpress.XtraGrid.Columns.GridColumn gcViewPic;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnViewPic;
        private DevExpress.XtraGrid.Columns.GridColumn gcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnView;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboArbitrationTeamAdvise;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtConfirmReason;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}