using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using XHX.Common;
using XHX.DTO;

namespace XHX.View
{
    public partial class SpecialCasePop : Form
    {
        string SpecialCaseCode = "";
        string FinalStatus;
        UserInfoDto _userinfo;
        localhost.Service webService = new localhost.Service();
        public SpecialCasePop()
        {
            InitializeComponent();
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
        public SpecialCasePop(string projectCode, string shopCode, string shopName, string subjectCode, string checkPoint,string flag,UserInfoDto userinfo)
            : this()
        {
            _userinfo = userinfo;
            if (flag == "Answer")
            {
                chkNeedVICoConfirmChk.Enabled = false;

                btnConfirm.Enabled = false;
            }
            else
            {
                chkNeedVICoConfirmChk.Enabled = true;

                btnConfirm.Enabled = true;
            }
            CommonHandler.SetComboBoxSelectedValue(cboProjects, projectCode);
            
            btnShopCode.Text = shopCode;
            txtShopName.Text = shopName;
            txtSubjectCode.Text = subjectCode;
            txtCheckPoint.Text = checkPoint;
            //this.SearchSpecialCase();

            
        }
        public SpecialCasePop(string specialCaseCode, UserInfoDto userinfo)
            : this()
        {
            _userinfo = userinfo;
            if (_userinfo.RoleType == "I")
            {
                chkNeedVICoConfirmChk.Enabled = false;
                btnConfirm.Enabled = false;
            }
            else
            {
                chkNeedVICoConfirmChk.Enabled = true;
                btnConfirm.Enabled = true;
            }
            SearchSpecialCase(specialCaseCode);
        }
        public void SearchSpecialCase(string specialCaseCode)
        {
            DataSet ds = webService.GetSpecialCase(specialCaseCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                txtApplyDesc.Text = ds.Tables[0].Rows[0]["ApplyDesc"].ToString();
                txtShopFeedback.Text = ds.Tables[0].Rows[0]["ShopFeedback"].ToString();
                txtExcute.Text = ds.Tables[0].Rows[0]["ExcuteInitialJudgment"].ToString();
                txtEvidence.Text = ds.Tables[0].Rows[0]["Evidence"].ToString();
                txtTreatmentAdvice.Text = ds.Tables[0].Rows[0]["FinalAdvice"].ToString();
                FinalStatus = ds.Tables[0].Rows[0]["FinalStatus"].ToString();
                SpecialCaseCode = ds.Tables[0].Rows[0]["SpecialCaseCode"].ToString();
                txtFilePath.Text = ds.Tables[0].Rows[0]["ImageName"].ToString();
                txtVICoAdvice.Text = ds.Tables[0].Rows[0]["VICoAdvice"].ToString();
                chkNeedVICoConfirmChk.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["NeedVICoConfirmChk"].ToString());
                CommonHandler.SetComboBoxSelectedValue(cboProjects, ds.Tables[0].Rows[0]["ProjectCode"].ToString());

                btnShopCode.Text = ds.Tables[0].Rows[0]["ShopCode"].ToString();
                txtShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
                txtSubjectCode.Text = ds.Tables[0].Rows[0]["SubjectCode"].ToString();
                txtCheckPoint.Text = ds.Tables[0].Rows[0]["CheckPoint"].ToString();
            }
            if (FinalStatus == "20")
            {
                txtTitle.Properties.ReadOnly = true;
                txtApplyDesc.Properties.ReadOnly = true;
                btnSave.Enabled = false;
                btnBrower.Enabled = false;
            }
 
        }
        //点击保存时的操作，保存申请信息
        private void btnSave_Click(object sender, EventArgs e)
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
            string RegType = "10";
            //保存特殊案例信息
            DataSet ds = webService.InsertSpecialCase(SpecialCaseCode, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text, txtSubjectCode.Text, txtTitle.Text, txtApplyDesc.Text, txtShopFeedback.Text, txtExcute.Text, txtEvidence.Text,txtTreatmentAdvice.Text, RegType, _userinfo.UserID, txtFilePath.Text, chkNeedVICoConfirmChk.Checked, txtVICoAdvice.Text);


             if (ds.Tables[0].Rows.Count > 0)
             {
                 this.SpecialCaseCode = ds.Tables[0].Rows[0]["SpecialCaseCode"].ToString();
             }
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
             this.SearchSpecialCase(SpecialCaseCode);


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
        //点击确定的时候，处理人的操作
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtTreatmentAdvice.Text))
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "处理意见不能为空!");
            //    return;
            //}
            string RegType = "20";
            if (chkNeedVICoConfirmChk.Checked && string.IsNullOrEmpty(txtVICoAdvice.Text))
                RegType = "30";
            //保存特殊案例信息
            DataSet ds = webService.InsertSpecialCase(SpecialCaseCode, CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text, txtSubjectCode.Text, txtTitle.Text, txtApplyDesc.Text,txtShopFeedback.Text,txtExcute.Text,txtEvidence.Text,txtTreatmentAdvice.Text, RegType, _userinfo.UserID, txtFilePath.Text, chkNeedVICoConfirmChk.Checked, txtVICoAdvice.Text);
            CommonHandler.ShowMessage(MessageType.Information, "保存成功!");
            this.SearchSpecialCase(SpecialCaseCode);
        }
        //点击查看图片时的操作
        private void btnViewPic_Click(object sender, EventArgs e)
        {
            string[] picNameList = null;
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                picNameList = txtFilePath.Text.Split(';');
            }
            if (picNameList == null)
            {
                return;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + @"UploadImage\SpecialCasePictures\" + SpecialCaseCode + @"\";
            AllPictureShow2 pic = new AllPictureShow2(path, picNameList, txtShopName.Text, txtSubjectCode.Text,"SpecialCase", SpecialCaseCode);
            pic.ShowDialog();
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
