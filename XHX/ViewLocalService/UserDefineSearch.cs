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
            //��ѯ����
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

            //Ҫ��ʾ������


        }
        private void BindColumns()
        {
            List<SearchColumnDto> list = new List<SearchColumnDto>();
            SearchColumnDto column1 = new SearchColumnDto();
            column1.ColumnCode = "ProjectCode";
            column1.ColumnName = "��Ŀ";
            list.Add(column1);
            SearchColumnDto column2 = new SearchColumnDto();
            column2.ColumnCode = "SubjectCode";
            column2.ColumnName = "��ϵ�ļ���";
            list.Add(column2);
            SearchColumnDto column3 = new SearchColumnDto();
            column3.ColumnCode = "ShopCode";
            column3.ColumnName = "�����̴���";
            list.Add(column3);
            SearchColumnDto column4 = new SearchColumnDto();
            column4.ColumnCode = "ShopName";
            column4.ColumnName = "��������";
            list.Add(column4);
            SearchColumnDto column5 = new SearchColumnDto();
            column5.ColumnCode = "Score";
            column5.ColumnName = "���շ���";
            list.Add(column5);
            SearchColumnDto column6 = new SearchColumnDto();
            column6.ColumnCode = "InUserID";
            column6.ColumnName = "ִ����";
            list.Add(column6);
            SearchColumnDto column7 = new SearchColumnDto();
            column7.ColumnCode = "InDateTime";
            column7.ColumnName = "ִ��ʱ��";
            list.Add(column7);
            SearchColumnDto column8 = new SearchColumnDto();
            column8.ColumnCode = "CheckOptionCode";
            column8.ColumnName = "����׼���";
            list.Add(column8);
            SearchColumnDto column9 = new SearchColumnDto();
            column9.ColumnCode = "CheckOptionCode";
            column9.ColumnName = "��׼ͼƬ���";
            list.Add(column9);
            SearchColumnDto column10 = new SearchColumnDto();
            column10.ColumnCode = "LossDesc";
            column10.ColumnName = "ʧ��˵��";
            list.Add(column10);
            SearchColumnDto column11 = new SearchColumnDto();
            column11.ColumnCode = "PicName";
            column11.ColumnName = "ʧ��ͼƬ";
            list.Add(column11);
            SearchColumnDto column12 = new SearchColumnDto();
            column12.ColumnCode = "StatusCode";
            column12.ColumnName = "���̴���";
            list.Add(column12);
            SearchColumnDto column13 = new SearchColumnDto();
            column13.ColumnCode = "Score";
            column13.ColumnName = "�׶ε÷�";
            list.Add(column13);
            SearchColumnDto column14 = new SearchColumnDto();
            column14.ColumnCode = "ModiUserID";
            column14.ColumnName = "�����";
            list.Add(column14);
            SearchColumnDto column15 = new SearchColumnDto();
            column15.ColumnCode = "ModiDateTime";
            column15.ColumnName = "���ʱ��";
            list.Add(column15);
            //SearchColumnDto column1 = new SearchColumnDto();
            //column1.ColumnCode = "ProjectCode";
            //column1.ColumnName = "��Ŀ";
            //SearchColumnDto column1 = new SearchColumnDto();
            //column1.ColumnCode = "ProjectCode";
            //column1.ColumnName = "��Ŀ";
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
            #region ����XML
            
            //��ò�ѯ���������SubjectCode
            for (int i = 0; i < grvSubject.RowCount; i++)
            {
                if (grvSubject.GetRowCellValue(i, "CheckMarkSelection") != null && grvSubject.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_subject += @"<Subject SubjectCode=""" + (grvSubject.GetRow(i) as SubjectDto).SubjectCode;
                    xml_subject += @""" />";
                }
            }
            xml_subject += "</Subjects>";

            //��ò�ѯ���������ShopCode
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_shop += @"<Shop ShopCode=""" + (gridView1.GetRow(i) as ShopDto).ShopCode;
                    xml_shop += @"""/>";
                }
            }
            xml_shop += "</Shops>";

            //��ò�ѯ���������UserId
            for (int i = 0; i < grvUserInfo.RowCount; i++)
            {
                if (grvUserInfo.GetRowCellValue(i, "CheckMarkSelection") != null && grvUserInfo.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    xml_user += @"<User UserID=""" + (grvUserInfo.GetRow(i) as UserInfoDto).UserID;
                    xml_user += @"""/>";
                }
            }
            xml_user += "</Users>";

            // ���Ҫ��ʾ����
            List<SearchColumnDto> list = new List<SearchColumnDto>();
            for (int i = 0; i < grvColumns.RowCount; i++)
            {
                if (grvColumns.GetRowCellValue(i, "CheckMarkSelection") != null && grvColumns.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "��������")
                    {
                        xml_column += @"<Column Name=""H." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "����׼���")
                    {
                        xml_column += @"<Column Name=""B." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "��׼ͼƬ���")
                    {
                        xml_column += @"<Column Name=""C." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "ʧ��˵��"
                            ||(grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "ʧ��ͼƬ")
                    {
                        xml_column += @"<Column Name=""D." + (grvColumns.GetRow(i) as SearchColumnDto).ColumnCode;
                    }
                    else if ((grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "���̴���"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "�׶ε÷�"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "�����"
                            || (grvColumns.GetRow(i) as SearchColumnDto).ColumnName == "���ʱ��")
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
                CommonHandler.ShowMessage(MessageType.Information, "û��ѡ��Ҫ��ʾ������");
                return;
            }
            UserDefinePopup pop = new UserDefinePopup(xml_subject, xml_shop, xml_user, xml_column, projectCode, list);
            pop.ShowDialog();
           
        }
        #endregion
    }
}