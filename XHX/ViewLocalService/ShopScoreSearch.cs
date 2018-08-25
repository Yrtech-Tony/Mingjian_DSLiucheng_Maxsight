using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace XHX.ViewLocalService
{
    public partial class ShopScoreSearch : BaseForm
    {
        ToolTip toolTip = null;
        localhost.Service webService = new localhost.Service();
        public ShopScoreSearch()
        {
            InitializeComponent(); 
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            BindComBox.BindProject(cboProject);
            toolTip = new ToolTip();

        }
        public void Search()
        {
            grcShopScore.DataSource = null;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string shopCode = btnShopCode.Text;
            bool lossCheck = chkLoss.Checked;
            bool recheck = chkRecheck.Checked;
            bool all = chkAll.Checked;
            List<TwoLevelColumnInfo> columnInfoList = SearchHead(projectCode, shopCode);
            List<ShopScoreBodyDto> dataList = SearchBodyData(projectCode, shopCode, lossCheck, recheck,all);
            List<ShopScoreInfoDto> leftList = SearchLeft(projectCode);

            DynamicColumnDataSet<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto>(columnInfoList, dataList, leftList);
            if (list != null && list.ColumnInfoList != null)
            {
                list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, ShopScoreBodyDto, ShopScoreInfoDto>(list.ColumnInfoList, list.DataList, list.DtoList);
            }

            //BindGrid

            CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, ShopScoreInfoDto>(grvShopScore, list.ColumnInfoList, list.DtoList);

            //foreach(DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
            foreach (GridColumn col in grvShopScore.Columns)
            {
                for (int i = 0; i < grvShopScore.RowCount; i++)
                {
                    if (grvShopScore.GetRowCellValue(i, col) == null || grvShopScore.GetRowCellValue(i, col).ToString() == "")
                    {
                        grvShopScore.SetRowCellValue(i, col, "--");
                    }
                }
                //RepositoryItemTextEdit textBox = new RepositoryItemTextEdit();
                //((System.ComponentModel.ISupportInitialize)(textBox)).BeginInit();
                //this.grcShopScore.RepositoryItems.Add(textBox);
                //textBox.Properties.NullText = "--";
                //col.ColumnEdit = textBox;
                //((System.ComponentModel.ISupportInitialize)(textBox)).EndInit();
            }
            grvShopScore.LeftCoord = 0;

        }
        public List<TwoLevelColumnInfo> SearchHead(string projectCode, string shopCode)
        {
            //string[] s = shopCode.Split(',');
            DataSet ds = webService.SearchHead(projectCode, shopCode);
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
            return columnInfoList;
        }
        public List<ShopScoreBodyDto> SearchBodyData(string projectCode, string shopCode, bool lossCheck, bool recheck,bool all)
        {
            DataSet ds = webService.SearchBodyData(projectCode, shopCode, lossCheck, recheck,all);
            List<ShopScoreBodyDto> shopScoreBodyList = new List<ShopScoreBodyDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopScoreBodyDto info = new ShopScoreBodyDto();
                    info.Column1 = Convert.ToString(ds.Tables[0].Rows[i]["Column1"]);
                    info.Column2 = Convert.ToString(ds.Tables[0].Rows[i]["Column2"]);

                    info.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    if (ds.Tables[0].Rows[i]["Value"] != DBNull.Value)
                    {
                        info.Value = Convert.ToString(ds.Tables[0].Rows[i]["Value"]);
                        if (info.Value.ToString().Contains("9999.00"))
                        {
                            info.Value = info.Value.ToString().Replace("9999.00", ".");
                        }
                        if (info.Value == null || Convert.ToString(info.Value) == "")
                        {
                            info.Value = "@@";
                        }
                    }
                    else
                    {
                        info.Value = "@@";
                    }

                    shopScoreBodyList.Add(info);
                }
            }
            return shopScoreBodyList;
        }
        //冒泡排序
        public void ExecuteSorteMethod(int[] num)
        {
            for (int i = 0; i < num.Length - 1; i++)
            {
                for (int j = 0; j < num.Length - 1 - i; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        int temp = num[j];
                        num[j] = num[j + 1];
                        num[j + 1] = temp;
                    }
                }
            }

        }
        public List<ShopScoreInfoDto> SearchLeft(string projectCode)
        {
            DataSet ds = webService.SearchLeft(projectCode);
            List<ShopScoreInfoDto> shopScoreLeftList = new List<ShopScoreInfoDto>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopScoreInfoDto info = new ShopScoreInfoDto();
                    info.CheckPoint = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                    info.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    info.SubjectOrderNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SubjectOrderNO"]);
                    shopScoreLeftList.Add(info);
                }
            }
            //List<ShopScoreInfoDto> listScore = Order(shopScoreLeftList);
            //return listScore;
            return shopScoreLeftList;
        }
        public List<ShopScoreInfoDto> Order(List<ShopScoreInfoDto> listNeedOrder)
        {
            Dictionary<int, List<ShopScoreInfoDto>> dic = new Dictionary<int, List<ShopScoreInfoDto>>();
            for (int i = 0; i < listNeedOrder.Count; i++)
            {
                string[] spitSubjectCode = listNeedOrder[i].SubjectCode.ToString().Split('.');
                if (!dic.Keys.Contains(Convert.ToInt32(spitSubjectCode[0])))
                {
                    List<ShopScoreInfoDto> ListTemp = new List<ShopScoreInfoDto>();
                    ListTemp.Add(listNeedOrder[i]);
                    dic.Add(Convert.ToInt32(spitSubjectCode[0]), ListTemp);
                }
                else
                {
                    List<ShopScoreInfoDto> lisTemp = (dic[Convert.ToInt32(spitSubjectCode[0])]);
                    lisTemp.Add(listNeedOrder[i]);
                    dic[Convert.ToInt32(spitSubjectCode[0])] = lisTemp;
                }
            }
            List<KeyValuePair<int, List<ShopScoreInfoDto>>> list = dic.OrderBy(d => d.Key).ToList();
            List<ShopScoreInfoDto> listNew = new List<ShopScoreInfoDto>();
            List<ShopScoreInfoDto> listNew1 = new List<ShopScoreInfoDto>();
            List<ShopScoreInfoDto> listNew2 = new List<ShopScoreInfoDto>();
            foreach (KeyValuePair<int, List<ShopScoreInfoDto>> item in list)
            {
                foreach (ShopScoreInfoDto shop in item.Value as List<ShopScoreInfoDto>)
                {
                    listNew.Add(shop);
                }
            }
            for (int i = 0; i < dic.Count; i++)
            {
                dic.Remove(i);
            }
            Dictionary<int, List<ShopScoreInfoDto>> dica = new Dictionary<int, List<ShopScoreInfoDto>>();
            for (int i = 0; i < listNew.Count; i++)
            {
                string[] spitSubjectCode = listNew[i].SubjectCode.ToString().Split('.');
                if (!dica.Keys.Contains(Convert.ToInt32(spitSubjectCode[0])))
                {
                    List<ShopScoreInfoDto> ListTemp = new List<ShopScoreInfoDto>();
                    ListTemp.Add(listNew[i]);
                    dica.Add(Convert.ToInt32(spitSubjectCode[0]), ListTemp);
                }
                else
                {
                    List<ShopScoreInfoDto> lisTemp = (dica[Convert.ToInt32(spitSubjectCode[0])]);
                    lisTemp.Add(listNew[i]);
                    dica[Convert.ToInt32(spitSubjectCode[0])] = lisTemp;
                }
            }

            foreach (int key in dica.Keys)
            {
                Dictionary<int, List<ShopScoreInfoDto>> dic1 = new Dictionary<int, List<ShopScoreInfoDto>>();
                for (int i = 0; i < dica[key].Count; i++)
                {
                    string[] spitSubjectCode = dica[key][i].SubjectCode.ToString().Split('.');
                    if (!dic1.Keys.Contains(Convert.ToInt32(spitSubjectCode[1])))
                    {
                        List<ShopScoreInfoDto> ListTemp = new List<ShopScoreInfoDto>();
                        ListTemp.Add(dica[key][i]);
                        dic1.Add(Convert.ToInt32(spitSubjectCode[1]), ListTemp);
                    }
                    else
                    {
                        List<ShopScoreInfoDto> lisTemp = (dic1[Convert.ToInt32(spitSubjectCode[1])]);
                        lisTemp.Add(dica[key][i]);
                        dic1[Convert.ToInt32(spitSubjectCode[1])] = lisTemp;
                    }
                }
                List<KeyValuePair<int, List<ShopScoreInfoDto>>> list1 = dic1.OrderBy(d => d.Key).ToList();
                foreach (KeyValuePair<int, List<ShopScoreInfoDto>> item in list1)
                {
                    foreach (ShopScoreInfoDto shop in item.Value as List<ShopScoreInfoDto>)
                    {
                        listNew1.Add(shop);
                    }
                }
                for (int i = 0; i < dic1.Count; i++)
                {
                    dic1.Remove(i);
                }
                Dictionary<int, List<ShopScoreInfoDto>> dic1a = new Dictionary<int, List<ShopScoreInfoDto>>();
                for (int i = 0; i < listNew1.Count; i++)
                {
                    string[] spitSubjectCode = listNew1[i].SubjectCode.ToString().Split('.');
                    if (!dic1a.Keys.Contains(Convert.ToInt32(spitSubjectCode[1])))
                    {
                        List<ShopScoreInfoDto> ListTemp = new List<ShopScoreInfoDto>();
                        ListTemp.Add(listNew1[i]);
                        dic1a.Add(Convert.ToInt32(spitSubjectCode[1]), ListTemp);
                    }
                    else
                    {
                        List<ShopScoreInfoDto> lisTemp = (dic1a[Convert.ToInt32(spitSubjectCode[1])]);
                        lisTemp.Add(listNew1[i]);
                        dic1a[Convert.ToInt32(spitSubjectCode[1])] = lisTemp;
                    }
                }
                foreach (int key1 in dic1a.Keys)
                {
                    Dictionary<int, List<ShopScoreInfoDto>> dic2 = new Dictionary<int, List<ShopScoreInfoDto>>();
                    for (int i = 0; i < dic1a[key1].Count; i++)
                    {
                        string[] spitSubjectCode = dic1a[key1][i].SubjectCode.ToString().Split('.');
                        if (!dic2.Keys.Contains(Convert.ToInt32(spitSubjectCode[2])))
                        {
                            List<ShopScoreInfoDto> ListTemp = new List<ShopScoreInfoDto>();
                            ListTemp.Add(dic1a[key1][i]);
                            dic2.Add(Convert.ToInt32(spitSubjectCode[2]), ListTemp);
                        }
                        else
                        {
                            List<ShopScoreInfoDto> lisTemp = (dic2[Convert.ToInt32(spitSubjectCode[2])]);
                            lisTemp.Add(dic1a[key1][i]);
                            dic2[Convert.ToInt32(spitSubjectCode[2])] = lisTemp;
                        }
                    }
                    List<KeyValuePair<int, List<ShopScoreInfoDto>>> list2 = dic2.OrderBy(d => d.Key).ToList();
                    foreach (KeyValuePair<int, List<ShopScoreInfoDto>> item in list2)
                    {
                        foreach (ShopScoreInfoDto shop in item.Value as List<ShopScoreInfoDto>)
                        {
                            listNew2.Add(shop);
                        }
                    }
                }
            }
            return listNew1;
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

        private void grvShopScore_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void grvShopScore_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvShopScore.FocusedColumn.Name != "详细")
            {
                e.Cancel = true;
            }
        }


        private void grvShopScore_DoubleClick(object sender, EventArgs e)
        {
            if (grvShopScore.FocusedRowHandle < 0) return;
            if (grvShopScore.FocusedColumn == gcCheckPoint ||
                grvShopScore.FocusedColumn == gcSubjectCode)
            {
                if (CommonHandler.GetComboBoxSelectedValue(cboProject) == null)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择一个项目");
                    return;
                }

                if (string.IsNullOrEmpty(btnShopCode.Text))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "请选择一个经销商");
                    return;
                }
                int order = 0;
                char checkType = '0';
                string examType = "";
                string shopCode = btnShopCode.Text;
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcSubjectCode).ToString();
                DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                    examType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);

                }
                DataSet dsCheckType = webService.SearchPassReCheckBySubjectCodeAndShopCode(projectCode, subjectCode, shopCode);
                if (dsCheckType.Tables[0].Rows.Count > 0)
                {
                    //checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
                }
                AnswerSubjectForm a = new AnswerSubjectForm(projectCode,
                    subjectCode,
                    shopCode, txtShopName.Text, order, checkType, this.UserInfoDto, examType,"ShopScoreSearch");
                a.ShowDialog();
            }
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }
        public override void InitButtonClick()
        {
            base.InitButtonClick();
        }
        public override void SearchButtonClick()
        {
            Search();
        }
        public override void ExcelDownButtonClick()
        {
            if (grcShopScore.DataSource != null)
                CommonHandler.ExcelExport(grvShopScore);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (grvShopScore.FocusedRowHandle < 0) return;

            if (CommonHandler.GetComboBoxSelectedValue(cboProject) == null)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择一个项目");
                return;
            }

            if (string.IsNullOrEmpty(btnShopCode.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择一个经销商");
                return;
            }
            int order = 0;
            char checkType = '0';
            string examType = "";
            string subjectType = "";
            string title = "";
            string shopCode = btnShopCode.Text;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string subjectCode = grvShopScore.GetRowCellValue(grvShopScore.FocusedRowHandle, gcSubjectCode).ToString();
            DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
            DataSet ds1 = webService.SearchShopExamTypeByProjectCodeAndShopCode(projectCode, shopCode);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                examType = Convert.ToString(ds1.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                
                subjectType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCode"]);
            }
            if (subjectType == "SA")
            {
                title = "照片类";
            }
            else if (subjectType == "SB")
            {
                title = "资料类";
            }
            else if (subjectType == "SC")
            {
                title = "交叉类";
            }
            DataSet dsCheckType = webService.SearchPassReCheckBySubjectCodeAndShopCode(projectCode, subjectCode, shopCode);
            if (dsCheckType.Tables[0].Rows.Count > 0)
            {
                checkType = Convert.ToChar("A");
            }
            CommonHandler.LoadView(this, "AnswerRecheck", title, projectCode, subjectCode, shopCode, order, checkType, examType,txtShopName.Text);
        }
    }
}
