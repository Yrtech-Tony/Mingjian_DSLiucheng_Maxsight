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
    public partial class InspectionStandardReportSearch : BaseForm
    {
        ToolTip toolTip = null;
        localhost.Service webService = new localhost.Service();
        public InspectionStandardReportSearch()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            toolTip = new ToolTip();

        }
        public void Search()
        {
            grcShopScore.DataSource = null;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string type = chkArea.Checked?"BigArea":"";
            List<TwoLevelColumnInfo> columnInfoList = SearchHead(type);
            List<InspectionStandardReportBodyDto> dataList = SearchBodyData(projectCode,type);
            List<InspectionStandardReportDto> leftList = SearchLeft(projectCode);

            DynamicColumnDataSet<TwoLevelColumnInfo, InspectionStandardReportBodyDto, InspectionStandardReportDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, InspectionStandardReportBodyDto, InspectionStandardReportDto>(columnInfoList, dataList, leftList);
            if (list != null && list.ColumnInfoList != null)
            {
                list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, InspectionStandardReportBodyDto, InspectionStandardReportDto>(list.ColumnInfoList, list.DataList, list.DtoList);
            }

            CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, InspectionStandardReportDto>(grvShopScore, list.ColumnInfoList, list.DtoList);

            grvShopScore.LeftCoord = 0;

        }
        public List<TwoLevelColumnInfo> SearchHead(string type)
        {
            DataSet ds = webService.SearchInspectionStandardReportBySmalllAreaHead(type);
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
        public List<InspectionStandardReportBodyDto> SearchBodyData(string projectCode,string type)
        {
            DataSet ds = webService.SearchInspectionStandardReportBySmallAreaBodyData(projectCode,type);
            List<InspectionStandardReportBodyDto> shopScoreBodyList = new List<InspectionStandardReportBodyDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardReportBodyDto info = new InspectionStandardReportBodyDto();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);
                    //info.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    info.Value = Convert.ToString(ds.Tables[0].Rows[i]["Value"]);
                    info.SubjectCodeSeqNO = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCodeSeqNO"]);
                    shopScoreBodyList.Add(info);
                }
            }
            return shopScoreBodyList;
        }
        public List<InspectionStandardReportDto> SearchLeft(string projectCode)
        {
            DataSet ds = webService.SearchInspectionStandardReportBySmallAreaLeft(projectCode);
            List<InspectionStandardReportDto> shopScoreLeftList = new List<InspectionStandardReportDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardReportDto info = new InspectionStandardReportDto();
                    info.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                    info.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    info.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    info.SubjectCodeSeqNO = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCodeSeqNO"]);
                    shopScoreLeftList.Add(info);
                }
            }
            return shopScoreLeftList;
        }
        private void grvShopScore_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
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
                CommonHandler.ExcelExportByExporter(grvShopScore);
        }
    }
}
