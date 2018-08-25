using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using System.Collections;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraEditors;
using XHX.View;
using XHX.ViewLocalService;
using System.Reflection;
using System.Configuration;
using XHX.DTO;
using XHX.Common;

namespace XHX
{
    public partial class MainForm : XtraForm
    {
        private bool _isMouseRightClick = false;
        private UserInfoDto _userInfoDto = null;

        // Create a MenuStrip control with a new window.
        MenuStrip ms = null;

        public UserInfoDto UserInfoDto
        {
            set { _userInfoDto = value; }
            get { return _userInfoDto; }
        }

        public MainForm()
        {
            InitializeComponent();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            LookAndFeel.SetSkinStyle(config.AppSettings.Settings["SkinName"].Value);

            #region MainMenu

            tbcPages.TabPages.Clear();
            tbcPages.Dock = DockStyle.Fill;

            ms = new MenuStrip();
            ms.Dock = DockStyle.Top;
            this.Controls.Add(ms);

            #endregion
        }

        #region Create Menu

        void CreateBizMenuList()
        {
            ToolStripMenuItem mainMenu = null;
            ToolStripMenuItem subMenu = null;

            #region 设置菜单
            mainMenu = new ToolStripMenuItem("现场");
            subMenu = new ToolStripMenuItem("区域管理", null, new EventHandler(menu_Click)); subMenu.Tag = "Area";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("经销商", null, new EventHandler(menu_Click)); subMenu.Tag = "Shop";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("执行文件", null, new EventHandler(menu_Click)); subMenu.Tag = "Subjects";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("得分登记", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerSubjects";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("申请复审", null, new EventHandler(menu_Click)); subMenu.Tag = "";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("查看复审意见", null, new EventHandler(menu_Click)); subMenu.Tag = "ExecuteTeamAlter";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("上传数据", null, new EventHandler(menu_Click)); subMenu.Tag = "PadToDB";
            mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);


            mainMenu = new ToolStripMenuItem("复审");
            subMenu = new ToolStripMenuItem("复审", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerRecheck";
            mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("资料类", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerRecheck";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("交叉类", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerRecheck";
            //mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);


            mainMenu = new ToolStripMenuItem("查询");
            subMenu = new ToolStripMenuItem("顾问检查结果查询", null, new EventHandler(menu_Click)); subMenu.Tag = "SalesContantReport";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("顾问检查结果查询_横向", null, new EventHandler(menu_Click)); subMenu.Tag = "SalesContantReport1";
            mainMenu.DropDownItems.Add(subMenu);

            subMenu = new ToolStripMenuItem("检查标准结果统计", null, new EventHandler(menu_Click)); subMenu.Tag = "InspectionStandardReportSearch";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("得分查询", null, new EventHandler(menu_Click)); subMenu.Tag = "ShopScoreSearch";
            mainMenu.DropDownItems.Add(subMenu);

            subMenu = new ToolStripMenuItem("用户自定义查询", null, new EventHandler(menu_Click)); subMenu.Tag = "UserDefineSearch";
            mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("得分率查询", null, new EventHandler(menu_Click)); subMenu.Tag = "RateSearch";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("加权得分率查询", null, new EventHandler(menu_Click)); subMenu.Tag = "WeightRateSearch";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("最终加权得分率查询", null, new EventHandler(menu_Click)); subMenu.Tag = "FinallyScoreRate";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("复审修改查询", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerScoreLog";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("往期得分查询", null, new EventHandler(menu_Click)); subMenu.Tag = "";
            //mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("复审进度查询", null, new EventHandler(menu_Click)); subMenu.Tag = "ReCheckProcess";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("复审错误类型统计", null, new EventHandler(menu_Click)); subMenu.Tag = "ReCheckDtlErrorSum";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("第三方仲裁", null, new EventHandler(menu_Click)); subMenu.Tag = "ArbitrationTeam";
            //mainMenu.DropDownItems.Add(subMenu);
            //subMenu = new ToolStripMenuItem("第三方仲裁", null, new EventHandler(menu_Click)); subMenu.Tag = "ArbitrationTeam";
            mainMenu.DropDownItems.Add(subMenu);
            

            ms.Items.Add(mainMenu);

            mainMenu = new ToolStripMenuItem("设置");
            //subMenu = new ToolStripMenuItem("数据导入/导出", null, new EventHandler(menu_Click)); subMenu.Tag = "DataTrans";
            //mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("数据导出", null, new EventHandler(menu_Click)); subMenu.Tag = "";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("用户名设置", null, new EventHandler(menu_Click)); subMenu.Tag = "UserInfo";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("权限-页面设置", null, new EventHandler(menu_Click)); subMenu.Tag = "RoleTypeProgram";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("经销商A/B卷设置", null, new EventHandler(menu_Click)); subMenu.Tag = "ShopSubjectType";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("删除错误分数", null, new EventHandler(menu_Click)); subMenu.Tag = "DeleteAnswerScore";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("不匹配数据设置", null, new EventHandler(menu_Click)); subMenu.Tag = "AnswerErrorData";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("执行文件修改", null, new EventHandler(menu_Click)); subMenu.Tag = "";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("图片上传设置", null, new EventHandler(menu_Click)); subMenu.Tag = "";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("Pad数据上传", null, new EventHandler(menu_Click)); subMenu.Tag = "PadToDB";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("单店报告生成", null, new EventHandler(menu_Click)); subMenu.Tag = "SingleShopReport";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("单店报告数据上传", null, new EventHandler(menu_Click)); subMenu.Tag = "SingleShopReport_UploadData";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("单店报告生成_每周", null, new EventHandler(menu_Click)); subMenu.Tag = "SingleShopReport_Week";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("皮肤");
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                ToolStripMenuItem skinMenu = new ToolStripMenuItem(skin.SkinName, null, new EventHandler(skin_Click));
                subMenu.DropDownItems.Add(skinMenu);
            }
            mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);


            mainMenu = new ToolStripMenuItem("报告");
            //subMenu = new ToolStripMenuItem("数据导入", null, new EventHandler(menu_Click)); subMenu.Tag = "DataTrans";
            //mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);

            mainMenu = new ToolStripMenuItem("公告");
            subMenu = new ToolStripMenuItem("公告管理", null, new EventHandler(menu_Click)); subMenu.Tag = "NoticeSearch";
            mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);


            mainMenu = new ToolStripMenuItem("案例库");
            subMenu = new ToolStripMenuItem("特殊案例申报", null, new EventHandler(menu_Click)); subMenu.Tag = "SpecialCaseReg";
            mainMenu.DropDownItems.Add(subMenu);
            subMenu = new ToolStripMenuItem("特殊案例查询", null, new EventHandler(menu_Click)); subMenu.Tag = "SpecialCaseSearch";
            mainMenu.DropDownItems.Add(subMenu);
            ms.Items.Add(mainMenu);

            #endregion

            #region 按照权限设置菜单
            List<ProgramDto> programDtoList = new List<ProgramDto>();
            if (_userInfoDto.IsNetWork)
            {
                localhost.Service webService = new localhost.Service();
                DataSet ds = webService.SearchCurrentUserProgram(_userInfoDto.RoleType);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ProgramDto programDto = new ProgramDto();
                        programDto.ProgramCode = Convert.ToString(ds.Tables[0].Rows[i]["ProgramCode"]);
                        programDto.ProgramName = Convert.ToString(ds.Tables[0].Rows[i]["ProgramName"]);
                        programDtoList.Add(programDto);
                    }
                }
            }
            else
            {
                //LocalService webService = new LocalService();
                localhost.Service webService = new localhost.Service();
                webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx"; 
                DataSet ds = webService.SearchCurrentUserProgram(_userInfoDto.RoleType);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ProgramDto programDto = new ProgramDto();
                        programDto.ProgramCode = Convert.ToString(ds.Tables[0].Rows[i]["ProgramCode"]);
                        programDto.ProgramName = Convert.ToString(ds.Tables[0].Rows[i]["ProgramName"]);
                        programDtoList.Add(programDto);
                    }
                }
            }
            foreach (ToolStripMenuItem mainMenuitem in ms.Items)
            {
                bool haveMainMenuRole = false;
                foreach (ToolStripMenuItem menuItem in mainMenuitem.DropDownItems)
                {
                    bool haveSubMenuRole = false;
                    foreach (ProgramDto item in programDtoList)
                    {
                        if (menuItem.Tag == null || (menuItem.Tag.ToString() != "" && menuItem.Tag.ToString().Equals(item.ProgramCode)))
                        {
                            haveMainMenuRole = true;
                            haveSubMenuRole = true; break;
                        }
                    }
                    if (!haveSubMenuRole)
                    {
                        menuItem.Visible = false;
                    }
                }
                if (!haveMainMenuRole)
                {
                    mainMenuitem.Visible = false;
                }
            }

            #endregion

        }

        void menu_Click(object sender, EventArgs e)
        {
            foreach (XtraTabPage page in tbcPages.TabPages)
            {
                if (page.Text == (sender as ToolStripMenuItem).Text)
                {
                    this.tbcPages.SelectedTabPage = page;
                    return;
                }
            }

            Assembly asmb = Assembly.Load("DSLiucheng");
            BaseForm pageControl = null;
            if (_userInfoDto.IsNetWork)
            {
                pageControl = asmb.CreateInstance("XHX.View." + (sender as ToolStripMenuItem).Tag) as BaseForm;
            }
            else
            {
                pageControl = asmb.CreateInstance("XHX.ViewLocalService." + (sender as ToolStripMenuItem).Tag) as BaseForm;
            }

            pageControl.CSParentForm = this;
            pageControl.AutoScroll = true;
            pageControl.Dock = DockStyle.Fill;
            pageControl.UserInfoDto = _userInfoDto;
            List<XHX.BaseForm.ButtonType> list = pageControl.CreateButton();
            List<ToolStripItem> toollist = new List<ToolStripItem>();
            toollist = this.CreatButtons(list);

            string name = (sender as ToolStripMenuItem).Text;
            if (name == "照片类")
            {
                pageControl.Tag = "照片类";

            }
            else if (name == "资料类")
            {
                pageControl.Tag = "资料类";
            }
            else if (name == "交叉类")
            {
                pageControl.Tag = "交叉类";
            }
            XtraTabPage tpg = new XtraTabPage();
            tpg.Text = (sender as ToolStripMenuItem).Text;
            tpg.Controls.Add(pageControl);
            tpg.Tag = toollist;
            this.tbcPages.TabPages.Add(tpg);
            tbcPages.SelectedTabPage = tpg;
            toolStrip1.Items.Clear();
            toolStrip1.Items.AddRange(toollist.ToArray());
            //tbcPages_Selected(null, null);
            // ((TabControl)tbcPages.c).SelectTab(tpg);


        }
        public List<ToolStripItem> CreatButtons(List<XHX.BaseForm.ButtonType> buttonTypeList)
        {

            List<ToolStripItem> toollist = new List<ToolStripItem>();
            foreach (XHX.BaseForm.ButtonType bt in buttonTypeList)
            {
                ToolStripButton tb = new ToolStripButton();
                switch (bt)
                {
                    case XHX.BaseForm.ButtonType.SearchButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgSearch;
                        tb.Text = "查询";
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;

                    case XHX.BaseForm.ButtonType.DeleteButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgDelete;
                        tb.Text = "删除";
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;

                    case XHX.BaseForm.ButtonType.SaveButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgSave;
                        tb.Text = "保存";
                        tb.Tag = bt;
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;
                    case XHX.BaseForm.ButtonType.ConfirmButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgConfirm;
                        tb.Text = "确认";
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;

                    case XHX.BaseForm.ButtonType.AddButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgAdd;
                        tb.Text = "新建";
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;

                    case XHX.BaseForm.ButtonType.AddRowButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgAddRow;
                        tb.Text = "新建行";
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Tag = bt;
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;

                    case XHX.BaseForm.ButtonType.DeleteRowButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgDeleteRow;
                        tb.Text = "删除行";
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;
                    case XHX.BaseForm.ButtonType.ExcelDownButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgExcelDown;
                        tb.Text = "Excel下载";
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;
                    case XHX.BaseForm.ButtonType.InitButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgInit;
                        tb.Text = "初始化";
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;
                    case XHX.BaseForm.ButtonType.NoteButton:
                        tb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                        tb.Image = Properties.Resources.imgNote;
                        tb.Text = "便签";
                        tb.Tag = bt;
                        tb.Padding = new Padding(3, 0, 3, 0);
                        tb.ImageTransparentColor = System.Drawing.Color.Magenta;
                        tb.Name = bt.ToString();
                        tb.Size = new System.Drawing.Size(36, 36);
                        tb.Click += new EventHandler(Button_Click);
                        toollist.Add(tb);
                        break;
                }
            }

            toolStrip1.Items.AddRange(toollist.ToArray());
            return toollist;


        }
        public void Button_Click(object sender, EventArgs e)
        {

            XtraTabPage tab = (XtraTabPage)(tbcPages.SelectedTabPage);
            XHX.BaseForm.ButtonType name = (XHX.BaseForm.ButtonType)((ToolStripButton)sender).Tag;
            switch (name)
            {
                case XHX.BaseForm.ButtonType.SearchButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).SearchButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.SaveButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).SaveButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.DeleteButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).DeleteButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.ConfirmButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).ConfirmButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.AddButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).AddButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.AddRowButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).AddRowButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.DeleteRowButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).DeleteRowButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.InitButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).InitButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.ExcelDownButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).ExcelDownButtonClick();
                    }
                    break;
                case XHX.BaseForm.ButtonType.NoteButton:
                    foreach (Control c in tab.Controls)
                    {
                        ((BaseForm)c).NoteButtonClick();
                    }
                    break;

            }
        }
        void skin_Click(object sender, EventArgs e)
        {
            CommonHandler.Skin_Name = (sender as ToolStripMenuItem).Text;
            LookAndFeel.SetSkinStyle((sender as ToolStripMenuItem).Text);
        }

        #endregion

        #region XtraTabControl CloseButtonClick

        private void tbcPages_CloseButtonClick(object sender, EventArgs e)
        {
            if (!_isMouseRightClick)
            {
                //XtraTabControl tcl = sender as XtraTabControl;
                //XtraTabHitInfo thi = tcl.CalcHitInfo(MousePosition);

                XtraTabPage tpg = ((ClosePageButtonEventArgs)e).Page as XtraTabPage;
                tpg.Controls[0].Dispose();
                tpg.Dispose();
                //if (tbcPages.SelectedTabPage == null)
                //{
                //    toolStrip1.Items.Clear();
                //}
            }
        }

        #endregion

        #region right-button click

        private void smiClose_Click(object sender, EventArgs e)
        {
            XtraTabPage tpg = this.tbcPages.SelectedTabPage;
            tpg.Controls[0].Dispose();
            this.tbcPages.TabPages.Remove(tpg);
        }

        private void smiCloseOther_Click(object sender, EventArgs e)
        {
            XtraTabPage currentPage = this.tbcPages.SelectedTabPage;
            XtraTabPageCollection tabPages = this.tbcPages.TabPages;
            List<XtraTabPage> removePages = new List<XtraTabPage>();

            for (int i = 0; i < tabPages.Count; i++)
            {
                if (tabPages[i] != currentPage)
                {
                    removePages.Add(tabPages[i]);
                }
            }

            for (int i = 0; i < removePages.Count; i++)
            {
                removePages[i].Controls[0].Dispose();
                tabPages.Remove(removePages[i]);
            }
        }

        private void tbcPages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _isMouseRightClick = true;
                ShowTabPageContextMenu(sender, new Point(e.X, e.Y));
            }
            else
            {
                _isMouseRightClick = false;
            }
        }

        private void ShowTabPageContextMenu(object sender, Point position)
        {
            object menu = cmsRightButtonClick;

            if (menu == null)
                return;

            XtraTabControl tabCtrl = sender as XtraTabControl;
            Point pt = MousePosition;
            XtraTabHitInfo info = tabCtrl.CalcHitInfo(tabCtrl.PointToClient(pt));

            ContextMenuStrip contextMenuStrip = menu as ContextMenuStrip;
            if (contextMenuStrip != null && info.HitTest == XtraTabHitTest.PageHeader)
            {
                tabCtrl.SelectedTabPage = info.Page;
                contextMenuStrip.Show(sender as Control, position);
                return;
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["SkinName"].Value = CommonHandler.Skin_Name;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateBizMenuList();

            BindComBox.IsNetWork = _userInfoDto.IsNetWork;
            CommonHandler.IsNetWork = _userInfoDto.IsNetWork;

            if (_userInfoDto.IsNetWork)
            {
                localhost.Service webService = new localhost.Service();
               // LocalService localService = new LocalService();
                #region 同步SP
                //{
                //    DataSet ds = webService.SyncSp();
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //        {
                //            string spName = ds.Tables[0].Rows[i]["SPName"].ToString();
                //            string spContent = ds.Tables[0].Rows[i]["SPContent"].ToString();
                //            localService.syncSP(spName, spContent);
                //        }
                //    }
                //}
                #endregion
                #region Notice
                {
                    DataSet ds = webService.GetAllNotice(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(2));
                    List<NoticeDto> noticeList = new List<NoticeDto>();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            NoticeDto dto = new NoticeDto();
                            dto.NoticeID = ds.Tables[0].Rows[i]["NoticeID"].ToString();
                            dto.NoticeTitle = ds.Tables[0].Rows[i]["NoticeTitle"].ToString();
                            dto.NoticeContent = ds.Tables[0].Rows[i]["NoticeContent"].ToString();
                            dto.FileExist = ds.Tables[0].Rows[i]["FileExist"].ToString();
                            dto.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);
                            noticeList.Add(dto);
                        }
                    }

                    foreach (NoticeDto dto in noticeList)
                    {
                        View.NoticePop noticePop = new XHX.View.NoticePop(dto.NoticeID);
                        noticePop.Show();
                    }
                }
                #endregion
                #region SpecialCase
                {
                    DataSet ds = webService.SearchSpecialCaseByNeedVICoConfirm();
                    List<SpecialCaseDto> specialCaseList = new List<SpecialCaseDto>();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            SpecialCaseDto dto = new SpecialCaseDto();
                            dto.ProjectCode = ds.Tables[0].Rows[i]["ProjectCode"].ToString();
                            dto.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                            dto.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                            dto.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                            dto.SpecialCaseCode = ds.Tables[0].Rows[i]["SpecialCaseCode"].ToString();
                            specialCaseList.Add(dto);
                        }
                    }

                    foreach (SpecialCaseDto dto in specialCaseList)
                    {
                        if (this.UserInfoDto.RoleType == "C")
                        {
                            //View.SpecialCasePop specialCasePop = new XHX.View.SpecialCasePop(dto.SpecialCaseCode, this.UserInfoDto);
                            //specialCasePop.Show();
                        }
                    }
                }
                #endregion
            }
            else
            {
                //LocalService localService = new LocalService();
                localhost.Service localService = new localhost.Service();
                localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx"; 
                //localhost1.Service localService = new localhost1.Service();
               
                #region Notice
                {
                    DataSet ds = localService.GetAllNotice(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(2));
                    List<NoticeDto> noticeList = new List<NoticeDto>();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            NoticeDto dto = new NoticeDto();
                            dto.NoticeID = ds.Tables[0].Rows[i]["NoticeID"].ToString();
                            dto.NoticeTitle = ds.Tables[0].Rows[i]["NoticeTitle"].ToString();
                            dto.NoticeContent = ds.Tables[0].Rows[i]["NoticeContent"].ToString();
                            dto.FileExist = ds.Tables[0].Rows[i]["FileExist"].ToString();
                            dto.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);
                            noticeList.Add(dto);
                        }
                    }

                    foreach (NoticeDto dto in noticeList)
                    {
                        ViewLocalService.NoticePop noticePop = new XHX.ViewLocalService.NoticePop(dto.NoticeID);
                        noticePop.Show();
                    }
                }
                #endregion
                #region SpecialCase
                {
                    DataSet ds = localService.SearchSpecialCaseByNeedVICoConfirm();
                    List<SpecialCaseDto> specialCaseList = new List<SpecialCaseDto>();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            SpecialCaseDto dto = new SpecialCaseDto();
                            dto.ProjectCode = ds.Tables[0].Rows[i]["ProjectCode"].ToString();
                            dto.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                            dto.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                            dto.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                            specialCaseList.Add(dto);
                        }
                    }

                    foreach (SpecialCaseDto dto in specialCaseList)
                    {
                        if (this.UserInfoDto.RoleType == "C" && dto.NeedVICoConfirmChk == true)
                        {
                            //ViewLocalService.SpecialCasePop specialCasePop = new XHX.ViewLocalService.SpecialCasePop(dto.SpecialCaseCode, this.UserInfoDto);
                            //specialCasePop.Show();
                        }
                    }
                }
                #endregion
            }
        }

        private void tbcPages_Selected(object sender, TabPageEventArgs e)
        {

            //XtraTabPage tab = (XtraTabPage)tbcPages.SelectedTabPage;
            XtraTabControl control = (XtraTabControl)sender;
            XtraTabPage tab = control.SelectedTabPage;
            toolStrip1.Items.Clear();
            if (tab != null)
            {
                List<ToolStripItem> toollist = (List<ToolStripItem>)tab.Tag;

                toolStrip1.Items.AddRange(toollist.ToArray());
            }
        }
        public void EnabelButton(XHX.BaseForm.ButtonType buttonType, bool enable)
        {
            XtraTabPage tab = (XtraTabPage)tbcPages.SelectedTabPage;
            if (tab != null)
            {
                List<ToolStripItem> toollist = (List<ToolStripItem>)tab.Tag;

                foreach (ToolStripItem item in toollist)
                {
                    if (((XHX.BaseForm.ButtonType)item.Tag) == buttonType)
                        item.Enabled = enable;
                }
            }
        }

        private void tbcPages_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage tab = (XtraTabPage)tbcPages.SelectedTabPage;
            //XtraTabControl control = (XtraTabControl)sender;
            //XtraTabPage tab = control.SelectedTabPage;
            toolStrip1.Items.Clear();
            if (tab != null)
            {
                List<ToolStripItem> toollist = (List<ToolStripItem>)tab.Tag;

                toolStrip1.Items.AddRange(toollist.ToArray());
            }
        }

    }
}
