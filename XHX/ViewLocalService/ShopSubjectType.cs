using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.DTO;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class ShopSubjectType: BaseForm
    {
        #region Field
        XtraGridDataHandler<ShopSubjectExamTypeDto> dataHandler = null;
        List<ShopSubjectExamTypeDto> listDto = new List<ShopSubjectExamTypeDto>();
        localhost.Service webService = new localhost.Service();
        //LocalService webService = new LocalService();
        #endregion
        public ShopSubjectType()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            OnLoadView();
        }
        #region Private Method
        /// <summary>
        /// 进入页面初始化数据
        /// </summary>
        private void OnLoadView()
        {
            grcShop.DataSource = new List<ShopSubjectExamTypeDto>();
            dataHandler = new XtraGridDataHandler<ShopSubjectExamTypeDto>(grvShop);

            //bind 项目
            XHX.Common.BindComBox.BindProject(cboProject);

            // bind A/B 卷
            List<ExamTypeDto> list = new List<ExamTypeDto>();
            ExamTypeDto examType1 = new ExamTypeDto();
            examType1.ExamTypeCode = "A";
            examType1.ExamTypeName = "A卷";
            list.Add(examType1);
            ExamTypeDto examType2 = new ExamTypeDto();
            examType2.ExamTypeCode = "B";
            examType2.ExamTypeName = "B卷";
            list.Add(examType2);
            ExamTypeDto examType3 = new ExamTypeDto();
            examType3.ExamTypeCode = "C";
            examType3.ExamTypeName = "普通";
            list.Add(examType3);

            CommonHandler.BindComboBoxItems<ExamTypeDto>(cboSubjectTypeExam, list, "ExamTypeName", "ExamTypeCode");
        }
        private void SearchResult()
        {
            string prjectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string shopCode = btnShopCode.Text;
            List<ShopSubjectExamTypeDto> list = new List<ShopSubjectExamTypeDto>();
            DataSet ds = webService.GetShopSubjectExamTypeList(prjectCode, shopCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopSubjectExamTypeDto exam = new ShopSubjectExamTypeDto();
                    exam.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    exam.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    exam.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    exam.ExamTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectTypeCodeExam"]);
                    exam.CheckUserId = Convert.ToString(ds.Tables[0].Rows[i]["CheckUserId"]);
                    if (ds.Tables[0].Rows[i]["CheckDate"] != DBNull.Value)
                    {
                        exam.CheckDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CheckDate"]);
                    }
                    else
                    {
                        exam.CheckDate = null;
                    }
                    list.Add(exam);
                }
            }
            grcShop.DataSource = list;
            listDto = list;
        }
        #endregion
        #region Event
        /// <summary>
        /// 经销商按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
        #region Override Method

        public override void SearchButtonClick()
        {
            SearchResult();
        }
        public override void SaveButtonClick()
        {
            try
            {
                grvShop.CloseEditor();
                if (dataHandler.DataList.Count > 0)
                {
                    foreach (ShopSubjectExamTypeDto shop in dataHandler.DataList)
                    {
                        webService.SaveShopExamType(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), shop.ShopCode, shop.ExamTypeCode, shop.CheckUserId,shop.CheckDate);
                    }
                }
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
            catch (Exception e)
            {
                CommonHandler.ShowMessage(e);
            }
            SearchResult();
        }
        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.SaveButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }
        public override void InitButtonClick()
        {
            OnLoadView();

        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvShop);
        }
        #endregion
    }
}