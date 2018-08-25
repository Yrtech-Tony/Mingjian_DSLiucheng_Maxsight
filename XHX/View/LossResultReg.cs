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

namespace XHX.View
{
    public partial class LossResultReg : BaseForm
    {
        XtraGridDataHandler<LossResultDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();
        public LossResultReg()
        {
            InitializeComponent();
            OnLoadView();
        }

        private void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<LossResultDto>(grvLossReg);
            CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            
        }

        private void SearchLoss()
        {
            List<LossResultDto> LossList = new List<LossResultDto>();
            DataSet ds = webService.SearchLoss("", txtLossDesc.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LossResultDto loss = new LossResultDto();
                    loss.LossCode = Convert.ToString(ds.Tables[0].Rows[i]["LossCode"]);
                    loss.LossName = Convert.ToString(ds.Tables[0].Rows[i]["LossName"]);
                    loss.InUserID = Convert.ToString(ds.Tables[0].Rows[i]["InUserID"]);
                    loss.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);

                    LossList.Add(loss);
                }
            }

            grcLossReg.DataSource = LossList;
        }



        private void grvLossReg_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (grcLossReg.DataSource == null || grvLossReg.RowCount == 0) return;
            LossResultDto loss = grvLossReg.GetRow(e.RowHandle) as LossResultDto;
            if (e.Column != gcLossName)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }

        private void grvLossReg_ShowingEditor(object sender, CancelEventArgs e)
        {
            LossResultDto shop = grvLossReg.GetRow(grvLossReg.FocusedRowHandle) as LossResultDto;
            if (grvLossReg.FocusedColumn !=gcLossName)
            {
                //if (shop.StatusType != 'I')
                //{
                    e.Cancel = true;

                //}
                //else
                //{
                //    e.Cancel = false;
                //}
            }
        }
        public override void SearchButtonClick()
        {
            SearchLoss();
            CSParentForm.EnabelButton(ButtonType.SaveButton, true);
            CSParentForm.EnabelButton(ButtonType.AddRowButton, true);
        }
        public override void AddRowButtonClick()
        {
            LossResultDto loss = new LossResultDto();
            List<LossResultDto> lossList = grcLossReg.DataSource as List<LossResultDto>;
            int seqNO = 0;
            if (lossList == null || lossList.Count == 0)
            {
                loss.LossCode = Convert.ToString(1);
            }
            else
            {

                foreach (LossResultDto inp in lossList)
                {
                    if (Convert.ToInt32(inp.LossCode) > seqNO)
                    {
                        seqNO = Convert.ToInt32(inp.LossCode);
                    }
                }
            }
            loss.LossCode = (seqNO + 1).ToString();
            loss.InDateTime = DateTime.Now;
            loss.InUserID = "sysadmin";
            dataHandler.AddRow(loss);
        }
        public override void SaveButtonClick()
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<LossResultDto> lossList = dataHandler.DataList;
                foreach (LossResultDto loss in lossList)
                {
                    if (loss.StatusType == 'I' || loss.StatusType == 'U')
                    {
                        webService.SaveLoss(loss.LossCode, loss.LossName, loss.InUserID);
                    }
                }
            }
            SearchLoss();
            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.AddRowButton);
            list.Add(ButtonType.SaveButton);
            
            return list;
        }
    }
}
