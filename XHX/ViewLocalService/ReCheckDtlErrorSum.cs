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

namespace XHX.ViewLocalService
{
    public partial class ReCheckDtlErrorSum : BaseForm
    {
        XtraGridDataHandler<RecheckDtlErrorSumDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();

        public ReCheckDtlErrorSum()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            CommonHandler.SetRowNumberIndicator(grvReCheckDtl);
            grcReCheckDtl.DataSource = new List<RecheckDtlErrorSumDto>();
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
        public override void ExcelDownButtonClick()
        {
            if (grcReCheckDtl.DataSource != null)
            {
                CommonHandler.ExcelExport(grvReCheckDtl);
            }
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
        private void SearchRecheckDtl()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            List<RecheckDtlErrorSumDto> reCheckDtlList = new List<RecheckDtlErrorSumDto>();
            DataSet ds = webService.SearchReCheckDtlSumError(projectCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RecheckDtlErrorSumDto reCheckDtl = new RecheckDtlErrorSumDto();
                    reCheckDtl.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    reCheckDtl.ScoreError = Convert.ToString(ds.Tables[0].Rows[i]["ScoreError"]);
                    reCheckDtl.DescError = Convert.ToString(ds.Tables[0].Rows[i]["DescError"]);
                    reCheckDtl.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    reCheckDtl.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    //reCheckDtl.PicError = Convert.ToString(ds.Tables[0].Rows[i]["PicError"]);
                    reCheckDtl.StanderdError = Convert.ToString(ds.Tables[0].Rows[i]["StanderdError"]);
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
    }
}
