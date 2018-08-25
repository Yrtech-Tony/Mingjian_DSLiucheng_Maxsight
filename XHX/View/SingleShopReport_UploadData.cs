using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO.SingleShopReport;
using XHX.DTO;
using XHX.Common;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Threading;

namespace XHX.View
{
    public partial class SingleShopReport_UploadData : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        MSExcelUtil msExcelUtil = new MSExcelUtil();
        public SingleShopReport_UploadData()
        {
            InitializeComponent();
            service.Url = "http://123.57.229.128/benzreportserver/service.asmx";
            XHX.Common.BindComBox.BindProject(cboProjects);
            btnModule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            return list;
        }

        private void btnModule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "Excel(*.xlsx)|";
            ofp.FilterIndex = 2;
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                btnModule.Text = ofp.FileName;
            }
        }

        private void btnAllCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["全国环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            string allScore = msExcelUtil.GetCellValue(worksheet_FengMian, "A", 2).ToString();
            string bdcScore = msExcelUtil.GetCellValue(worksheet_FengMian, "B", 2).ToString();
            string receptionistScore = msExcelUtil.GetCellValue(worksheet_FengMian, "C", 2).ToString();
            string saleScore = msExcelUtil.GetCellValue(worksheet_FengMian, "D", 2).ToString();
            service.UploadAllScore(projectCode, allScore,bdcScore, receptionistScore,saleScore,"", this.UserInfoDto.UserID);
            for (int i = 5; i < 20; i++)
            {
                string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, i, 1).ToString();
                if (!string.IsNullOrEmpty(charterCode))
                {
                    string CharterScore = msExcelUtil.GetCellValue(worksheet_FengMian, i, 2).ToString();
                    service.UploadAllCharterScore(projectCode, charterCode, CharterScore, "", this.UserInfoDto.UserID);
                }
            }

            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnAreaCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["区域环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 20; i++)
            {
                string areaCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(areaCode))
                {
                    string score = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    string areaTypeCode = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    string bdcScore = msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString();
                    string receptionistScore = msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString();
                    string saleScore = msExcelUtil.GetCellValue(worksheet_FengMian, "F", i).ToString(); 
                    service.UploadAreaScore(projectCode, areaCode, score,bdcScore, receptionistScore,saleScore, "", areaTypeCode, this.UserInfoDto.UserID);
                    for (int j = 7; j < 20; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(charterCode))
                        {
                            service.UploadAreaCharterScore(projectCode, areaCode, charterCode,
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), "", "", this.UserInfoDto.UserID);
                        }
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnShopCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["经销商环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 520; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    for (int j = 2; j < 15; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(charterCode))
                        {
                            service.UploadShopCharterScore(projectCode, shopCode, msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString(),
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), "", this.UserInfoDto.UserID);
                        }
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnShopSubject_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["经销商得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 3; i < 520; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    string orderNO_All = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    string orderNO_Area = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    string score = msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString();
                    string mustLoss = msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString();
                    string saleContant = msExcelUtil.GetCellValue(worksheet_FengMian, "F", i).ToString();
                    service.UploadShopScore(projectCode, shopCode, score, Convert.ToInt32(orderNO_All), 0, Convert.ToInt32(orderNO_Area), mustLoss, this.UserInfoDto.UserID, saleContant);
                    for (int j = 7; j < 120; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        string score1 = msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString();
                        string fullScore = msExcelUtil.GetCellValue(worksheet_FengMian, j, 2).ToString();
                        if (!string.IsNullOrEmpty(subjectCode))
                            service.UploadShopSubjectScore(projectCode, shopCode, subjectCode, score1, "", fullScore, this.UserInfoDto.UserID);
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnAreaSubject_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["区域体系得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 20; i++)
            {
                string areaCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(areaCode))
                {
                    string areaTypeCode = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    for (int j = 3; j < 120; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(subjectCode))
                        {
                            service.UploadAreaSubjectScore(projectCode, areaCode, subjectCode,
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), this.UserInfoDto.UserID);
                        }
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnSalesCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["销售顾问环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 1590; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    string salesName = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    string salesType = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    for (int j = 4; j < 15; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        string charterScore = msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString();
                        if (!string.IsNullOrEmpty(charterCode) && !string.IsNullOrEmpty(charterScore))
                        {
                            service.UploadSalesContantCharterScore(projectCode, shopCode, salesType, salesName, charterCode,
                                charterScore, this.UserInfoDto.UserID);
                        }
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnsaleContantSubject_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["销售顾问体系得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 3; i < 1590; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    string salesName = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    string salesType = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    int orderNO_All = msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString()==""?0:Convert.ToInt32(msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString());
                    int orderNO_SmallArea = msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString()==""?0:Convert.ToInt32(msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString());
                    string score = msExcelUtil.GetCellValue(worksheet_FengMian, "F", i).ToString();
                    service.UploadSalesContantInfo(projectCode, shopCode, salesType, salesName, score, "", orderNO_All, orderNO_SmallArea, this.UserInfoDto.UserID);
                    for (int j = 7; j < 130; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        string subjectScore = msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString();
                        if (!string.IsNullOrEmpty(subjectCode) && !string.IsNullOrEmpty(subjectScore))
                        {
                            service.UploadSalesContantSubjectScore(projectCode, shopCode, subjectCode,salesType,salesName,
                                subjectScore, this.UserInfoDto.UserID);
                        }
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnCharterSale_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["全国环节销售得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 1; i < 11; i++)
            {
                string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, i, 1).ToString();
                if (!string.IsNullOrEmpty(charterCode))
                {
                    string CharterScore = msExcelUtil.GetCellValue(worksheet_FengMian, i, 2).ToString();
                    service.UploadAllCharterSaleScore(projectCode, charterCode, CharterScore);
                }
            }

            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnAreaCharterSale_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["区域环节销售得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 15; i++)
            {
                string areaCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(areaCode))
                {
                    for (int j = 3; j < 15; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(charterCode))
                        {
                            service.UploadAreaCharterSaleScore(projectCode, areaCode, charterCode,
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString());
                        }
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                service.Url = "http://47.93.118.1/benzreportserver/service.asmx";
            }
            else
            {
                service.Url = "http://123.57.229.128/benzreportserver/service.asmx";
            }
        }
    }
}
