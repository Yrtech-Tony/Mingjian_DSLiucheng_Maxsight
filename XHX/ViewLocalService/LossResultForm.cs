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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace XHX.ViewLocalService
{
    public partial class LossResultForm : Form
    {
        localhost.Service webService = new localhost.Service();
        XtraGridDataHandler<LossResultDto> dataHandler1 = null;
        XtraGridDataHandler<LossResultDto> dataHandler2 = null;
        XtraGridDataHandler<LossResultDto> dataHandler3= null;
        string _RoleType = string.Empty;
        GridCheckMarksSelection selection1;
        internal GridCheckMarksSelection Selection1
        {
            get
            {
                return selection1;
            }
        }
        GridCheckMarksSelection selection2;
        internal GridCheckMarksSelection Selection2
        {
            get
            {
                return selection2;
            }
        }
        GridCheckMarksSelection selection3;
        internal GridCheckMarksSelection Selection3
        {
            get
            {
                return selection3;
            }
        }
        public LossResultForm()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
        }
        public LossResultForm(string projectCode, string subjectCode,string roleType)
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            _RoleType = roleType;
            dataHandler1 = new XtraGridDataHandler<LossResultDto>(grvLossResult1);
            dataHandler2 = new XtraGridDataHandler<LossResultDto>(grvLossResult2);
            dataHandler3 = new XtraGridDataHandler<LossResultDto>(grvLossResult3);

            CommonHandler.SetRowNumberIndicator(grvLossResult1);
            grcLossResult1.DataSource = new List<LossResultDto>();
            selection1 = new GridCheckMarksSelection(grvLossResult1);
            selection1.CheckMarkColumn.VisibleIndex = 0;

            grcLossResult2.DataSource = new List<LossResultDto>();
            selection2 = new GridCheckMarksSelection(grvLossResult2);
            selection2.CheckMarkColumn.VisibleIndex = 0;

            grcLossResult3.DataSource = new List<LossResultDto>();
            selection3 = new GridCheckMarksSelection(grvLossResult3);
            selection3.CheckMarkColumn.VisibleIndex = 0;
            this.projectCode = projectCode;
            this.subjectCode = subjectCode;
            SearchLoss(projectCode, subjectCode);
        }

        private void SearchLoss(string projectCode, string subjectCode)
        {
            List<LossResultDto> LossList1 = new List<LossResultDto>();
            List<LossResultDto> LossList2= new List<LossResultDto>();
            List<LossResultDto> LossList3 = new List<LossResultDto>();
            DataSet ds = webService.SearchLoss(projectCode, subjectCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LossResultDto loss = new LossResultDto();
                    loss.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    loss.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    loss.LossCode = Convert.ToString(ds.Tables[0].Rows[i]["LossCode"]);
                    loss.LossName= Convert.ToString(ds.Tables[0].Rows[i]["LossName"]);
                    loss.InUserID = Convert.ToString(ds.Tables[0].Rows[i]["InUserID"]);
                    loss.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);
                    loss.LossType = Convert.ToString(ds.Tables[0].Rows[i]["LossType"]);
                    if (loss.LossType == "01")
                    {
                        LossList1.Add(loss);
                    }
                    else if (loss.LossType == "02")
                    {
                        LossList2.Add(loss);
                    }
                    else
                    {
                        LossList3.Add(loss);
                    }
                }
                
            }

            grcLossResult1.DataSource = LossList1;
            grcLossResult2.DataSource = LossList2;
            grcLossResult3.DataSource = LossList3;
        }
        private string projectCode;

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }
        private string subjectCode;

        public string SubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPage1)
            {
                LossResultDto inspection = new LossResultDto();
                //List<LossResultDto> inspectionList = grcLossResult1.DataSource as List<LossResultDto>;
                //int seqNO = 0;
                //if (inspectionList == null || inspectionList.Count == 0)
                //{
                //    inspection.LossCode = Convert.ToString(1);
                //}
                //else
                //{

                //    foreach (LossResultDto inp in inspectionList)
                //    {
                //        if (Convert.ToInt32(inp.LossCode) > seqNO)
                //        {
                //            seqNO = Convert.ToInt32(inp.LossCode);
                //        }
                //    }
                //}
                //inspection.LossCode = Convert.ToString(seqNO + 1);
                inspection.ProjectCode = projectCode;
                inspection.SubjectCode = subjectCode;
                dataHandler1.AddRow(inspection);
            }
            else if (tabControl.SelectedTab == tabPage2)
            {
                LossResultDto inspection = new LossResultDto();
                ////List<LossResultDto> inspectionList = grcLossResult2.DataSource as List<LossResultDto>;
                ////int seqNO = 0;
                ////if (inspectionList == null || inspectionList.Count == 0)
                ////{
                ////    inspection.LossCode = Convert.ToString(1);
                ////}
                ////else
                ////{

                ////    foreach (LossResultDto inp in inspectionList)
                ////    {
                ////        if (Convert.ToInt32(inp.LossCode) > seqNO)
                ////        {
                ////            seqNO = Convert.ToInt32(inp.LossCode);
                ////        }
                ////    }
                ////}
                ////inspection.LossCode = Convert.ToString(seqNO + 1);
                inspection.ProjectCode = projectCode;
                inspection.SubjectCode = subjectCode;
                dataHandler2.AddRow(inspection);
            }
            else {
                LossResultDto inspection = new LossResultDto();
                //List<LossResultDto> inspectionList = grcLossResult3.DataSource as List<LossResultDto>;
                //int seqNO = 0;
                //if (inspectionList == null || inspectionList.Count == 0)
                //{
                //    inspection.LossCode = Convert.ToString(1);
                //}
                //else
                //{

                //    foreach (LossResultDto inp in inspectionList)
                //    {
                //        if (Convert.ToInt32(inp.LossCode) > seqNO)
                //        {
                //            seqNO = Convert.ToInt32(inp.LossCode);
                //        }
                //    }
                //}
                //inspection.LossCode = Convert.ToString(seqNO + 1);
                inspection.ProjectCode = projectCode;
                inspection.SubjectCode = subjectCode;
                dataHandler3.AddRow(inspection);
            
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPage1)
            {
                dataHandler1.DelCheckedRow(grvLossResult1.Columns.ColumnByFieldName("CheckMarkSelection"));
                selection1.ClearSelection();
            }
            else if (tabControl.SelectedTab == tabPage2)
            {
                dataHandler2.DelCheckedRow(grvLossResult2.Columns.ColumnByFieldName("CheckMarkSelection"));
                selection2.ClearSelection();
            }
            else {
                dataHandler3.DelCheckedRow(grvLossResult3.Columns.ColumnByFieldName("CheckMarkSelection"));
                selection3.ClearSelection();
            }
        }
        private void SaveLoss(List<LossResultDto> lossList, string lossType)
        {
            foreach (LossResultDto loss in lossList)
            {
                webService.SaveLossForm(loss.ProjectCode, loss.SubjectCode, loss.LossCode, loss.LossName, loss.InUserID, loss.StatusType,lossType);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_RoleType=="C")return;
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<LossResultDto> lossList = null;
                string lossType = string.Empty;
                if (tabControl.SelectedTab == tabPage1)
                {
                    lossList = dataHandler1.DataList;
                    lossType = "01";
                }
                else if (tabControl.SelectedTab == tabPage2)
                {
                    lossList = dataHandler2.DataList;
                    lossType = "02";
                }
                else 
                {
                    lossList = dataHandler3.DataList;
                    lossType = "03";
                }
                SaveLoss(lossList, lossType);

            }
            SearchLoss(projectCode,subjectCode);
            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }

        private void grvLossResult_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcCode)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }

        private void grvLossResult2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn7)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }

        private void grvLossResult3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn11)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }
    }
}
