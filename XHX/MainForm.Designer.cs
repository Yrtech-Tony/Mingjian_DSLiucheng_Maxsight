namespace XHX
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.cmsRightButtonClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbcPages = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.cmsRightButtonClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbcPages)).BeginInit();
            this.tbcPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsRightButtonClick
            // 
            this.cmsRightButtonClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiClose,
            this.smiCloseOther});
            this.cmsRightButtonClick.Name = "cmsRightButtonClick";
            this.cmsRightButtonClick.Size = new System.Drawing.Size(123, 48);
            // 
            // smiClose
            // 
            this.smiClose.Name = "smiClose";
            this.smiClose.Size = new System.Drawing.Size(122, 22);
            this.smiClose.Text = "关闭";
            this.smiClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smiClose.Click += new System.EventHandler(this.smiClose_Click);
            // 
            // smiCloseOther
            // 
            this.smiCloseOther.Name = "smiCloseOther";
            this.smiCloseOther.Size = new System.Drawing.Size(122, 22);
            this.smiCloseOther.Text = "关闭其他";
            this.smiCloseOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smiCloseOther.Click += new System.EventHandler(this.smiCloseOther_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(791, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbcPages
            // 
            this.tbcPages.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tbcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcPages.Location = new System.Drawing.Point(0, 25);
            this.tbcPages.Name = "tbcPages";
            this.tbcPages.SelectedTabPage = this.xtraTabPage1;
            this.tbcPages.Size = new System.Drawing.Size(791, 588);
            this.tbcPages.TabIndex = 3;
            this.tbcPages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.tbcPages.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.tbcPages_Selected);
            this.tbcPages.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbcPages_SelectedPageChanged);
            this.tbcPages.CloseButtonClick += new System.EventHandler(this.tbcPages_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.AutoScroll = true;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(782, 558);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(782, 558);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(791, 613);
            this.Controls.Add(this.tbcPages);
            this.Controls.Add(this.toolStrip1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(799, 647);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XHX";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.cmsRightButtonClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbcPages)).EndInit();
            this.tbcPages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsRightButtonClick;
        private System.Windows.Forms.ToolStripMenuItem smiClose;
        private System.Windows.Forms.ToolStripMenuItem smiCloseOther;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public DevExpress.XtraTab.XtraTabControl tbcPages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;

    }
}