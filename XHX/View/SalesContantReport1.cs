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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace XHX.View
{
    public partial class SalesContantReport1 : BaseForm
    {
        ToolTip toolTip = null;
        localhost.Service webService = new localhost.Service();
        public SalesContantReport1()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            toolTip = new ToolTip();

        }
        public void Search()
        {
            grcShopScore.DataSource = null;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string shopCode = btnShopCode.Text;
            bool scoreChk = chkScore.Checked;
            bool photoScoreChk = chkPhotoScore.Checked;
            bool mScoreChk = chkMScore.Checked;
            bool lossCheck = chkLoss.Checked;
            string province = txtProvince.Text.Trim();
            string city = txtCity.Text.Trim();
            string group = txtGroup.Text.Trim();
            string salesOrAfterSales = txtSalesOrAftersales.Text.Trim();
            string carType = txtCarType.Text.Trim();
            
            List<TwoLevelColumnInfo> columnInfoList = SearchHead(projectCode,scoreChk,lossCheck);
            List<SalesConsultantReportBodyDto> dataList = SearchBodyData(projectCode,province,city,group,salesOrAfterSales,carType,shopCode,scoreChk,lossCheck);
            List<SalesConsultantReportDto> leftList = SearchLeft(projectCode, province, city, group, salesOrAfterSales, carType, shopCode);

            DynamicColumnDataSet<TwoLevelColumnInfo, SalesConsultantReportBodyDto, SalesConsultantReportDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, SalesConsultantReportBodyDto, SalesConsultantReportDto>(columnInfoList, dataList, leftList);
            if (list != null && list.ColumnInfoList != null)
            {
                list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, SalesConsultantReportBodyDto, SalesConsultantReportDto>(list.ColumnInfoList, list.DataList, list.DtoList);
            }
            CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, SalesConsultantReportDto>(grvShopScore, list.ColumnInfoList, list.DtoList);
            
            grvShopScore.LeftCoord = 0;

        }
        public List<TwoLevelColumnInfo> SearchHead(string projectCode, bool scoreChk, bool lossChk)
        {
            DataSet ds = webService.SearchSalesConsultantHead(projectCode, scoreChk, lossChk);
            List<TwoLevelColumnInfo> columnInfoList = new List<TwoLevelColumnInfo>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TwoLevelColumnInfo info = new TwoLevelColumnInfo();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);
                    info.Caption1 = Convert.ToString(ds.Tables[0].Rows[i]["Caption1"]);
                    info.Caption2 = Convert.ToString(ds.Tables[0].Rows[i]["Caption2"]);
                    info.Order = Convert.ToInt32(ds.Tables[0].Rows[i]["Order"]);
                    columnInfoList.Add(info);
                }
            }
            return columnInfoList;
        }
        public List<SalesConsultantReportBodyDto> SearchBodyData(string projectCode, string province, string city, string groupName, string salesOfAfterSales, string carType, string shopCode, bool scoreChk, bool lossChk)
        {
            DataSet ds = webService.SearchSalesConsultantBodyData(projectCode, province, city, groupName, salesOfAfterSales, carType, shopCode,scoreChk,lossChk);
            List<SalesConsultantReportBodyDto> shopScoreBodyList = new List<SalesConsultantReportBodyDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SalesConsultantReportBodyDto info = new SalesConsultantReportBodyDto();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);
                    info.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    info.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    info.SeqNO = Convert.ToString(ds.Tables[0].Rows[i]["SeqNO"]);
                    info.SalesConsultant = Convert.ToString(ds.Tables[0].Rows[i]["SalesConsultant"]);
                    info.Value = Convert.ToString(ds.Tables[0].Rows[i]["Value"]);

                    shopScoreBodyList.Add(info);
                }
            }
            return shopScoreBodyList;
        }
        public List<SalesConsultantReportDto> SearchLeft(string projectCode, string province, string city, string groupName, string salesOfAfterSales, string carType, string shopCode)
        {
            DataSet ds = webService.SearchSalesConsultantLeft(projectCode, province, city, groupName, salesOfAfterSales, carType, shopCode);
            List<SalesConsultantReportDto> shopScoreLeftList = new List<SalesConsultantReportDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SalesConsultantReportDto info = new SalesConsultantReportDto();
                    info.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    info.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    info.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    info.SeqNO = Convert.ToString(ds.Tables[0].Rows[i]["SeqNO"]);
                    info.SalesConsultant = Convert.ToString(ds.Tables[0].Rows[i]["SalesConsultant"]);
                    info.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    info.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                    info.GroupName = Convert.ToString(ds.Tables[0].Rows[i]["GroupName"]);
                    shopScoreLeftList.Add(info);
                }
            }
            return shopScoreLeftList;
        }
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
        }

        private void grvShopScore_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void grvShopScore_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvShopScore.FocusedColumn.Name != "详细")
            {
                e.Cancel = true;
            }
        }


        private void grvShopScore_DoubleClick(object sender, EventArgs e)
        {
            if (grvShopScore.FocusedRowHandle < 0) return;
            if (grvShopScore.FocusedColumn == gcShopCode ||
                grvShopScore.FocusedColumn == gcCity)
            {
                if (CommonHandler.GetComboBoxSelectedValue(cboProject) == null)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择一个项目");
                    return;
                }

                if (string.IsNullOrEmpty(btnShopCode.Text))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择一个经销商");
                    return;
                }
                int order = 0;
                char checkType = '0';
                string examType = "";
                string shopCode = btnShopCode.Text;
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcCity).ToString();
                DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                    examType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);

                }
                DataSet dsCheckType = webService.SearchPassReCheckBySubjectCodeAndShopCode(projectCode, subjectCode, shopCode);
                if (dsCheckType.Tables[0].Rows.Count > 0)
                {
                    //checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
                }
                AnswerSubjectForm a = new AnswerSubjectForm(projectCode,
                    subjectCode,
                    shopCode, txtShopName.Text, order, checkType, this.UserInfoDto, examType, "ShopScoreSearch");
                a.ShowDialog();
            }
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }
        public override void InitButtonClick()
        {
            base.InitButtonClick();
        }
        public override void SearchButtonClick()
        {
            Search();
        }
        public override void ExcelDownButtonClick()
        {
            if (grcShopScore.DataSource != null)
                //CommonHandler.ExcelExport(grvShopScore);
            CommonHandler.ExcelExportByExporter(grvShopScore);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (grvShopScore.FocusedRowHandle < 0) return;

            if (CommonHandler.GetComboBoxSelectedValue(cboProject) == null)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择一个项目");
                return;
            }

            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择一个经销商");
                return;
            }
            int order = 0;
            char checkType = '0';
            string examType = "";
            string subjectType = "";
            string title = "";
            string shopCode = btnShopCode.Text;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcCity).ToString();
            DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
            DataSet ds1 = webService.SearchShopExamTypeByProjectCodeAndShopCode(projectCode, shopCode);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                examType = Convert.ToString(ds1.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);

                subjectType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCode"]);
            }
            if (subjectType == "SA")
            {
                title = "照片类";
            }
            else if (subjectType == "SB")
            {
                title = "资料类";
            }
            else if (subjectType == "SC")
            {
                title = "交叉类";
            }
            DataSet dsCheckType = webService.SearchPassReCheckBySubjectCodeAndShopCode(projectCode, subjectCode, shopCode);
            if (dsCheckType.Tables[0].Rows.Count > 0)
            {
                checkType = Convert.ToChar("A");
            }
            CommonHandler.LoadView(this, "AnswerRecheck", title, projectCode, subjectCode, shopCode, order, checkType, examType, txtShopName.Text);
        }
    }
}
