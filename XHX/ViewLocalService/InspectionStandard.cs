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

namespace XHX.ViewLocalService
{
    public partial class InspectionStandard : Form
    {
        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<InspectionStandardDto> dataHandler = null;
        string _RoleType = string.Empty;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public InspectionStandard()
        {
        }
        public InspectionStandard(string projectCode, string subjectCode,string roleType)
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            _RoleType = roleType;
            dataHandler = new XtraGridDataHandler<InspectionStandardDto>(grvInpectionStandard);
            CommonHandler.SetRowNumberIndicator(grvInpectionStandard);
            grcInspectionStandard.DataSource = new List<InspectionStandardDto>();
            selection = new GridCheckMarksSelection(grvInpectionStandard);
            selection.CheckMarkColumn.VisibleIndex = 0;
            this.projectCode = projectCode;
            this.subjectCode = subjectCode;
            SearchProject(projectCode, subjectCode);
        }
        private void SearchProject(string projectCode,string subjectCode)
        {
 
            grcInspectionStandard.DataSource = null;
            List<InspectionStandardDto> inspectionList = new List<InspectionStandardDto>();
            //string sql = string.Format("EXEC up_XHX_InspectionStandard_R '{0}','{1}'", projectCode, subjectCode);
            //DataSet ds = CommonHandler.query(sql);
            DataSet ds = service.SearchInspectionStandard(projectCode, subjectCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspection = new InspectionStandardDto();
                    inspection.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    inspection.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    inspection.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    inspection.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                    inspectionList.Add(inspection);
                }
                grcInspectionStandard.DataSource = inspectionList;
            }
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
            

            InspectionStandardDto inspection = new InspectionStandardDto();
            List<InspectionStandardDto> inspectionList = grcInspectionStandard.DataSource as List<InspectionStandardDto>;
              int seqNO = 0;
              if (inspectionList == null || inspectionList.Count == 0)
              {
                  inspection.SeqNO = 1;
              }
              else
              {

                  foreach (InspectionStandardDto inp in inspectionList)
                  {
                      if (inp.SeqNO > seqNO)
                      {
                          seqNO = inp.SeqNO;
                      }
                  }
              }
            inspection.SeqNO = seqNO + 1;
            inspection.ProjectCode = projectCode;
            inspection.SubjectCode = subjectCode;
            dataHandler.AddRow(inspection);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dataHandler.DelCheckedRow(grvInpectionStandard.Columns.ColumnByFieldName("CheckMarkSelection"));
            selection.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_RoleType == "C") return;
            foreach (InspectionStandardDto inspection in (grcInspectionStandard.DataSource) as List<InspectionStandardDto>)
            {
                if (inspection.SeqNO==0)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "标准代码不能为空或者为0");
                    grvInpectionStandard.FocusedColumn = gcCode;
                    grvInpectionStandard.FocusedRowHandle = (grcInspectionStandard.DataSource as List<InspectionStandardDto>).IndexOf(inspection);
                    return;
                }
                foreach (InspectionStandardDto inspec in dataHandler.DataList)
                {
                    if (inspection != inspec)
                    {
                        if (inspec.SeqNO == inspection.SeqNO && inspec.StatusType != 'D')
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "标准代码号重复");
                            grvInpectionStandard.FocusedColumn = gcCode;
                            grvInpectionStandard.FocusedRowHandle = (grcInspectionStandard.DataSource as List<InspectionStandardDto>).IndexOf(inspection);
                            return;
                        }
                    }
                }
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<InspectionStandardDto> insList = dataHandler.DataList;
                foreach (InspectionStandardDto ins in insList)
                {
                    //string sql = string.Empty;
                    //if (ins.StatusType == 'I' || ins.StatusType == 'U')
                    //{
                    //    sql = string.Format("EXEC up_XHX_InspectionStandard_S '{0}','{1}','{2}','{3}','{4}'"
                    //       , ins.ProjectCode, ins.SubjectCode, ins.SeqNO, ins.InspectionStandardName, "Sysadmin");
                    //}
                    //else if (ins.StatusType == 'D')
                    //{
                    //    sql = string.Format("EXEC  up_XHX_InspectionStandard_D '{0}','{1}','{2}'",
                    //        ins.ProjectCode, ins.SubjectCode, ins.SeqNO);
                    //}
                    //CommonHandler.query(sql);
                    service.SaveInspectionStandard(ins.ProjectCode, ins.SubjectCode, ins.SeqNO, ins.InspectionStandardName, "Sysadmin", ins.StatusType);
                }
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
            SearchProject(projectCode, subjectCode);
            
           // this.Close();
            
        }

        private void grvInpectionStandard_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcCode)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }
    }
}
