using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;

namespace XHX.View
{
    public partial class SalesContantPop : Form
    {
        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<SalesConsultantDto> dataHandler = null;
        XtraGridDataHandler<LossDescDto> dataHandler1 = null;

        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        GridCheckMarksSelection selection1;
        internal GridCheckMarksSelection Selection1
        {
            get
            {
                return selection1;
            }
        }

        private string _shopCode = "";
        private string _userId = "";
        private int _fatherSeqNO = 0;
        private bool _scoreCheck = true;
        private string _memberType = "";
        // private decimal _avgScore = 0;
        public SalesContantPop(string projectCode, string shopCode, string shopName, string subjectCode, UserInfoDto user, string pageName, bool scoreChk, string memberType, string fullScore, string lowestScore)
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            CommonHandler.SetComboBoxSelectedValue(cboProject, projectCode.Trim());
            txtShopName.Text = "(" + shopCode.Trim() + ")" + shopName.Trim();
            txtSubjectCode.Text = subjectCode.Trim();
            txtFullScore.Text = fullScore;
            _shopCode = shopCode;
            _userId = user.UserID;
            _scoreCheck = scoreChk;
            _memberType = memberType;
            OnLoadView();
            RecheckStatus(projectCode, shopCode, user, pageName);
            //RoleStatus(user, pageName);
        }
        public void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<SalesConsultantDto>(grvSaleContant);
            CommonHandler.SetRowNumberIndicator(grvSaleContant);
            grcSaleContant.DataSource = new List<SalesConsultantDto>();
            selection = new GridCheckMarksSelection(grvSaleContant);
            selection.CheckMarkColumn.VisibleIndex = 0;

            dataHandler1 = new XtraGridDataHandler<LossDescDto>(grvLossDesc);
            CommonHandler.SetRowNumberIndicator(grvLossDesc);
            grcLossDesc.DataSource = new List<LossDescDto>();
            selection1 = new GridCheckMarksSelection(grvLossDesc);
            selection1.CheckMarkColumn.VisibleIndex = 0;

