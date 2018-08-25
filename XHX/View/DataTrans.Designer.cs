namespace XHX.View
{
    partial class DataTrans
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearbyShop = new DevExpress.XtraEditors.SimpleButton();
            this.btnShop = new DevExpress.XtraEditors.SimpleButton();
            this.btnDownLoadScoreData = new DevExpress.XtraEditors.SimpleButton();
            this.btnShop_Out = new DevExpress.XtraEditors.SimpleButton();
            this.btnMasterDataDownLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnswer_Out = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnswer = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.btnShopCode = new DevExpress.XtraEditors.ButtonEdit();
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl2.Size = new System.Drawing.Size(980, 45);
            this.panelControl2.TabIndex = 10;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.buttonEdit1);
            this.panelControl1.Controls.Add(this.txtShopName);
            this.panelControl1.Controls.Add(this.btnShopCode);
            this.panelControl1.Controls.Add(this.cboProjects);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(5, 50);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl1.Size = new System.Drawing.Size(980, 575);
            this.panelControl1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearbyShop);
            this.panel1.Controls.Add(this.btnShop);
            this.panel1.Controls.Add(this.btnDownLoadScoreData);
            this.panel1.Controls.Add(this.btnShop_Out);
            this.panel1.Controls.Add(this.btnMasterDataDownLoad);
            this.panel1.Controls.Add(this.btnAnswer_Out);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnAnswer);
            this.panel1.Location = new System.Drawing.Point(285, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 226);
            this.panel1.TabIndex = 28;
            // 
            // btnClearbyShop
            // 
            this.btnClearbyShop.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClearbyShop.Location = new System.Drawing.Point(135, 128);
            this.btnClearbyShop.Margin = new System.Windows.Forms.Padding(10);
            this.btnClearbyShop.Name = "btnClearbyShop";
            this.btnClearbyShop.Size = new System.Drawing.Size(106, 25);
            this.btnClearbyShop.TabIndex = 20;
            this.btnClearbyShop.Text = "清除数据";
            this.btnClearbyShop.Visible = false;
            this.btnClearbyShop.Click += new System.EventHandler(this.btnClearbyShop_Click);
            // 
            // btnShop
            // 
            this.btnShop.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnShop.Location = new System.Drawing.Point(19, 94);
            this.btnShop.Margin = new System.Windows.Forms.Padding(10);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(96, 25);
            this.btnShop.TabIndex = 8;
            this.btnShop.Text = "基础数据导入";
            this.btnShop.Visible = false;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // btnDownLoadScoreData
            // 
            this.btnDownLoadScoreData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDownLoadScoreData.Location = new System.Drawing.Point(135, 159);
            this.btnDownLoadScoreData.Margin = new System.Windows.Forms.Padding(10);
            this.btnDownLoadScoreData.Name = "btnDownLoadScoreData";
            this.btnDownLoadScoreData.Size = new System.Drawing.Size(96, 25);
            this.btnDownLoadScoreData.TabIndex = 26;
            this.btnDownLoadScoreData.Text = "下载得分数据";
            this.btnDownLoadScoreData.Click += new System.EventHandler(this.btnDownLoadScoreData_Click);
            // 
            // btnShop_Out
            // 
            this.btnShop_Out.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnShop_Out.Location = new System.Drawing.Point(135, 94);
            this.btnShop_Out.Margin = new System.Windows.Forms.Padding(10);
            this.btnShop_Out.Name = "btnShop_Out";
            this.btnShop_Out.Size = new System.Drawing.Size(106, 25);
            this.btnShop_Out.TabIndex = 8;
            this.btnShop_Out.Text = "基础数据导出";
            this.btnShop_Out.Click += new System.EventHandler(this.btnShop_Out_Click);
            // 
            // btnMasterDataDownLoad
            // 
            this.btnMasterDataDownLoad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMasterDataDownLoad.Location = new System.Drawing.Point(19, 159);
            this.btnMasterDataDownLoad.Margin = new System.Windows.Forms.Padding(10);
            this.btnMasterDataDownLoad.Name = "btnMasterDataDownLoad";
            this.btnMasterDataDownLoad.Size = new System.Drawing.Size(96, 25);
            this.btnMasterDataDownLoad.TabIndex = 25;
            this.btnMasterDataDownLoad.Text = "下载基础数据";
            this.btnMasterDataDownLoad.Click += new System.EventHandler(this.btnMasterDataDownLoad_Click);
            // 
            // btnAnswer_Out
            // 
            this.btnAnswer_Out.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAnswer_Out.Location = new System.Drawing.Point(135, 59);
            this.btnAnswer_Out.Margin = new System.Windows.Forms.Padding(10);
            this.btnAnswer_Out.Name = "btnAnswer_Out";
            this.btnAnswer_Out.Size = new System.Drawing.Size(106, 25);
            this.btnAnswer_Out.TabIndex = 12;
            this.btnAnswer_Out.Text = "得分导出";
            this.btnAnswer_Out.Click += new System.EventHandler(this.btnAnswer_Out_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Location = new System.Drawing.Point(19, 128);
            this.btnClear.Margin = new System.Windows.Forms.Padding(10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 25);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清空测试数据";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAnswer.Location = new System.Drawing.Point(19, 59);
            this.btnAnswer.Margin = new System.Windows.Forms.Padding(10);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(96, 25);
            this.btnAnswer.TabIndex = 11;
            this.btnAnswer.Text = "得分导入";
            this.btnAnswer.Visible = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.EditValue = "";
            this.buttonEdit1.Location = new System.Drawing.Point(236, 56);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(340, 20);
            this.buttonEdit1.TabIndex = 27;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // txtShopName
            // 
            this.txtShopName.Enabled = false;
            this.txtShopName.Location = new System.Drawing.Point(338, 30);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(238, 20);
            this.txtShopName.TabIndex = 16;
            // 
            // btnShopCode
            // 
            this.btnShopCode.EditValue = "";
            this.btnShopCode.Location = new System.Drawing.Point(236, 29);
            this.btnShopCode.Name = "btnShopCode";
            this.btnShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnShopCode.Size = new System.Drawing.Size(100, 20);
            this.btnShopCode.TabIndex = 15;
            this.btnShopCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnShopCode_ButtonClick);
            // 
            // cboProjects
            // 
            this.cboProjects.Location = new System.Drawing.Point(76, 25);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjects.Size = new System.Drawing.Size(100, 20);
            this.cboProjects.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(194, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "经销商";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "项目名";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(182, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "图片路径";
            // 
            // DataTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "DataTrans";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(990, 630);
            this.Load += new System.EventHandler(this.DataTrans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.ButtonEdit btnShopCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClearbyShop;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnAnswer;
        private DevExpress.XtraEditors.SimpleButton btnAnswer_Out;
        private DevExpress.XtraEditors.SimpleButton btnShop;
        private DevExpress.XtraEditors.SimpleButton btnShop_Out;
        private DevExpress.XtraEditors.SimpleButton btnDownLoadScoreData;
        private DevExpress.XtraEditors.SimpleButton btnMasterDataDownLoad;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}