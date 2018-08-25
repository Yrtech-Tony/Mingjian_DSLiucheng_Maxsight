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
    public partial class SujbectPop : Form
    {
        localhost.Service service = new localhost.Service();
        List<SubjectDto> subjectList = new List<SubjectDto>();
        public string _linkCode = "";
        public List<SubjectDto> SubjectList
        {
            get { return subjectList; }
            set { subjectList = value; }
        }
        XtraGridDataHandler<SubjectDto> dataHandler = null;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public SujbectPop(string projectCode,string linkCode,string linkName)
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            CommonHandler.SetComboBoxSelectedValue(cboProject, projectCode);
            //BindComBox.BindChapter(projectCode, cboChapter);
            this._linkCode = linkCode;
            txtLink.Text = linkName;
            OnLoadView();
        }

        private void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<SubjectDto>(grvSubject);
            CommonHandler.SetRowNumberIndicator(grvSubject);
            grcSubject.DataSource = new List<SubjectDto>();
            selection = new GridCheckMarksSelection(grvSubject);
            selection.CheckMarkColumn.VisibleIndex = 0;
            SearchSubject();
        }

        private void SearchSubject()
        {
            string[] linkCodeSearch = _linkCode.Split(',');
            List<SubjectDto> sourceSubjectList = new List<SubjectDto>();
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            for (int i = 0; i < linkCodeSearch.Length; i++)
            {
                string linkCode = linkCodeSearch[i].ToString();
                DataSet ds = service.SearchSubject(projectCode, "",linkCodeSearch[i],"");
                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        SubjectDto subject = new SubjectDto();
                        subject.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                        subject.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                        subject.SubjectCode = Convert.ToString(ds.Tables[0].Rows[j]["SubjectCode"]);
                        subject.CheckPoint = Convert.ToString(ds.Tables[0].Rows[j]["CheckPoint"]);
                        subject.ChapterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                        sourceSubjectList.Add(subject);
                    }
                }
            }
            grcSubject.DataSource = sourceSubjectList;
        }
         
        private void cboChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboChapter) != null
                )
            {
                BindComBox.BindLink(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(),
                    CommonHandler.GetComboBoxSelectedValue(cboChapter).ToString(), cboLink);
            }

        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboProject) != null &&
               !string.IsNullOrEmpty(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString()))
            {
                BindComBox.BindChapter(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), cboChapter);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvSubject.RowCount; i++)
            {
                if (grvSubject.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    subjectList.Add(grvSubject.GetRow(i) as SubjectDto);
                }
            }
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string linkCode = CommonHandler.GetComboBoxSelectedValue(cboLink).ToString();
            List<SubjectDto> sourceSubjectList = new List<SubjectDto>();

            DataSet ds = service.SearchSubject(projectCode, "", linkCode,"");
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    SubjectDto subject = new SubjectDto();
                    subject.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                    subject.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                    subject.SubjectCode = Convert.ToString(ds.Tables[0].Rows[j]["SubjectCode"]);
                    subject.CheckPoint = Convert.ToString(ds.Tables[0].Rows[j]["CheckPoint"]);
                    subject.ChapterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                    sourceSubjectList.Add(subject);
                }
            }

            grcSubject.DataSource = sourceSubjectList;
        }
    }
}
