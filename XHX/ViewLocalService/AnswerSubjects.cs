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
using System.Net;
using System.Xml;

namespace XHX.ViewLocalService
{

    public partial class AnswerSubjects : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        int CurrentOrderNo = 0;
        string ProjectCode_Golbal = "";
        string SubjectCode_Golbal = "";
        string ShopCode_Golbal = "";
        int OrderNO_Golbal = 1;
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

        public AnswerSubjects()
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
        public AnswerSubjects(string projectCode, string subjectCode, string shopCode, int order, char checkType)
        {
            InitializeComponent();


            dataHandler = new XtraGridDataHandler<InspectionStandardDto>(grvInspectionStandard);
            dataHandler2 = new XtraGridDataHandler<InspectionStandardDto>(grvFileAndPic);
            dataHandler3 = new XtraGridDataHandler<LossResultDto>(grvLoss);
            XHX.Common.BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, projectCode);
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboCheckOptions, GetAllCheckOptions(), "CheckOptionName", "CheckOptionCode");
            CommonHandler.BindComboBoxItems<CheckOptionsDto>(cboFileAndPicCheckOptions, GetAllFileAndPictureCheckOptions(), "CheckOptionName", "CheckOptionCode");
            Transfor(projectCode, subjectCode, shopCode, order, checkType);

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
            // txtImplementation.Text = "";
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
            grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
            grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);
            BindComBox.BindLoss(cboLoss, cboLoss2, cboLoss3, "", "");

        }
        public bool RecheckStatus()
        {
            DataSet ds = service.SearchRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0 || cboProjects.SelectedIndex != 0)
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

        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            if (base.UserInfoDto.RoleType == "C")
            {
                cboLoss.Enabled = false;
                cboLoss2.Enabled = false;
                cboLoss3.Enabled = false;
                txtRemark.Enabled = false;

            }
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            DataSet ds = service.AnswerStartInfoSearch(ProjectCode_Golbal, btnShopCode.Text);
            if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count == 0)
            {
                AnswerStartInfo answer = new AnswerStartInfo(ProjectCode_Golbal, btnShopCode.Text, txtShopName.Text, this.UserInfoDto.UserID);
                answer.ShowDialog();
            }
            btnTransfer.Enabled = true;
           // ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            StartCheck('0', ButtonType.StartCheck);
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            string imageName = "";
            string LastSubjectCode = "";
            string LastOrderNO = "";
            LastSubjectCode = SubjectCode_Golbal;
            LastOrderNO = OrderNO_Golbal.ToString();

            if (imageName == null)
            {
                return;
            }
            decimal fullScore = 0;

            DataSet dsFullScore = service.SearchFullScoreByProjectCodeAndSubjectCode(ProjectCode_Golbal, SubjectCode_Golbal);
            if (dsFullScore.Tables[0].Rows.Count > 0)
            {
                fullScore = (decimal)dsFullScore.Tables[0].Rows[0]["FullScore"];
            }
            
            if (string.IsNullOrEmpty(txtScore.Text) && !chkNotinvolved.Checked)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请填写分数");
                return;
            }
            
            //if (grvInspectionStandard.RowCount != 0 && (SubjectCode_Golbal != "1.2.1" && SubjectCode_Golbal != "1.2.5"))
            //{
            //    // 选是的个数
            //    int YesCount = 0;
            //    //选不涉及的个数
            //    int notCheckCount = 0;
            //    foreach (InspectionStandardDto dto in grcInspectionStandard.DataSource as List<InspectionStandardDto>)
            //    {
            //        if (dto.CheckOptionCode == "01")
            //        {
            //            YesCount++;
            //        }
            //        if (dto.CheckOptionCode == "03")
            //        {
            //            notCheckCount++;
            //        }
            //    }
            //    if (!chkNotinvolved.Checked)
            //    {
            //        if (notCheckCount == 0)
            //        {
            //            if (YesCount == (grcInspectionStandard.DataSource as List<InspectionStandardDto>).Count)
            //            {
            //                if (Convert.ToDecimal(txtScore.Text) != fullScore)
            //                {
            //                    CommonHandler.ShowMessage(MessageType.Information, "检查标准全部选择为" + " :是 只能输入" + fullScore.ToString() + "分");
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                if (Convert.ToDecimal(txtScore.Text) == fullScore)
            //                {
            //                    CommonHandler.ShowMessage(MessageType.Information, "检查标准存在为" + " :否 不能输入满分");
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (YesCount + notCheckCount != (grcInspectionStandard.DataSource as List<InspectionStandardDto>).Count
            //                && (Convert.ToDecimal(txtScore.Text) == fullScore))
            //            {
            //                CommonHandler.ShowMessage(MessageType.Information, "检查标准存在为" + " :否 不能输入满分");
            //                return;
            //            }
            //            if (YesCount + notCheckCount == (grcInspectionStandard.DataSource as List<InspectionStandardDto>).Count
            //                && (Convert.ToDecimal(txtScore.Text) != fullScore))
            //            {
            //                CommonHandler.ShowMessage(MessageType.Information, "检查标准全部选择为" + " :是 只能输入" + fullScore.ToString() + "分");
            //                return;
            //            }

            //        }
            //    }
            //}
            //if (!chkNotinvolved.Checked)
            //{
            //    if ((Convert.ToDecimal(txtScore.Text) != fullScore) && (grcLoss.DataSource as List<LossResultDto>).Count == 0
            //        && SubjectCode_Golbal != "1.2.1" && SubjectCode_Golbal != "1.2.5")
            //    {
            //        CommonHandler.ShowMessage(MessageType.Information, "不是满分，必须添加失分说明");
            //        return;
            //    }
            //}
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
                            score, txtRemark.Text, imageName, this.UserInfoDto.UserID,
                            CheckType, passReCheck, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"),"");

            //保存得分记录
            service.SaveAnswerLog(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, "00", score, txtRemark.Text, this.UserInfoDto.UserID);
            //保存问卷的检查标准信息
            foreach (InspectionStandardDto dto in grcInspectionStandard.DataSource as List<InspectionStandardDto>)
            {

                service.SaveAnswerDtl(ProjectCode_Golbal, SubjectCode_Golbal, ShopCode_Golbal,
                                                 dto.SeqNO, this.UserInfoDto.UserID, dto.CheckOptionCode, "");
            }
            //保存图片或者文件存在与否的信息
            foreach (InspectionStandardDto dto in grcFileAndPic.DataSource as List<InspectionStandardDto>)
            {

                service.SaveAnswerDtl2Stream(ProjectCode_Golbal,
                                     SubjectCode_Golbal,
                                     ShopCode_Golbal,
                                     dto.SeqNO,
                                     this.UserInfoDto.UserID,
                                     dto.CheckOptionCode, null, txtShopName.Text, dto.FileExtend);

            }
            //保存失分说明
            foreach (LossResultDto dto in dataHandler3.DataList as List<LossResultDto>)
            {
                service.SaveLossDesc(ProjectCode_Golbal, ShopCode_Golbal,txtShopName.Text.Trim(), SubjectCode_Golbal, dto.LossName, dto.PicName, dto.SeqNO, dto.StatusType,"");
            }
            //查询下一个问卷信息并显示
            DataSet ds = service.SearchNextSubject(ProjectCode_Golbal, ShopCode_Golbal,
                                                    OrderNO_Golbal, CheckType, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());
            if (!GetSubject(ds, ButtonType.Next))
                return;

            try
            {

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
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "02" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist2.Add(inspectionStandardDto);
                }

            }
            grcInspectionStandard.DataSource = null;
            grcInspectionStandard.DataSource = inspectionStandardlist2;

            GetFileAndPic();
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
                SubjectCode_Golbal = LastSubjectCode;
                txtSubjectCode.Text = SubjectCode_Golbal;

                OrderNO_Golbal = Convert.ToInt32(LastOrderNO);
                txtSeqNo.Text = OrderNO_Golbal.ToString();
            }
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
            //List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();

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
        }


        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfor();
        }
        public void Transfor(string projectCode, string subjectCode, string shopCode, int order, char checktype)
        {
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            RecheckStatus();
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
            GetLossDesc(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal);

        }
        private void Transfor()
        {
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;
            RecheckStatus();

            DataSet ds = service.SearchPreSubjectTypeISO(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                btnShopCode.Text, Convert.ToInt32(txtOrder2.Text), CheckType, CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString());
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
            if (base.UserInfoDto.RoleType == "C")
            {
                e.Cancel = true;
            }
            //if (grvInspectionStandard.FocusedColumn == gcCheckResult && RecheckStatus())
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
            if (CommonHandler.GetComboBoxSelectedValue(cboExamType).ToString() == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有设置经销商的试卷类型！");
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
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "02" : Convert.ToString(ds2.Tables[0].Rows[i]["CheckOptionCode"]);
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
            //txtImplementation.Text = subjectDto.Implementation;
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


            DataSet dsCheckType = service.SearchPassReCheckBySubjectCode(subjectDto.ProjectCode, subjectDto.SubjectCode, btnShopCode.Text);

            if (dsCheckType.Tables[0].Rows.Count > 0)
            {
                //checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
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
            if (base.UserInfoDto.RoleType == "C" && grvFileAndPic.FocusedColumn != gcViewPicture)
            {
                e.Cancel = true;
            }
            if ((RecheckStatus() || cboProjects.SelectedIndex != 0) && (grvFileAndPic.FocusedColumn == gcBrower || grvFileAndPic.FocusedColumn == gcDelete
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
                PictureShow2 pic = new PictureShow2(dto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text,
                                                    txtSubjectCode.Text, dto.FilePath);
                pic.ShowDialog();
            }
            else
            {
                OfficeShow office = new OfficeShow(dto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, txtSubjectCode.Text, dto.FileExtend);
                office.ShowDialog();
            }

        }

        private void btnPictureUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            string appDomainPath = string.Empty;
            //查看用户自己设置的图片存储路径
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);
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
                grvFileAndPic.SetRowCellValue(grvFileAndPic.FocusedRowHandle, gcFileExtend, extend);
                if (uploaddto.FileType == "图片")
                {
                    CommonHandler.CompressionPic(ProjectCode_Golbal, this.UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, ProjectCode_Golbal + txtShopName.Text);
                }
                else
                {
                    string uploadImagePath = appDomainPath + @"UploadImage\" + txtShopName.Text + @"\";
                    try
                    {
                        if (!Directory.Exists(appDomainPath + @"UploadImage\" + txtShopName.Text))
                        {
                            Directory.CreateDirectory(appDomainPath + @"UploadImage\" + txtShopName.Text);
                        }
                        if (File.Exists(appDomainPath + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend))
                        {
                            File.Delete(appDomainPath + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);
                        }
                        File.Copy(uploaddto.FilePath, appDomainPath + @"UploadImage\" + txtShopName.Text + @"\" + uploaddto.FileName + extend);

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
                service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName, "", extend, SubjectCode_Golbal);
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
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

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
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除吗？") == DialogResult.Yes)
            {
                InspectionStandardDto dto = grvFileAndPic.GetRow(grvFileAndPic.FocusedRowHandle) as InspectionStandardDto;
                try
                {
                    service.DeletePicture(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, dto.FileName, SubjectCode_Golbal);
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
            if (CommonHandler.GetComboBoxSelectedValue(cboLoss) != null && CommonHandler.GetComboBoxSelectedValue(cboLoss).ToString() != "选择")
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

                    CommonHandler.CompressionPic(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), this.UserInfoDto.UserID, fileNames[i], filenameList[i], CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text);
                    string appDomainPath = string.Empty;
                    appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                    if (string.IsNullOrEmpty(appDomainPath))
                    {
                        appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    string filePath = appDomainPath + @"\" + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + filenameList[i] + ".jpg";
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
                    service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID,
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
            string appDomainPath = string.Empty;
            //查看用户自己设置的图片存储路径
            appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);
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
                        CommonHandler.CompressionPic(ProjectCode_Golbal, this.UserInfoDto.UserID, uploaddto.FilePath, uploaddto.FileName, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text);
                    }
                    else//如果是Office文件的话 Copy到指定的路径
                    {
                        string uploadImagePath = appDomainPath + @"\" + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text + @"\";
                        try
                        {
                            if (!Directory.Exists(appDomainPath + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text))
                            {
                                Directory.CreateDirectory(appDomainPath + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text);
                            }
                            if (File.Exists(appDomainPath + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text + @"\" + uploaddto.FileName + extend))
                            {
                                File.Delete(appDomainPath + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text + @"\" + uploaddto.FileName + extend);
                            }
                            File.Copy(fileNamesString, appDomainPath + @"\" + @"UploadImage\" + ProjectCode_Golbal + txtShopName.Text + @"\" + uploaddto.FileName + extend);

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
                    try
                    {
                        service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, uploaddto.FileName, "", extend, SubjectCode_Golbal);
                    }
                    catch (Exception exxx)
                    {
                        MessageBox.Show(exxx.ToString());
                    }
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
            //  dar  return;
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
                loss.SeqNO = seqNO + 1;
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


        /// <summary>
        /// 检查需要打分的数据是否都已经进行打分
        /// 不需要打分的内容是否被打分
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="shopCode"></param>
        /// <param name="userid"></param>
        private void CheckScoreValid(string projectCode, string shopCode, string userid)
        {

        }
        private void btnRecheckApply_Click(object sender, EventArgs e)
        {
            List<SubjectCheckDto> list = new List<SubjectCheckDto>();
            string strList = "";

            DataSet ds = service.GetNotAnswerSubject(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ErrorType"].ToString() == "1")
                    {
                        SubjectCheckDto subject = new SubjectCheckDto();
                        subject.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                        strList += subject.SubjectCode + ";";
                        list.Add(subject);
                    }
                }
            }
            if (list.Count > 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "存在没有打分的题" + strList);
                return;
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要申请复审吗？") == DialogResult.Yes)
            {
                service.SaveRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal, "S0", this.UserInfoDto.UserID);
                Transfor();
            }
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LossResultDto dto = grvLoss.GetRow(grvLoss.FocusedRowHandle) as LossResultDto;
            string picname = dto.PicName;
            string[] picnamelist = picname.Split(';');

            string path = AppDomain.CurrentDomain.BaseDirectory + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\";

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
        public override void InitButtonClick()
        {
            InitializeView();
            btnAnswerStart.Enabled = true;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
        }
        public override List<XHX.BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            list.Add(XHX.BaseForm.ButtonType.InitButton);

            return list;
        }

        private void btnUploadDataToServer_Click(object sender, EventArgs e)
        {
            if (txtShopName.Text == "" || btnShopCode.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            try
            {
                UploadData(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
                string appDomainPath = string.Empty;
                appDomainPath = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                if (string.IsNullOrEmpty(appDomainPath))
                {
                    appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                string path = appDomainPath + @"\" + @"UploadImage\" +
                    CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text;
                if (Directory.Exists(path))
                {
                    //Makefolder((CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text), "ftp://60.247.70.133/UpLoadImage/", "dsat", "dsat2011");
                    string[] AllFilesList = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                    //foreach (string name in AllFilesList)
                    //{
                    //    string[] temp = name.Split('\\');
                    //    string foler = temp[temp.Length - 2];
                    //    string url = temp[temp.Length - 1];
                    //    DeleteFTPFile(url,
                    //        ("ftp://60.247.70.133/UpLoadImage" + "/" + (CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text+"/")).Replace("\\", "//"), "dsat", "dsat2011");
                    //}
                    foreach (string name in AllFilesList)
                    {
                        if (!name.Contains("Thumbs.db"))
                        {
                            string[] temp = name.Split('\\');
                            string foler = temp[temp.Length - 2];
                            string url = temp[temp.Length - 1];
                            //DeleteFTPFile(url,
                            //    ("ftp://60.247.70.133/UpLoadImage" + "/" +
                            //    (CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text+@"/")).Replace("\\", "//"), "dsat", "dsat2011");
                            //Upload(name,
                            //    ("ftp://60.247.70.133/UpLoadImage" + "/" + (CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text) + "/" + url).Replace("\\", "//"), "dsat", "dsat2011");
                            string appDomain = string.Empty;
                            appDomain = service.getImagePath(ProjectCode_Golbal, this.UserInfoDto.UserID);

                            if (string.IsNullOrEmpty(appDomain))
                            {
                                appDomain = AppDomain.CurrentDomain.BaseDirectory;
                            }
                            string filePath = appDomain + @"\" + @"UploadImage\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text + @"\" + url;
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
                            service.SaveAnswerDtl2Streampic(base.UserInfoDto.UserID, image, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + txtShopName.Text, url.Replace(".jpg", ""), "upload", "", SubjectCode_Golbal);
                        }
                    }

                    CommonHandler.ShowMessage(MessageType.Information, "数据上传完成");
                }
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }
        void DeleteFTPFile(string fileName, string uploadUrl, string UserName, string Password)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;


            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest uploadRequest = (FtpWebRequest)(WebRequest.Create(uploadUrl));
                uploadRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                if (UserName.Length > 0)
                {
                    NetworkCredential nc = new NetworkCredential(UserName, Password);
                    uploadRequest.Credentials = nc;
                }
                WebResponse response = uploadRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
                string line = reader.ReadLine();


                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                string[] listDetail = result.ToString().Split('\n');
                bool containFolder = false;
                foreach (string detail in listDetail)
                {
                    if (detail.Contains(fileName))
                    {
                        containFolder = true;
                        break;
                    }
                }
                if (containFolder)
                {
                    // if (WebRequest.e)
                    uploadRequest = (FtpWebRequest)(WebRequest.Create(uploadUrl + fileName));
                    uploadRequest.Method = WebRequestMethods.Ftp.DeleteFile;//設定Method上傳檔案
                    uploadRequest.Proxy = null;
                    if (UserName.Length > 0)
                    {
                        NetworkCredential nc = new NetworkCredential(UserName, Password);
                        uploadRequest.Credentials = nc;
                    }
                    uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                }

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
        void UploadData(string projectCode, string shopCode)
        {
            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            string fName = projectCode + shopCode + ".xml";
            DataSet ds = new LocalService().AnswerOut(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string result = ds.Tables[0].Rows[0]["XMLDATA"].ToString();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                doc.Save(fName);
                XmlDocument doc1 = new XmlDocument();
                string path = AppDomain.CurrentDomain.BaseDirectory + fName;
                doc1.Load(path);
                string s = doc.OuterXml;
                service.AnswerIn(s, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
                //CommonHandler.ShowMessage(MessageType.Information, "导出完成,");
            }
            //}
            //service.UploadData(projectCode, shopCode);
        }
        void Makefolder(string folderName, string url, string UserName, string Password)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;


            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest uploadRequest = (FtpWebRequest)(WebRequest.Create(url));
                uploadRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                if (UserName.Length > 0)
                {
                    NetworkCredential nc = new NetworkCredential(UserName, Password);
                    uploadRequest.Credentials = nc;
                }
                WebResponse response = uploadRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
                string line = reader.ReadLine();


                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                string[] listDetail = result.ToString().Split('\n');
                bool containFolder = false;
                foreach (string detail in listDetail)
                {
                    if (detail.Contains(folderName))
                    {
                        containFolder = true;
                        break;
                    }
                }
                if (!containFolder)
                {
                    // if (WebRequest.e)
                    uploadRequest = (FtpWebRequest)(WebRequest.Create(url + folderName));
                    uploadRequest.Method = WebRequestMethods.Ftp.MakeDirectory;//設定Method上傳檔案
                    uploadRequest.Proxy = null;
                    if (UserName.Length > 0)
                    {
                        NetworkCredential nc = new NetworkCredential(UserName, Password);
                        uploadRequest.Credentials = nc;
                    }
                    uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                }

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

        private void btnStandViewPic_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string picList = "";
            string[] list = null;
            DataSet ds2 = service.GetPicListByInstandard(ProjectCode_Golbal, ShopCode_Golbal, SubjectCode_Golbal, Convert.ToInt32(grvInspectionStandard.GetRowCellValue(grvInspectionStandard.FocusedRowHandle, gcSeqNo).ToString()));

            if (ds2.Tables[0].Rows.Count > 0)
            {
                picList = Convert.ToString(ds2.Tables[0].Rows[0]["PicNameList"]);
            }
            list = picList.Split(';');
            AllPictureShow2 show = new AllPictureShow2("", list, ProjectCode_Golbal + txtShopName.Text, SubjectCode_Golbal, "", "");
            show.Show();
        }

    }
}
