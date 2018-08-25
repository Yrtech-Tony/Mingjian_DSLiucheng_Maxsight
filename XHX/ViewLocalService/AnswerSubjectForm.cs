using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;
using DevExpress.XtraEditors;
using XHX.Common;
using System.IO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Net;

namespace XHX.ViewLocalService
{
    public partial class AnswerSubjectForm : Form
    {
        public static localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        int CurrentOrderNo = 0;
        string ProjectCode_Golbal = "";
        string SubjectCode_Golbal = "";
        string ShopCode_Golbal = "";
        int OrderNO_Golbal = 1; 
        string ExamTypeCode = "";
        UserInfoDto _UserInfoDto;
        string _pageName = "";
        char CheckType = '0'; //区别当前的开始类型是0：得分登记 1：第一次复查 2：第二次复查 3：第三次复查
        DateTime dateTime_Golbal = DateTime.Now;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        XtraGridDataHandler<InspectionStandardDto> dataHandler = null;
        XtraGridDataHandler<InspectionStandardDto> dataHandler2 = null;
        XtraGridDataHandler<LossResultDto> dataHandler3 = null;

        List<CheckEdit> checklist = new List<CheckEdit>();

        public AnswerSubjectForm()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            dataHandler = new XtraGridDataHandler<InspectionStandardDto>(grvInspectionStandard);
            dataHandler2 = new XtraGridDataHandler<InspectionStandardDto>(grvFileAndPic);
            dataHandler3 = new XtraGridDataHandler<LossResultDto>(grvLoss);
            OnLoadView();
            InitializeView();
            grcLoss.DataSource = new List<LossResultDto>();
            selection = new GridCheckMarksSelection(grvLoss);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }
        public AnswerSubjectForm(string projectCode, string subjectCode, string shopCode, string shopName, int order, char checkType, UserInfoDto userinfodto,string examType,string pageName)
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            _UserInfoDto = userinfodto;
            btnShopCode.Text = shopCode;
            txtShopName.Text = shopName;
            ExamTypeCode = examType;
            _pageName = pageName;
            btnRecheckApply.Enabled = false;
            CommonHandler.SetComboBoxSelectedValue(cboExamType,examType);
            dataHandler = new XtraGridDataHandler<InspectionStandardDto>(grvInspectionStandard);
            dataHandler2 = new XtraGridDataHandler<InspectionStandardDto>(grvFileAndPic);
            dataHandler3 = new XtraGridDataHandler<LossResultDto>(grvLoss);

