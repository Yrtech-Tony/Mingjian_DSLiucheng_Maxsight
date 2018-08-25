using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;

namespace XHX.ViewLocalService
{
    public partial class ReCheckProcess : BaseForm
    {
        #region Field
        localhost.Service service = new localhost.Service();
        #endregion
        #region Construtor
        public ReCheckProcess()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            InitView();
            InitData();
        }
        #endregion
        #region Private Method
        private void InitData()
        {
            XHX.Common.BindComBox.BindProject(cboProjects);
            grcRecheckProcess.DataSource = null;
            grcRecheckProcess.DataSource = new List<AnswerStatusTypeCodeDto>();
            CommonHandler.SetRowNumberIndicator(grvRecheckProcess);
            CommonHandler.SetRowNumberIndicator(grvRecheckProcessDtl);
        }
        private void InitView()
        {
            btnShopCode.Text = "";
            txtShopName.Text = "";
        }
        private void SearchAnswerLog()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            string shopCode = btnShopCode.Text;
            List<AnswerStatusTypeCodeDto> list = new List<AnswerStatusTypeCodeDto>();
            DataSet ds = service.SearchReCheckProcess(projectCode, shopCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    AnswerStatusTypeCodeDto answer = new AnswerStatusTypeCodeDto();
                    answer.ShopCode = Convert.ToString(ds.Tables[0].Rows[j]["ShopCode"]);
                    answer.ShopName = Convert.ToString(ds.Tables[0].Rows[j]["ShopName"]);
                    answer.StatusCode = Convert.ToString(ds.Tables[0].Rows[j]["StatusCode"]);
                    //answer.StatusName = Convert.ToString(ds.Tables[0].Rows[j]["CNDesc"]);
                    if (answer.StatusCode == "S0")
                    {
                        answer.RecheckRegister = "■";
                    }
                    else if (answer.StatusCode == "S1")
                    {
                        answer.ModifyFinish = "■";
                    }
                    else if (answer.StatusCode == "S2")
                    {
                        answer.ReCheckFinish = "■";
                    }
                    else
                    {
                        answer.RecheckProcess = "■" + answer.StatusCode;
                    }
                    
                    
                    list.Add(answer);
                }


            }
            else
            {
                list = new List<AnswerStatusTypeCodeDto>();
            }
            grcRecheckProcess.DataSource = list;
            SearchDtl(projectCode, shopCode);
        }
        private void SearchDtl(string projectCode,string shopCode)
        {
            List<RecheckProcessDtlDto> list = new List<RecheckProcessDtlDto>();
            DataSet ds = service.SearchReCheckProcessdtl(projectCode, shopCode);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RecheckProcessDtlDto dtl = new RecheckProcessDtlDto();
                    dtl.ProjectCode = projectCode;
                    dtl.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                    dtl.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                    dtl.StepStartUserName = ds.Tables[0].Rows[i]["StepStartUserName"].ToString();
                    dtl.StepApplyStartUserName = ds.Tables[0].Rows[i]["StepApplyStartUserName"].ToString();
                    dtl.StepPhotoUserName = ds.Tables[0].Rows[i]["StepPhotoUserName"].ToString();
                    dtl.StepFileUserName = ds.Tables[0].Rows[i]["StepFileUserName"].ToString();
                    dtl.StepCrossUserName = ds.Tables[0].Rows[i]["StepCrossUserName"].ToString();
                    dtl.StepRecheck1UserName = ds.Tables[0].Rows[i]["StepRecheck1UserName"].ToString();
                    dtl.StepRecheck1ModifyUserName = ds.Tables[0].Rows[i]["StepRecheck1ModifyUserName"].ToString();
                    if (ds.Tables[0].Rows[i]["StepStartDate"] != DBNull.Value)
                    {
                        dtl.StepStartDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepStartDate"]);
                    }
                    else
                    {
                        dtl.StepStartDate = null;
                    }
                    if (ds.Tables[0].Rows[i]["StepApplyStartDate"] != DBNull.Value)
                    {
                        dtl.StepApplyStartDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepApplyStartDate"]);
                    }
                    else
                    {
                        dtl.StepApplyStartDate = null;
                    }
                    if (ds.Tables[0].Rows[i]["StepPhotoDate"] != DBNull.Value)
                    {
                        dtl.StepPhotoDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepPhotoDate"]);
                    }
                    else
                    {
                        dtl.StepPhotoDate = null;
                    }
                    if (ds.Tables[0].Rows[i]["StepFileDate"] != DBNull.Value)
                    {
                        dtl.StepFileDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepFileDate"]);
                    }
                    else
                    {
                        dtl.StepFileDate = null;
                    }
                    if (ds.Tables[0].Rows[i]["StepCrossDate"] != DBNull.Value)
                    {
                        dtl.StepCrossDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepCrossDate"]);
                    }
                    else
                    {
                        dtl.StepCrossDate = null;
                    }
                    if (ds.Tables[0].Rows[i]["StepRecheck1Date"] != DBNull.Value)
                    {
                        dtl.StepRecheck1Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepRecheck1Date"]);
                    }
                    else
                    {
                        dtl.StepRecheck1Date = null;

                    }
                    if (ds.Tables[0].Rows[i]["StepRecheck1ModifyDate"] != DBNull.Value)
                    {

                        dtl.StepRecheck1ModifyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["StepRecheck1ModifyDate"]);
                    }
                    else
                    {
                        dtl.StepRecheck1ModifyDate = null;
                    }
                    list.Add(dtl);
                }
                grcRecheckProcessDtl.DataSource = list;
            }
        }
        #endregion
        #region Event
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
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAnswerLog();
        }

        private void grvRecheckProcess_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (grvRecheckProcess.FocusedColumn != e.Column&&grvRecheckProcess.FocusedRowHandle==e.RowHandle)
            {
                e.Appearance.ForeColor = Color.White;
            }
            else
            {
                e.Appearance.ForeColor = Color.Black;
            }
        }
        public override void SearchButtonClick()
        {
            SearchAnswerLog();
        }
        public override void InitButtonClick()
        {
            InitView();
            InitData();
        }
        public override void ExcelDownButtonClick()
        {
            if (grcRecheckProcess.DataSource != null)
                CommonHandler.ExcelExport(grvRecheckProcess);
            if (grcRecheckProcessDtl.DataSource != null)
                CommonHandler.ExcelExport(grvRecheckProcessDtl);
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }

        private void grcRecheckProcess_DoubleClick(object sender, EventArgs e)
        {
            AnswerStatusTypeCodeDto type = grvRecheckProcess.GetFocusedRow() as AnswerStatusTypeCodeDto;
            SearchDtl(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), type.ShopCode);
        }
    }
}
