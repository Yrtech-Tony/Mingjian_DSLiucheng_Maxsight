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
using System.Data.SqlClient;

namespace XHX.ViewLocalService
{

    public partial class AnswerRecheck : BaseForm
    {
        public string ProjectCode_Load { get; set; }
        public string SubjectCode_Load { get; set; }
        public string ShopCode_Load { get; set; }
        public string OrderNO_Load { get; set; }
        public char CheckType_Load { get; set; }

        public static localhost.Service service = new localhost.Service();

        int CurrentOrderNo = 0;
        string ProjectCode_Golbal = "";
        string SubjectCode_Golbal = "";
        string ShopCode_Golbal = "";
        int OrderNO_Golbal = 1;
        public string MenumName = string.Empty;
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

        public AnswerRecheck()
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
        public AnswerRecheck(string projectCode, string subjectCode, string shopCode, int order, char checkType, string examType, string shopName)
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            dataHandler = new XtraGridDataHandler<InspectionStandardDto>(grvInspectionStandard);
            dataHandler2 = new XtraGridDataHandler<InspectionStandardDto>(grvFileAndPic);
            dataHandler3 = new XtraGridDataHandler<LossResultDto>(grvLoss);
            XHX.Common.BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, projectCode);
            XHX.Common.BindComBox.BindSubjectExamType(cboExamType);
            CommonHandler.SetComboBoxSelectedValue(cboExamType, examType);
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboCheckOptions, GetAllCheckOptions(), "CheckOptionName", "CheckOptionCode");
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboFileAndPicCheckOptions, GetAllFileAndPictureCheckOptions(), "CheckOptionName", "CheckOptionCode");
            btnShopCode.Text = shopCode;
            txtShopName.Text = shopName;
            Transfor(projectCode, subjectCode, shopCode, order, checkType);

        }
        public override void InitButtonClick()
        {
            InitializeView();
            btnRecheck.Enabled = true;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

        }
        public override List<XHX.BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            list.Add(XHX.BaseForm.ButtonType.InitButton);
            return list;
        }
        public void OnLoadView()
        {
            XHX.Common.BindComBox.BindProject(cboProjects);
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            XHX.Common.BindComBox.BindSubjectExamType(cboExamType);
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
            txtShopName.Text = "";
            txtOrder2.Text = "1";
            txtScore.Text = "";
            txtLastScore.Text = "";
            txtRecheckContent.Text = "";
            txtScore.Enabled = false;

            chkLastNotinvolved.Checked = false;
            chkNotinvolved.Checked = false;
            btnShopCode.Properties.ReadOnly = false;
            btnShopCode.Text = "";
            btnShopCode.Enabled = true;
            cboProjects.Properties.ReadOnly = false;
            grcInspectionStandard.DataSource = null;
            grcFileAndPic.DataSource = null;
            grcLoss.DataSource = null;
            btnSpecialCaseApply.Enabled = false; ;
            btnSpecialCaseSearch.Enabled = false;
            btnTransfer.Enabled = false;
            txtScore.Enabled = true;
            txtRemark.Enabled = true;
            chkLastNotinvolved.Enabled = false;
            chkNotinvolved.Enabled = false;
            txtRecheckContent.Enabled = false;
            grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
            grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);

        }
        public bool RecheckStatus()
        {
            DataSet ds = service.SearchRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSpecialCaseApply.Enabled = false;
                grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
                txtScore.Enabled = false;
                chkNotinvolved.Enabled = false;
                txtRemark.Enabled = false;
                //btnReCheckFinish.Enabled = false;
                return true;
            }
            else
            {
                btnSpecialCaseApply.Enabled = true; ;
                grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
                grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);
                txtScore.Enabled = true;
                chkNotinvolved.Enabled = true;
                txtRemark.Enabled = true;
                // btnReCheckFinish.Enabled = true;
                return false;
            }


        }
        #region 事件

        private void btnShopCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Shop_Popup pop = new Shop_Popup("", "", false);
            pop.ShowDialog();
            ShopDto dto = pop.Shopdto;
            if (dto != null)
            {
                btnShopCode.Text = dto.ShopCode;
                txtShopName.Text = dto.ShopName;
            }
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            //卖场改变的时候对应的试卷类型也进行改变

            //List<ShopSubjectExamTypeDto> list = new List<ShopSubjectExamTypeDto>();
            ShopSubjectExamTypeDto shop = new ShopSubjectExamTypeDto();
            DataSet ds = service.SearchShopExamTypeByProjectCodeAndShopCode(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                shop.ExamTypeCode = ds.Tables[0].Rows[0]["SubjectTypeCodeExam"] == null ? "" : ds.Tables[0].Rows[0]["SubjectTypeCodeExam"].ToString();
            }
            else
            {
                shop.ExamTypeCode = "";
            }
            CommonHandler.SetComboBoxSelectedValue(cboExamType, shop.ExamTypeCode);
        }
        private string GetRecheckStatusCode()
        {
            DataSet ds = service.SearchRecheckStatus(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
            string recheckStatusCode = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                recheckStatusCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();

            }
            return recheckStatusCode;
        }
        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            DataSet ds = service.SearchReCheckProcess(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count == 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有提交复审");
                return;
            }

            RecheckStatus();
            if (MenumName == "照片类")
            {
                CheckType = 'A';

                btnTransfer.Enabled = true;

                StartCheck('A', ButtonType.FirstReCheck);
            }
            else if (MenumName == "资料类")
            {
                CheckType = 'B';

                btnTransfer.Enabled = true;

                StartCheck('B', ButtonType.SecondReChek);
            }
            else if (MenumName == "交叉类")
            {
                CheckType = 'C';

                btnTransfer.Enabled = true;

                StartCheck('C', ButtonType.ThirdReCheck);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            string imageName = "";
            if (imageName == null)
            {
                return;
            }
            string reCheckTypeCode = "0" + CheckType;
            string passReCheck = "";
            if (rdoYes.Checked)
                passReCheck = "1";
            else
                passReCheck = "0";
            decimal? score;
            if (chkNotinvolved.Checked)
            {
                score = null;
            }
            else
            {
                score = Convert.ToDecimal(txtScore.Text);
            }
            service.SaveRecheck(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, this.UserInfoDto.UserID,
                                   txtRecheckContent.Text, reCheckTypeCode, passReCheck, score, chkSystem.Checked);

            //保存RecheckDtl
            string ScoreError = "";
            string DescError = "";
            string PicError = "";
            string StandardEorror = "";
            if (chkScoreError.Checked)
            {
                ScoreError = "EA";
            }
            if (chkDesc.Checked)
            {
                DescError = "EB";
            }
            if (chkPic.Checked)
            {
                PicError = "EC";
            }
            if (chkStandardError.Checked)
            {
                StandardEorror = "ED";
            }
            if (ScoreError == "")
            {
                service.DeleteRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, "EA");
            }
            else
            {
                service.SaveRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, this.UserInfoDto.UserID, ScoreError);
            }
            if (DescError == "")
            {
                service.DeleteRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, "EB");
            }
            else
            {
                service.SaveRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, this.UserInfoDto.UserID, DescError);
            }
            if (PicError == "")
            {
                service.DeleteRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, "EC");
            }
            else
            {
                service.SaveRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, this.UserInfoDto.UserID, PicError);
            }
            if (StandardEorror == "")
            {
                service.DeleteRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, "ED");
            }
            else
            {
                service.SaveRecheckDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal, reCheckTypeCode, this.UserInfoDto.UserID, StandardEorror);
            }
            //查询下一个问卷信息并显示
            DataSet ds = service.SearchNextSubject(ProjectCode_Golbal, ShopCode_Golbal,
                                                    OrderNO_Golbal, CheckType, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());
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
            GetRecheckDtl(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, reCheckTypeCode);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (base.UserInfoDto.RoleType == "C") return;
            //查询上一个问卷信息并显示

            DataSet ds = service.SearchPreSubject(ProjectCode_Golbal,
                                                    ShopCode_Golbal,
                                                    OrderNO_Golbal, CheckType, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());

            if (!GetSubject(ds, ButtonType.Previous))
                return;



            //查询下一个问卷的检查标准信息
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();

            DataSet ds2 = service.SearchPreSubjectInsecptionStardard(ProjectCode_Golbal,
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
            GetRecheckDtl(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, "0" + CheckType);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfor();
            btnSpecialCaseSearch.Enabled = true;
        }
        public void Transfor(string projectCode, string subjectCode, string shopCode, int order, char checktype)
        {
            //RecheckStatus();
            btnSpecialCaseApply.Enabled = false;
            grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
            grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
            txtScore.Enabled = false;
            chkNotinvolved.Enabled = false;
            txtRemark.Enabled = false;
            panel1.Enabled = false;

            DataSet ds = service.SearchPreSubjectTypeISO(projectCode, shopCode, order, checktype, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());
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
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist;

            GetFileAndPic();
        }
        private void Transfor()
        {
            RecheckStatus();

            DataSet ds = service.SearchPreSubjectTypeISO(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                btnShopCode.Text, Convert.ToInt32(txtOrder2.Text), CheckType, "A");
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
            GetRecheckDtl(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, "0" + CheckType);
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
            if (base.UserInfoDto.RoleType == "C")
            {
                e.Cancel = true;
            }
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
            //RecheckStatus();
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
                if (ds.Tables[0].Rows[0]["PassReCheck"] == DBNull.Value)
                {
                    subjectDto.PassReCheck = true;
                }
                else
                {
                    subjectDto.PassReCheck = Convert.ToBoolean(ds.Tables[0].Rows[0]["PassReCheck"]);
                }
                subjectDto.ReCheckContent = Convert.ToString(ds.Tables[0].Rows[0]["ReCheckContent"]);
                subjectDto.CheckYesOrNO = Convert.ToBoolean(ds.Tables[0].Rows[0]["CheckYesOrNO"]);
                subjectDto.AssessmentDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AssessmentDate"]);
                subjectDto.SubjectTypeCodeExam = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
                subjectDto.AdminModifyChk = Convert.ToBoolean(ds.Tables[0].Rows[0]["AdminModifyChk"]);
            }
            else
            {
                //如果直接点击跳转按钮的话，不存在Subject弹出提示
                if (buttonType == ButtonType.Transfer)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "不存在这个执行文件！");
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
                    CommonHandler.ShowMessage(MessageType.Information, "已经完毕,可以使用跳转功能来查看！");
                    return false;
                }

                else if (buttonType == ButtonType.FirstReCheck)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "照片类复查已经完毕，可以使用跳转功能来查看！");
                    return false;
                }

                else if (buttonType == ButtonType.SecondReChek)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "资料类复查已经完毕，可以使用跳转功能来查看！");
                    return false;
                }

                else if (buttonType == ButtonType.ThirdReCheck)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "交叉类复查已经完毕，可以使用跳转功能来查看！");
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
            CurrentOrderNo = subjectDto.OrderNO;
            txtAdditionalDesc.Text = subjectDto.AdditionalDesc;
            txtCheckPoint.Text = subjectDto.CheckPoint;
            txtDesc.Text = subjectDto.Desc;
            txtImplementation.Text = subjectDto.Implementation;
            txtInspectionDesc.Text = subjectDto.InspectionDesc;
            txtRemark.Text = subjectDto.Remark;
            txtSeqNo.Text = subjectDto.OrderNO.ToString();

            if (subjectDto.Score == 9999)
            {
                chkNotinvolved.Checked = true;
                txtScore.Text = string.Empty;
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
            CommonHandler.SetComboBoxSelectedValue(cboExamType, subjectDto.SubjectTypeCodeExam.ToString());
            cboExamType.Properties.ReadOnly = true;
            OrderNO_Golbal = subjectDto.OrderNO;

            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            char checkType = '0';


            DataSet dsCheckType = service.SearchPassReCheckBySubjectCode(subjectDto.ProjectCode, subjectDto.SubjectCode, btnShopCode.Text);

            if (dsCheckType.Tables[0].Rows.Count > 0)
            {
                // checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
            }
            //if (checkType != '0')
            //{

            //if (subjectDto.CheckYesOrNO == true)
            //{
            if (subjectDto.PassReCheck)
                rdoYes.Checked = true;
            else
                rdoNO.Checked = true;
            txtRecheckContent.Text = subjectDto.ReCheckContent;
            //}
            rdoYes.Enabled = true;
            rdoNO.Enabled = true;
            txtRecheckContent.Enabled = true;
            //}
            if (subjectDto.AdminModifyChk == true)
            {
                chkSystem.Checked = true;
            }
            else
            {
                chkSystem.Checked = false;
            }
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
        public void GetRecheckDtl(string projectCode, string shopCode, string subjectCode, string recheckType)
        {
            List<ReCheckDtlDto> reCheckDtlList = new List<ReCheckDtlDto>();
            DataSet ds = service.SearchReCheckDtl(projectCode, subjectCode, shopCode, recheckType);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ReCheckDtlDto reCheckDtl = new ReCheckDtlDto();
                    reCheckDtl.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    reCheckDtl.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    reCheckDtl.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    reCheckDtl.ReCheckType = Convert.ToString(ds.Tables[0].Rows[i]["ReCheckType"]);
                    reCheckDtl.ErrorType = Convert.ToString(ds.Tables[0].Rows[i]["ErrorType"]);
                    if (reCheckDtl.ErrorType == "EA")
                    {
                        chkScoreError.Checked = true;
                    }
                    else
                    {

                        chkScoreError.Checked = false;
                    }
                    if (reCheckDtl.ErrorType == "EB")
                    {
                        chkDesc.Checked = true;
                    }
                    else
                    {
                        chkDesc.Checked = false;
                    }
                    if (reCheckDtl.ErrorType == "EC")
                    {
                        chkPic.Checked = true;
                    }
                    else
                    {
                        chkPic.Checked = false;
                    }
                    if (reCheckDtl.ErrorType == "ED")
                    {
                        chkStandardError.Checked = true;
                    }
                    else
                    {
                        chkStandardError.Checked = false;
                    }
                    reCheckDtlList.Add(reCheckDtl);
                }
            }
            else
            {
                chkScoreError.Checked = false;
                chkDesc.Checked = false;
                chkPic.Checked = false;
                chkStandardError.Checked = false;
            }
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
            if (base.UserInfoDto.RoleType == "C" && grvFileAndPic.FocusedColumn != gcViewPicture)
            {
                e.Cancel = true;
            }
            if (RecheckStatus() && (grvFileAndPic.FocusedColumn == gcBrower || grvFileAndPic.FocusedColumn == gcDelete
                                    || grvFileAndPic.FocusedColumn == gcPictureUpload))
            {
                e.Cancel = true;
            }

        }

        private void btnViewPicture_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            InspectionStandardDto dto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;
            if (dto.FileType == "图片")
            {
                PictureShow2 pic = new PictureShow2(dto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, txtSubjectCode.Text, dto.FilePath);
                pic.ShowDialog();
            }

        }

        private void btnPictureUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            InspectionStandardDto uploaddto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;

            if (string.IsNullOrEmpty(uploaddto.FilePath))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择图片!");
                grvFileAndPic.FocusedColumn = gcBrower;
                grvFileAndPic.FocusedRowHandle = (grcFileAndPic.DataSource as List<InspectionStandardDto>).IndexOf(uploaddto);
                return;
            }
            if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
            {
                CommonHandler.CompressionPic(ProjectCode_Golbal, this.UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, txtShopName.Text);

                string appDomainPath = string.Empty;
                appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                if (string.IsNullOrEmpty(appDomainPath))
                {
                    appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                string filePath = appDomainPath + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + ".jpg";
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
                //service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName,"");
                CommonHandler.ShowMessage(MessageType.Information, "图片上传成功！");
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
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string path = appDomainPath + @"UploadImage\" + txtShopName.Text + @"\";
            string[] picList = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                picList[i] = (list[i] as InspectionStandardDto).FileName;
            }

            AllPictureShow2 pic = new AllPictureShow2(path, picList, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, txtSubjectCode.Text, "", "");
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
            InspectionStandardDto dto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;
            try
            {
                service.DeletePicture(txtShopName.Text, dto.FileName, SubjectCode_Golbal);
                string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = appDomainPath + @"UploadImage\" + txtShopName.Text + @"\" + dto.FileName + ".jpg";
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
        string[] lossDesc = new string[3];


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
            GridHitInfo bdhi = grvLoss.CalcHitInfo(new Point(e.X, e.Y));
            bdhi = grvLoss.CalcHitInfo(grcLoss.PointToClient(new System.Drawing.Point(e.X, e.Y)));
            if (bdhi.InRow)
            {

                int rowHandle = bdhi.RowHandle;

                String[] fileNames = (String[])e.Data.GetData(DataFormats.FileDrop);
                string fileNamesString = String.Empty;

                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNamesString += fileNames[i];
                    if (i != fileNames.Length - 1)
                        fileNamesString += ";";
                }
                grvLoss.SetRowCellValue(rowHandle, gcLossBrower, fileNamesString);
                LossResultDto uploaddto = grvLoss.GetRow(rowHandle) as LossResultDto;
                if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
                {
                    uploaddto.FileName = txtShopName.Text + "_" + txtSubjectCode.Text + "_" + grvLoss.FocusedRowHandle.ToString();

                    grvLoss.SetRowCellValue(rowHandle, "PicName", uploaddto.FileName);

                    CommonHandler.CompressionPic(ProjectCode_Golbal, this.UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, txtShopName.Text);
                    string appDomainPath = string.Empty;
                    appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                    if (string.IsNullOrEmpty(appDomainPath))
                    {
                        appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    string filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + ".jpg";
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
                    //service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName,"");
                    CommonHandler.ShowMessage(MessageType.Information, "图片上传成功！");
                    //GetFileAndPic();
                }
            }
        }
        private void grcFileAndPic_DragDrop(object sender, DragEventArgs e)
        {
            GridHitInfo bdhi = grvFileAndPic.CalcHitInfo(new Point(e.X, e.Y));
            bdhi = grvFileAndPic.CalcHitInfo(grcFileAndPic.PointToClient(new System.Drawing.Point(e.X, e.Y)));
            if (bdhi.InRow)
            {

                int rowHandle = bdhi.RowHandle;

                String[] fileNames = (String[])e.Data.GetData(DataFormats.FileDrop);
                string fileNamesString = String.Empty;

                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNamesString += fileNames[i];
                    if (i != fileNames.Length - 1)
                        fileNamesString += ";";
                }
                grvFileAndPic.SetRowCellValue(rowHandle, gcBrower, fileNamesString);
                InspectionStandardDto uploaddto = grvFileAndPic.GetRow(rowHandle) as InspectionStandardDto;
                if (uploaddto.FilePath.Contains(':') && uploaddto.FilePath.Contains('\\'))
                {
                    CommonHandler.CompressionPic(ProjectCode_Golbal, this.UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, txtShopName.Text);
                    string appDomainPath = string.Empty;
                    appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                    if (string.IsNullOrEmpty(appDomainPath))
                    {
                        appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    string filePath = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + uploaddto.FileName + ".jpg";
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
                    //service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName,"");
                    CommonHandler.ShowMessage(MessageType.Information, "图片上传成功！");
                    //GetFileAndPic();
                }
            }

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

        //private void btnRecheckApply_Click(object sender, EventArgs e)
        //{
        //    if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要申请复审吗？") == DialogResult.Yes)
        //    {
        //        service.SaveRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal, "02", this.UserInfoDto.UserID);
        //        Transfor();
        //    }
        //}

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LossResultDto dto = grvLoss.GetRow(grvLoss.FocusedRowHandle) as LossResultDto;

            //PictureShow2 pic = new PictureShow2(dto.PicName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, dto.FilePath);
            //pic.ShowDialog();
            string picname = dto.PicName;
            string[] picnamelist = picname.Split(';');
            string appDomainPath = string.Empty;
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string path = appDomainPath + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\";

            AllPictureShow2 pic = new AllPictureShow2(path, picnamelist, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, txtSubjectCode.Text, "", "");
            pic.ShowDialog();

        }

        private void btnSpecialCaseApply_Click(object sender, EventArgs e)
        {
            SpecialCasePop specialCase = new SpecialCasePop(ProjectCode_Golbal, ShopCode_Golbal, txtShopName.Text, SubjectCode_Golbal, txtCheckPoint.Text, "Answer", this.UserInfoDto);
            specialCase.ShowDialog();

        }

        private void btnSpecialCaseSearch_Click(object sender, EventArgs e)
        {
            SpecialCaseSearchPop spop = new SpecialCaseSearchPop("", "", "", txtSubjectCode.Text, this.UserInfoDto);
            spop.ShowDialog();
        }

        private void AnswerRecheck_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                MenumName = this.Tag.ToString();
                btnRecheck.Text = MenumName;
            }

        }

        private void btnReCheckFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            DataSet ds = service.SearchReCheckProcess(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count == 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有提交复审");
                return;
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定复审完毕吗？") == DialogResult.Yes)
            {
                if (MenumName == "照片类")
                {
                    service.RechekComplete(ProjectCode_Golbal, ShopCode_Golbal, "SA", this.UserInfoDto.UserID);

                }
                else if (MenumName == "资料类")
                {
                    service.RechekComplete(ProjectCode_Golbal, ShopCode_Golbal, "SB", this.UserInfoDto.UserID);

                }
                else if (MenumName == "交叉类")
                {
                    service.RechekComplete(ProjectCode_Golbal, ShopCode_Golbal, "SC", this.UserInfoDto.UserID);

                }
                //所有的都通过复审的话，自动保存为一审修改完毕
                if (Convert.ToInt32(service.CheckShopAllPassRechk(ProjectCode_Golbal, ShopCode_Golbal, "07").Tables[0].Rows[0]["NotPassCount"]) == 0)
                {
                    service.RechekComplete(ProjectCode_Golbal, ShopCode_Golbal, "S1", this.UserInfoDto.UserID);
                }
            }

        }

    }
}
