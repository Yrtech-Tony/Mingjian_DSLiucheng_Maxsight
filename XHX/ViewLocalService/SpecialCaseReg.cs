using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using XHX.DTO;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class SpecialCaseReg : BaseForm
    {
        string SpecialCaseCode = "";
        string FinalStatus;
        localhost.Service webService = new localhost.Service();
        public SpecialCaseReg()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            this.OnLoadView();
        }
        public void OnLoadView()
        {
            XHX.Common.BindComBox.BindProject(cboProjects);
            txtSubjectCode.Leave += new EventHandler(txtSubjectCode_Leave);
        }

        void txtSubjectCode_Leave(object sender, EventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            string subjectCode = txtSubjectCode.Text;
            if (string.IsNullOrEmpty(subjectCode))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请输入体系定位号!");
                return;
            }
            DataSet ds = webService.GetSpecialCaseSubject(projectCode, subjectCode);
            SubjectDto dto = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dto = new SubjectDto();
                dto.SubjectCode = ds.Tables[0].Rows[0]["SubjectCode"].ToString();
                dto.CheckPoint = ds.Tables[0].Rows[0]["CheckPoint"].ToString();
            }
            if (dto == null)
            {
                CommonHandler.ShowMessage(MessageType.Information, "不存在的体系定位号!");
                txtCheckPoint.Text = "";
                txtSubjectCode.Focus();
                return;
            }
            txtCheckPoint.Text = dto.CheckPoint;
        }
        //public void SearchSpecialCase()
        //{
        //    DataSet ds = webService.GetSpecialCase(txtProjectCode.Text, txtShopCode.Text, txtSubjectCode.Text);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
        //        txtApplyDesc.Text = ds.Tables[0].Rows[0]["ApplyDesc"].ToString();
        //        txtTreatmentAdvice.Text = ds.Tables[0].Rows[0]["FinalAdvice"].ToString();
        //        FinalStatus = ds.Tables[0].Rows[0]["FinalStatus"].ToString();
        //        SpecialCaseCode = ds.Tables[0].Rows[0]["SpecialCaseCode"].ToString();
        //        txtFilePath.Text = ds.Tables[0].Rows[0]["ImageName"].ToString();
        //    }
        //    if (FinalStatus == "20")
        //    {
        //        txtTitle.Properties.ReadOnly = true;
        //        txtApplyDesc.Properties.ReadOnly = true;
        //        btnSave.Enabled = false;
        //        btnBrower.Enabled = false;
        //    }
 
        //}
        //点击保存时的操作，保存申请信息
        private void Save()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "标题不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtApplyDesc.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "说明不能为空!");
                return;
            }
            //if (string.IsNullOrEmpty(btnShopCode.Text))
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "经销商不能为空!");
            //    return;
            //}
            if (string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "执行文件不能为空!");
                return;
            }
            string RegType = "10";
            //保存特殊案例信息
            //DataSet ds = webService.InsertSpecialCase(SpecialCaseCode, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text, txtSubjectCode.Text, txtTitle.Text, txtApplyDesc.Text, txtTreatmentAdvice.Text, RegType, this.UserInfoDto.UserID, txtFilePath.Text,false,"");


            // if (ds.Tables[0].Rows.Count > 0)
            // {
            //     this.SpecialCaseCode = ds.Tables[0].Rows[0]["SpecialCaseCode"].ToString();
            // }
            //保存图片
             if (!string.IsNullOrEmpty(txtFilePath.Text))
             {
                 if (txtFilePath.Text.Contains("\\") && txtFilePath.Text.Contains(":"))
                 {
                     string[] filelist = txtFilePath.Text.Split(';');
                     foreach (string item in filelist)
                     {
                         FileInfo filetemp = new FileInfo(item);
                         byte[] file = null;
                         if (File.Exists(item))
                         {
                             FileStream fs = new FileStream(item, FileMode.Open);
                             int streamLength = (int)fs.Length;
                             file = new byte[streamLength];
                             fs.Read(file, 0, streamLength);
                             fs.Close();
                         }
                         else
                         {
                             file = new byte[0];
                         }
                         webService.InsertSpecialCasePic(SpecialCaseCode, filetemp.Name, file);
                     }
                 }
             }
             CommonHandler.ShowMessage(MessageType.Information, "保存成功!");
             btnShopCode.Text = "";
             txtShopName.Text = "";
             txtSubjectCode.Text = "";
             txtTitle.Text = "";
             txtFilePath.Text = "";
             txtApplyDesc.Text = "";
             txtTreatmentAdvice.Text = "";
             SpecialCaseCode = "";
             txtCheckPoint.Text = "";



        }
        //点击浏览图片的时候的操作，可以选择多张图片
        private void btnBrower_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.JPG;*.GIF;*.BMP;*.PNG;*.JPEG";
            string[] fileNames = null;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
                if (fileNames.Length > 0)
                {
                    string filename_temp = "";
                    foreach (string fileName in fileNames)
                    {
                        filename_temp += fileName + ";";
                    }

                    if (filename_temp.EndsWith(";"))
                    {
                        //txtFile.Text = txtFile.Text.Remove(txtFile.Text.LastIndexOf("; "));
                        filename_temp = filename_temp.Remove(filename_temp.LastIndexOf(";"));
                        txtFilePath.Text = filename_temp;
                    }
                }

            }
        }
        //点击查看图片时的操作
        private void btnViewPic_Click(object sender, EventArgs e)
        {

        }
        public override void SaveButtonClick()
        {
            this.Save();
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.SaveButton);
            return list;
        }
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

        private void txtSubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
                string subjectCode = txtSubjectCode.Text;
                if (string.IsNullOrEmpty(subjectCode))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请输入体系定位号!");
                    return;
                }
                DataSet ds = webService.GetSpecialCaseSubject(projectCode, subjectCode);
                SubjectDto dto = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dto = new SubjectDto();
                    dto.SubjectCode = ds.Tables[0].Rows[0]["SubjectCode"].ToString();
                    dto.CheckPoint = ds.Tables[0].Rows[0]["CheckPoint"].ToString();
                }
                if (dto == null)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "不存在的体系定位号!");
                    txtCheckPoint.Text = "";
                    return;
                }
                txtCheckPoint.Text = dto.CheckPoint;
            }
        }
    }
}
