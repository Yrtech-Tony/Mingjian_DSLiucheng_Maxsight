using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.Common;
using XHX.DTO;

namespace XHX.View
{
    public partial class DeleteAnswerScore : BaseForm
    {
        localhost.Service service = new localhost.Service();
        
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
        public DeleteAnswerScore()
        {
            InitializeComponent();
            OnLoadView();
        }
        private void SearchShop()
        {
            List<ShopDto> shopList = new List<ShopDto>();
            DataSet ds = service.SearchShop("","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopDto shop = new ShopDto();
                    shop.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shop.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shop.SaleBig = Convert.ToString(ds.Tables[0].Rows[i]["SellBigAreaCode"]);
                    shop.SaleSmall = Convert.ToString(ds.Tables[0].Rows[i]["SellSmallAreaCode"]);
                    shop.AfterBig = Convert.ToString(ds.Tables[0].Rows[i]["AfterBigAreaCode"]);
                    shop.AfterSmall = Convert.ToString(ds.Tables[0].Rows[i]["AfterSmallAreaCode"]);
                    //shop.UseChk = Convert.ToBoolean(ds.Tables[0].Rows[i]["UseChk"]);
                    shopList.Add(shop);
                }
            }

            grcShop.DataSource = shopList;
        }
        private void SearchSubject()
        {

            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject) == null ? "" : CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                List<SubjectDto> sourceSubjectList = new List<SubjectDto>();
                DataSet ds = service.SearchSubject(projectCode, "", "", "");
                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        SubjectDto subject = new SubjectDto();
                        subject.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                        subject.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                        subject.SubjectCode = Convert.ToString(ds.Tables[0].Rows[j]["SubjectCode"]);
                        subject.CheckPoint = Convert.ToString(ds.Tables[0].Rows[j]["CheckPoint"]);
                        subject.ChapterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                        sourceSubjectList.Add(subject);
                    }
                }
                grcSubject.DataSource = sourceSubjectList;
        }
        private void OnLoadView()
        {
            BindComBox.BindProject(cboProject);

            SearchSubject();
            SearchShop();
            selection = new GridCheckMarksSelection(grvSubject);
            selection.CheckMarkColumn.VisibleIndex = 0;

            selection1 = new GridCheckMarksSelection(grvShop);
            selection1.CheckMarkColumn.VisibleIndex = 0;
        }
        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSubject();
        }
        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<BaseForm.ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.DeleteButton);
            return list;
        }
        public override void DeleteButtonClick()
        {
            
                List<SubjectDto> list_subject = new List<SubjectDto>();
                List<ShopDto> list_shop = new List<ShopDto>();

                for (int i = 0; i < grvSubject.RowCount; i++)
                {
                    if (grvSubject.GetRowCellValue(i, "CheckMarkSelection") != null && grvSubject.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                    {
                        list_subject.Add(grvSubject.GetRow(i) as SubjectDto);
                    }
                }

                for (int i = 0; i < grvShop.RowCount; i++)
                {
                    if (grvShop.GetRowCellValue(i, "CheckMarkSelection") != null && grvShop.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                    {
                        list_shop.Add(grvShop.GetRow(i) as ShopDto);
                    }
                }
                if (list_subject.Count == 0)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "没有选择任何执行文件");
                    return;
                }
                if (list_shop.Count == 0)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "没有选择任何经销商");
                    return;
                }
                if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除吗？") == DialogResult.Yes)
                {
                    foreach (ShopDto shop in list_shop)
                    {
                        foreach (SubjectDto subject in list_subject)
                        {
                            service.DeleteAnserForError(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), shop.ShopCode, subject.SubjectCode, checkBox1.Checked);
                        }
                    }
                    CommonHandler.ShowMessage(MessageType.Information, "删除成功");
                }

        }
    }
}