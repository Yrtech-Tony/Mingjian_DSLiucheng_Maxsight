using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using System.IO;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using XHX.DTO;

namespace XHX.View
{
    public partial class DataTrans : BaseForm
    {
        LocalService localservice = new LocalService();
        localhost.Service service = new XHX.localhost.Service();
        public DataTrans()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProjects);
           
            
            //if(DateTime.Now<)
        }

        private void btnShop_Out_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UserInfoDto.RoleType == "C") return;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "xml|*.xml";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FilterIndex = 2;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = saveFileDialog.FileName;
                    DataSet ds = service.ShopAndSubjectOut(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string result = ds.Tables[0].Rows[0]["XMLDATA"].ToString();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        doc.Save(fName);
                        CommonHandler.ShowMessage(MessageType.Information, "导出完成,");
                    }
                }

            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UserInfoDto.RoleType == "C") return;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "xml|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(openFileDialog.FileName);
                    string s = doc.OuterXml;
                    //string sql = string.Format("up_XHX_DataTransfer_ShopAndSubject_IN '{0}'", s);
                    //DataSet ds = CommonHandler.query(sql);
                    service.ShopAndSubjectIn(s);
                    CommonHandler.ShowMessage(MessageType.Information, "导入完成,");
                }
            }
            catch (SqlException ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请先导入和回答问题有关的其他文件");
            }
            catch (Exception exe)
            {
                CommonHandler.ShowMessage(exe);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UserInfoDto.RoleType == "C") return;
                if (string.IsNullOrEmpty(btnShopCode.Text))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                    return;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "xml|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(openFileDialog.FileName);
                    string s = doc.OuterXml;
                    service.AnswerIn(s, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
                    CommonHandler.ShowMessage(MessageType.Information, "导入完成,");
                }
            }
            catch (SqlException ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请先导入和回答问题有关的其他文件");
            }
            catch (Exception exe)
            {
                CommonHandler.ShowMessage(exe);
            }

        }

        private void btnAnswer_Out_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UserInfoDto.RoleType == "C") return;
                if (string.IsNullOrEmpty(btnShopCode.Text))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "xml|*.xml";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FilterIndex = 2;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = saveFileDialog.FileName;
                    DataSet ds = service.AnswerOut(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string result = ds.Tables[0].Rows[0]["XMLDATA"].ToString();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        doc.Save(fName);
                        CommonHandler.ShowMessage(MessageType.Information, "导出完成,");
                    }
                }

            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UserInfoDto.RoleType == "C") return;
                if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要清空吗？") == DialogResult.Yes)
                {
                    service.DeleteData(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());

                    CommonHandler.ShowMessage(MessageType.Information, "删除完毕,");
                }
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }

        private void btnShopCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (base.UserInfoDto.RoleType == "C") return;
            Shop_Popup pop = new Shop_Popup("", "", false);
            pop.ShowDialog();
            ShopDto dto = pop.Shopdto;
            if (dto != null)
            {
                btnShopCode.Text = dto.ShopCode;
                txtShopName.Text = dto.ShopName;
            }
        }

        private void btnClearbyShop_Click(object sender, EventArgs e)
        {
            if (base.UserInfoDto.RoleType == "C") return;
            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            string sql = string.Format("Exec DeleteDataByShopCode '{0}'，‘{1}’ ",
                CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
            DataSet ds = CommonHandler.query(sql);

            CommonHandler.ShowMessage(MessageType.Information, "删除完毕,");
        }
        public override void InitButtonClick()
        {
            BindComBox.BindProject(cboProjects);
            btnShopCode.Text = "";
            txtShopName.Text = "";
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            return list;
        }

        private void btnMasterDataDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                localservice.MasterDataDownLoad(this.UserInfoDto.UserID);
                CommonHandler.ShowMessage(MessageType.Information, "基础数据下载完毕");
            }
            catch (Exception ex)
            {

                CommonHandler.ShowMessage(ex);
            }
        }

        private void btnDownLoadScoreData_Click(object sender, EventArgs e)
        {
            if (btnShopCode.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择经销商");
                return;
            }
            try
            {
                localservice.ScoreDataDownLoad(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text);
                CommonHandler.ShowMessage(MessageType.Information, "得分数据下载完毕");
            }
            catch (Exception ex)
            {

                CommonHandler.ShowMessage(ex);
            }
        }

        private void DataTrans_Load(object sender, EventArgs e)
        {
            GetUserImageFilePath(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), this.UserInfoDto.UserID);
            if (this.UserInfoDto.RoleType != "S")
            {
                btnAnswer.Enabled = false;
                btnShop.Enabled = false;
            }
            else
            {
                btnAnswer.Enabled = true;
                btnShop.Enabled = true;
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = fbd.SelectedPath;
                SaveUserImageFilePath();

            }

        }
        private void SaveUserImageFilePath()
        {
            if (string.IsNullOrEmpty(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString()))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择项目名。");
                return;
            }
            if (string.IsNullOrEmpty(buttonEdit1.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择图片临时存储目录。");
                return;
            }

            if (CommonHandler.ShowMessage(MessageType.Confirm, "确认保存以下路径为图片临时存储目录？\r\n" + buttonEdit1.Text) == DialogResult.Yes)
            {
                service.SaveUserImageFilePath(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), this.UserInfoDto.UserID, buttonEdit1.Text);
                localservice.SaveUserImageFilePath(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), this.UserInfoDto.UserID, buttonEdit1.Text);
            }

        }
        private void GetUserImageFilePath(string projectCode, string userID)
        {
            string path = service.getImagePath(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), this.UserInfoDto.UserID);
            buttonEdit1.Text = path;
        }
    }
}
