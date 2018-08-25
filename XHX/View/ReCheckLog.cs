using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;

namespace XHX.View
{
    public partial class ReCheckLog : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service service = new localhost.Service();
        public ReCheckLog()
        {
            //InitializeComponent();
        }
         public ReCheckLog(string projectCode,string shopCode,string subjectCode)
        {
            InitializeComponent();
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            Search( projectCode, shopCode, subjectCode);
           
        }

         private void Search(string projectCode, string shopCode, string subjectCode)
         {
             List<ReCheckLogDto> shopList = new List<ReCheckLogDto>();
             //string sql = string.Format("EXEC [XHX_ReCheckLog_R] '{0}','{1}','{2}' ", projectCode, shopCode,subjectCode);
             //DataSet ds = CommonHandler.query(sql);
             DataSet ds = service.SearchRecheckLog(projectCode, shopCode, subjectCode);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     ReCheckLogDto shop = new ReCheckLogDto();
                     shop.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                     shop.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                     shop.CheckPoint = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                     shop.ReCheckName = Convert.ToString(ds.Tables[0].Rows[i]["ReCheckName"]);
                     shop.ReCheckContent = Convert.ToString(ds.Tables[0].Rows[i]["ReCheckContent"]);
                     shopList.Add(shop);
                 }
             }
             grcShop.DataSource = shopList;
         }
    }
}
