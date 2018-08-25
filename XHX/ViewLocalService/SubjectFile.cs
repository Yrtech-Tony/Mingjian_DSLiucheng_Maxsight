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
    public partial class SubjectFile : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service webService = new localhost.Service();
        XtraGridDataHandler<FileAndPictureDto> dataHandler = null;
        string _RoleType = string.Empty;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public SubjectFile()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
        }
        public SubjectFile(string projectCode,string subjectCode,string roleType)
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            _RoleType = roleType;
            dataHandler = new XtraGridDataHandler<FileAndPictureDto>(grvShopFile);
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            CommonHandler.SetRowNumberIndicator(grvShopFile);
            grcShopFile.DataSource = new List<FileAndPictureDto>();
            selection = new GridCheckMarksSelection(grvShopFile);
            selection.CheckMarkColumn.VisibleIndex = 0;
            this.projectCode = projectCode;
            this.subjectCode = subjectCode;
            List<FileTypeDto> List = new List<FileTypeDto>();
            FileTypeDto filepic = new FileTypeDto();
            filepic.FileType = "01";
            filepic.FileTypeName = "图片";
            List.Add(filepic);
            FileTypeDto file = new FileTypeDto();
            file.FileType = "02";
            file.FileTypeName = "文件";
            List.Add(file);

            CommonHandler.BindComboBoxItems<FileTypeDto>(comFileType, List, "FileTypeName", "FileType");
            SearchSubjectFile(projectCode, subjectCode);
        }
        private void SearchSubjectFile(string projectCode, string subjectCode)
        {
            grcShopFile.DataSource = null;
            List<FileAndPictureDto> fileList = new List<FileAndPictureDto>();
            //string sql = string.Format("EXEC up_XHX_FileAndPicture_R '{0}','{1}'", projectCode, subjectCode);
            DataSet ds = webService.SearchSubjectFile(projectCode, subjectCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FileAndPictureDto file = new FileAndPictureDto();
                    file.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    file.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    file.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    file.FileName = Convert.ToString(ds.Tables[0].Rows[i]["FileName"]);
                    file.FileType = Convert.ToString(ds.Tables[0].Rows[i]["FileType"]);
                    fileList.Add(file);
                }
                grcShopFile.DataSource = fileList;
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
            FileAndPictureDto file = new FileAndPictureDto();
            List<FileAndPictureDto> fileList = grcShopFile.DataSource as List<FileAndPictureDto>;
            int seqNO = 0;
            if (fileList == null || fileList.Count == 0)
            {
                file.SeqNO = 1;
            }
            else
            {

                foreach (FileAndPictureDto inp in fileList)
                {
                    if (inp.SeqNO > seqNO)
                    {
                        seqNO = inp.SeqNO;
                    }
                }
            }
            file.SeqNO = seqNO + 1;
            file.ProjectCode = projectCode;
            file.SubjectCode = subjectCode;
            file.FileType = "01";
            dataHandler.AddRow(file);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dataHandler.DelCheckedRow(grvShopFile.Columns.ColumnByFieldName("CheckMarkSelection"));
            selection.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_RoleType == "C") return;
            foreach (FileAndPictureDto inspection in (grcShopFile.DataSource) as List<FileAndPictureDto>)
            {
                if (inspection.SeqNO == 0)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "标准代码不能为空或者为0");
                    grvShopFile.FocusedColumn = gcCode;
                    grvShopFile.FocusedRowHandle = (grcShopFile.DataSource as List<FileAndPictureDto>).IndexOf(inspection);
                    return;
                }
                foreach (FileAndPictureDto inspec in dataHandler.DataList)
                {
                    if (inspection != inspec)
                    {
                        if (inspec.SeqNO == inspection.SeqNO && inspec.StatusType != 'D')
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "标准代码号重复");
                            grvShopFile.FocusedColumn = gcCode;
                            grvShopFile.FocusedRowHandle = (grcShopFile.DataSource as List<FileAndPictureDto>).IndexOf(inspection);
                            return;
                        }
                    }
                }
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<FileAndPictureDto> insList = dataHandler.DataList;
                foreach (FileAndPictureDto ins in insList)
                {
                    //string sql = string.Empty;
                    //if (ins.StatusType == 'I' || ins.StatusType == 'U')
                    //{
                    //    sql = string.Format("EXEC up_XHX_FileAndPicture_S '{0}','{1}','{2}','{3}','{4}','{5}'"
                    //       , ins.ProjectCode, ins.SubjectCode, ins.SeqNO, ins.FileName,ins.FileType, "Sysadmin");
                    //}
                    //else if (ins.StatusType == 'D')
                    //{
                    //    sql = string.Format("EXEC  up_XHX_FileAndPicture_D '{0}','{1}','{2}'",
                    //        ins.ProjectCode, ins.SubjectCode, ins.SeqNO);
                    //}
                    webService.SaveFileAndPicture(ins.StatusType, ins.ProjectCode, ins.SubjectCode, ins.SeqNO, ins.FileName, ins.FileType);
                }
                CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
            }
            SearchSubjectFile(projectCode, subjectCode);
           
        } 
    }
}
