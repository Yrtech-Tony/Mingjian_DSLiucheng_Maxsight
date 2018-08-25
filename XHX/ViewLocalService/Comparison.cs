using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;
using XHX.Common;
using System.IO;

namespace XHX.ViewLocalService
{
    public partial class Comparison : BaseForm
    {
        localhost.Service service = new localhost.Service();
        public Comparison()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            BindComBox.BindProject(cboProject);
        }

        private void tbnChapter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void tbnShop_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            List<ShopDto> shopList = new List<ShopDto>();
            Shop_Popup shop = new Shop_Popup("", "", true);
            shop.ShowDialog();

            string shopName = string.Empty;
            string shopCode = string.Empty;
            shopList = shop.ShopList;
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


        private List<ScoreWeigthBodayRateDto> SearchBodyData(string projectCode, string chapterCode, string shopCode, bool fCheck, bool check)
        {
            DataSet ds = service.SearchBodayForWeightRate(projectCode, chapterCode, shopCode, fCheck, check);
            List<ScoreWeigthBodayRateDto> shopScoreBodyList = new List<ScoreWeigthBodayRateDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ScoreWeigthBodayRateDto info = new ScoreWeigthBodayRateDto();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);
                    info.ChapterCode = Convert.ToString(ds.Tables[0].Rows[i]["CharterCode"]);
                    if (ds.Tables[0].Rows[i]["Value"] != DBNull.Value)
                    {
                        info.Value = (Convert.ToDecimal(ds.Tables[0].Rows[i]["Value"])*100).ToString("0.00")+"%";
                        //string temp  =Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[i]["Value"])*100);
                        //info.Value = temp.Split('.')[0] + "." + temp.Split('.')[1].Substring(0,2) + "%";
                    }
                    else
                    {
                        info.Value = "0.00"+"%";
                    }
                    shopScoreBodyList.Add(info);
                }
            }
            return shopScoreBodyList;
        }

        private List<ScoreWeigthRateDto> SearchLeft(string projectCode, string chapterCode, bool check)
        {
            DataSet ds = service.SearchLeftForWeightRate(projectCode, chapterCode, chkFCheck.Checked);
            List<ScoreWeigthRateDto> shopScoreLeftList = new List<ScoreWeigthRateDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ScoreWeigthRateDto info = new ScoreWeigthRateDto();
                    info.ChapterCode = Convert.ToString(ds.Tables[0].Rows[i]["CharterCode"]);
                    info.ChapterName = Convert.ToString(ds.Tables[0].Rows[i]["CharterName"]);
                    shopScoreLeftList.Add(info);
                }
            }
            return shopScoreLeftList;
        }

        private List<TwoLevelColumnInfo> SearchHead(string projectCode, string shopCode)
        {
            DataSet ds = service.SearchHearForWeightRate(projectCode, shopCode);
            List<TwoLevelColumnInfo> columnInfoList = new List<TwoLevelColumnInfo>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TwoLevelColumnInfo info = new TwoLevelColumnInfo();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);
                    info.Caption1 = Convert.ToString(ds.Tables[0].Rows[i]["Caption1"]);
                    info.Caption2 = Convert.ToString(ds.Tables[0].Rows[i]["Caption2"]);
                    info.Order = Convert.ToInt32(ds.Tables[0].Rows[i]["Order"]);
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
            return lastlist;
        }

        private void grvWeightRate_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            
            //string fileNames = null;
            //openFileDialog.Multiselect = false;

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    fileNames = openFileDialog.FileName;
            //}
            //using (FileStream fs = new FileStream(fileNames, FileMode.Open))
            //{
            //    byte[] b = new byte[fs.Length];
            //    fs.Read(b, 0, b.Length);
            //  //  service.
            //    service.ImportFFV(b, CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), "sysadmin");
            //}
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
                    List<FFVRateDto> ffvRateList = null;
                    List<FFVShopRateDto> ffvShopRateList = null;
                    ExcelUtil.ImportFFVRate(ms, out ffvRateList, out ffvShopRateList);
                    foreach (FFVRateDto subject in ffvRateList)
                    {
                        service.SaveFFVRate(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), subject.AllRate, subject.EastRate, subject.SouthRate, subject.WestRate, subject.NorthRate,subject.WestRate, subject.UserID);
                    }
                    foreach (FFVShopRateDto shopscore in ffvShopRateList)
                    {

                        service.SaveFFVShopRate(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), shopscore.ShopCode, 
                            shopscore.Weight,shopscore.UserID);
                    }
                    //gridControl1.DataSource = subjectDtoList;
                    //gridControl2.DataSource = shopSubjectScoreDtoList;
                }
                CommonHandler.ShowMessage(MessageType.Information, "上传成功");
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(ex);
            }
        }


        public override void SearchButtonClick()
        {
            grcWeightRate.DataSource = null;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string shopCode = tbnShop.Text;
            List<TwoLevelColumnInfo> columnInfoList = SearchHead(projectCode, shopCode);
            List<ScoreWeigthBodayRateDto> dataList = SearchBodyData(projectCode, tbnChapter.Text, shopCode, true, chkFCheck.Checked);
            List<ScoreWeigthRateDto> leftList = SearchLeft(projectCode, tbnChapter.Text, chkFCheck.Checked);

            DynamicColumnDataSet<TwoLevelColumnInfo, ScoreWeigthBodayRateDto, ScoreWeigthRateDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, ScoreWeigthBodayRateDto, ScoreWeigthRateDto>(columnInfoList, dataList, leftList);
            if (list != null && list.ColumnInfoList != null)
            {
                list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, ScoreWeigthBodayRateDto, ScoreWeigthRateDto>(list.ColumnInfoList, list.DataList, list.DtoList);
            }

            //BindGrid

            CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, ScoreWeigthRateDto>(grvWeightRate, list.ColumnInfoList, list.DtoList);
            grvWeightRate.LeftCoord = 0;
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvWeightRate);
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
