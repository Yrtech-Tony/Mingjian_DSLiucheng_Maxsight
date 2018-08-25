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

namespace XHX.ViewLocalService
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
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            XHX.Common.BindComBox.BindProject(cboProjects);
            tbnFilePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            btnModule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            SearchAllShopByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
            CommonHandler.SetRowNumberIndicator(gridView1);
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
            DataSet[] dataSetList = service.GetShopReportDto(projectCode, shopCode);
            ShopReportDto shopReportDto = new ShopReportDto();

            List<AllScoreDto26> allScoreDtoList26 = new List<AllScoreDto26>();
            List<AllScoreDto31> allScoreDtoList31 = new List<AllScoreDto31>();
            List<AllScoreSumDto> allScoreSumDtoList = new List<AllScoreSumDto>();
            List<AllShopScoreDto11> allShopScoreDtoList11 = new List<AllShopScoreDto11>();
            List<AllShopScoreDto16> allShopScoreDtoList16 = new List<AllShopScoreDto16>();
            List<ChaptersScoreDto27To30> chaptersScoreDtoList27To30 = new List<ChaptersScoreDto27To30>();
            List<ChaptersScoreDto32To35> chaptersScoreDtoList32To35 = new List<ChaptersScoreDto32To35>();
            List<SubjectsScoreDto> subjectsScoreDtoList = new List<SubjectsScoreDto>();

            shopReportDto.AllScoreDtoList26 = allScoreDtoList26;
            shopReportDto.AllScoreDtoList31 = allScoreDtoList31;
            shopReportDto.AllScoreSumDtoList = allScoreSumDtoList;
            shopReportDto.AllShopScoreDtoList11 = allShopScoreDtoList11;
            shopReportDto.AllShopScoreDtoList16 = allShopScoreDtoList16;
            shopReportDto.ChaptersScoreDtoList27To30 = chaptersScoreDtoList27To30;
            shopReportDto.ChaptersScoreDtoList32To35 = chaptersScoreDtoList32To35;
            shopReportDto.SubjectsScoreDtoList = subjectsScoreDtoList;

            #region 封面信息
            DataSet ds = dataSetList[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    shopReportDto.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    shopReportDto.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shopReportDto.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shopReportDto.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                    shopReportDto.Province = Convert.ToString(ds.Tables[0].Rows[i]["Province"]);
                    shopReportDto.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                }
            }
            #endregion
            #region 11行
            ds = dataSetList[1];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AllShopScoreDto11 allshopScore = new AllShopScoreDto11();
                    allshopScore.Type = "A";
                    allshopScore.ScoreShop = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    allShopScoreDtoList11.Add(allshopScore);
                }
            }
            #endregion
            #region 12到15行
            ds = dataSetList[2];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopChapterScoreDto12To15 shopChapterScore = new ShopChapterScoreDto12To15();
                    shopChapterScore.Type = "A";
                    //shopChapterScore.CharterName = Convert.string(ds.Tables[0].Rows[i]["CharterName"]);
                    shopChapterScore.ScoreShop = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    shopChapterScore.SubjectPassCount = Convert.ToDecimal(ds.Tables[0].Rows[i]["CNT"]);
                    shopChapterScoreDtoList12To15.Add(shopChapterScore);
                }
            }
            #endregion
            #region 16行
            ds = dataSetList[3];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AllShopScoreDto16 allshopScore = new AllShopScoreDto16();
                    allshopScore.Type = "B";
                    allshopScore.ScoreShop = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    allShopScoreDtoList16.Add(allshopScore);
                }
            }
            #endregion
            #region 17到20行
            ds = dataSetList[4];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopChapterScoreDto17To20 shopChapterScore = new ShopChapterScoreDto17To20();
                    shopChapterScore.Type = "B";
                    //shopChapterScore.CharterName = Convert.ToDecimal(ds.Tables[0].Rows[i]["CharterName"]);
                    shopChapterScore.ScoreShop = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    shopChapterScore.SubjectPassCount = Convert.ToDecimal(ds.Tables[0].Rows[i]["CNT"]);
                    shopChapterScoreDtoList17To20.Add(shopChapterScore);
                }
            }
            #endregion
            #region 25行
            ds = dataSetList[5];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AllScoreSumDto allscoreSum = new AllScoreSumDto();
                    allscoreSum.ScoreArea_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaAVG"]);
                    allscoreSum.ScoreArea_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaMAX"]);
                    allscoreSum.ScoreAll_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllAVG"]);
                    allscoreSum.ScoreAll_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllMAX"]);
                    allScoreSumDtoList.Add(allscoreSum);
                }
            }
            #endregion
            #region 26行
            ds = dataSetList[6];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AllScoreDto26 allscore = new AllScoreDto26();
                    allscore.Type = "A";
                    allscore.ScoreArea_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaAVG"]);
                    allscore.ScoreArea_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaMAX"]);
                    allscore.ScoreAll_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllAVG"]);
                    allscore.ScoreAll_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllMAX"]);
                    allScoreDtoList26.Add(allscore);
                }
            }
            #endregion
            #region 27到30行
            ds = dataSetList[7];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ChaptersScoreDto27To30 chapterScore = new ChaptersScoreDto27To30();
                    chapterScore.Type = "A";
                    chapterScore.ScoreArea_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaAVG"]);
                    chapterScore.ScoreArea_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaMAX"]);
                    chapterScore.ScoreAll_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllAVG"]);
                    chapterScore.ScoreAll_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllMAX"]);
                    chaptersScoreDtoList27To30.Add(chapterScore);
                }
            }
            #endregion
            #region 31行
            ds = dataSetList[8];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AllScoreDto31 allscore = new AllScoreDto31();
                    allscore.Type = "B";
                    allscore.ScoreArea_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaAVG"]);
                    allscore.ScoreArea_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaMAX"]);
                    allscore.ScoreAll_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllAVG"]);
                    allscore.ScoreAll_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllMAX"]);
                    allScoreDtoList31.Add(allscore);
                }
            }
            #endregion
            #region 32到35行
            ds = dataSetList[9];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ChaptersScoreDto32To35 chapterScore = new ChaptersScoreDto32To35();
                    chapterScore.Type = "B";
                    chapterScore.ScoreArea_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaAVG"]);
                    chapterScore.ScoreArea_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AreaMAX"]);
                    chapterScore.ScoreAll_AVG = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllAVG"]);
                    chapterScore.ScoreAll_MAX = Convert.ToDecimal(ds.Tables[0].Rows[i]["AllMAX"]);
                    chaptersScoreDtoList32To35.Add(chapterScore);
                }
            }
            #endregion
            #region 指标点得分
            ds = dataSetList[10];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SubjectsScoreDto subjectScore = new SubjectsScoreDto();
                    subjectScore.FullScore = Convert.ToDecimal(ds.Tables[0].Rows[i]["FullScore"]);
                    subjectScore.Score = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    subjectScore.LostDesc = Convert.ToString(ds.Tables[0].Rows[i]["LossDesc"]);
                    subjectScore.PicName = Convert.ToString(ds.Tables[0].Rows[i]["PicName"]);
                    subjectScore.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    subjectsScoreDtoList.Add(subjectScore);
                }
            }
            #endregion
            return shopReportDto;
        }

        private void WriteDataToExcel(ShopReportDto shopReportDto)
        {
            //  Workbook workbook = msExcelUtil.OpenExcelByMSExcel(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Template\SingleShopReportTemplate_20130812.xlsx");
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);

            #region 封面
            {
                Worksheet worksheet_FengMian = workbook.Worksheets["封面"] as Worksheet;
                msExcelUtil.SetCellValue(worksheet_FengMian, "C9", shopReportDto.ShopCode);
                msExcelUtil.SetCellValue(worksheet_FengMian, "F9", shopReportDto.ShopName);
                msExcelUtil.SetCellValue(worksheet_FengMian, "C11", shopReportDto.AreaName);
                msExcelUtil.SetCellValue(worksheet_FengMian, "F11", shopReportDto.Province + shopReportDto.City);
                //msExcelUtil.SetCellValue(worksheet_FengMian, "D17", shopReportDto.ProjectCode);
                //msExcelUtil.SetCellValue(worksheet_FengMian, "H17", shopReportDto.City);
            }
            #endregion

            #region 经销商得分概况
            {
                Worksheet worksheet_ShopScore = workbook.Worksheets["经销商得分概况"] as Worksheet;
                //#region 11行 16行
                //List<AllShopScoreDto11> allShopScoreDtoList11= shopReportDto.AllShopScoreDtoList11;
                //foreach (AllShopScoreDto11 allShopScore in allShopScoreDtoList11)
                //{
                //        msExcelUtil.SetCellValue(worksheet_ShopScore, "H", 11, allShopScore.ScoreShop);
                //}

                //List<AllShopScoreDto16> allShopScoreDtoList16 = shopReportDto.AllShopScoreDtoList16;
                //foreach (AllShopScoreDto16 allShopScore in allShopScoreDtoList16)
                //{
                //    msExcelUtil.SetCellValue(worksheet_ShopScore, "H", 16, allShopScore.ScoreShop);
                //}
                //#endregion
                #region 12到15行 17到20行
                List<ShopChapterScoreDto12To15> shopChpterScoreDtoList12To15 = shopReportDto.ShopChapterScoreDtoList12To15;
                int rowIndex = 12;
                foreach (ShopChapterScoreDto12To15 shopChpterScore in shopChpterScoreDtoList12To15)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", rowIndex, shopChpterScore.SubjectPassCount);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "H", rowIndex, shopChpterScore.ScoreShop);
                    rowIndex++;
                }

                List<ShopChapterScoreDto17To20> shopChpterScoreDtoList17To20 = shopReportDto.ShopChapterScoreDtoList17To20;
                 rowIndex = 17;
                foreach (ShopChapterScoreDto17To20 shopChpterScore in shopChpterScoreDtoList17To20)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", rowIndex, shopChpterScore.SubjectPassCount);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "H", rowIndex, shopChpterScore.ScoreShop);
                    rowIndex++;
                }
                #endregion
                #region 25行
                List<AllScoreSumDto> allScoreSumList = shopReportDto.AllScoreSumDtoList;
                foreach (AllScoreSumDto allScoreSum in allScoreSumList)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "D", 25, allScoreSum.ScoreArea_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "E", 25, allScoreSum.ScoreArea_MAX);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "F", 25, allScoreSum.ScoreAll_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", 25, allScoreSum.ScoreAll_MAX);
                }
                #endregion
                #region 26行 31行
                List<AllScoreDto26> allScoreDto26List = shopReportDto.AllScoreDtoList26;
                foreach (AllScoreDto26 allScoreDto in allScoreDto26List)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "D", 26, allScoreDto.ScoreArea_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "E", 26, allScoreDto.ScoreArea_MAX);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "F", 26, allScoreDto.ScoreAll_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", 26, allScoreDto.ScoreAll_MAX);
                }

                List<AllScoreDto31> allScoreDto31List = shopReportDto.AllScoreDtoList31;
                foreach (AllScoreDto31 allScoreDto in allScoreDto31List)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "D", 31, allScoreDto.ScoreArea_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "E", 31, allScoreDto.ScoreArea_MAX);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "F", 31, allScoreDto.ScoreAll_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", 31, allScoreDto.ScoreAll_MAX);
                }
                #endregion
                #region 27到30行 32到35行
                 List<ChaptersScoreDto27To30> chaptersScoreDto27To30List = shopReportDto.ChaptersScoreDtoList27To30;
                 rowIndex = 27;
                foreach (ChaptersScoreDto27To30 chpterScore in chaptersScoreDto27To30List)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "D", rowIndex, chpterScore.ScoreArea_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "E", rowIndex, chpterScore.ScoreArea_MAX);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "F", rowIndex, chpterScore.ScoreAll_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", rowIndex, chpterScore.ScoreAll_MAX);
                    rowIndex++;
                }

                List<ChaptersScoreDto32To35> chaptersScoreDto32To35List = shopReportDto.ChaptersScoreDtoList32To35;
                rowIndex = 32;
                foreach (ChaptersScoreDto32To35 chpterScore in chaptersScoreDto32To35List)
                {
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "D", rowIndex, chpterScore.ScoreArea_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "E", rowIndex, chpterScore.ScoreArea_MAX);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "F", rowIndex, chpterScore.ScoreAll_AVG);
                    msExcelUtil.SetCellValue(worksheet_ShopScore, "G", rowIndex, chpterScore.ScoreAll_MAX);
                    rowIndex++;
                }

                #endregion

            }
            #endregion

            #region 指标点得分详情
            List<SubjectsScoreDto> subjectsScoreDtoListDetail = shopReportDto.SubjectsScoreDtoList;
            {
                Worksheet worksheet_ShopScoreDetail = workbook.Worksheets["指标点得分详情"] as Worksheet;
                int rowIndex1 = 4;
                foreach (SubjectsScoreDto subjectsScoreDto in subjectsScoreDtoListDetail)
                {
                    for (int i = 4; i < 150; i++)
                    {
                        if (subjectsScoreDto.SubjectCode == msExcelUtil.GetCellValue(worksheet_ShopScoreDetail, "C", i).ToString())
                        {
                            //msExcelUtil.SetCellValue(worksheet_ShopScoreDetail, "F", i, subjectsScoreDto.FullScore);
                            if (subjectsScoreDto.Score == Convert.ToDecimal(9999.00))
                            {
                                msExcelUtil.SetCellValue(worksheet_ShopScoreDetail, "G", i, ".");
                            }
                            else
                            {
                                msExcelUtil.SetCellValue(worksheet_ShopScoreDetail, "G", i,subjectsScoreDto.Score);
                            }
                            msExcelUtil.SetCellValue(worksheet_ShopScoreDetail, "H", i, subjectsScoreDto.LostDesc);
                        }
                    }
                }
            }
            #endregion
            #region 失分照片
            {
                List<SubjectsScoreDto> subjectsScoreDtoList = shopReportDto.SubjectsScoreDtoList;
                Worksheet worksheet_ShopScoreDetail2 = workbook.Worksheets["失分照片"] as Worksheet;
                int rowIndex = 3;
                foreach (SubjectsScoreDto subjectsScoreDto in subjectsScoreDtoList)
                {
                    if (String.IsNullOrEmpty(subjectsScoreDto.LostDesc) || String.IsNullOrEmpty(subjectsScoreDto.PicName)
                        || subjectsScoreDto.LostDesc == null || subjectsScoreDto.PicName==null)
                    {
                        msExcelUtil.DeleteRow(worksheet_ShopScoreDetail2, rowIndex);
                        continue;
                    }
                    else
                    {
                       // msExcelUtil.SetCellValue(worksheet_ShopScoreDetail2, "F", rowIndex, subjectsScoreDto.LostDesc);
                        string[] picNameArray = subjectsScoreDto.PicName.Split(';');
                        int picIndex = 0;
                        foreach (string picName in picNameArray)
                        {
                            if (picIndex != 0 && picIndex % 3 == 0)
                            {
                                msExcelUtil.AddRow(worksheet_ShopScoreDetail2, ++rowIndex);
                            }
                            if (string.IsNullOrEmpty(picName)) continue;
                            byte[] bytes = service.SearchAnswerDtl2Pic(picName.Replace(".jpg", ""), shopReportDto.ProjectCode + shopReportDto.ShopName, subjectsScoreDto.SubjectCode, "", "");
                            if (bytes == null || bytes.Length == 0) continue;
                            Image.FromStream(new MemoryStream(bytes)).Save(Path.Combine(Path.GetTempPath(), picName + ".jpg"));
                            int colIndex = 3 + picIndex % 3;

                            msExcelUtil.InsertPicture(worksheet_ShopScoreDetail2, worksheet_ShopScoreDetail2.Cells[rowIndex, colIndex] as Microsoft.Office.Interop.Excel.Range, Path.Combine(Path.GetTempPath(), picName + ".jpg"), rowIndex);
                            picIndex++;
                        }
                    }

                    rowIndex++;
                }
            }
            #endregion
            //workbook.Save(Path.Combine(tbnFilePath.Text,shopReportDto.ProjectCode+"_"+shopReportDto.ShopName+".xls"));
            workbook.Close(true, Path.Combine(tbnFilePath.Text, shopReportDto.ProjectCode + "_" + shopReportDto.ShopName + ".xlsx"), Type.Missing);
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
            string path = tbnFilePath.Text + "\\"+"Error.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, errMessage+"\r\n");
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
                    WriteErrorLog(shopDto.ShopCode+shopDto.ShopName+ex.Message.ToString());
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
                btnModule.Text = ofp.FileName;
            }
        }
    }
}
