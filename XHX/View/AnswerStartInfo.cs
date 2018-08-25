using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.Common;

namespace XHX.View
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="shopCode"></param>
        /// <param name="shopName"></param>
        /// <param name="userID"></param>
        public AnswerStartInfo(string projectCode, string shopCode, string shopName,string userID):base()
        {
            InitializeComponent();
            ProjectCode = projectCode;
            ShopCode = shopCode;
            UserId = userID;
            BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, ProjectCode);
            btnShopCode.Text = ShopCode;
            txtShopName.Text = shopName;
            dateStartDate.DateTime = DateTime.Now;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeaderName.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "组长姓名不能为空");
                return;
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？保存之后将不能修改") == DialogResult.Yes)
            {
                service.AnswerStartInfoSave(ProjectCode, ShopCode, txtLeaderName.Text, UserId, dateStartDate.DateTime.ToString("yyyy-MM-dd") + " " + dateStartTime.Value.ToString("HH:mm:dd"));
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
        }
    }
}