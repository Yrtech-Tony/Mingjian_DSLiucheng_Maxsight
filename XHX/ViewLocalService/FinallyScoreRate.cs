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

namespace XHX.ViewLocalService
{
    public partial class FinallyScoreRate : BaseForm
    {
        localhost.Service webService = new localhost.Service();
        public FinallyScoreRate()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
             UserInfoDto u = (new MainForm()).UserInfoDto;
             
            BindComBox.BindProject(cboProject);

            webService.SearchFinallyScoreRateCompleted += new XHX.localhost.SearchFinallyScoreRateCompletedEventHandler(webService_SearchFinallyScoreRateCompleted);
        }

        void webService_SearchFinallyScoreRateCompleted(object sender, XHX.localhost.SearchFinallyScoreRateCompletedEventArgs e)
        {
            try
            {
                #region FinallyWeight

                DataSet[][] allResult = e.Result;

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

                #endregion

                #region Data

                List<FinallyScoreRateBodyDto> dataList = new List<FinallyScoreRateBodyDto>();
                if (bodyDataDataSet.Tables.Count > 0 && bodyDataDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < bodyDataDataSet.Tables[0].Rows.Count; i++)
                    {
                        FinallyScoreRateBodyDto info = new FinallyScoreRateBodyDto();
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

                List<FinallyScoreRateDto> leftList = new List<FinallyScoreRateDto>();
                if (leftDataSet.Tables.Count > 0 && leftDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < leftDataSet.Tables[0].Rows.Count; i++)
                    {
                        FinallyScoreRateDto info = new FinallyScoreRateDto();
                        info.ChapterCode = Convert.ToString(leftDataSet.Tables[0].Rows[i]["CharterCode"]);
                        info.ChapterName = Convert.ToString(leftDataSet.Tables[0].Rows[i]["CharterName"]);
                        //info.Weight = Convert.ToDecimal(leftDataSet.Tables[0].Rows[i]["Weight"]);
                        leftList.Add(info);
                    }
                }

                #endregion

                DynamicColumnDataSet<TwoLevelColumnInfo, FinallyScoreRateBodyDto, FinallyScoreRateDto> list = new DynamicColumnDataSet<TwoLevelColumnInfo, FinallyScoreRateBodyDto, FinallyScoreRateDto>(columnInfoList, dataList, leftList);
                if (list != null && list.ColumnInfoList != null)
                {
                    list.DtoList = DynamicColumnUtil.CombineDynamicColumnDto<TwoLevelColumnInfo, FinallyScoreRateBodyDto, FinallyScoreRateDto>(list.ColumnInfoList, list.DataList, list.DtoList);
                }

                //BindGrid
                CommonHandler.BuildDynamicColumn<TwoLevelColumnInfo, FinallyScoreRateDto>(grvFinallyScoreRateForWeight, list.ColumnInfoList, list.DtoList);
                //InitGridControl(grcShopScore);
                //grvShopScore.SetAllColumnEditable(false);
                // grcAuditionPass.SetColumnEditableByColumn(true, gcAuditioinHis, gcResume, gcPassTypeCode, gcPassRemark, gcWorkYear);
                grvFinallyScoreRateForWeight.LeftCoord = 0;

	            #endregion

                #region FinallyWeightRANK

                result = allResult[1];
                List<FinallyScoreRateRankDto> finallyScoreRateRankDtoList = new List<FinallyScoreRateRankDto>();
                if (result[0].Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < result[0].Tables[0].Rows.Count; i++)
                    {
                        FinallyScoreRateRankDto finallyScoreRateRankDto = new FinallyScoreRateRankDto();
                        finallyScoreRateRankDto.ProjectCode = Convert.ToString(result[0].Tables[0].Rows[i]["ProjectCode"]);
                        finallyScoreRateRankDto.ShopName = Convert.ToString(result[0].Tables[0].Rows[i]["ShopName"]);
                        finallyScoreRateRankDto.Rate = Convert.ToDecimal(result[0].Tables[0].Rows[i]["Rate"] == null ? 0 : result[0].Tables[0].Rows[i]["Rate"]);
                        finallyScoreRateRankDto.RANK = Convert.ToInt32(result[0].Tables[0].Rows[i]["RANK"] == DBNull.Value ? 0 : result[0].Tables[0].Rows[i]["RANK"]);
                        finallyScoreRateRankDtoList.Add(finallyScoreRateRankDto);
                    }
                }

                grcFinallyScoreRateForOrder.DataSource = finallyScoreRateRankDtoList;

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

        private void grvFinallyScoreRateForWeight_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;

        }

        private void grvFinallyScoreRateForOrder_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.Gray;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CommonHandler.ExcelExport(grvFinallyScoreRateForOrder);
            
        }
        public override void SearchButtonClick()
        {
            try
            {
                string projectCode = string.Empty;
                projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                this.Enabled = false;
                webService.SearchFinallyScoreRateAsync(projectCode);
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, ex.Message); this.Enabled = true; return;
            }
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvFinallyScoreRateForWeight);
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
