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

namespace XHX.ViewLocalService
{
    public partial class UserDefineSearch : BaseForm
    {
        public UserDefineSearch()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            OnLoadView();
        }
        #region Field:
        localhost.Service service = new localhost.Service();
        GridCheckMarksSelection selection_subject;
        internal GridCheckMarksSelection Selection_subject
        {
            get
            {
                return selection_subject;
            }
        }
        GridCheckMarksSelection selection_shop;
        internal GridCheckMarksSelection Selection_shop
        {
            get
            {
                return selection_shop;
            }
        }
        GridCheckMarksSelection selection_user;
        internal GridCheckMarksSelection Selection_user
        {
            get
            {
                return selection_user;
            }
        }
        GridCheckMarksSelection selection_column;
        internal GridCheckMarksSelection Selection_column
        {
            get
            {
                return selection_column;
            }
        }
        #endregion
        #region private

        private void OnLoadView()
        {
            BindComBox.BindProject(cboProject);
            //查询条件
            SearchSubject();
            SearchShop();
            SearchUser();
            BindColumns();
            selection_column = new GridCheckMarksSelection(grvColumns);
            selection_subject = new GridCheckMarksSelection(grvSubject);
            selection_shop = new GridCheckMarksSelection(gridView1);
            selection_user = new GridCheckMarksSelection(grvUserInfo);
            selection_subject.CheckMarkColumn.VisibleIndex = 0;
            selection_shop.CheckMarkColumn.VisibleIndex = 0;
            selection_user.CheckMarkColumn.VisibleIndex = 0;
            selection_column.CheckMarkColumn.VisibleIndex = 0;

            //要显示的内容


        }
        private void BindColumns()
        {
            List<SearchColumnDto> list = new List<SearchColumnDto>();
            SearchColumnDto column1 = new SearchColumnDto();
            column1.ColumnCode = "ProjectCode";
            column1.ColumnName = "项目";
            list.Add(column1);
            SearchColumnDto column2 = new SearchColumnDto();
            column2.ColumnCode = "SubjectCode";
            column2.ColumnName = "体系文件号";
            list.Add(column2);
            SearchColumnDto column3 = new SearchColumnDto();
            column3.ColumnCode = "ShopCode";
            column3.ColumnName = "经销商代码";
            list.Add(column3);
            SearchColumnDto column4 = new SearchColumnDto();
            column4.ColumnCode = "ShopName";
            column4.ColumnName = "经销商名";
            list.Add(column4);
            SearchColumnDto column5 = new SearchColumnDto();
            column5.ColumnCode = "Score";
            column5.ColumnName = "最终分数";
            list.Add(column5);
            SearchColumnDto column6 = new SearchColumnDto();
            column6.ColumnCode = "InUserID";
            column6.ColumnName = "执行者";
            list.Add(column6);
            SearchColumnDto column7 = new SearchColumnDto();
            column7.ColumnCode = "InDateTime";
            column7.ColumnName = "执行时间";
            list.Add(column7);
            SearchColumnDto column8 = new SearchColumnDto();
            column8.ColumnCode = "CheckOptionCode";
            column8.ColumnName = "检查标准与否";
            list.Add(column8);
            SearchColumnDto column9 = new SearchColumnDto();
            column9.ColumnCode = "CheckOptionCode";
            column9.ColumnName = "标准图片与否";
            list.Add(column9);
            SearchColumnDto column10 = new SearchColumnDto();
            column10.ColumnCode = "LossDesc";
            column10.ColumnName = "失分说明";
            list.Add(column10);
            SearchColumnDto column11 = new SearchColumnDto();
            column11.ColumnCode = "PicName";
            column11.ColumnName = "失分图片";
            list.Add(column11);
            SearchColumnDto column12 = new SearchColumnDto();
            column12.ColumnCode = "StatusCode";
            column12.ColumnName = "流程代码";
            list.Add(column12);
            SearchColumnDto column13 = new SearchColumnDto();
            column13.ColumnCode = "Score";
            column13.ColumnName = "阶段得分";
            list.Add(column13);
            SearchColumnDto column14 = new SearchColumnDto();
            column14.ColumnCode = "ModiUserID";
            column14.ColumnName = "打分人";
            list.Add(column14);
            SearchColumnDto column15 = new SearchColumnDto();
            column15.ColumnCode = "ModiDateTime";
            column15.ColumnName = "打分时间";
            list.Add(column15);
            //SearchColumnDto column1 = new SearchColumnDto();
            //column1.ColumnCode = "ProjectCode";
            //column1.ColumnName = "项目";
            //SearchColumnDto column1 = new SearchColumnDto();
            //column1.ColumnCode = "ProjectCode";
            //column1.ColumnName = "项目";
            grcColumns.DataSource = list;

        }
        private void SearchSubject()
        {
            DataSet ds = service.SearchSubject(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), "", "", "");
            List<SubjectDto> list = new List<SubjectDto>();
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    SubjectDto subject = new SubjectDto();
                    //subject.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                    //subject.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                    subject.SubjectCode = Convert.ToString(ds.Tables[0].Rows[j]["SubjectCode"]);
                    //subject.CheckPoint = Convert.ToString(ds.Tables[0].Rows[j]["CheckPoint"]);
                    //subject.ChapterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                    list.Add(subject);
                }
            }
            grcSubject.DataSource = list;
        }
        private void SearchShop()
        {
            DataSet ds = service.SearchShop("","");
            List<ShopDto> list = new List<ShopDto>();
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ShopDto shop = new ShopDto();
                    shop.ShopCode = ds.Tables[0].Rows[j]["ShopCode"].ToString();
                    shop.ShopName = ds.Tables[0].Rows[j]["ShopName"].ToString();
                    list.Add(shop);
                }
            }
            grcShop.DataSource = list;
        }
        private void SearchUser()
        {
            DataSet ds = service.SearchUserInfo("");
            List<UserInfoDto> list = new List<UserInfoDto>();
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    UserInfoDto user = new UserInfoDto();
                    user.UserID = ds.Tables[0].Rows[j]["UserID"].ToString();
                    list.Add(user);
                }
            }
            grcUserInfo.DataSource = list;
        }
        #endregion
        #region override

        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.SearchButton);
            return list;
        }
        public override void SearchButtonClick()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();

            string xml_subject = @"<Subjects>";
            string xml_shop = @"<Shops>";
            string xml_user = @"<Users>";
            string xml_column = @"<Columns>";
            #region 生成XML
            
            //获得查询条件里面的SubjectCode
            for (int i = 0; i < grvSubject.RowCount; i++)
            {
                if (grvSubject.GetRowCellValue(i, "CheckMarkSelection") != null && grvSubject.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_subject += @"<Subject SubjectCode=""" + (grvSubject.GetRow(i) as SubjectDto).SubjectCode;
                    xml_subject += @""" />";
                }
            }
            xml_subject += "</Subjects>";

            //获得查询条件里面的ShopCode
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_shop += @"<Shop ShopCode=""" + (gridView1.GetRow(i) as ShopDto).ShopCode;
                    xml_shop += @"""/>";
                }
            }
            xml_shop += "</Shops>";

            //获得查询条件里面的UserId
            for (int i = 0; i < grvUserInfo.RowCount; i++)
            {
                if (grvUserInfo.GetRowCellValue(i, "CheckMarkSelection") != null && grvUserInfo.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_user += @"<User UserID=""" + (grvUserInfo.GetRow(i) as UserInfoDto).UserID;
                    xml_user += @"""/>";
                }
            }
            xml_user += "</Users>";

            // 获得要显示的列
            List<SearchColumnDto> list = new List<SearchColumnDto>();
            for (int i = 0; i < grvColumns.RowCount; i++)
            {
                if (grvColumns.GetRowCellValue(i, "CheckMarkSelection") != null && grvColumns.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "经销商名")
                    {
                        xml_column += @"<Column Name=""H." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "检查标准与否")
                    {
                        xml_column += @"<Column Name=""B." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "标准图片与否")
                    {
                        xml_column += @"<Column Name=""C." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "失分说明"
                            ||(grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "失分图片")
                    {
                        xml_column += @"<Column Name=""D." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "流程代码"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "阶段得分"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "打分人"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "打分时间")
                    {
                        xml_column += @"<Column Name=""E." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else
                    {
                        xml_column += @"<Column Name=""A." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    list.Add(grvColumns.GetRow(i) as SearchColumnDto);
                    xml_column += @""" />";
                }
            }
            xml_column += "</Columns>";
            #endregion

            if (list.Count == 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有选择要显示的内容");
                return;
            }
            UserDefinePopup pop = new UserDefinePopup(xml_subject, xml_shop, xml_user, xml_column, projectCode, list);
            pop.ShowDialog();
           
        }
        #endregion
    }
}