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
    public partial class ReCheckDtl : BaseForm
    {
        XtraGridDataHandler<ReCheckDtlDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();

        public ReCheckDtl()
        {
            InitializeComponent();
            CommonHandler.SetRowNumberIndicator(grvReCheckDtl);
            grcReCheckDtl.DataSource = new List<ReCheckDtlDto>();
            InitData();
        }
        private void InitData()
        {
            BindComBox.BindProject(cboProject);
            BindShop();

        }

        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);

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

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString());
        }

        private void BindShop()
        {

            List<ShopDto> shopList = new List<ShopDto>();
            DataSet ds = webService.SearchShop("", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ShopDto allShop = new ShopDto();
                allShop.ShopCode = "";
                allShop.ShopName = "全部";
                shopList.Add(allShop);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopDto shop = new ShopDto();
                    shop.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shop.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shopList.Add(shop);
                }
                CommonHandler.SetComboBoxEditItems(cboShop, shopList, "ShopName", "ShopCode");
            }
        }

        private void BindSubject(string projectCode)
        {

            List<SubjectDto> subjectList = new List<SubjectDto>();
            DataSet ds = webService.SearchSubject(projectCode, "","","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                SubjectDto allSubject = new SubjectDto();
                allSubject.SubjectCode = "";
                subjectList.Add(allSubject);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SubjectDto subject = new SubjectDto();
                    subject.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    subjectList.Add(subject);
                }
                CommonHandler.SetComboBoxEditItems(cboSubject, subjectList, "SubjectCode", "SubjectCode");
            }
        }

        private void SearchRecheckDtl()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string subjectCode = CommonHandler.GetComboBoxSelectedValue(cboSubject).ToString();
            string shopCode = CommonHandler.GetComboBoxSelectedValue(cboShop).ToString();

            List<ReCheckDtlDto> reCheckDtlList = new List<ReCheckDtlDto>();
            DataSet ds = webService.SearchReCheckDtl(projectCode, subjectCode, shopCode,"");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ReCheckDtlDto reCheckDtl = new ReCheckDtlDto();
                    reCheckDtl.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    reCheckDtl.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    reCheckDtl.CheckPoint = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                    reCheckDtl.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    reCheckDtl.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    reCheckDtl.ReCheckType = Convert.ToString(ds.Tables[0].Rows[i]["ReCheckType"]);
                    reCheckDtl.ErrorType = Convert.ToString(ds.Tables[0].Rows[i]["ErrorType"]);
                    reCheckDtl.Remark = Convert.ToString(ds.Tables[0].Rows[i]["Remark"]);
                    reCheckDtl.InUserID = Convert.ToString(ds.Tables[0].Rows[i]["InUserID"]);
                    reCheckDtl.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);

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
