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

namespace XHX.ViewLocalService
{
    public partial class ChapterPop : Form
    {
        localhost.Service service = new localhost.Service();
        List<ChapterDto> chapterList = new List<ChapterDto>();

        public List<ChapterDto> ChapterList
        {
            get { return chapterList; }
            set { chapterList = value; }
        }
        XtraGridDataHandler<ChapterDto> dataHandler = null;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public ChapterPop(string projectCode)
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            BindComBox.BindProject(cboProject);
            CommonHandler.SetComboBoxSelectedValue(cboProject, projectCode);
            OnLoadView();
        }
        public void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<ChapterDto>(grvChapter);
            CommonHandler.SetRowNumberIndicator(grvChapter);
            grcChapter.DataSource = new List<ChapterDto>();
            selection = new GridCheckMarksSelection(grvChapter);
            selection.CheckMarkColumn.VisibleIndex = 0;
            SearchChapter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchChapter();
        }
        private void SearchChapter()
        {
            List<ChapterDto> sourcechapterList = new List<ChapterDto>();
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
           DataSet ds =  service.SearchChapter(projectCode, "");
           if (ds.Tables.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ChapterDto chapter = new ChapterDto();
                   chapter.CharterName = Convert.ToString(ds.Tables[0].Rows[i]["CharterName"]);
                   chapter.CharterCode = Convert.ToString(ds.Tables[0].Rows[i]["CharterCode"]);
                   chapter.CharterContent = Convert.ToString(ds.Tables[0].Rows[i]["CharterContent"]);
                   //inspection.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                   sourcechapterList.Add(chapter);
               }
               grcChapter.DataSource = sourcechapterList;
           }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           // List<ChapterDto> chapterList = new List<ChapterDto>(); ;
            for (int i = 0; i < grvChapter.RowCount; i++)
            {
                if (grvChapter.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    chapterList.Add(grvChapter.GetRow(i) as ChapterDto);
                }
            }
            this.Close();
        }

        private void grvChapter_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvChapter.FocusedColumn == gcChapterCode || grvChapter.FocusedColumn == gcChapterName)
            {
                e.Cancel = true;
            }
        }

        private void grvChapter_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gcChapterName || e.Column == gcChapterCode)
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }

        private void ChapterPop_FormClosing(object sender, FormClosingEventArgs e)
        {
            //chapterList = null;
            GC.Collect();
        }
    }
}
