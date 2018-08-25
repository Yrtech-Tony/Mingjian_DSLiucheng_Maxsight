namespace XHX.View
{
    partial class SingleShopReport_UploadData
    {
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAreaCharterSale = new DevExpress.XtraEditors.SimpleButton();
            this.btnCharterSale = new DevExpress.XtraEditors.SimpleButton();
            this.btnsaleContantSubject = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalesCharter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAreaSubject = new DevExpress.XtraEditors.SimpleButton();
            this.btnShopSubject = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnModule = new DevExpress.XtraEditors.ButtonEdit();
            this.btnShopCharter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAreaCharter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllCharter = new DevExpress.XtraEditors.SimpleButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnModule.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.checkBox1);
            this.grdShop.Controls.Add(this.labelControl1);
            this.grdShop.Controls.Add(this.cboProjects);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(982, 42);
            this.grdShop.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Location = new System.Drawing.Point(24, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "项目名";
            // 
            // cboProjects
            // 
            this.cboProjects.Location = new System.Drawing.Point(71, 12);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjects.Size = new System.Drawing.Size(100, 21);
            this.cboProjects.TabIndex = 12;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAreaCharterSale);
            this.groupControl2.Controls.Add(this.btnCharterSale);
            this.groupControl2.Controls.Add(this.btnsaleContantSubject);
            this.groupControl2.Controls.Add(this.btnSalesCharter);
            this.groupControl2.Controls.Add(this.btnAreaSubject);
            this.groupControl2.Controls.Add(this.btnShopSubject);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.btnModule);
            this.groupControl2.Controls.Add(this.btnShopCharter);
            this.groupControl2.Controls.Add(this.btnAreaCharter);
            this.groupControl2.Controls.Add(this.btnAllCharter);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(5, 47);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(982, 125);
            this.groupControl2.TabIndex = 92;
            // 
            // btnAreaCharterSale
            // 
            this.btnAreaCharterSale.Location = new System.Drawing.Point(485, 24);
            this.btnAreaCharterSale.Name = "btnAreaCharterSale";
            this.btnAreaCharterSale.Size = new System.Drawing.Size(109, 44);
            this.btnAreaCharterSale.TabIndex = 99;
            this.btnAreaCharterSale.Text = "区域环节销售得分";
            this.btnAreaCharterSale.Click += new System.EventHandler(this.btnAreaCharterSale_Click);
            // 
            // btnCharterSale
            // 
            this.btnCharterSale.Location = new System.Drawing.Point(364, 24);
            this.btnCharterSale.Name = "btnCharterSale";
            this.btnCharterSale.Size = new System.Drawing.Size(115, 45);
            this.btnCharterSale.TabIndex = 98;
            this.btnCharterSale.Text = "全国环节销售得分";
            this.btnCharterSale.Click += new System.EventHandler(this.btnCharterSale_Click);
            // 
            // btnsaleContantSubject
            // 
            this.btnsaleContantSubject.Location = new System.Drawing.Point(243, 66);
            this.btnsaleContantSubject.Name = "btnsaleContantSubject";
            this.btnsaleContantSubject.Size = new System.Drawing.Size(115, 45);
            this.btnsaleContantSubject.TabIndex = 97;
            this.btnsaleContantSubject.Text = "销售顾问体系得分";
            this.btnsaleContantSubject.Click += new System.EventHandler(this.btnsaleContantSubject_Click);
            // 
            // btnSalesCharter
            // 
            this.btnSalesCharter.Location = new System.Drawing.Point(122, 66);
            this.btnSalesCharter.Name = "btnSalesCharter";
            this.btnSalesCharter.Size = new System.Drawing.Size(115, 45);
            this.btnSalesCharter.TabIndex = 96;
            this.btnSalesCharter.Text = "销售顾问环节得分";
            this.btnSalesCharter.Click += new System.EventHandler(this.btnSalesCharter_Click);
            // 
            // btnAreaSubject
            // 
            this.btnAreaSubject.Location = new System.Drawing.Point(868, 66);
            this.btnAreaSubject.Name = "btnAreaSubject";
            this.btnAreaSubject.Size = new System.Drawing.Size(109, 44);
            this.btnAreaSubject.TabIndex = 95;
            this.btnAreaSubject.Text = "区域体系得分";
            this.btnAreaSubject.Click += new System.EventHandler(this.btnAreaSubject_Click);
            // 
            // btnShopSubject
            // 
            this.btnShopSubject.Location = new System.Drawing.Point(733, 66);
            this.btnShopSubject.Name = "btnShopSubject";
            this.btnShopSubject.Size = new System.Drawing.Size(129, 44);
            this.btnShopSubject.TabIndex = 94;
            this.btnShopSubject.Text = "经销商体系得分";
            this.btnShopSubject.Click += new System.EventHandler(this.btnShopSubject_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(12, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 93;
            this.labelControl2.Text = "模板路径";
            // 
            // btnModule
            // 
            this.btnModule.EditValue = "";
            this.btnModule.Location = new System.Drawing.Point(71, 24);
            this.btnModule.Name = "btnModule";
            this.btnModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnModule.Size = new System.Drawing.Size(287, 21);
            this.btnModule.TabIndex = 92;
            this.btnModule.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnModule_ButtonClick);
            // 
            // btnShopCharter
            // 
            this.btnShopCharter.Location = new System.Drawing.Point(597, 66);
            this.btnShopCharter.Name = "btnShopCharter";
            this.btnShopCharter.Size = new System.Drawing.Size(129, 44);
            this.btnShopCharter.TabIndex = 91;
            this.btnShopCharter.Text = "经销商环节得分";
            this.btnShopCharter.Click += new System.EventHandler(this.btnShopCharter_Click);
            // 
            // btnAreaCharter
            // 
            this.btnAreaCharter.Location = new System.Drawing.Point(482, 66);
            this.btnAreaCharter.Name = "btnAreaCharter";
            this.btnAreaCharter.Size = new System.Drawing.Size(109, 44);
            this.btnAreaCharter.TabIndex = 90;
            this.btnAreaCharter.Text = "区域环节得分";
            this.btnAreaCharter.Click += new System.EventHandler(this.btnAreaCharter_Click);
            // 
            // btnAllCharter
            // 
            this.btnAllCharter.Location = new System.Drawing.Point(361, 66);
            this.btnAllCharter.Name = "btnAllCharter";
            this.btnAllCharter.Size = new System.Drawing.Size(115, 45);
            this.btnAllCharter.TabIndex = 88;
            this.btnAllCharter.Text = "全国环节得分";
            this.btnAllCharter.Click += new System.EventHandler(this.btnAllCharter_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(280, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "上传到报告平台";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SingleShopReport_UploadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grdShop);
            this.Name = "SingleShopReport_UploadData";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(992, 555);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnModule.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAllCharter;
        private DevExpress.XtraEditors.SimpleButton btnAreaCharter;
        private DevExpress.XtraEditors.SimpleButton btnShopCharter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit btnModule;
        private DevExpress.XtraEditors.SimpleButton btnShopSubject;
        private DevExpress.XtraEditors.SimpleButton btnAreaSubject;
        private DevExpress.XtraEditors.SimpleButton btnSalesCharter;
        private DevExpress.XtraEditors.SimpleButton btnsaleContantSubject;
        private DevExpress.XtraEditors.SimpleButton btnAreaCharterSale;
        private DevExpress.XtraEditors.SimpleButton btnCharterSale;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
