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
    public partial class LinkPop : Form
    {
        localhost.Service service = new localhost.Service();
        List<LinkDto> linkList = new List<LinkDto>();
        public string _chapterCode = "";
        public List<LinkDto> LinkList
        {
            get { return linkList; }
            set { linkList = value; }
        }
        XtraGridDataHandler<LinkDto> dataHandler = null;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public LinkPop(string projectCode, string chapterCode, string chapterName)
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            CommonHandler.SetComboBoxSelectedValue(cboProject, projectCode);
           // BindComBox.BindChapter(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), cboChapter);
           // CommonHandler.SetComboBoxSelectedValue(cboChapter, chapterCode);
            this._chapterCode = chapterCode;
            txtChapter.Text = chapterName;
            OnLoadView();
        }

        private void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<LinkDto>(grvLink);
            CommonHandler.SetRowNumberIndicator(grvLink);
            grcLink.DataSource = new List<ChapterDto>();
            selection = new GridCheckMarksSelection(grvLink);
            selection.CheckMarkColumn.VisibleIndex = 0;
            SearchLink();
        }

        private void SearchLink()
        {
            string[] chapterCodeSearch = _chapterCode.Split(',');
            List<LinkDto> sourcelinkList = new List<LinkDto>();
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            for (int i = 0; i < chapterCodeSearch.Length; i++)
            {
                string chapterCode = chapterCodeSearch[i].ToString();
                DataSet ds = service.SearchLink(projectCode, chapterCode);
                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        LinkDto link = new LinkDto();
                        link.CharterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                        link.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                        link.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                        link.LinkContent = Convert.ToString(ds.Tables[0].Rows[j]["LinkContent"]);
                        //inspection.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                        sourcelinkList.Add(link);
                    }
                }
            }

            grcLink.DataSource = sourcelinkList;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string chapterCode = CommonHandler.GetComboBoxSelectedValue(cboChapter).ToString();
            List<LinkDto> list = new List<LinkDto>();
            DataSet ds = service.SearchLink(projectCode, chapterCode);
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    LinkDto link = new LinkDto();
                    link.CharterName = Convert.ToString(ds.Tables[0].Rows[j]["CharterName"]);
                    link.LinkCode = Convert.ToString(ds.Tables[0].Rows[j]["LinkCode"]);
                    link.LinkName = Convert.ToString(ds.Tables[0].Rows[j]["LinkName"]);
                    link.LinkContent = Convert.ToString(ds.Tables[0].Rows[j]["LinkContent"]);
                    //inspection.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                    list.Add(link);
                }
            }
            grcLink.DataSource = list;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvLink.RowCount; i++)
            {
                if (grvLink.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    linkList.Add(grvLink.GetRow(i) as LinkDto);
                }
            }
            this.Close();
        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboProject) != null &&
                !string.IsNullOrEmpty(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString()))
            {
                BindComBox.BindChapter(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(),cboChapter);
            }
        }
    }
}
