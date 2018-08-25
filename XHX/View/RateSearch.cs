using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;
using System.IO;

namespace XHX.View
{
    public partial class RateSearch : BaseForm
    {
        localhost.Service webService = new localhost.Service();
        public RateSearch()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);

            webService.SearchScoreRateCompleted += new XHX.localhost.SearchScoreRateCompletedEventHandler(webService_SearchScoreRateCompleted);
        }

        private void btnChapter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            ChapterPop chapter = new ChapterPop(projectCode);
            chapter.ShowDialog();
            string chapterName = string.Empty;
            string chapterCode = string.Empty;
            List<ChapterDto> chapterList = chapter.ChapterList;
            if (chapterList != null && chapterList.Count != 0)
            {

                foreach (ChapterDto chapt in chapterList)
                {
                    if (!string.IsNullOrEmpty(chapterName))
                    {
                        chapterName += "," + chapt.CharterName;
                    }
                    else
                    {
                        chapterName = chapt.CharterName;
                    }
                    if (!string.IsNullOrEmpty(chapterCode))
                    {
                        chapterCode += "," + chapt.CharterCode;
                    }
                    else
                    {
                        chapterCode = chapt.CharterCode;
                    }
                }
                txtChapter.Text = chapterName;
                tbnChapter.Text = chapterCode;

            }


        }

        private void btnLink_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string chapterCode = tbnChapter.Text;
            string chapterName = txtChapter.Text;
            LinkPop link = new LinkPop(projectCode, chapterCode, chapterName);
            link.ShowDialog();
            string linkName = string.Empty;
            string linkCode = string.Empty;
            List<LinkDto> linkList = link.LinkList;
            if (linkList != null && linkList.Count != 0)
            {

                foreach (LinkDto linkdto in linkList)
                {
                    if (!string.IsNullOrEmpty(linkName))
                    {
                        linkName += "," + linkdto.LinkName;
                    }
                    else
                    {
                        linkName = linkdto.LinkName;
                    }
                    if (!string.IsNullOrEmpty(linkCode))
                    {
                        linkCode += "," + linkdto.LinkCode;
                    }
                    else
                    {
                        linkCode = linkdto.LinkCode;
                    }
                }
                txtLink.Text = linkName;
                tbnLink.Text = linkCode;
            }
        }

        private void btnShop_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Shop_Popup shop = new Shop_Popup("", "", true);
            shop.ShowDialog();

            string shopName = string.Empty;
            string shopCode = string.Empty;
            List<ShopDto> shopList = shop.ShopList;
            if (shopList != null && shopList.Count != 0)
            {

                foreach (ShopDto shopdto in shopList)
                {
                    if (!string.IsNullOrEmpty(shopName))
                    {
                        shopName += "," + shopdto.ShopName;
                    }
                    else
                    {
                        shopName = shopdto.ShopName;
                    }
                    if (!string.IsNullOrEmpty(shopCode))
                    {
                        shopCode += "," + shopdto.ShopCode;
                    }
                    else
                    {
                        shopCode = shopdto.ShopCode;
                    }
                }
                txtShop.Text = shopName;
                tbnShop.Text = shopCode;
            }
        }

        private void btnSubject_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string linkCode = tbnLink.Text;
            string linkName = txtLink.Text;
            SujbectPop subject = new SujbectPop(projectCode, linkCode, linkName);
            subject.ShowDialog();
            string subjectName = string.Empty;
            string subjectCode = string.Empty;
            List<SubjectDto> subjectList = subject.SubjectList;
            if (subjectList != null && subjectList.Count != 0)
            {

                foreach (SubjectDto subjectdto in subjectList)
                {
                    if (!string.IsNullOrEmpty(subjectName))
                    {
                        subjectName += "," + subjectdto.CheckPoint;
                    }
                    else
                    {
                        subjectName = subjectdto.CheckPoint;
                    }
                    if (!string.IsNullOrEmpty(subjectCode))
                    {
                        subjectCode += "," + subjectdto.SubjectCode;
                    }
                    else
                    {
                        subjectCode = subjectdto.SubjectCode;
                    }
                }
                txtSubject.Text = subjectName;
                tbnSubject.Text = subjectCode;
            }
        }

        private void webService_SearchScoreRateCompleted(object sender, XHX.localhost.SearchScoreRateCompletedEventArgs e)
        {
            try
            {

                DataSet[][] allResult = e.Result;

                #region Chapter

                DataSet[] result = allResult[0];

                DataSet leftDataSet = result[2];
                DataSet bodyDataDataSet = result[1];
                DataSet headDataSet = result[0];

                #region Head

                List<TwoLevelColumnInfo> columnInfoList = new List<TwoLevelColumnInfo>();
                if (headDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < headDataSet.Tables[0].Rows.Count; i++)
                    {
                        TwoLevelColumnInfo info = new TwoLevelColumnInfo();
                        info.Column1 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Column1"]);
                        info.Column2 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Column2"]);
                        info.Caption1 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Caption1"]);
                        info.Caption2 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Caption2"]);
                        info.Order = Convert.ToInt32(headDataSet.Tables[0].Rows[i]["Order"]);
                        columnInfoList.Add(info);
                    }
                }
                List<TwoLevelColumnInfo> tempList = new List<TwoLevelColumnInfo>();
                for (int i = 0; i < columnInfoList.Count; i++)
                {
                    if (columnInfoList[i].Order > 4)
                    {
                        tempList.Add(columnInfoList[i]);
                    }
                }
                List<int> existOrderList = new List<int>();
                for (int i = 0; i < tempList.Count; i++)
                {
                    if (!existOrderList.Contains(tempList[i].Order))
                    {
                        tempList[i].Order = tempList[i].Order;// + i
                        existOrderList.Add(tempList[i].Order);
                    }
                    else
                    {
                        int tempOrder = tempList[i].Order;
                        while (existOrderList.Contains(tempOrder))
                            tempOrder++;
                        tempList[i].Order = tempOrder;// + i
                        existOrderList.Add(tempOrder);
                    }
                }
                List<TwoLevelColumnInfo> lastlist = new List<TwoLevelColumnInfo>();
                for (int i = 0; i < columnInfoList.Count; i++)
                {
                    if (columnInfoList[i].Order < 5)
                    {
                        lastlist.Add(columnInfoList[i]);
                    }
                }
                for (int i = 0; i < tempList.Count; i++)
                {
                    lastlist.Add(tempList[i]);
                }
                columnInfoList.Clear();
                columnInfoList = lastlist;

                #endregion

                #region Data

                List<ScoreRateForChapterBodyDto> dataList = new List<ScoreRateForChapterBodyDto>();
                if (bodyDataDataSet.Tables.Count > 0 && bodyDataDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < bodyDataDataSet.Tables[0].Rows.Count; i++)
                    {
                        ScoreRateForChapterBodyDto info = new ScoreRateForChapterBodyDto();
                        info.Column1 = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["Column1"]);
                        info.Column2 = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["Column2"]);
                        info.ChapterCode = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["CharterCode"]);
                        if (bodyDataDataSet.Tables[0].Rows[i]["Value"] != DBNull.Value)
                        {
                            //string temp = Convert.ToString(Convert.ToDecimal(bodyDataDataSet.Tables[0].Rows[i]["Value"]) * 100);
                            //info.Value = temp.Split('.')[0] + "." + temp.Split('.')[1].Substring(0, 2) + "%";
                            info.Value = (Convert.ToDecimal(bodyDataDataSet.Tables[0].Rows[i]["Value"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            info.Value = "0.00" + "%";
                        }
                        dataList.Add(info);
                    }
                }

                #endregion

                #region Left

                List<ScoreRateForChapterDto> leftList = new List<ScoreRateForChapterDto>();
                if (leftDataSet.Tables.Count > 0 && leftDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < leftDataSet.Tables[0].Rows.Count; i++)
                    {
                        ScoreRateForChapterDto info = new ScoreRateForChapterDto();
                        info.ChapterCode = Convert.ToString(leftDataSet.Tables[0].Rows[i]["CharterCode"]);
                        info.ChapterName = Convert.ToString(leftDataSet.Tables[0].Rows[i]["CharterName"]);
                        leftList.Add(info);
                    }
                }

                #endregion

                DynamicColumnDataSet<TwoLevelColumnInfo, ScoreRateForChapterBodyDto, ScoreRateForChapterDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, ScoreRateForChapterBodyDto, ScoreRateForChapterDto>(columnInfoList, dataList, leftList);
                if (list != null && list.ColumnInfoList != null)
                {
                    list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, ScoreRateForChapterBodyDto, ScoreRateForChapterDto>(list.ColumnInfoList, list.DataList, list.DtoList);
                }

                //BindGrid

                CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, ScoreRateForChapterDto>(grvChapterRatio, list.ColumnInfoList, list.DtoList);
                //InitGridControl(grcShopScore);
                //grvShopScore.SetAllColumnEditable(false);
                // grcAuditionPass.SetColumnEditableByColumn(true, gcAuditioinHis, gcResume, gcPassTypeCode, gcPassRemark, gcWorkYear);
                grvChapterRatio.LeftCoord = 0;

                #endregion

                #region Link

                result = allResult[1];

                leftDataSet = result[2];
                bodyDataDataSet = result[1];
                headDataSet = result[0];

                #region Head

                columnInfoList = new List<TwoLevelColumnInfo>();
                if (headDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < headDataSet.Tables[0].Rows.Count; i++)
                    {
                        TwoLevelColumnInfo info = new TwoLevelColumnInfo();
                        info.Column1 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Column1"]);
                        info.Column2 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Column2"]);
                        info.Caption1 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Caption1"]);
                        info.Caption2 = Convert.ToString(headDataSet.Tables[0].Rows[i]["Caption2"]);
                        info.Order = Convert.ToInt32(headDataSet.Tables[0].Rows[i]["Order"]);
                        columnInfoList.Add(info);
                    }
                }
                tempList = new List<TwoLevelColumnInfo>();
                for (int i = 0; i < columnInfoList.Count; i++)
                {
                    if (columnInfoList[i].Order > 4)
                    {
                        tempList.Add(columnInfoList[i]);
                    }
                }
                existOrderList = new List<int>();
                for (int i = 0; i < tempList.Count; i++)
                {
                    if (!existOrderList.Contains(tempList[i].Order))
                    {
                        tempList[i].Order = tempList[i].Order;// + i
                        existOrderList.Add(tempList[i].Order);
                    }
                    else
                    {
                        int tempOrder = tempList[i].Order;
                        while (existOrderList.Contains(tempOrder))
                            tempOrder++;
                        tempList[i].Order = tempOrder;// + i
                        existOrderList.Add(tempOrder);
                    }
                }
                lastlist = new List<TwoLevelColumnInfo>();
                for (int i = 0; i < columnInfoList.Count; i++)
                {
                    if (columnInfoList[i].Order < 5)
                    {
                        lastlist.Add(columnInfoList[i]);
                    }
                }
                for (int i = 0; i < tempList.Count; i++)
                {
                    lastlist.Add(tempList[i]);
                }
                columnInfoList.Clear();
                columnInfoList = lastlist;

                #endregion

                #region Data

                List<ScoreRateForLinkBodyDto> dataList1 = new List<ScoreRateForLinkBodyDto>();
                if (bodyDataDataSet.Tables.Count > 0 && bodyDataDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < bodyDataDataSet.Tables[0].Rows.Count; i++)
                    {
                        ScoreRateForLinkBodyDto info = new ScoreRateForLinkBodyDto();
                        info.Column1 = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["Column1"]);
                        info.Column2 = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["Column2"]);
                        info.LinkCode = Convert.ToString(bodyDataDataSet.Tables[0].Rows[i]["LinkCode"]);
                        if (bodyDataDataSet.Tables[0].Rows[i]["Value"] != DBNull.Value)
                        {
                            //string temp = Convert.ToString(Convert.ToDecimal(bodyDataDataSet.Tables[0].Rows[i]["Value"]) * 100);
                            //info.Value = temp.Split('.')[0] + "." + temp.Split('.')[1].Substring(0, 2) + "%";
                            info.Value = (Convert.ToDecimal(bodyDataDataSet.Tables[0].Rows[i]["Value"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            info.Value = "0.00" + "%";
                        }
                        dataList1.Add(info);
                    }
                }

                #endregion

                #region Left

                List<ScoreRateForLinkDto> leftList1 = new List<ScoreRateForLinkDto>();
                if (leftDataSet.Tables.Count > 0 && leftDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < leftDataSet.Tables[0].Rows.Count; i++)
                    {
                        ScoreRateForLinkDto info = new ScoreRateForLinkDto();
                        info.LinkCode = Convert.ToString(leftDataSet.Tables[0].Rows[i]["LinkCode"]);
                        info.LinkName = Convert.ToString(leftDataSet.Tables[0].Rows[i]["LinkName"]);
                        leftList1.Add(info);
                    }
                }

                #endregion

                DynamicColumnDataSet<TwoLevelColumnInfo, ScoreRateForLinkBodyDto, ScoreRateForLinkDto> list1 = new DynamicColumnDataSet<TwoLevelColumnInfo, ScoreRateForLinkBodyDto, ScoreRateForLinkDto>(columnInfoList, dataList1, leftList1);
                if (list1 != null && list1.ColumnInfoList != null)
                {
                    list1.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, ScoreRateForLinkBodyDto, ScoreRateForLinkDto>(list1.ColumnInfoList, list1.DataList, list1.DtoList);
                }

                //BindGrid

                CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, ScoreRateForLinkDto>(grvLinkRatio, list1.ColumnInfoList, list1.DtoList);
                //InitGridControl(grcShopScore);
                //grvShopScore.SetAllColumnEditable(false);
                // grcAuditionPass.SetColumnEditableByColumn(true, gcAuditioinHis, gcResume, gcPassTypeCode, gcPassRemark, gcWorkYear);
                grvLinkRatio.LeftCoord = 0;

                #endregion

                #region Subject

                result = allResult[2];
                List<SubjectDto> subjectList = new List<SubjectDto>();

                if (result[0].Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < result[0].Tables[0].Rows.Count; i++)
                    {
                        SubjectDto subjectDto = new SubjectDto();
                        subjectDto.SubjectCode = Convert.ToString(result[0].Tables[0].Rows[i]["SubjectCode"]);
                        subjectDto.CheckPoint = Convert.ToString(result[0].Tables[0].Rows[i]["CheckPoint"]);

                        if (result[0].Tables[0].Rows[i]["全国"] != DBNull.Value)
                        {
                            subjectDto.AllCountry = (Convert.ToDecimal(result[0].Tables[0].Rows[i]["全国"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            subjectDto.AllCountry = "0.00" + "%";
                        }
                        if (result[0].Tables[0].Rows[i]["东区"] != DBNull.Value)
                        {
                            subjectDto.EastArea = (Convert.ToDecimal(result[0].Tables[0].Rows[i]["东区"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            subjectDto.EastArea = "0.00" + "%";
                        }
                        if (result[0].Tables[0].Rows[i]["南区"] != DBNull.Value)
                        {
                            subjectDto.SouthArea = (Convert.ToDecimal(result[0].Tables[0].Rows[i]["南区"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            subjectDto.SouthArea = "0.00" + "%";
                        }
                        if (result[0].Tables[0].Rows[i]["西区"] != DBNull.Value)
                        {
                            subjectDto.WestArea = (Convert.ToDecimal(result[0].Tables[0].Rows[i]["西区"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            subjectDto.WestArea = "0.00" + "%";
                        }
                        if (result[0].Tables[0].Rows[i]["北区"] != DBNull.Value)
                        {
                            subjectDto.NorthArea = (Convert.ToDecimal(result[0].Tables[0].Rows[i]["北区"]) * 100).ToString("0.00") + "%";
                        }
                        else
                        {
                            subjectDto.NorthArea = "0.00" + "%";
                        }
                         

                        //subjectDto.EastArea = Convert.ToDecimal(result[0].Tables[0].Rows[i]["东区"] == DBNull.Value ? ("0.00" + "%") : (Convert.ToDecimal(result[0].Tables[0].Rows[i]["东区"]) * 100).ToString("0.00") + "%");
                        //subjectDto.SouthArea = Convert.ToDecimal(result[0].Tables[0].Rows[i]["南区"] == DBNull.Value ? ("0.00" + "%") : (Convert.ToDecimal(result[0].Tables[0].Rows[i]["南区"]) * 100).ToString("0.00") + "%");
                        //subjectDto.WestArea = Convert.ToDecimal(result[0].Tables[0].Rows[i]["西区"] == DBNull.Value ? ("0.00" + "%") : (Convert.ToDecimal(result[0].Tables[0].Rows[i]["西区"]) * 100).ToString("0.00") + "%");
                        //subjectDto.NorthArea = Convert.ToDecimal(result[0].Tables[0].Rows[i]["北区"] == DBNull.Value ? ("0.00" + "%") : (Convert.ToDecimal(result[0].Tables[0].Rows[i]["北区"]) * 100).ToString("0.00") + "%");
                        subjectList.Add(subjectDto);
                    }
                }

                grcSubjectRatio.DataSource = subjectList; ;

                #endregion
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, ex.Message); return;
            }
            finally
            {
                this.Enabled = true;
            }
        }
        private void grvChapterRatio_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void grvLinkRatio_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void grvSubjectRatio_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fileStream = File.OpenRead(ofd.FileName);
                    byte[] buffer = new byte[fileStream.Length];
                    if (fileStream.Length < int.MaxValue)
                        fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
                    else
                    {
                        byte[] split = null;
                        int count = 0;
                        for (long index = 0; index < fileStream.Length; )
                        {
                            if ((long)int.MaxValue + index < fileStream.Length)
                            {
                                count = int.MaxValue;
                            }
                            else
                            {
                                count = Convert.ToInt32(fileStream.Length - index);
                            }
                            split = new byte[count];
                            fileStream.Read(split, 0, count);
                            split.CopyTo(buffer, index);
                            index += count;
                        }
                    }
                    MemoryStream ms = new MemoryStream(buffer);
                    List<SubjectDto> subjectDtoList = null;
                    List<ShopSubjectScoreDto> shopSubjectScoreDtoList = null;
                    ExcelUtil.ImportShopSubjectScore(ms, out subjectDtoList, out shopSubjectScoreDtoList);
                    foreach (SubjectDto subject in subjectDtoList)
                    {
                        webService.SaveFeiJianSubject(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), subject.SubjectCode, subject.CheckPoint, "sysadmin", subject.LinkCode);
                    }
                    foreach (ShopSubjectScoreDto shopscore in shopSubjectScoreDtoList)
                    {
                        decimal? score = null;
                        if (shopscore.Score == ".")
                        {
                            score = null;
                        }
                        else
                        {
                            score = Convert.ToDecimal(shopscore.Score);
                        }
                       webService.SaveFeiJianScore(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), shopscore.SubjectCode, shopscore.ShopCode, score, "sysadmin");
                    }
                    //gridControl1.DataSource = subjectDtoList;
                    //gridControl2.DataSource = shopSubjectScoreDtoList;
                }
                CommonHandler.ShowMessage(MessageType.Information,"上传成功");
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }
        public override void SearchButtonClick()
        {
            try
            {
                string projectCode = string.Empty;
                string[] shopCodes = default(string[]);
                string[] chaterCodes = default(string[]);
                string[] linkCodes = default(string[]);
                string[] subjectCodes = default(string[]);
                bool fCheck = default(bool);

                projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                shopCodes = tbnShop.Text.Split(',');
                chaterCodes = tbnChapter.Text.Split(',');
                linkCodes = tbnLink.Text.Split(',');
                subjectCodes = tbnSubject.Text.Split(',');
                fCheck = chkFCheck.Checked;

                this.Enabled = false;

                webService.SearchScoreRateAsync(projectCode, chaterCodes, linkCodes, subjectCodes, shopCodes, fCheck);
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, ex.Message); this.Enabled = true; return;
            }
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvChapterRatio);
            CommonHandler.ExcelExport(grvLinkRatio);
            CommonHandler.ExcelExport(grvSubjectRatio);
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }
    }
}
