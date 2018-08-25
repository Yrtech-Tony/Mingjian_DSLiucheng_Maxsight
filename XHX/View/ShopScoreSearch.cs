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
    public partial class ShopScoreSearch : BaseForm
    {
        ToolTip toolTip = null;
        localhost.Service webService = new localhost.Service();
        public ShopScoreSearch()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            toolTip = new ToolTip();
            webService.Timeout = 1000000000;

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
            
            List<TwoLevelColumnInfo> columnInfoList = SearchHead(projectCode, shopCode,province,city,group,salesOrAfterSales,carType,lossCheck,scoreChk,photoScoreChk,mScoreChk);
            List<ShopScoreBodyDto> dataList = SearchBodyData(projectCode, shopCode,province,city,group,salesOrAfterSales,carType,lossCheck,scoreChk,photoScoreChk,mScoreChk);
            List<ShopScoreInfoDto> leftList = SearchLeft(projectCode);

            DynamicColumnDataSet<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto>(columnInfoList, dataList, leftList);
            if (list != null && list.ColumnInfoList != null)
            {
                list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto>(list.ColumnInfoList, list.DataList, list.DtoList);
            }
            CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, ShopScoreInfoDto>(grvShopScore, list.ColumnInfoList, list.DtoList);
            foreach (GridColumn col in grvShopScore.Columns)
            {
                for (int i = 0; i < grvShopScore.RowCount; i++)
                {
                    if (col.Caption != "失分说明")
                    {
                        if ((grvShopScore.GetRowCellValue(i, col) == null || grvShopScore.GetRowCellValue(i, col).ToString() == ""))
                        {
                            grvShopScore.SetRowCellValue(i, col, "--");
                        }
                    }
                    else
                    {
                        if (grvShopScore.GetRowCellValue(i, col) != null && grvShopScore.GetRowCellValue(i, col).ToString() == "@@")
                        {
                            grvShopScore.SetRowCellValue(i, col, "");
                        }
                    }
                }
            }
            grvShopScore.LeftCoord = 0;

        }
        public List<TwoLevelColumnInfo> SearchHead(string projectCode, string shopCode,string province,string city,string groupName,string salesOrAftersales,string carType,bool lossChk,bool score,bool photoScore,bool mscore)
        {
            DataSet ds = webService.SearchHead(projectCode, shopCode, province, city, groupName, salesOrAftersales, carType, lossChk,score,photoScore,mscore);
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
        public List<ShopScoreBodyDto> SearchBodyData(string projectCode, string shopCode, string province, string city, string groupName, string salesOrAftersales, string carType, bool lossChk, bool score, bool photoScore, bool mscore)
        {
            DataSet ds = webService.SearchBodyData(projectCode, shopCode, province, city, groupName, salesOrAftersales, carType, lossChk, score, photoScore, mscore);
            List<ShopScoreBodyDto> shopScoreBodyList = new List<ShopScoreBodyDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopScoreBodyDto info = new ShopScoreBodyDto();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);

                    info.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    if (ds.Tables[0].Rows[i]["Value"] != DBNull.Value)
                    {
                        info.Value = Convert.ToString(ds.Tables[0].Rows[i]["Value"]);
                        if (info.Value.ToString().Contains("9999.00"))
                        {
                            info.Value = info.Value.ToString().Replace("9999.00", ".");
                        }
                        if ((info.Value == null || Convert.ToString(info.Value) == ""))
                        {
                            info.Value = "@@";
                        }
                    }
                    else
                    {
                        info.Value = "@@";
                    }

                    shopScoreBodyList.Add(info);
                }
            }
            return shopScoreBodyList;
        }
        public List<ShopScoreInfoDto> SearchLeft(string projectCode)
        {
            DataSet ds = webService.SearchLeft(projectCode);
            List<ShopScoreInfoDto> shopScoreLeftList = new List<ShopScoreInfoDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopScoreInfoDto info = new ShopScoreInfoDto();
                    info.CheckPoint = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                    info.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    info.SubjectOrderNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SubjectOrderNO"]);
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
            if (grvShopScore.FocusedColumn == gcCheckPoint ||
                grvShopScore.FocusedColumn == gcSubjectCode)
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
                string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcSubjectCode).ToString();
                DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                    //examType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
                }
                DataSet ds1 = webService.SearchShopExamTypeByProjectCodeAndShopCode(projectCode, shopCode);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                    examType = Convert.ToString(ds1.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
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
            string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcSubjectCode).ToString();
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