            SearchSaleContant();
            BindComBox.BindLoss(cboLoss, cboLoss2, cboLoss3, CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), txtSubjectCode.Text);


        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSaleContant();
        }
        public void RecheckStatus(string projectCode, string shopCode, UserInfoDto userDto, string pageName)
        {
            if (userDto.RoleType == "S")
            {
                btnSave.Enabled = true;
                btnSaveLossDesc.Enabled = true;
            }
            else
            {
                if (userDto.RoleType == "I")
                {
                    DataSet ds1 = service.SearchRecheckStatus(projectCode, shopCode);
                    string statusCode = "";
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        statusCode = ds1.Tables[0].Rows[0]["StatusCode"].ToString();
                    }
                    if (string.IsNullOrEmpty(statusCode))
                    {
                        btnSave.Enabled = true;
                        btnSaveLossDesc.Enabled = true;
                    }
                    else if (statusCode == "S2" && pageName == "ExecuteTeamAlter")
                    {
                        btnSave.Enabled = true;
                        btnSaveLossDesc.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        btnSaveLossDesc.Enabled = false;
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSaveLossDesc.Enabled = false;

                }
            }

            //if (pageName == "AnswerSubject")
            //{
            //    DataSet ds = service.SearchRecheckStatus(projectCode, shopCode);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        btnSave.Enabled = false;
            //        btnSaveLossDesc.Enabled = false;
            //    }
            //}
            //else
            //{
            //    RoleStatus(userDto, pageName);
            //}
        }
        public void RoleStatus(UserInfoDto userDto, string pageName)
        {
            if (userDto.RoleType == "S")
            {
                btnSaveLossDesc.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                if (userDto.RoleType == "I" && pageName == "ExecuteTeamAlter")
                {
                    btnSaveLossDesc.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSaveLossDesc.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }
        private void SearchSaleContant()
        {
            List<SalesConsultantDto> sourcechapterList = new List<SalesConsultantDto>();
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            DataSet ds = service.SearchSalesConsultant(projectCode, _shopCode, txtSubjectCode.Text, _memberType);
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SalesConsultantDto chapter = new SalesConsultantDto();
                    chapter.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    chapter.SalesConsultant = Convert.ToString(ds.Tables[0].Rows[i]["SalesConsultant"]);
                    if (ds.Tables[0].Rows[i]["Score"] == DBNull.Value)
                    {
                        if (string.IsNullOrEmpty(txtFullScore.Text))
                        {
                            chapter.Score = null;
                        }
                        else
                        {
                            chapter.Score = Convert.ToDecimal(txtFullScore.Text);
                        }

                        //chapter.Notinvolved = false;
                    }
                    else
                    {
                        //if (Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]) == 9999)
                        //{
                        //    chapter.Notinvolved = true;
                        //    chapter.Score = null;
                        //}
                        //else
                        //{
                        chapter.Score = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                        chapter.Notinvolved = false;
                        //}
                    }
                    chapter.LossDesc = Convert.ToString(ds.Tables[0].Rows[i]["LossDesc"]);
                    sourcechapterList.Add(chapter);
                }
                grcSaleContant.DataSource = sourcechapterList;
                if (_memberType == "01")
                {
                    gridColumn2.Caption = "顾问名称";
                }
                else
                {
                    gridColumn2.Caption = "接待人员名称";
                }
            }
        }
        private void SearchLossDesc(string lossDesc)
        {
            grcLossDesc.DataSource = null;
            List<LossDescDto> list = new List<LossDescDto>();
            if (!string.IsNullOrEmpty(lossDesc))
            {
                string[] strList = lossDesc.Split(';');
                for (int i = 0; i < strList.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strList[i]))
                    {
                        LossDescDto loss = new LossDescDto();
                        loss.LossCode = (i + 1);
                        loss.LossName = strList[i];
                        list.Add(loss);
                    }
                }
                grcLossDesc.DataSource = list;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ChapterPop_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            SalesConsultantDto loss = new SalesConsultantDto();
            List<SalesConsultantDto> inspectionList = grcSaleContant.DataSource as List<SalesConsultantDto>;
           // DataSet ds = service.SearchSalesConsultanMaxSeqNO(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), _shopCode);
            int seqNO = 0;
            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    seqNO = Convert.ToInt32(ds.Tables[0].Rows[0]["SeqNO"]);
            //}
            if (inspectionList.Count == 0)
            {
                loss.SeqNO = 1;
            }
            else
            {

                foreach (SalesConsultantDto inp in inspectionList)
                {
                    if (Convert.ToInt32(inp.SeqNO) > seqNO)
                    {
                        seqNO = inp.SeqNO;
                    }
                }
                loss.SeqNO = seqNO + 1;
            }
            loss.Score = Convert.ToDecimal(txtFullScore.Text);
            dataHandler.AddRow(loss);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grvSaleContant.CloseEditor();
                grvSaleContant.UpdateCurrentRow();
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();

                foreach (SalesConsultantDto dto in grcSaleContant.DataSource as List<SalesConsultantDto>)
                {

                    if ((dto.Score == null) && _scoreCheck)
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "请填写分数");
                        return;
                    }
                    if (Convert.ToDecimal(dto.Score) > Convert.ToDecimal(txtFullScore.Text) && dto.Score != Convert.ToDecimal(9999))
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "分数超过最高分");
                        return;
                    }
                }

                if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
                {
                    foreach (SalesConsultantDto dto in grcSaleContant.DataSource as List<SalesConsultantDto>)
                    {
                        string score = "";

                        score = Convert.ToString(dto.Score);
                        service.SaveSalesConsultant(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), _shopCode, txtSubjectCode.Text.Trim(), Convert.ToString(dto.SeqNO),
                            dto.SalesConsultant, score, "", _userId, dto.StatusType, _memberType);
                    }
                }
                SearchSaleContant();
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }

        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除吗？") == DialogResult.Yes)
            {
                dataHandler.DelCheckedRow(grvSaleContant.Columns.ColumnByFieldName("CheckMarkSelection"));
                selection.ClearSelection();
                foreach (SalesConsultantDto dto in dataHandler.DataList as List<SalesConsultantDto>)
                {
                    if (dto.StatusType == 'D')
                        service.SaveSalesConsultant(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), _shopCode, txtSubjectCode.Text.Trim(), Convert.ToString(dto.SeqNO),
                                        dto.SalesConsultant, "", "", _userId, dto.StatusType, _memberType);
                }
            }
            SearchSaleContant();

        }
        private void btnLossDescDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            SalesConsultantDto sales = grvSaleContant.GetFocusedRow() as SalesConsultantDto;
            if (sales.StatusType == 'I' || sales.StatusType == 'U')
            {
                CommonHandler.ShowMessage(MessageType.Information, "请先保存");
                return;
            }
            panelControl2.Visible = true;
            SalesConsultantDto sale = grvSaleContant.GetRow(grvSaleContant.FocusedRowHandle) as SalesConsultantDto;
            _fatherSeqNO = sale.SeqNO;
            SearchLossDesc(sale.LossDesc);
        }
        private void btnAddLossDesc_Click(object sender, EventArgs e)
        {
            DataSet ds = service.SearchSalesConsultanExistsChk(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), _shopCode, txtSubjectCode.Text,
                Convert.ToString(_fatherSeqNO));
            if (ds.Tables[0].Rows.Count == 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请先保存销售信息");
                return;
            }
            if (string.IsNullOrEmpty(txtLossDesc.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择失分说明");
                return;
            }
            LossDescDto loss = new LossDescDto();
            List<LossDescDto> inspectionList = grcLossDesc.DataSource as List<LossDescDto>;
            int lossCode = 0;
            if (inspectionList == null || inspectionList.Count == 0)
            {
                loss.LossCode = 1;
            }
            else
            {

                foreach (LossDescDto inp in inspectionList)
                {
                    if (Convert.ToInt32(inp.LossCode) > lossCode)
                    {
                        lossCode = inp.LossCode;
                    }
                }
                loss.LossCode = lossCode + 1;
            }
            loss.LossName = txtLossDesc.Text.Trim();
            dataHandler1.AddRow(loss);
        }
        private void btnDeleteLossRow_Click(object sender, EventArgs e)
        {
            dataHandler1.DelCheckedRow(grvLossDesc.Columns.ColumnByFieldName("CheckMarkSelection"));
            selection.ClearSelection();
        }
        private void btnSaveLossDesc_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
                {
                    if (grcLossDesc.DataSource == null)
                        return;
                    string lossDesc = "";
                    foreach (LossDescDto loss in grcLossDesc.DataSource as List<LossDescDto>)
                    {
                        lossDesc += loss.LossName + ";";
                    }
                    if (!string.IsNullOrEmpty(lossDesc) && lossDesc.Substring(lossDesc.Length - 1, 1) == ";")
                    {
                        lossDesc = lossDesc.Substring(0, lossDesc.Length - 1);
                    }
                    //if (!string.IsNullOrEmpty(lossDesc))
                    service.UpdateSalesConsultant(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), _shopCode, txtSubjectCode.Text, _fatherSeqNO.ToString(), lossDesc);
                }
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
                SearchSaleContant();
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
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

    }

}
