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
    public partial class SingleShopReport : BaseForm
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
        public SingleShopReport()
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
                DataSet[] dataSetList = service.GetShopReportDto(projectCode, shopCode, false);

                List<ShopCharterScoreInfoDto> shopCharterScoreInfoDtoList = new List<ShopCharterScoreInfoDto>();
                List<ShopSubjectScoreInfoDto> shopSubjectScoreInfoDtoList = new List<ShopSubjectScoreInfoDto>();
                shopReportDto.ShopCharterScoreInfoDtoList = shopCharterScoreInfoDtoList;
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
                        shopReportDto.ShopScore = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopScore"]);
                        shopReportDto.OrderNO_All = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_All"]);
                        shopReportDto.OrderNO_Area = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_SmallArea"]);
                        shopReportDto.SalesContant = Convert.ToString(dsShop.Tables[0].Rows[i]["SaleContant"]);
                        shopReportDto.SmallAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["SmallScore"]);
                        shopReportDto.BigAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["BigScore"]);
                        shopReportDto.AllScore = Convert.ToString(dsShop.Tables[0].Rows[i]["AllScore"]);
                        shopReportDto.MustLoss = Convert.ToString(dsShop.Tables[0].Rows[i]["MustLoss"]);
                    }
                }
                #endregion
                #region 章节信息
                DataSet dsCharter = dataSetList[1];
                if (dsCharter.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCharter.Tables[0].Rows.Count; i++)
                    {
                        ShopCharterScoreInfoDto shopCharterScoreInfo = new ShopCharterScoreInfoDto();
                        shopCharterScoreInfo.CharterCode = Convert.ToString(dsCharter.Tables[0].Rows[i]["CharterCode"]);
                        shopCharterScoreInfo.ShopScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["ShopCharterScore"]);
                        shopCharterScoreInfo.SmallScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["SmallCharterScore"]);
                        shopCharterScoreInfo.BigScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["BigCharterScore"]);
                        shopCharterScoreInfo.AllScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["AllCharterScore"]);
                        shopCharterScoreInfoDtoList.Add(shopCharterScoreInfo);
                    }
                }
                #endregion
                #region 体系信息
                DataSet dsSubject = dataSetList[2];
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
                DataSet[] dataSetList = service.GetShopReportDto(projectCode, shopCode, true);

                List<ShopCharterScoreInfoDto> shopCharterScoreInfoDtoList = new List<ShopCharterScoreInfoDto>();
                List<ShopSubjectScoreInfoDto> shopSubjectScoreInfoDtoList = new List<ShopSubjectScoreInfoDto>();
                List<BDCORRepScoreInfoDto> bdcOrrepScoreInfoList = new List<BDCORRepScoreInfoDto>();
                List<ShopSubjectScoreInfo_BDCOrRepDto> bdcShopSubjectScoreInfoList = new List<ShopSubjectScoreInfo_BDCOrRepDto>();

                List<SaleContantScoreInfoDto> saleContantScoreInfoList = new List<SaleContantScoreInfoDto>();
                List<SaleContantScoreInfo_AreaDto> saleContantScoreInfo_AreaList = new List<SaleContantScoreInfo_AreaDto>();
                List<SaleContantCharterScoreInfoDto> saleContantCharterScoreInfoDtoList = new List<SaleContantCharterScoreInfoDto>();
                List<SaleAreaCharterScoreDto> saleAreaCharterScoreDtoList = new List<SaleAreaCharterScoreDto>();
                List<SaleContantSubjectScoreDto> saleContantSubjectScoreDtoList = new List<SaleContantSubjectScoreDto>();

                shopReportDto.ShopCharterScoreInfoDtoList = shopCharterScoreInfoDtoList;
                shopReportDto.ShopSubjectScoreInfoDtoList = shopSubjectScoreInfoDtoList;
                shopReportDto.BDCORRepScoreInfoDtoList = bdcOrrepScoreInfoList;
                shopReportDto.BDCShopSubjectScoreInfoList = bdcShopSubjectScoreInfoList;

                shopReportDto.SaleContantScoreInfoList = saleContantScoreInfoList;
                shopReportDto.SaleContantScoreInfo_AreaList = saleContantScoreInfo_AreaList;
                shopReportDto.SaleContantCharterScoreInfoDtoList = saleContantCharterScoreInfoDtoList;
                shopReportDto.SaleAreaCharterScoreDtoList = saleAreaCharterScoreDtoList;
                shopReportDto.SaleContantSubjectScoreDtoList = saleContantSubjectScoreDtoList;

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
                        shopReportDto.ShopScore = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopScore"]);
                        shopReportDto.OrderNO_All = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_All"]);
                        shopReportDto.OrderNO_Area = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_SmallArea"]);
                        shopReportDto.SalesContant = Convert.ToString(dsShop.Tables[0].Rows[i]["SaleContant"]);
                        shopReportDto.SmallAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["SmallScore"]);
                        shopReportDto.BigAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["BigScore"]);
                        shopReportDto.AllScore = Convert.ToString(dsShop.Tables[0].Rows[i]["AllScore"]);
                        shopReportDto.MustLoss = Convert.ToString(dsShop.Tables[0].Rows[i]["MustLoss"]);
                    }
                }
                #endregion
                #region 章节信息
                DataSet dsCharter = dataSetList[1];
                if (dsCharter.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCharter.Tables[0].Rows.Count; i++)
                    {
                        ShopCharterScoreInfoDto shopCharterScoreInfo = new ShopCharterScoreInfoDto();
                        shopCharterScoreInfo.CharterCode = Convert.ToString(dsCharter.Tables[0].Rows[i]["CharterCode"]);
                        shopCharterScoreInfo.ShopScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["ShopCharterScore"]);
                        shopCharterScoreInfo.SmallScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["SmallCharterScore"]);
                        shopCharterScoreInfo.BigScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["BigCharterScore"]);
                        shopCharterScoreInfo.AllScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["AllCharterScore"]);
                        shopCharterScoreInfoDtoList.Add(shopCharterScoreInfo);
                    }
                }
                #endregion
                #region 体系信息
                DataSet dsSubject = dataSetList[2];
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

                //#region BDC
                //DataSet dsBDCScoreInfo = dataSetList[3];
                //if (dsBDCScoreInfo.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < dsBDCScoreInfo.Tables[0].Rows.Count; i++)
                //    {
                //        BDCORRepScoreInfoDto bdcScoreInfo = new BDCORRepScoreInfoDto();
                //        bdcScoreInfo.SaleName = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["SaleName"]);
                //        bdcScoreInfo.SalesType = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["SalesType"]);
                //        bdcScoreInfo.Score = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["Score"]);
                //        bdcScoreInfo.SmallAreaScore = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["SmallScore"]);
                //        bdcScoreInfo.BigAreaScore = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["BigScore"]);
                //        bdcScoreInfo.AllScore = Convert.ToString(dsBDCScoreInfo.Tables[0].Rows[i]["AllScore"]);
                //        bdcOrrepScoreInfoList.Add(bdcScoreInfo);
                //    }
                //}

                //DataSet dsBDCSubjectScoreInfo = dataSetList[4];
                //if (dsBDCSubjectScoreInfo.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < dsBDCSubjectScoreInfo.Tables[0].Rows.Count; i++)
                //    {
                //        ShopSubjectScoreInfo_BDCOrRepDto bdcSubjectScoreInfo = new ShopSubjectScoreInfo_BDCOrRepDto();
                //        bdcSubjectScoreInfo.SubjectCode = Convert.ToString(dsBDCSubjectScoreInfo.Tables[0].Rows[i]["SubjectCode"]);
                //        bdcSubjectScoreInfo.Score = Convert.ToString(dsBDCSubjectScoreInfo.Tables[0].Rows[i]["Score"]);
                //        bdcSubjectScoreInfo.LossDesc = Convert.ToString(dsBDCSubjectScoreInfo.Tables[0].Rows[i]["LossDesc"]);
                //        bdcSubjectScoreInfo.Remark = Convert.ToString(dsBDCSubjectScoreInfo.Tables[0].Rows[i]["Remark"]);
                //        bdcShopSubjectScoreInfoList.Add(bdcSubjectScoreInfo);
                //    }
                //}
                //#endregion
                #region 销售顾问
                DataSet dsSaleContantInfo = dataSetList[5];
                if (dsSaleContantInfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleContantInfo.Tables[0].Rows.Count; i++)
                    {
                        SaleContantScoreInfoDto saleContantScoreInfo = new SaleContantScoreInfoDto();
                        saleContantScoreInfo.SaleName = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["SaleName"]);
                        saleContantScoreInfo.Score = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["Score"]);

                        saleContantScoreInfoList.Add(saleContantScoreInfo);
                    }
                }

                DataSet dsSaleContantInfo_Area = dataSetList[6];
                if (dsSaleContantInfo_Area.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleContantInfo_Area.Tables[0].Rows.Count; i++)
                    {
                        SaleContantScoreInfo_AreaDto saleContantScoreInfo_Area = new SaleContantScoreInfo_AreaDto();
                        saleContantScoreInfo_Area.SmallAreaScore = Convert.ToString(dsSaleContantInfo_Area.Tables[0].Rows[i]["SmallScore"]);
                        saleContantScoreInfo_Area.BigAreaScore = Convert.ToString(dsSaleContantInfo_Area.Tables[0].Rows[i]["BigScore"]);
                        saleContantScoreInfo_Area.AllScore = Convert.ToString(dsSaleContantInfo_Area.Tables[0].Rows[i]["AllScore"]);

                        saleContantScoreInfo_AreaList.Add(saleContantScoreInfo_Area);
                    }
                }

                DataSet dsSaleContantCharterScore = dataSetList[7];
                if (dsSaleContantCharterScore.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleContantCharterScore.Tables[0].Rows.Count; i++)
                    {
                        SaleContantCharterScoreInfoDto saleContantCharterScoreInfo = new SaleContantCharterScoreInfoDto();
                        saleContantCharterScoreInfo.CharterCode = Convert.ToString(dsSaleContantCharterScore.Tables[0].Rows[i]["CharterCode"]);
                        saleContantCharterScoreInfo.SaleName = Convert.ToString(dsSaleContantCharterScore.Tables[0].Rows[i]["SaleName"]);
                        saleContantCharterScoreInfo.Score = Convert.ToString(dsSaleContantCharterScore.Tables[0].Rows[i]["Score"]);

                        saleContantCharterScoreInfoDtoList.Add(saleContantCharterScoreInfo);
                    }
                }

                DataSet dsSaleAreaCharterScore = dataSetList[8];
                if (dsSaleAreaCharterScore.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSaleAreaCharterScore.Tables[0].Rows.Count; i++)
                    {
                        SaleAreaCharterScoreDto saleAreaCharterScore = new SaleAreaCharterScoreDto();
                        saleAreaCharterScore.CharterCode = Convert.ToString(dsSaleAreaCharterScore.Tables[0].Rows[i]["CharterCode"]);
                        saleAreaCharterScore.SmallCharterScore = Convert.ToString(dsSaleAreaCharterScore.Tables[0].Rows[i]["SmallCharterScore"]);
                        saleAreaCharterScore.BigCharterScore = Convert.ToString(dsSaleAreaCharterScore.Tables[0].Rows[i]["BigCharterScore"]);
                        saleAreaCharterScore.AllCharterScore = Convert.ToString(dsSaleAreaCharterScore.Tables[0].Rows[i]["AllCharterScore"]);

                        saleAreaCharterScoreDtoList.Add(saleAreaCharterScore);
                    }
                }

                DataSet dsSaleSubjectScoreInfo = dataSetList[9];
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
                Workbook workbook = msExcelUtil.OpenExcelByMSExcel(tbnFilePath.Text + @"\" + "梅赛德斯-迈巴赫销售质量现场考核综合报告.xlsx");

                #region 经销商基本信息
                {
                    Worksheet worksheet_FengMian = workbook.Worksheets["本店总分"] as Worksheet;
                    #region 经销商基本信息
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D10", shopReportDto.ShopName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D12", shopReportDto.AreaName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "J12", shopReportDto.City);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "J14", shopReportDto.SalesContant);

                    msExcelUtil.SetCellValue(worksheet_FengMian, "G20", shopReportDto.ShopScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "H20", shopReportDto.SmallAreaScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "I20", shopReportDto.BigAreaScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "J20", shopReportDto.AllScore);

                    msExcelUtil.SetCellValue(worksheet_FengMian, "G21", shopReportDto.OrderNO_All);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "G22", shopReportDto.OrderNO_Area);

                    // msExcelUtil.SetCellValue(worksheet_FengMian, "G30", shopReportDto.MustLoss);
                    #endregion
                    #region 章节信息
                    for (int i = 23; i < 30; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopCharterScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopCharterScoreInfoDtoList[j].CharterCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopCharterScoreInfoDtoList[j].ShopScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopCharterScoreInfoDtoList[j].SmallScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "I", i, shopReportDto.ShopCharterScoreInfoDtoList[j].BigScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "J", i, shopReportDto.ShopCharterScoreInfoDtoList[j].AllScore);
                            }
                        }
                    }

                    #endregion
                    #region 体系信息
                    for (int i = 50; i < 152; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopSubjectScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode
                                || msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == "*"+shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Score);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc);
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
                workbook.Close(true, Path.Combine(tbnFilePath.Text, projectCode+"梅赛德斯-迈巴赫销售质量现场考核" + "_" + shopReportDto.ShopCode +"_" + shopReportDto.ShopName + "综合报告"+ ".xlsx"), Type.Missing);
            }
            else
            {
                Workbook workbook = msExcelUtil.OpenExcelByMSExcel(tbnFilePath.Text + @"\" + "梅赛德斯-奔驰销售质量现场考核综合报告.xlsx");
                Worksheet worksheet_FengMian = workbook.Worksheets["本店总分"] as Worksheet;
                #region 经销商基本信息
                {

                    #region 经销商基本信息
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D10", shopReportDto.ShopName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "D12", shopReportDto.AreaName);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "I12", shopReportDto.City);
                    //msExcelUtil.SetCellValue(worksheet_FengMian, "J14", shopReportDto.SalesContant);

                    msExcelUtil.SetCellValue(worksheet_FengMian, "G20", shopReportDto.ShopScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "H20", shopReportDto.SmallAreaScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "I20", shopReportDto.BigAreaScore);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "J20", shopReportDto.AllScore);

                    msExcelUtil.SetCellValue(worksheet_FengMian, "G21", shopReportDto.OrderNO_All);
                    msExcelUtil.SetCellValue(worksheet_FengMian, "G22", shopReportDto.OrderNO_Area);

                    // msExcelUtil.SetCellValue(worksheet_FengMian, "G30", shopReportDto.MustLoss);
                    #endregion
                    #region 章节信息
                    for (int i = 23; i < 33; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopCharterScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopCharterScoreInfoDtoList[j].CharterCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopCharterScoreInfoDtoList[j].ShopScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopCharterScoreInfoDtoList[j].SmallScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "I", i, shopReportDto.ShopCharterScoreInfoDtoList[j].BigScore);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "J", i, shopReportDto.ShopCharterScoreInfoDtoList[j].AllScore);
                            }
                        }
                    }

                    #endregion
                    #region 体系信息
                    for (int i = 54; i < 210; i++)
                    {
                        for (int j = 0; j < shopReportDto.ShopSubjectScoreInfoDtoList.Count; j++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode
                                || msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == "*" + shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode)
                            {
                                msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Score);
                                msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc);
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
                //#region BDC
                //if (shopReportDto.BDCORRepScoreInfoDtoList != null && shopReportDto.BDCORRepScoreInfoDtoList.Count > 0)
                //{
                //    if (shopReportDto.BDCORRepScoreInfoDtoList[0].SalesType == "2")
                //    {
                //        Worksheet worksheet_BDC = workbook.Worksheets["电话咨询环节得分（BDC）"] as Worksheet;
                //        msExcelUtil.SetCellValue(worksheet_BDC, "G4", "BDC" + "\r\n" + shopReportDto.BDCORRepScoreInfoDtoList[0].SaleName);
                //        msExcelUtil.SetCellValue(worksheet_BDC, "G5", shopReportDto.BDCORRepScoreInfoDtoList[0].Score);
                //        msExcelUtil.SetCellValue(worksheet_BDC, "H5", shopReportDto.BDCORRepScoreInfoDtoList[0].SmallAreaScore);
                //        msExcelUtil.SetCellValue(worksheet_BDC, "I5", shopReportDto.BDCORRepScoreInfoDtoList[0].BigAreaScore);
                //        msExcelUtil.SetCellValue(worksheet_BDC, "J5", shopReportDto.BDCORRepScoreInfoDtoList[0].AllScore);

                //        msExcelUtil.SetCellValue(worksheet_BDC, "G7", "BDC" + "\r\n" + shopReportDto.BDCORRepScoreInfoDtoList[0].SaleName);


                //        for (int i = 8; i < 26; i++)
                //        {
                //            for (int j = 0; j < shopReportDto.BDCShopSubjectScoreInfoList.Count; j++)
                //            {
                //                if (msExcelUtil.GetCellValue(worksheet_BDC, "B", i).ToString() == shopReportDto.BDCShopSubjectScoreInfoList[j].SubjectCode)
                //                {
                //                    msExcelUtil.SetCellValue(worksheet_BDC, "G", i, shopReportDto.BDCShopSubjectScoreInfoList[j].Score);
                //                    msExcelUtil.SetCellValue(worksheet_BDC, "H", i, shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length > 32)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 36);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length >= 48)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 48);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length >= 64)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 60);
                //                    msExcelUtil.SetCellValue(worksheet_BDC, "J", i, shopReportDto.BDCShopSubjectScoreInfoList[j].Remark);
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Worksheet worksheet_Rep = workbook.Worksheets["接待员 销售顾问环节得分"] as Worksheet;
                //        msExcelUtil.SetCellValue(worksheet_Rep, "G4", "接待员" + "\r\n" + shopReportDto.BDCORRepScoreInfoDtoList[0].SaleName);
                //        msExcelUtil.SetCellValue(worksheet_Rep, "G5", shopReportDto.BDCORRepScoreInfoDtoList[0].Score);
                //        msExcelUtil.SetCellValue(worksheet_Rep, "H5", shopReportDto.BDCORRepScoreInfoDtoList[0].SmallAreaScore);
                //        msExcelUtil.SetCellValue(worksheet_Rep, "I5", shopReportDto.BDCORRepScoreInfoDtoList[0].BigAreaScore);
                //        msExcelUtil.SetCellValue(worksheet_Rep, "J5", shopReportDto.BDCORRepScoreInfoDtoList[0].AllScore);

                //        msExcelUtil.SetCellValue(worksheet_Rep, "G7", "接待员" + "\r\n" + shopReportDto.BDCORRepScoreInfoDtoList[0].SaleName);


                //        for (int i = 8; i < 26; i++)
                //        {
                //            for (int j = 0; j < shopReportDto.BDCShopSubjectScoreInfoList.Count; j++)
                //            {
                //                if (msExcelUtil.GetCellValue(worksheet_Rep, "B", i).ToString() == shopReportDto.BDCShopSubjectScoreInfoList[j].SubjectCode)
                //                {
                //                    msExcelUtil.SetCellValue(worksheet_Rep, "G", i, shopReportDto.BDCShopSubjectScoreInfoList[j].Score);
                //                    msExcelUtil.SetCellValue(worksheet_Rep, "H", i, shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length > 32)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 36);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length >= 48)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 48);
                //                    if (shopReportDto.BDCShopSubjectScoreInfoList[j].LossDesc.Length >= 64)
                //                        msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 60);
                //                    msExcelUtil.SetCellValue(worksheet_Rep, "J", i, shopReportDto.BDCShopSubjectScoreInfoList[j].Remark);
                //                }
                //            }
                //        }
                //    }
                //}

                //#endregion
                #region 销售顾问
                Worksheet worksheet_SaleContant = workbook.Worksheets["销售顾问得分"] as Worksheet;
                if (shopReportDto.SaleContantScoreInfoList.Count > 0)
                {
                    for (int i = 0; i < shopReportDto.SaleContantScoreInfoList.Count; i++)
                    {
                        msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 5, "销售顾问" + "\r\n" + shopReportDto.SaleContantScoreInfoList[i].SaleName);
                        msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 6,  shopReportDto.SaleContantScoreInfoList[i].Score);
                    }
                }
                msExcelUtil.SetCellValue(worksheet_SaleContant, "O", 6, shopReportDto.SaleContantScoreInfo_AreaList[0].SmallAreaScore);
                msExcelUtil.SetCellValue(worksheet_SaleContant, "P", 6, shopReportDto.SaleContantScoreInfo_AreaList[0].BigAreaScore);
                msExcelUtil.SetCellValue(worksheet_SaleContant, "Q", 6, shopReportDto.SaleContantScoreInfo_AreaList[0].AllScore);

                for (int i = 7; i < 16; i++)
                {
                    for (int j = 0; j < shopReportDto.SaleContantCharterScoreInfoDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == shopReportDto.SaleContantCharterScoreInfoDtoList[j].CharterCode)
                        {
                            for (int z = 7; z < 15; z++)
                            {
                                if (msExcelUtil.GetCellValue(worksheet_SaleContant, z, 5).ToString()
                                == "销售顾问" + "\r\n" + shopReportDto.SaleContantCharterScoreInfoDtoList[j].SaleName)
                                {
                                    msExcelUtil.SetCellValue(worksheet_SaleContant, z, i, shopReportDto.SaleContantCharterScoreInfoDtoList[j].Score);
                                    if (shopReportDto.SaleContantCharterScoreInfoDtoList[j].Score.Length > 20)
                                        msExcelUtil.SetCellHeight(worksheet_FengMian, z, i, 36);
                                    if (shopReportDto.SaleContantCharterScoreInfoDtoList[j].Score.Length >= 30)
                                        msExcelUtil.SetCellHeight(worksheet_FengMian, z, i, 48);
                                    if (shopReportDto.SaleContantCharterScoreInfoDtoList[j].Score.Length >= 40)
                                        msExcelUtil.SetCellHeight(worksheet_FengMian, z, i, 60);
                                    if (shopReportDto.SaleContantCharterScoreInfoDtoList[j].Score.Length >= 50)
                                        msExcelUtil.SetCellHeight(worksheet_FengMian, z, i, 72);
                                }
                            }
                        }
                    }
                }

                for (int i = 7; i < 16; i++)
                {
                    for (int j = 0; j < shopReportDto.SaleAreaCharterScoreDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == shopReportDto.SaleAreaCharterScoreDtoList[j].CharterCode)
                        {
                            msExcelUtil.SetCellValue(worksheet_SaleContant, "O", i, shopReportDto.SaleAreaCharterScoreDtoList[j].SmallCharterScore);
                            msExcelUtil.SetCellValue(worksheet_SaleContant, "P", i, shopReportDto.SaleAreaCharterScoreDtoList[j].BigCharterScore);
                            msExcelUtil.SetCellValue(worksheet_SaleContant, "Q", i, shopReportDto.SaleAreaCharterScoreDtoList[j].AllCharterScore);
                        }
                    }
                }

                for (int i = 20; i < 130; i++)
                {
                    for (int j = 0; j < shopReportDto.SaleContantSubjectScoreDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode
                            || msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == "*"+shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode)
                        {
                            //msExcelUtil.SetCellValue(worksheet_SaleContant, "O", i, shopReportDto.SaleContantSubjectScoreDtoList[j].Remark);
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
                workbook.Close(true, Path.Combine(tbnFilePath.Text, projectCode+"梅赛德斯-奔驰销售质量现场考核" + "_" + shopReportDto.ShopCode + "_" + shopReportDto.ShopName + "_综合报告"+ ".xlsx"), Type.Missing);
            }
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (tbnFilePath.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择\"数据路径\"");
                tbnFilePath.Focus();
                return;
            }
            _shopDtoList = new List<ShopDto>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    _shopDtoList.Add(gridView1.GetRow(i) as ShopDto);
                }
            }

            foreach (ShopDto shop in _shopDtoList)
            {
                if (!Directory.Exists(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName))
                {
                    Directory.CreateDirectory(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName);
                }
                DataSet ds = service.SearchSubjectFile(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), txtSubjectCode.Text);
                // DataSet ds = service.SearchLossPicByShopCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), shop.ShopCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (!Directory.Exists(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName + @"\" + ds.Tables[0].Rows[i]["SubjectCode"].ToString()))
                        {
                            Directory.CreateDirectory(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName + @"\" + ds.Tables[0].Rows[i]["SubjectCode"].ToString());
                        }
                        string fileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                        //string lossDesc = ds.Tables[0].Rows[i]["LossDesc"].ToString();
                        //if (picName.Length == 1)
                        //{
                        byte[] image = service.SearchPicStream(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName, ds.Tables[0].Rows[i]["SubjectCode"].ToString(), fileName.Replace(".jpg", ""));
                        if (image != null)
                        {

                            MemoryStream buf = new MemoryStream(image);
                            Image picimage = Image.FromStream(buf, true);
                            picimage.Save(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName + @"\" + ds.Tables[0].Rows[i]["SubjectCode"].ToString() + @"\" + fileName.Replace(".jpg", "") + ".jpg");
                        }
                        //}
                        //else
                        //{
                        //    for (int j = 0; j < picName.Length; j++)
                        //    {
                        //        byte[] image = service.SearchPicStream(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName, ds.Tables[0].Rows[i]["SubjectCode"].ToString(), picName[j].Replace(".jpg", ""));
                        //        if (image != null)
                        //        {
                        //            MemoryStream buf = new MemoryStream(image);
                        //            Image picimage = Image.FromStream(buf, true);
                        //            picimage.Save(tbnFilePath.Text + @"\" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + shop.ShopName + @"\" + ds.Tables[0].Rows[i]["SubjectCode"].ToString() + @"\" + picName[j].Replace(".jpg", "") + ".jpg");
                        //        }
                        //    }
                        //}

                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "生成完毕");
        }

 
    }
}
