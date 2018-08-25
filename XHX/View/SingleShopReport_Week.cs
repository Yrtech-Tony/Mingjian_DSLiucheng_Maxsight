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
    public partial class SingleShopReport_Week : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        MSExcelUtil msExcelUtil = new MSExcelUtil();
        List<ShopDto> shopList = new List<ShopDto>();
        List<ShopDto> shopLeft = new List<ShopDto>();
        public List<ShopDto> ShopList
        {
            get { return shopList; }
            set { shopList = value; }
        }
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public SingleShopReport_Week()
        {
            InitializeComponent();
            XHX.Common.BindComBox.BindProject(cboProjects);
            tbnFilePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //btnModule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            CommonHandler.SetRowNumberIndicator(gridView1);
            SearchAllShopByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());

            selection = new GridCheckMarksSelection(gridView1);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            return list;
        }

        private List<ShopDto> SearchAllShopByProjectCode(string projectCode)
        {
            DataSet ds = service.SearchShopByProjectCode(projectCode);
            List<ShopDto> shopDtoList = new List<ShopDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopDto shopDto = new ShopDto();
                    shopDto.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shopDto.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shopDtoList.Add(shopDto);
                }
            }
            grcShop.DataSource = shopDtoList;
            return shopDtoList;
        }

        private ShopReportDto GetShopReportDto(string projectCode, string shopCode)
        {
            ShopReportDto shopReportDto = new ShopReportDto();
            #region 迈巴赫
            if (!checkBox1.Checked)
            {
                DataSet[] dataSetList = service.GetShopReportDto_Week(projectCode, shopCode, false);

                List<ShopSubjectScoreInfoDto> shopSubjectScoreInfoDtoList = new List<ShopSubjectScoreInfoDto>();
                shopReportDto.ShopSubjectScoreInfoDtoList = shopSubjectScoreInfoDtoList;

                #region 经销商基本信息
                DataSet dsShop = dataSetList[0];
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsShop.Tables[0].Rows.Count; i++)
                    {
                        shopReportDto.ShopCode = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopCode"]);
                        shopReportDto.ShopName = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopName"]);
                        shopReportDto.AreaName = Convert.ToString(dsShop.Tables[0].Rows[i]["AreaCode"]);
                        shopReportDto.City = Convert.ToString(dsShop.Tables[0].Rows[i]["City"]);
                    }
                }
                #endregion

                #region 体系信息
                DataSet dsSubject = dataSetList[1];
                if (dsSubject.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSubject.Tables[0].Rows.Count; i++)
                    {
                        ShopSubjectScoreInfoDto shopSubjectScoreInfo = new ShopSubjectScoreInfoDto();
                        shopSubjectScoreInfo.SubjectCode = Convert.ToString(dsSubject.Tables[0].Rows[i]["SubjectCode"]);
                        shopSubjectScoreInfo.CheckPoint = Convert.ToString(dsSubject.Tables[0].Rows[i]["CheckPoint"]);
                        shopSubjectScoreInfo.Score = Convert.ToString(dsSubject.Tables[0].Rows[i]["Score"]);
                        shopSubjectScoreInfo.LossDesc = Convert.ToString(dsSubject.Tables[0].Rows[i]["LossDesc"]);
                        shopSubjectScoreInfo.Remark = Convert.ToString(dsSubject.Tables[0].Rows[i]["Remark"]);
                        shopSubjectScoreInfoDtoList.Add(shopSubjectScoreInfo);
                    }
                }
                #endregion
            }
            #endregion
            #region 奔驰
            else
            {
                DataSet[] dataSetList = service.GetShopReportDto_Week(projectCode, shopCode, true);
                List<ShopSubjectScoreInfoDto> shopSubjectScoreInfoDtoList = new List<ShopSubjectScoreInfoDto>();
                List<SaleContantScoreInfoDto> saleContantScoreInfoList = new List<SaleContantScoreInfoDto>();
                List<SaleContantSubjectScoreDto> saleContantSubjectScoreDtoList = new List<SaleContantSubjectScoreDto>();
                shopReportDto.SaleContantScoreInfoList = saleContantScoreInfoList;
                //shopReportDto.ShopSubjectScoreInfoDtoList = shopSubjectScoreInfoDtoList;
                shopReportDto.SaleContantSubjectScoreDtoList = saleContantSubjectScoreDtoList;
                shopReportDto.ShopSubjectScoreInfoDtoList = shopSubjectScoreInfoDtoList;
                #region 经销商基本信息
                DataSet dsShop = dataSetList[0];
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsShop.Tables[0].Rows.Count; i++)
                    {
                        shopReportDto.ShopCode = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopCode"]);
                        shopReportDto.ShopName = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopName"]);
                        shopReportDto.AreaName = Convert.ToString(dsShop.Tables[0].Rows[i]["AreaCode"]);
                        shopReportDto.City = Convert.ToString(dsShop.Tables[0].Rows[i]["City"]);
                    }
                }
                #endregion
                #region 体系信息
                DataSet dsSubject = dataSetList[1];
                if (dsSubject.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSubject.Tables[0].Rows.Count; i++)
                    {
                        ShopSubjectScoreInfoDto shopSubjectScoreInfo = new ShopSubjectScoreInfoDto();
                        shopSubjectScoreInfo.SubjectCode = Convert.ToString(dsSubject.Tables[0].Rows[i]["SubjectCode"]);
                        shopSubjectScoreInfo.CheckPoint = Convert.ToString(dsSubject.Tables[0].Rows[i]["CheckPoint"]);
                        shopSubjectScoreInfo.Score = Convert.ToString(dsSubject.Tables[0].Rows[i]["Score"]);
                        shopSubjectScoreInfo.LossDesc = Convert.ToString(dsSubject.Tables[0].Rows[i]["LossDesc"]);
                        shopSubjectScoreInfo.Remark = Convert.ToString(dsSubject.Tables[0].Rows[i]["Remark"]);
                        shopSubjectScoreInfoDtoList.Add(shopSubjectScoreInfo);
                    }
                }
                #endregion
                #region 销售顾问

                DataSet dsSaleContantInfo = dataSetList[2];
                if (dsSaleContantInfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleContantInfo.Tables[0].Rows.Count; i++)
                    {
                        SaleContantScoreInfoDto saleContantScoreInfo = new SaleContantScoreInfoDto();
                        saleContantScoreInfo.SaleName = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["SaleName"]);
                        //saleContantScoreInfo.Score = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["Score"]);

                        saleContantScoreInfoList.Add(saleContantScoreInfo);
                    }
                }
                DataSet dsSaleSubjectScoreInfo = dataSetList[3];
                if (dsSaleSubjectScoreInfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleSubjectScoreInfo.Tables[0].Rows.Count; i++)
                    {
                        SaleContantSubjectScoreDto saleSubjectSore = new SaleContantSubjectScoreDto();
                        saleSubjectSore.SubjectCode = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["SubjectCode"]);
                        saleSubjectSore.SaleName = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["SalesConsultant"]);
                        saleSubjectSore.Score = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["Score"]);
                        saleSubjectSore.Remark = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["Remark"]);

                        saleContantSubjectScoreDtoList.Add(saleSubjectSore);
                    }
                }
                #endregion
            }
            #endregion
            return shopReportDto;
        }

        private void WriteDataToExcel(ShopReportDto shopReportDto)
        {
            if (!checkBox1.Checked)
            {
                Workbook workbook = msExcelUtil.OpenExcelByMSExcel(tbnFilePath.Text + @"\" + "梅赛德斯-迈巴赫销售质量现场考核_单店报告.xlsx");

                #region 经销商基本信息
                {
                    Worksheet worksheet_FengMian = workbook.Worksheets["本店总分"] as Worksheet;
                    #region 经销商基本信息
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D10", shopReportDto.ShopName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D12", shopReportDto.AreaName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "J12", shopReportDto.City);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "J14", shopReportDto.SalesContant);

                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G20", shopReportDto.ShopScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "H20", shopReportDto.SmallAreaScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "I20", shopReportDto.BigAreaScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "J20", shopReportDto.AllScore);

                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G21", shopReportDto.OrderNO_All);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G22", shopReportDto.OrderNO_Area);

                    // msExcelUtil.SetCellValue(worksheet_FengMian, "G30", shopReportDto.MustLoss);
                    #endregion

                    #region 体系信息
                    for (int i = 30; i < 100; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopSubjectScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode
                                || msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == "*" + shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Score);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, GetString(shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Split(';')));
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 38)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 45);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 57)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 60);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 76)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 75);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 95)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 90);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 110)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 105);
                                //msExcelUtil.SetCellValue(worksheet_FengMian, "I", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Remark);
                            }
                        }
                    }
                    #endregion


                }
                #endregion
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
                projectCode = "20" + projectCode.Substring(3, 2) + "Q" + projectCode.Substring(6, 1);
                workbook.Close(true, Path.Combine(tbnFilePath.Text,projectCode+"梅赛德斯-迈巴赫销售质量现场考核" + "_" + shopReportDto.ShopCode + "_" + shopReportDto.ShopName + "_单店报告" + ".xlsx"), Type.Missing);
            }
            else
            {
                Workbook workbook = msExcelUtil.OpenExcelByMSExcel(tbnFilePath.Text + @"\" + "梅赛德斯-奔驰销售质量现场考核_单店报告.xlsx");
                Worksheet worksheet_FengMian = workbook.Worksheets["本店总分"] as Worksheet;
                #region 经销商基本信息
                {

                    #region 经销商基本信息
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D10", shopReportDto.ShopName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D12", shopReportDto.AreaName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "I12", shopReportDto.City);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "J14", shopReportDto.SalesContant);

                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G20", shopReportDto.ShopScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "H20", shopReportDto.SmallAreaScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "I20", shopReportDto.BigAreaScore);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "J20", shopReportDto.AllScore);

                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G21", shopReportDto.OrderNO_All);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "G22", shopReportDto.OrderNO_Area);

                    // msExcelUtil.SetCellValue(worksheet_FengMian, "G30", shopReportDto.MustLoss);
                    #endregion
                    #region 体系信息
                    for (int i = 31; i < 155; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopSubjectScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode
                                || msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == "*" + shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Score);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, GetString(shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Split(';')));
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length > 66)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 36);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 99)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 48);
                                if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 132)
                                    msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 60);
                                //msExcelUtil.SetCellValue(worksheet_FengMian, "J", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Remark);
                            }
                        }
                    }
                    #endregion


                }
                #endregion
                #region 销售顾问
                Worksheet worksheet_SaleContant = workbook.Worksheets["销售顾问得分"] as Worksheet;

                if (shopReportDto.SaleContantScoreInfoList.Count > 0)
                {
                    for (int i = 0; i < shopReportDto.SaleContantScoreInfoList.Count; i++)
                    {
                        msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 5, "销售顾问" + "\r\n" + shopReportDto.SaleContantScoreInfoList[i].SaleName);
                        //msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 6, shopReportDto.SaleContantScoreInfoList[i].Score);
                    }
                }

                for (int i = 18; i < 130; i++)
                {
                    for (int j = 0; j < shopReportDto.SaleContantSubjectScoreDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode
                            || msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == "*" + shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode)
                        {
                            msExcelUtil.SetCellValue(worksheet_SaleContant, "O", i, shopReportDto.SaleContantSubjectScoreDtoList[j].Remark);
                            for (int z = 7; z < 15; z++)
                            {
                                if (msExcelUtil.GetCellValue(worksheet_SaleContant, z, 5).ToString()
                                == "销售顾问" + "\r\n" + shopReportDto.SaleContantSubjectScoreDtoList[j].SaleName)
                                {
                                    msExcelUtil.SetCellValue(worksheet_SaleContant, z, i, shopReportDto.SaleContantSubjectScoreDtoList[j].Score);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length > 20)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 36);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 30)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 48);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 40)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 60);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 50)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 72);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 60)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 84);
                                    if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 70)
                                        msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 96);

                                }
                            }
                        }
                    }
                }
                #endregion
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
                projectCode = "20" + projectCode.Substring(2, 2) + "Q" + projectCode.Substring(5, 1);
                workbook.Close(true, Path.Combine(tbnFilePath.Text, projectCode + "梅赛德斯-奔驰销售质量现场考核" + "_" + shopReportDto.ShopCode + "_" + shopReportDto.ShopName + "_单店报告" + ".xlsx"), Type.Missing);
            }
        }
        public  string GetString(string[] values)
        {
            string result = "";
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(values[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(values[i]);

            }
            foreach (string str in list)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    result += str + ";";
                }
            }
            return result;
            //return list.ToArray();


        }

        private void GenerateReport()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            _shopDtoList = new List<ShopDto>();
            //_shopDtoList = SearchAllShopByProjectCode(projectCode);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    _shopDtoList.Add(gridView1.GetRow(i) as ShopDto);
                }
            }
            _shopDtoListCount = _shopDtoList.Count;
            this.Enabled = false;
            _bw = new BackgroundWorker();
            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            _bw.WorkerReportsProgress = true;
            _bw.RunWorkerAsync(new object[] { projectCode });
        }

        BackgroundWorker _bw;
        List<ShopDto> _shopDtoList;
        int _shopDtoListCount = 0;
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbrProgress.Value = (e.ProgressPercentage) * 100 / _shopDtoListCount;
            System.Windows.Forms.Application.DoEvents();
        }
        void WriteErrorLog(string errMessage)
        {
            string path = tbnFilePath.Text + "\\" + "Error.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, errMessage + "\r\n");
            }

        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] shopNames;
            int currentShopDtoIndex = 0;
            foreach (ShopDto shopDto in _shopDtoList)
            {
                try
                {
                    object[] arguments = e.Argument as object[];
                    ShopReportDto shopReportDto = GetShopReportDto(arguments[0] as string, shopDto.ShopCode);
                    WriteDataToExcel(shopReportDto);
                    _bw.ReportProgress(currentShopDtoIndex++);
                }
                catch (Exception ex)
                {
                    shopLeft.Add(shopDto);
                    WriteErrorLog(shopDto.ShopCode + shopDto.ShopName + ex.Message.ToString());
                    continue;
                }

            }
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Enabled = true;
            List<ShopDto> gridSource = grcShop.DataSource as List<ShopDto>;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "CheckMarkSelection", false);
                foreach (ShopDto shop in shopLeft)
                {
                    if (shop.ShopCode == gridSource[i].ShopCode)
                    {
                        gridView1.SetRowCellValue(i, "CheckMarkSelection", true);
                    }
                    //else
                    //{
                    //    gridView1.SetRowCellValue(i, "CheckMarkSelection", false);
                    //}
                }
            }
            //if (shopLeft.Count > 0)
            //{
            //    string str = string.Empty;
            //    foreach (ShopDto shop in shopLeft)
            //    {
            //        str += shop.ShopCode + ":" + shop.ShopName + ";";
            //    }
            //    CommonHandler.ShowMessage(MessageType.Information, "报告生成完毕未生成报告经销商如下:" + str);
            //}
            //else
            //{
            CommonHandler.ShowMessage(MessageType.Information, "报告生成完毕");
            //}

        }

        private void tbnFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbnFilePath.Text = fbd.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbnFilePath.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择报告生成路径");
                return;
            }
            GenerateReport();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SearchAllShopByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //ShopNotInScore shop = new ShopNotInScore(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
            //shop.ShowDialog();

        }

        private void btnModule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "Excel(*.xlsx)|";
            ofp.FilterIndex = 2;
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                //btnModule.Text = ofp.FileName;
            }
        }

        private void btnMBReport_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(tbnFilePath.Text))
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "请选择路径");
            //    return;
            //}
            //DirectoryInfo dataDir = new DirectoryInfo(tbnFilePath.Text);
            //// DirectoryInfo[] dirInfos = dataDir.GetDirectories();
            //FileInfo[] fileList = dataDir.GetFiles();
            //foreach (FileInfo file in fileList)
            //{
            //    try
            //    {
            //        aliyun.PutObject("yrtech", "BENZReport" + @"/" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + @"/" + file.Name,
            //                            file.FullName);

            //        // pbrProgressForUpload.Value += (int)((subjectDirSize / shopDirSize) * 100D);
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
            //CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }
    }
}
