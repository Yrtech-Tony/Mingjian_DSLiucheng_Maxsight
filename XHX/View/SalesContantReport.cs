using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;

namespace XHX.View
{
    public partial class SalesContantReport : BaseForm
    {
        XtraGridDataHandler<SalesConsultantDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();

        public SalesContantReport()
        {
            InitializeComponent();
            CommonHandler.SetRowNumberIndicator(grvReCheckDtl);
            grcReCheckDtl.DataSource = new List<SalesConsultantDto>();
            InitData();
        }
        private void InitData()
        {
            BindComBox.BindProject(cboProject);
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
            InitData();
            grcReCheckDtl.DataSource = null;
        }
        public override void SearchButtonClick()
        {
            SearchRecheckDtl();
        }
        public override void ExcelDownButtonClick()
        {
            if (grvReCheckDtl.DataSource != null)
            {
                CommonHandler.ExcelExportByExporter(grvReCheckDtl);
            }
        }
        private void SearchRecheckDtl()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string shopCode = btnShopCode.Text;

            List<SalesConsultantDto> reCheckDtlList = new List<SalesConsultantDto>();
            DataSet ds = webService.SearchSalesConsultantReport(projectCode,shopCode,"");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SalesConsultantDto reCheckDtl = new SalesConsultantDto();
                    reCheckDtl.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    reCheckDtl.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    reCheckDtl.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    reCheckDtl.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    if (ds.Tables[0].Rows[i]["Score"] == DBNull.Value)
                    {
                        reCheckDtl.Score = null;
                    }
                    else
                    {
                        reCheckDtl.Score = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    }
                    reCheckDtl.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    reCheckDtl.SalesConsultant = Convert.ToString(ds.Tables[0].Rows[i]["SalesConsultant"]);
                    reCheckDtl.LossDesc = Convert.ToString(ds.Tables[0].Rows[i]["LossDesc"]);
                    reCheckDtl.MemberType = Convert.ToString(ds.Tables[0].Rows[i]["MemberType"]);

                    reCheckDtlList.Add(reCheckDtl);
                }
                grcReCheckDtl.DataSource = reCheckDtlList;
            }
            else
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有数据");
                grcReCheckDtl.DataSource = null;
            }
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
    }
}