            XHX.Common.BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, projectCode);
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboCheckOptions, GetAllCheckOptions(), "CheckOptionName", "CheckOptionCode");
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboFileAndPicCheckOptions, GetAllFileAndPictureCheckOptions(), "CheckOptionName", "CheckOptionCode");
            grcLoss.DataSource = new List<LossResultDto>();
            Transfor(projectCode, subjectCode, shopCode, order, checkType);
            if (_UserInfoDto.RoleType == "C")
            {
                btnSpecialCaseApply.Enabled = false;
                grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
                btnAddRowLoss.Enabled = false;
                btnDeleteLoss.Enabled = false;
                txtScore.Enabled = false;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = false;
            }
            selection = new GridCheckMarksSelection(grvLoss);
            selection.CheckMarkColumn.VisibleIndex = 0;

        }
        
        public void OnLoadView()
        {
            XHX.Common.BindComBox.BindProject(cboProjects);
            XHX.Common.BindComBox.BindSubjectExamType(cboExamType);
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboCheckOptions, GetAllCheckOptions(), "CheckOptionName", "CheckOptionCode");
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboFileAndPicCheckOptions, GetAllFileAndPictureCheckOptions(), "CheckOptionName", "CheckOptionCode");
        }

        public void InitializeView()
        {
            txtAdditionalDesc.Text = "";
            txtCheckPoint.Text = "";
            txtDesc.Text = "";
            txtImplementation.Text = "";
            txtInspectionDesc.Text = "";
            txtRemark.Text = "";
            txtSeqNo.Text = "";
            txtSubjectCode.Text = "";
            txtLossDesc.Text = "";
            txtShopName.Text = "";
            txtOrder2.Text = "1";
            txtScore.Text = "";
            txtLastScore.Text = "";
            chkLastNotinvolved.Checked = false;
            chkNotinvolved.Checked = false;
            btnShopCode.Properties.ReadOnly = false;
            btnShopCode.Text = "";
            btnShopCode.Enabled = true;
            cboProjects.Properties.ReadOnly = false;
            grcInspectionStandard.DataSource = null;
            grcFileAndPic.DataSource = null;
            grcLoss.DataSource = null;
            btnSpecialCaseApply.Enabled = true;
            btnAddRowLoss.Enabled = true;
            btnDeleteLoss.Enabled = true;
            txtScore.Enabled = true;
            txtRemark.Enabled = true;
            chkLastNotinvolved.Enabled = false;
            chkNotinvolved.Enabled = true;
            grcFileAndPic.DragEnter+=new DragEventHandler(grcFileAndPic_DragEnter);
            grcLoss.DragEnter+=new DragEventHandler(grcLoss_DragEnter);
            BindComBox.BindLoss(cboLoss,cboLoss2,cboLoss3,"","");
            
        }
        public bool RecheckStatus()
        {
            DataSet ds = service.SearchRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0||cboProjects.SelectedIndex!=0)
            {
                btnSpecialCaseApply.Enabled = false;
                grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
                btnAddRowLoss.Enabled = false;
                btnDeleteLoss.Enabled = false;
                txtScore.Enabled = false;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = false;
                return true;
            }
            else
            {
                btnSpecialCaseApply.Enabled = true; ;
                grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);
                btnAddRowLoss.Enabled = true; ;
                btnDeleteLoss.Enabled = true;
                txtScore.Enabled = true;
                chkNotinvolved.Enabled = true;
                txtRemark.Enabled = true;
                return false;
            }
            
            
        }
        #region 事件

        private void btnShopCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Shop_Popup pop = new Shop_Popup("", "",false);
            pop.ShowDialog();
            ShopDto dto = pop.Shopdto;
            if (dto != null)
            {
                btnShopCode.Text = dto.ShopCode;
                txtShopName.Text = dto.ShopName;
            }
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
        }

        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            if (_UserInfoDto.RoleType == "C")
            {
                cboLoss.Enabled = false;
                cboLoss2.Enabled = false;
                cboLoss3.Enabled = false;
                txtRemark.Enabled = false;

            }
           
            btnTransfer.Enabled = true;
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            StartCheck('0', ButtonType.StartCheck);
        }

        

        private void btnNext_Click(object sender, EventArgs e)
        {
            string imageName = "";
            if (imageName == null)
            {
                return;
            }

            foreach (InspectionStandardDto dto in grcInspectionStandard.DataSource as List<InspectionStandardDto>)
            {
                if (string.IsNullOrEmpty(dto.CheckOptionCode))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "相应检查标准没有选择！");
                    grvInspectionStandard.FocusedColumn = gcCheckResult;
                    grvInspectionStandard.FocusedRowHandle = (grcInspectionStandard.DataSource as List<InspectionStandardDto>).IndexOf(dto);
                    return;
                }
            }
            foreach (InspectionStandardDto dto in grcFileAndPic.DataSource as List<InspectionStandardDto>)
            {
                //if (string.IsNullOrEmpty(dto.CheckOptionCode))
                //{
                //    CommonHandler.ShowMessage(MessageType.Information, "相关图片和文件没有选择存在类型！");
                //    grvFileAndPic.FocusedColumn = gcExistOrNo;
                //    grvFileAndPic.FocusedRowHandle = (grcFileAndPic.DataSource as List<InspectionStandardDto>).IndexOf(dto);
                //    return;
                //}
                //if (string.IsNullOrEmpty(dto.FilePath) && dto.CheckOptionCode=="01")
                //{
                //    CommonHandler.ShowMessage(MessageType.Information, "图片路径不能为空！");
                //    grvFileAndPic.FocusedColumn = gcExistOrNo;
                //    grvFileAndPic.FocusedRowHandle = (grcFileAndPic.DataSource as List<InspectionStandardDto>).IndexOf(dto);
                //    return;
                //}
            }
            if (string.IsNullOrEmpty(txtScore.Text) && !chkNotinvolved.Checked)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请填写分数");
                return;
            }
            string reCheckTypeCode = "0" + CheckType;
            string passReCheck = "";

            decimal? score = 0;
            if (chkNotinvolved.Checked)
            {
                score = 9999;
            }
            else
            {
                score = Convert.ToDecimal(txtScore.Text);
            }
         
            //保存问卷信息
            service.SaveAnswer(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal,
                            score, txtRemark.Text, imageName, _UserInfoDto.UserID,
                            CheckType, passReCheck, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"),"");

            //保存得分记录
            /*最终管理员修改成绩的时候不更新Log表，
             方便区分最终成绩和一审完毕的成绩*/
            //service.SaveAnswerLog(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, "02", score, txtRemark.Text, _UserInfoDto.UserID);
            //保存问卷的检查标准信息
            foreach (InspectionStandardDto dto in grcInspectionStandard.DataSource as List<InspectionStandardDto>)
            {

                service.SaveAnswerDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal,
                                                 dto.SeqNO, _UserInfoDto.UserID,dto.CheckOptionCode,"");
            }
            //保存图片或者文件存在与否的信息
            foreach (InspectionStandardDto dto in grcFileAndPic.DataSource as List<InspectionStandardDto>)
            {
               
                service.SaveAnswerDtl2Stream(ProjectCode_Golbal,
                                     SubjectCode_Golbal,
                                     ShopCode_Golbal,
                                     dto.SeqNO,
                                     _UserInfoDto.UserID,
                                     dto.CheckOptionCode, null, txtShopName.Text, dto.FileExtend);
                
            }
            //保存失分说明
            foreach (LossResultDto dto in dataHandler3.DataList as List<LossResultDto>)
            {
                service.SaveLossDesc(ProjectCode_Golbal, ShopCode_Golbal,txtShopName.Text.Trim(), SubjectCode_Golbal, dto.LossName, dto.PicName, dto.SeqNO,dto.StatusType,"");
            }
            //查询下一个问卷信息并显示
            DataSet ds = service.SearchNextSubject(ProjectCode_Golbal, ShopCode_Golbal,
                                                    OrderNO_Golbal, CheckType, ExamTypeCode);
            if (!GetSubject(ds, ButtonType.Next))
                return;



            //查询下一个问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist2 = new List<InspectionStandardDto>();

            DataSet ds2 = service.SearchNextSubjectInsectionStardard(
                                            ProjectCode_Golbal,
                                            SubjectCode_Golbal, 
                                            btnShopCode.Text);//cboArea.SelectedItem

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.InspectionStandardName = Convert.ToString(ds2.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist2.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist2;

            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_UserInfoDto.RoleType == "C") return;
            //查询上一个问卷信息并显示
          
            DataSet ds = service.SearchPreSubject(ProjectCode_Golbal,
                                                    ShopCode_Golbal,
                                                    OrderNO_Golbal, CheckType,ExamTypeCode);

            if (!GetSubject(ds, ButtonType.Previous))
                return;



            //查询下一个问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
            //List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();

            DataSet ds2 = service.SearchPreSubjectInsecptionStardard( ProjectCode_Golbal,
                                                        SubjectCode_Golbal, 
                                                        btnShopCode.Text);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.InspectionStandardName = Convert.ToString(ds2.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist;

            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
        }

  
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfor();
        }
        public void Transfor(string projectCode, string subjectCode, string shopCode, int order, char checktype)
        {
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            //RecheckStatus();
            /*在查看复审意见页面进来的时候可以进行修改*/
            if (_UserInfoDto.RoleType == "S" && _pageName=="ShopScoreSearch")
            {
                txtScore.Enabled = true;
                chkNotinvolved.Enabled = true;
                txtRemark.Enabled = true;
                btnAddRowLoss.Enabled = true;
                btnDeleteLoss.Enabled = true;
                //btnAnswerStart.Enabled = true;
            }
            else if (_UserInfoDto.RoleType == "I" && _pageName == "ExecuteTeamAlter")
            {
                txtScore.Enabled = true;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = true;
                btnAddRowLoss.Enabled = true;
                btnDeleteLoss.Enabled = true;
                btnAnswerStart.Enabled = false;
            }
            else
            {
                txtScore.Enabled = false;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = false;
                btnAddRowLoss.Enabled = false;
                btnDeleteLoss.Enabled = false;
                btnAnswerStart.Enabled = false;
            }
            DataSet ds = service.SearchPreSubjectTypeISO(projectCode, shopCode, order, checktype, ExamTypeCode);
            if (!GetSubject(ds, ButtonType.Transfer))
                return;

            ProjectCode_Golbal = projectCode;
            ShopCode_Golbal = shopCode;
            btnShopCode.Enabled = false;
            cboProjects.Properties.ReadOnly = true;
            btnShopCode.Properties.ReadOnly = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;

            //查询下一个问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
            //sql = string.Format("EXEC [up_XHX_AnswerSubjectAnswerDtl_R] @ProjectCode= '{0}',@SubjectCode = '{1}',@ShopCode = '{2}' ", ProjectCode_Golbal, SubjectCode_Golbal, shopCode);//cboArea.SelectedItem
            DataSet ds2 = service.SearchNextSubjectInsectionStardard(ProjectCode_Golbal, SubjectCode_Golbal, shopCode);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.InspectionStandardName = Convert.ToString(ds2.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"])==""?"01":Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist;

            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
        }
        private void Transfor()
        {
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            //RecheckStatus();
            
            DataSet ds = service.SearchPreSubjectTypeISO(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                btnShopCode.Text, Convert.ToInt32(txtOrder2.Text), CheckType, ExamTypeCode);
            if (!GetSubject(ds, ButtonType.Transfer))
                return;

            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            btnShopCode.Enabled = false;
            cboProjects.Properties.ReadOnly = true;
            btnShopCode.Properties.ReadOnly = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;

            //查询下一个问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
            DataSet ds2 = service.SearchNextSubjectInsectionStardard(ProjectCode_Golbal, SubjectCode_Golbal, btnShopCode.Text);


            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.InspectionStandardName = Convert.ToString(ds2.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist;

            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
        }
        private void btnShopCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataSet ds = service.SearchShopByShopCode(btnShopCode.Text);
                ShopDto shopDto = new ShopDto();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    shopDto.ShopCode = Convert.ToString(ds.Tables[0].Rows[0]["ShopCode"]);
                    shopDto.ShopName = Convert.ToString(ds.Tables[0].Rows[0]["ShopName"]);
                }
                else
                {
                    btnShopCode.Text = "";
                    txtShopName.Text = "";
                    return;
                }
                btnShopCode.Text = shopDto.ShopCode;
                txtShopName.Text = shopDto.ShopName;
            }
        }

        #endregion


        private List<CheckOptionsDto> GetAllCheckOptions()
        {
            List<CheckOptionsDto> checkOptionsDtolist = new List<CheckOptionsDto>();
            
            DataSet ds2 = service.SearchAllCheckOptions();

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    CheckOptionsDto checkOptionsDto = new CheckOptionsDto();
                    checkOptionsDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    checkOptionsDto.CheckOptionName = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionName"]);
                    checkOptionsDtolist.Add(checkOptionsDto);
                }

            }
            return checkOptionsDtolist;

        }
        private List<CheckOptionsDto> GetAllFileAndPictureCheckOptions()
        {
            List<CheckOptionsDto> checkOptionsDtolist = new List<CheckOptionsDto>();
            checkOptionsDtolist.Add(new CheckOptionsDto() { CheckOptionCode = "01", CheckOptionName = "有" });
            checkOptionsDtolist.Add(new CheckOptionsDto() { CheckOptionCode = "02", CheckOptionName = "没有" });
            checkOptionsDtolist.Add(new CheckOptionsDto() { CheckOptionCode = "03", CheckOptionName = "未涉及" });
            return checkOptionsDtolist;

        }
        private void grvInspectionStandard_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (_UserInfoDto.RoleType == "C" )
            {
                e.Cancel = true;
            }
            //if (grvInspectionStandard.FocusedColumn == gcCheckResult&&RecheckStatus())
            //{
            //    e.Cancel = true;
            //}
            
        }

        private void StartCheck(char p_checkType, ButtonType buttonType)
        {
            if (btnShopCode.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "经销商不能为空！");
                return;
            }
           
            //问卷开始的时候查询上次没答完的那个问卷开始回答，如果没答过问卷就查询第一个

            DataSet ds = service.SearchStartSubject(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                                                btnShopCode.Text, p_checkType, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());
            if (!GetSubject(ds, buttonType))
                return;
            RecheckStatus();
            CheckType = p_checkType;
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;

            btnShopCode.Enabled = false;
            cboProjects.Properties.ReadOnly = true;
            btnShopCode.Properties.ReadOnly = true;


            //查询该问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
    

            DataSet ds2 = service.SearchPreSubjectInsecptionStardard(ProjectCode_Golbal, SubjectCode_Golbal, btnShopCode.Text);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds2.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.InspectionStandardName = Convert.ToString(ds2.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist;
            BindComBox.BindLoss(cboLoss, cboLoss2, cboLoss3, ProjectCode_Golbal, SubjectCode_Golbal);
            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
        }

        public bool GetSubject(DataSet ds, ButtonType buttonType)
        {
            SubjectDto subjectDto = new SubjectDto();
            if (ds.Tables[0].Rows.Count > 0)
            {
                subjectDto.SubjectCode = Convert.ToString(ds.Tables[0].Rows[0]["SubjectCode"]);
                subjectDto.ProjectCode = Convert.ToString(ds.Tables[0].Rows[0]["ProjectCode"]);
                subjectDto.OrderNO = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                subjectDto.Implementation = Convert.ToString(ds.Tables[0].Rows[0]["Implementation"]);
                subjectDto.InspectionDesc = Convert.ToString(ds.Tables[0].Rows[0]["InspectionDesc"]);
                subjectDto.InspectionNeedFile = Convert.ToString(ds.Tables[0].Rows[0]["InspectionNeedFile"]);

                subjectDto.AdditionalDesc = Convert.ToString(ds.Tables[0].Rows[0]["AdditionalDesc"]);
                subjectDto.CheckPoint = Convert.ToString(ds.Tables[0].Rows[0]["CheckPoint"]);
                subjectDto.Desc = Convert.ToString(ds.Tables[0].Rows[0]["Desc"]);
                subjectDto.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                if (ds.Tables[0].Rows[0]["Score"] == DBNull.Value)
                {
                    subjectDto.Score = null;
                }
                else
                {
                    subjectDto.Score = Convert.ToDecimal(ds.Tables[0].Rows[0]["Score"]);
                }
                 if (ds.Tables[0].Rows[0]["LastProjectScore"] == DBNull.Value)
                {
                    subjectDto.LastProjectScore = null;
                }
                else
                {
                    subjectDto.LastProjectScore = Convert.ToDecimal(ds.Tables[0].Rows[0]["LastProjectScore"]);
                }
                
                subjectDto.PassReCheck = Convert.ToBoolean(ds.Tables[0].Rows[0]["PassReCheck"]);
                subjectDto.ReCheckContent = Convert.ToString(ds.Tables[0].Rows[0]["ReCheckContent"]);
                subjectDto.CheckYesOrNO = Convert.ToBoolean(ds.Tables[0].Rows[0]["CheckYesOrNO"]);
                subjectDto.AssessmentDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AssessmentDate"]);
                

            }
            else
            {
                //如果直接点击跳转按钮的话，不存在Subject弹出提示
                if (buttonType == ButtonType.Transfer)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "不存在类型下的相关文件！");
                    return false;
                }
                //如果是点击上一步的时候
                else if (buttonType == ButtonType.Previous)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "已经是第一个执行文件！");
                    return false;
                }
                else if (buttonType == ButtonType.StartCheck)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "得分登记已经完毕,可以使用跳转功能来查看！");
                    return false;
                }

               

                else if (buttonType == ButtonType.Next)
                {
                    string s = "已经是最后一个执行文件，所有记录都已经保存，修改或者查看记录请使用跳转功能！";

                    /*
                    if (CheckType == '0')
                        s = "得分登记之前已经完毕，修改或者查询得分记录请使用转到功能！";
                    else
                        s = "第" + CheckType.ToString() + "次复查已经完毕，可以使用跳转功能来查看!";
                     * */

                    CommonHandler.ShowMessage(MessageType.Information, s);
                    return false;
                }


                
            }
            SubjectCode_Golbal = subjectDto.SubjectCode;
            BindComBox.BindLoss(cboLoss, cboLoss2, cboLoss3, ProjectCode_Golbal, SubjectCode_Golbal);
            CurrentOrderNo = subjectDto.OrderNO;
            txtAdditionalDesc.Text = subjectDto.AdditionalDesc;
            txtCheckPoint.Text = subjectDto.CheckPoint;
            txtDesc.Text = subjectDto.Desc;
            txtImplementation.Text = subjectDto.Implementation;
            txtInspectionDesc.Text = subjectDto.InspectionDesc;
         
            txtSeqNo.Text = subjectDto.OrderNO.ToString();
            chkNotinvolved.Checked = false;
            if (subjectDto.Score == 9999)
            {
                chkNotinvolved.Checked = true;
            }
            else
            {
                txtScore.Text = subjectDto.Score.ToString();
            }
            if (subjectDto.LastProjectScore == 9999)
            {
                chkLastNotinvolved.Checked = true;
            }
            else
            {
                txtLastScore.Text = subjectDto.LastProjectScore.ToString();
            }
            txtSubjectCode.Text = subjectDto.SubjectCode;
            SubjectCode_Golbal = subjectDto.SubjectCode;
            txtRemark.Text = subjectDto.Remark;
            OrderNO_Golbal = subjectDto.OrderNO;
            
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            char checkType = '0';


            //DataSet dsCheckType = service.SearchPassReCheckBySubjectCode(subjectDto.ProjectCode, subjectDto.SubjectCode, btnShopCode.Text);

            //if (dsCheckType.Tables[0].Rows.Count > 0)
            //{
            //    checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
            //}
         
          
            return true;
        }

        public void GetFileAndPic()
        {
            DataSet ds = service.SearchAnswerDtl2(ProjectCode_Golbal, SubjectCode_Golbal, btnShopCode.Text);
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.FileName = Convert.ToString(ds.Tables[0].Rows[i]["FileName"]);
                    inspectionStandardDto.FileType = Convert.ToString(ds.Tables[0].Rows[i]["FileType"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardDto.FileExtend = Convert.ToString(ds.Tables[0].Rows[i]["FileExtend"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }
            }
            grcFileAndPic.DataSource = null;
            grcFileAndPic.DataSource = inspectionStandardlist;
        }
        public void GetLossDesc(string projectCode, string shopCode, string subjectCode)
        {
            DataSet ds = service.SearchLossDesc(projectCode, shopCode, subjectCode);
            List<LossResultDto> lossResultList = new List<LossResultDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LossResultDto loss = new LossResultDto();
                   loss.LossName = ds.Tables[0].Rows[i]["LossDesc"].ToString();
                   loss.PicName = ds.Tables[0].Rows[i]["PicName"].ToString();
                   if (ds.Tables[0].Rows[i]["SeqNO"] != DBNull.Value)
                   {
                       loss.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                   }
                   lossResultList.Add(loss);   
                }
            }
            grcLoss.DataSource = lossResultList;

        }

        public enum ButtonType
        {
            None,
            StartCheck,
            FirstReCheck,
            SecondReChek,
            ThirdReCheck,
            Transfer,
            Next,
            Previous
        }

        private void grvFileAndPic_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvFileAndPic.FocusedColumn == gcFileName
                || (grvFileAndPic.FocusedColumn == gcSelected)
                )
                
            {
                e.Cancel = true;
            }
            if (_UserInfoDto.RoleType == "C"&&grvFileAndPic.FocusedColumn!=gcViewPicture)
            {
                e.Cancel = true;
            }
            if ((cboProjects.SelectedIndex!=0) && (grvFileAndPic.FocusedColumn == gcBrower || grvFileAndPic.FocusedColumn == gcDelete 
                                    ))
            {
                e.Cancel = true;
            }
        }

        private void btnViewPicture_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            InspectionStandardDto dto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;
            if (dto.FileType == "图片")
            {
                PictureShow2 pic = new PictureShow2(dto.FileName,CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString()+txtShopName.Text,txtSubjectCode.Text, dto.FilePath);
                pic.ShowDialog();
            }
            else
            {
                OfficeShow office = new OfficeShow(dto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text,txtSubjectCode.Text, dto.FileExtend);
                office.ShowDialog();
            }
            
        }

        private void btnPictureUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string appDomainPath = string.Empty;
            //查看用户自己设置的图片存储路径
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this._UserInfoDto.UserID);
            //如果当然用户没有设置路径在程序安装下生成路径
            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }

            InspectionStandardDto uploaddto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;

            if (string.IsNullOrEmpty(uploaddto.FilePath))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择图片/文件!");
                grvFileAndPic.FocusedColumn = gcBrower;
                grvFileAndPic.FocusedRowHandle = (grcFileAndPic.DataSource as List<InspectionStandardDto>).IndexOf(uploaddto);
                return;
            }
            if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
            {
                string extend = "." + uploaddto.FilePath.Split('.')[1];
                if (uploaddto.FileType == "图片")
                {
                    CommonHandler.CompressionPic(ProjectCode_Golbal, this._UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, ProjectCode_Golbal + txtShopName.Text);
                }
                else
                {
                    string uploadImagePath = appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\";
                    try
                    {
                        if (!Directory.Exists(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text))
                        {
                            Directory.CreateDirectory(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text);
                        }
                        if (File.Exists(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend))
                        {
                            File.Delete(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);
                        }
                        File.Copy(uploaddto.FilePath, appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                string filePath = string.Empty;
                if (uploaddto.FileType == "图片")
                {
                    filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + ".jpg";
                }
                else
                {
                    filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + extend;
                }
                byte[] image = null;
                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    int streamLength = (int)fs.Length;
                    image = new byte[streamLength];
                    fs.Read(image, 0, streamLength);
                    fs.Close();
                }
                else
                {
                    image = new byte[0];
                }
                service.SaveAnswerDtl2Streampic(_UserInfoDto.UserID, image, 
                    CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName, "",
                    extend,SubjectCode_Golbal);
                CommonHandler.ShowMessage(MessageType.Information, "图片/文件 上传成功！");
                // GetFileAndPic();
            }

        }

        private void btnBrowerGrid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string[] fileNames = null;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
                if (fileNames.Length > 0)
                {
                    //txtFile.Text = "";
                    string filename_temp = "";
                    foreach (string fileName in fileNames)
                    {
                        //txtFile.Text += fileName + "; ";
                        filename_temp += fileName + ";";
                        grvFileAndPic.SetRowCellValue(grvFileAndPic.FocusedRowHandle, gcBrower, filename_temp);

                    }

                    if (filename_temp.EndsWith(";"))
                    {
                        //txtFile.Text = txtFile.Text.Remove(txtFile.Text.LastIndexOf("; "));
                        filename_temp = filename_temp.Remove(filename_temp.LastIndexOf(";"));
                        grvFileAndPic.SetRowCellValue(grvFileAndPic.FocusedRowHandle, gcBrower, filename_temp);
                    }
                }

            }

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            List<InspectionStandardDto> list = grcFileAndPic.DataSource as List<InspectionStandardDto>;
            if (list == null || list.Count <= 0)
            {
                return;
            }
            string appDomainPath = string.Empty;
            appDomainPath = service.getImagePath(ProjectCode_Golbal, _UserInfoDto.UserID);

            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string path = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\";
            string[] picList = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i] as InspectionStandardDto).FileType == "图片")
                {
                    picList[i] = (list[i] as InspectionStandardDto).FileName;
                }
            }

            AllPictureShow2 pic = new AllPictureShow2(path, picList, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text,txtSubjectCode.Text, "", "");
            pic.ShowDialog();
        }

        private void btnViewRecheck_Click(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboProjects) == null ||
                string.IsNullOrEmpty(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString()))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择项目");
                return;
            }
            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            if (string.IsNullOrEmpty(txtSubjectCode.Text))
            {

                CommonHandler.ShowMessage(MessageType.Information, "没有体系定位号");
                return;
            }
            ReCheckLog re = new ReCheckLog(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                btnShopCode.Text, txtSubjectCode.Text);
            re.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除吗？") == DialogResult.Yes)
            {

                InspectionStandardDto dto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;
                try
                {
                    service.DeletePicture(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, dto.FileName,SubjectCode_Golbal);
                    string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                    string filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + dto.FileName + ".jpg";
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    CommonHandler.ShowMessage(MessageType.Information, "删除完毕");
                    GetFileAndPic();
                }
                catch (Exception ex)
                {
                    CommonHandler.ShowMessage(ex);
                }
            }
        }
        string[] lossDesc = new string[3];
        private void cboLoss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboLoss) != null && CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString()!="选择")
            {
                lossDesc[0] = CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString();
            }
            else
            {
                lossDesc[0] = "";
            }
            txtLossDesc.Text = lossDesc[0] + lossDesc[1] + lossDesc[2];
        }
        private void cboLoss2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboLoss2) != null && CommonHandler.GetComboBoxSelectedValue(cboLoss2).ToString() != "选择")
            {
                lossDesc[1] = CommonHandler.GetComboBoxSelectedValue(cboLoss2).ToString();
            }
            else
            {
                lossDesc[1] = "";
            }
            txtLossDesc.Text = lossDesc[0] + lossDesc[1] + lossDesc[2];
        }
        private void cboLoss3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboLoss3) != null && CommonHandler.GetComboBoxSelectedValue(cboLoss3).ToString() != "选择")
            {
                lossDesc[2] = CommonHandler.GetComboBoxSelectedValue(cboLoss3).ToString();
            }
            else
            {
                lossDesc[2] = "";
            }
            txtLossDesc.Text = lossDesc[0] + lossDesc[1] + lossDesc[2];
        }
        private void grcFileAndPic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }

        }
        private void grcLoss_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void grcLoss_DragDrop(object sender, DragEventArgs e)
        {
            if (_UserInfoDto.RoleType == "C") return;
            GridHitInfo bdhi = grvLoss.CalcHitInfo(new Point(e.X, e.Y));
            bdhi = grvLoss.CalcHitInfo(grcLoss.PointToClient(new System.Drawing.Point(e.X, e.Y)));
            if (bdhi.InRow)
            {

                int rowHandle = bdhi.RowHandle;

                String[] fileNames = (String[])e.Data.GetData(DataFormats.FileDrop);
                string fileNamesString = String.Empty;
                string fileName = string.Empty;

                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNamesString += fileNames[i];
                    fileName += txtShopName.Text + "_" + txtSubjectCode.Text + "_" + rowHandle + i.ToString();
                    if (i != fileNames.Length - 1)
                    {
                        fileNamesString += ";";
                        fileName += ";";
                    }
                }
                grvLoss.SetRowCellValue(rowHandle, gcLossBrower, fileNamesString);
                LossResultDto uploaddto = grvLoss.GetRow(rowHandle) as LossResultDto;
                uploaddto.FileName = fileName;
                grvLoss.SetRowCellValue(rowHandle, "PicName", uploaddto.FileName);
                string[] filenameList = fileName.Split(';');
                for (int i = 0; i < filenameList.Length; i++)
                {
                    //if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
                    //{
                    //uploaddto.FileName = txtShopName.Text + "_" + txtSubjectCode.Text + "_" + grvLoss.FocusedRowHandle.ToString();

                    CommonHandler.CompressionPic(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                        _UserInfoDto.UserID,fileNames[i], filenameList[i], CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text);
                    string appDomainPath = string.Empty;
                    appDomainPath = service.getImagePath(ProjectCode_Golbal, _UserInfoDto.UserID);

                    if (string.IsNullOrEmpty(appDomainPath))
                    {
                        appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    string filePath = appDomainPath +@"\"+ @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + filenameList[i] + ".jpg";
                    byte[] image = null;
                    if (File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open);
                        int streamLength = (int)fs.Length;
                        image = new byte[streamLength];
                        fs.Read(image, 0, streamLength);
                        fs.Close();
                    }
                    else
                    {
                        image = new byte[0];
                    }
                    service.SaveAnswerDtl2Streampic(_UserInfoDto.UserID,
                        image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text,
                        filenameList[i], "", "",SubjectCode_Golbal);
                    //}

                    //GetFileAndPic();
                }
                CommonHandler.ShowMessage(MessageType.Information, "图片上传成功！");
            }
        }
        private void grcFileAndPic_DragDrop(object sender, DragEventArgs e)
        {
            if (_UserInfoDto.RoleType == "C") return;
            string appDomainPath = string.Empty;
            //查看用户自己设置的图片存储路径
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this._UserInfoDto.UserID);
            //如果当然用户没有设置路径在程序安装下生成路径
            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            GridHitInfo bdhi = grvFileAndPic.CalcHitInfo(new Point(e.X, e.Y));
            bdhi = grvFileAndPic.CalcHitInfo(grcFileAndPic.PointToClient(new System.Drawing.Point(e.X, e.Y)));
            if (bdhi.InRow)
            {
                int rowHandle = bdhi.RowHandle;
                //获取当前文件
                String[] fileNames = (String[])e.Data.GetData(DataFormats.FileDrop);
                string fileNamesString = String.Empty;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNamesString += fileNames[i];
                    if (i != fileNames.Length - 1)
                        fileNamesString += ";";
                }
                //获得扩展名
                string extend = "." + fileNamesString.Split('.')[1];
                grvFileAndPic.SetRowCellValue(rowHandle, gcFileExtend, extend);

                grvFileAndPic.SetRowCellValue(rowHandle, gcBrower, fileNamesString);
                InspectionStandardDto uploaddto = grvFileAndPic.GetRow(rowHandle) as InspectionStandardDto;
                if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
                {
                    //如果是图片的话进行压缩
                    if (uploaddto.FileType == "图片")
                    {
                        CommonHandler.CompressionPic(ProjectCode_Golbal,_UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text);
                    }
                    else//如果是Office文件的话 Copy到指定的路径
                    {
                        string uploadImagePath = appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\";
                        try
                        {
                            if (!Directory.Exists(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text))
                            {
                                Directory.CreateDirectory(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text);
                            }
                            if (File.Exists(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend))
                            {
                                File.Delete(appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);
                            }
                            File.Copy(fileNamesString, appDomainPath + @"\" + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    string filePath = string.Empty;
                    if (uploaddto.FileType == "图片")
                    {
                        filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + ".jpg";
                    }
                    else
                    {
                        filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + extend;
                    }
                    byte[] image = null;
                    if (File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open);
                        int streamLength = (int)fs.Length;
                        image = new byte[streamLength];
                        fs.Read(image, 0, streamLength);
                        fs.Close();
                    }
                    else
                    {
                        image = new byte[0];
                    }
                    service.SaveAnswerDtl2Streampic(_UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName, "", extend,SubjectCode_Golbal);
                    CommonHandler.ShowMessage(MessageType.Information, "图片/文件 上传成功！");
                }
            }

        }

        private void btnAddRowLoss_Click(object sender, EventArgs e)
        {
            //if (CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString() == "选择" ||
            //    CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString() == "选择" ||
            //    CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString() == "选择")
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "失分说明选择不全！");
            //    return;
            //}
            LossResultDto loss = new LossResultDto();
            List<LossResultDto> inspectionList = grcLoss.DataSource as List<LossResultDto>;
            int? seqNO = 0;
            if (inspectionList == null || inspectionList.Count == 0)
            {
                loss.SeqNO = 1;
            }
            else
            {

                foreach (LossResultDto inp in inspectionList)
                {
                    if (Convert.ToInt32(inp.SeqNO) > seqNO)
                    {
                        seqNO = inp.SeqNO;
                    }
                }
                loss.SeqNO = seqNO+1;
            }
            
            //loss.LossName = lossDesc[0]+lossDesc[1]+lossDesc[2];
            loss.LossName = txtLossDesc.Text;
            dataHandler3.AddRow(loss);
        }

        private void btnDeleteLoss_Click(object sender, EventArgs e)
        {
            dataHandler3.DelCheckedRow(grvLoss.Columns.ColumnByFieldName("CheckMarkSelection"));
            selection.ClearSelection();
        }

        private void chkNotinvolved_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotinvolved.Checked)
            {
                txtScore.Text = "";
                txtScore.Properties.ReadOnly = true;
            }
            else
            {
                txtScore.Properties.ReadOnly = false;
            }
        }

        private void btnRecheckApply_Click(object sender, EventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要申请复审吗？") == DialogResult.Yes)
            {
                service.SaveRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal, "02", _UserInfoDto.UserID);
                Transfor();
            }
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LossResultDto dto = grvLoss.GetRow(grvLoss.FocusedRowHandle) as LossResultDto;

            string picname = dto.PicName;
            string[] picnamelist = picname.Split(';');
            string appDomainPath = string.Empty;
            appDomainPath = service.getImagePath(ProjectCode_Golbal, _UserInfoDto.UserID);

            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string path = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\";

            AllPictureShow2 pic = new AllPictureShow2(path, picnamelist, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text,txtSubjectCode.Text, "", "");
            pic.ShowDialog();

        }

        private void btnSpecialCaseApply_Click(object sender, EventArgs e)
        {
            SpecialCasePop specialCase = new SpecialCasePop(ProjectCode_Golbal, ShopCode_Golbal, txtShopName.Text, SubjectCode_Golbal, txtCheckPoint.Text, "Answer",_UserInfoDto);
            specialCase.ShowDialog();
            
        }

        private void btnSpecialCaseSearch_Click(object sender, EventArgs e)
        {
            SpecialCaseSearchPop spop = new SpecialCaseSearchPop();
            spop.ShowDialog();
        }

        private void btnUploadDataToServer_Click(object sender, EventArgs e)
        {
            if (txtShopName.Text == "" || btnShopCode.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                    return;
            }
            string appDomainPath = string.Empty;
            appDomainPath = service.getImagePath(ProjectCode_Golbal, _UserInfoDto.UserID);

            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string path = appDomainPath + @"UploadImage\" +
                CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text;
            string[] AllFilesList = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string name in AllFilesList)
            {
                string[] temp = name.Split('\\');
                string url = temp[temp.Length - 1];
                Upload(name, ("ftp://60.247.70.133//" + url).Replace("\\", "//"), "dsat", "dsat2011");
            }
        }
        bool Upload(string fileName, string uploadUrl, string UserName, string Password)
        {//fileName上傳的檔案ex : c:\abc.xml , uploadUrl上傳的FTP伺服器路徑ftp://127.0.0.1,UserName使用者FTP登入帳號 , Password使用者登入密碼

            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;

            try
            {

                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(uploadUrl);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;//設定Method上傳檔案
                uploadRequest.Proxy = null;
                if (UserName.Length > 0)//如果需要帳號登入
                {
                    NetworkCredential nc = new NetworkCredential(UserName, Password);
                    uploadRequest.Credentials = nc; //設定帳號

                }

                requestStream = uploadRequest.GetRequestStream();

                fileStream = File.Open(fileName, FileMode.Open);

                byte[] buffer = new byte[1024];

                int bytesRead;

                while (true)
                {//開始上傳資料流

                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    requestStream.Write(buffer, 0, bytesRead);
                }
                requestStream.Close();
                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                if (uploadResponse != null)
                    uploadResponse.Close();
                if (fileStream != null)
                    fileStream.Close();
                if (requestStream != null)
                    requestStream.Close();
            }

        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitializeView();
            btnAnswerStart.Enabled = true;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjects.SelectedIndex != 0)
            {
                btnSpecialCaseApply.Enabled = false;
                grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
                btnAddRowLoss.Enabled = false;
                btnDeleteLoss.Enabled = false;
                txtScore.Enabled = false;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = false;
            }
            else
            {
                btnSpecialCaseApply.Enabled = true; ;
                grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);
                btnAddRowLoss.Enabled = true; ;
                btnDeleteLoss.Enabled = true;
                txtScore.Enabled = true;
                chkNotinvolved.Enabled = true;
                txtRemark.Enabled = true;
            }
        }


    
    }
}
