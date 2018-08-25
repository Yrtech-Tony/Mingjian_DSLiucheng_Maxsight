using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class AnswerStartInfo : DevExpress.XtraEditors.XtraForm
    {
        public string ProjectCode = "";
        public string ShopCode = "";
        public string UserId = "";
        public static localhost.Service service = new localhost.Service();
        public AnswerStartInfo()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
        }
        public AnswerStartInfo(string projectCode, string shopCode, string shopName,string userID):base()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            ProjectCode = projectCode;
            ShopCode = shopCode;
            UserId = userID;
            BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, ProjectCode);
            btnShopCode.Text = ShopCode;
            txtShopName.Text = shopName;
        }
        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？保存之后将不能修改") == DialogResult.Yes)
            {
                service.AnswerStartInfoSave(ProjectCode, ShopCode, txtLeaderName.Text, UserId, dateStartDate.DateTime.ToShortDateString() + " " + dateStartTime.Value.ToString("HH:mm:dd"));
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
        }
    }
}