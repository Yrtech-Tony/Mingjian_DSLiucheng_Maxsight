/*
 * 公告管理页面
 * 2011-10-23 ChaiYunChun
 */
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
using System.IO;

namespace XHX.View
{
    public partial class NoticePop : Form
    {
        
        public string NoticeID = "";
        XtraGridDataHandler<NoticeAttachmentDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();
        GridCheckMarksSelection selection;

        public GridCheckMarksSelection Selection
        {
            get { return selection; }
            set { selection = value; }
        }



        public void OnLoadView()
        {
            dataHandler = new XtraGridDataHandler<NoticeAttachmentDto>(grvAttachment);
            grcAttachment.DataSource = new List<NoticeAttachmentDto>();
            selection = new GridCheckMarksSelection(grvAttachment);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        public void InitializeView()
        {
        }

        public NoticePop()
        {
            InitializeComponent();
            OnLoadView();
        }

        public NoticePop(string NoticeID):this()
        {
            
            if(!string.IsNullOrEmpty(NoticeID))
                this.SearchNotice(NoticeID);
        }

        private void SearchNotice(string noticeID)
        {
            DataSet ds1 = webService.GetNoticeByNoticeID(noticeID);
            List<NoticeDto> noteList = new List<NoticeDto>();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                NoticeDto dto = new NoticeDto();
                dto.NoticeID = ds1.Tables[0].Rows[0]["NoticeID"].ToString();
                dto.NoticeTitle = ds1.Tables[0].Rows[0]["NoticeTitle"].ToString();
                dto.NoticeContent = ds1.Tables[0].Rows[0]["NoticeContent"].ToString();
                this.NoticeID = dto.NoticeID;
                txtTitle.Text = dto.NoticeTitle;
                txtContent.Text = dto.NoticeContent;

            }
            DataSet ds2 = webService.GetAllNoticeAttachment(NoticeID);
            List<NoticeAttachmentDto> noticeAttachmentList = new List<NoticeAttachmentDto>();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    NoticeAttachmentDto dto = new NoticeAttachmentDto();
                    dto.AttachName = ds2.Tables[0].Rows[i]["AttachName"].ToString();
                    dto.SeqNO = Convert.ToInt32(ds2.Tables[0].Rows[i]["SeqNO"]);
                    if (!string.IsNullOrEmpty(dto.AttachName))
                        dto.FileExist = true;
                    else
                        dto.FileExist = false;
                    noticeAttachmentList.Add(dto);
                }
            }
            grcAttachment.DataSource = noticeAttachmentList;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "标题不能为空!");
                txtTitle.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "内容不能为空!");
                txtContent.Focus();
                return;
            }
            //保存公告信息并查询
            DataSet ds = webService.SaveNoticeAndSearch(NoticeID, txtTitle.Text, txtContent.Text, "SYSADMIN");

            if (ds.Tables[0].Rows.Count > 0)
            {
                NoticeDto dto = new NoticeDto();
                dto.NoticeID = ds.Tables[0].Rows[0]["NoticeID"].ToString();
                dto.NoticeTitle = ds.Tables[0].Rows[0]["NoticeTitle"].ToString();
                dto.NoticeContent = ds.Tables[0].Rows[0]["NoticeContent"].ToString();

                NoticeID = dto.NoticeID;
                txtTitle.Text = dto.NoticeTitle;
                txtContent.Text = dto.NoticeContent;
            }
            else
                return;

            List<NoticeAttachmentDto> noticeAttachMentList = dataHandler.DataList;

            foreach (NoticeAttachmentDto item in noticeAttachMentList)
            {
                if (item.StatusType == 'I')
                {
                    byte[] file = null;
                    if (File.Exists(item.FilePath))
                    {
                        FileStream fs = new FileStream(item.FilePath, FileMode.Open);
                        int streamLength = (int)fs.Length;
                        file = new byte[streamLength];
                        fs.Read(file, 0, streamLength);
                        fs.Close();
                    }
                    else
                    {
                        file = new byte[0];
                    }
                    webService.InsertNoticeAttachment(NoticeID, item.AttachName, file);
                }
                else if (item.StatusType == 'D')
                {
                    webService.DeleteNoticeAttachment(NoticeID,item.SeqNO.ToString(),item.AttachName);
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "保存成功!");
            this.SearchNotice(NoticeID);

        }
        //下载文件
        private void btnDownFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            NoticeAttachmentDto dto = grvAttachment.GetRow(grvAttachment.FocusedRowHandle) as NoticeAttachmentDto;
            if (dto.FileExist == false)
                return;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "All Files|*.*";
            saveDialog.FileName = dto.AttachName;
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                byte[] filebyte = webService.DownNoticeAttachment(NoticeID, dto.AttachName);
                if (filebyte != null)
                {
                    MemoryStream buf = new MemoryStream(filebyte);

                    FileStream fs = new FileStream(saveDialog.FileName, FileMode.OpenOrCreate);
                    buf.WriteTo(fs);
                    buf.Close();
                    fs.Close();
                    buf = null;
                    fs = null;
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            NoticeAttachmentDto dto = new NoticeAttachmentDto();
            dto.StatusType = 'I';
            dataHandler.AddRow(dto);
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);

            selection.ClearSelection();
        }

        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            string[] fileNames = null;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
                if (fileNames.Length > 0)
                {
                    //txtFile.Text = "";
                   // string filename_temp = "";
                    foreach (string fileName in fileNames)
                    {
                        //txtFile.Text += fileName + "; ";
                        FileInfo file = new FileInfo(fileName);
                        grvAttachment.SetRowCellValue(grvAttachment.FocusedRowHandle, gcAttachName, file.Name);
                        grvAttachment.SetRowCellValue(grvAttachment.FocusedRowHandle, gcSelectFile, file.FullName);

                    }

                    //if (filename_temp.EndsWith(";"))
                    //{
                    //    txtFile.Text = txtFile.Text.Remove(txtFile.Text.LastIndexOf("; "));
                    //    filename_temp = filename_temp.Remove(filename_temp.LastIndexOf(";"));
                    //    grvFileAndPic.SetRowCellValue(grvFileAndPic.FocusedRowHandle, gcBrower, filename_temp);
                    //}
                }

            }
        }

        private void grvAttachment_ShowingEditor(object sender, CancelEventArgs e)
        {
            NoticeAttachmentDto dto = grvAttachment.GetRow(grvAttachment.FocusedRowHandle) as NoticeAttachmentDto; 
            if (grvAttachment.FocusedColumn == gcAttachName 
                ||(grvAttachment.FocusedColumn == gcSelectFile && dto.FileExist == true))
               
                e.Cancel = true;
        }
    }
}
