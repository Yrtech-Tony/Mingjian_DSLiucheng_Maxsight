using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.DTO;
using System.Collections;

namespace XHX.ViewLocalService
{
    public partial class UserDefinePopup : Form
    {
        localhost.Service service = new localhost.Service();
        public UserDefinePopup()
        {
        }
        public UserDefinePopup(string xml_subjects, string xml_shops, string xml_users,
            string xml_columns, string projectCode, List<SearchColumnDto> columnList)
            : this()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            DataSet ds = service.UserDinfineSearch(xml_subjects, xml_shops, xml_users, projectCode, xml_columns);
            grcShop.DataSource = ds.Tables[0];
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = columnList[i].ColumnName;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonHandler.ExcelExport(gridView1);
        }
    }
}