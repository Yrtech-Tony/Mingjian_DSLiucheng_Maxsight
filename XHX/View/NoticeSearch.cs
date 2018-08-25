/*
 * 公告查询，删除
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

namespace XHX.View
{
    public partial class NoticeSearch : BaseForm
    {
        XtraGridDataHandler<NoticeDto> dataHandler = null;
        GridCheckMarksSelection selection;
        localhost.Service webService = new localhost.Service();

        public NoticeSearch()
        {
            InitializeComponent();
            OnLoadView();
        }
        public void OnLoadView()
        {
            //初始化Grid样式
            CommonHandler.SetRowNumberIndicator(grvNotice);

            dataHandler = new XtraGridDataHandler<NoticeDto>(grvNotice);
            grcNotice.DataSource = new List<NoticeDto>();
            selection = new GridCheckMarksSelection(grvNotice);
            selection.CheckMarkColumn.VisibleIndex = 0;

            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天
        }


        private void btnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            NoticeDto dto = grvNotice.GetRow(grvNotice.FocusedRowHandle) as NoticeDto;
            NoticePop note = new NoticePop(dto.NoticeID);
            note.ShowDialog();

        }

        private void grvNotice_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvNotice.FocusedColumn == gcFileExist
                || grvNotice.FocusedColumn == gcInDateTime
                || grvNotice.FocusedColumn == gcNoticeTitle
                )
            {
                e.Cancel = true;
            }
        }
        public override void SearchButtonClick()
        {
            DataSet ds = webService.GetAllNotice(dateStart.DateTime, dateEnd.DateTime);
            List<NoticeDto> noticeList = new List<NoticeDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    NoticeDto dto = new NoticeDto();
                    dto.NoticeID = ds.Tables[0].Rows[i]["NoticeID"].ToString();
                    dto.NoticeTitle = ds.Tables[0].Rows[i]["NoticeTitle"].ToString();
                    dto.NoticeContent = ds.Tables[0].Rows[i]["NoticeContent"].ToString();
                    dto.FileExist = ds.Tables[0].Rows[i]["FileExist"].ToString();
                    dto.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);
                    noticeList.Add(dto);
                }
            }
            grcNotice.DataSource = noticeList;
        }
        public override void AddButtonClick()
        {
            NoticePop note = new NoticePop();
            note.ShowDialog();
        }
        public override void DeleteButtonClick()
        {
            DialogResult reslut = CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除选中的行吗？");
            if (reslut != DialogResult.Yes)
                return;
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);
            selection.ClearSelection();

            foreach (NoticeDto item in dataHandler.DataList)
            {
                if (item.StatusType == 'D')
                {
                    webService.DeleteNotice(item.NoticeID);
                }
            }
            this.SearchButtonClick();
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.SearchButton);

            list.Add(ButtonType.AddButton);
            list.Add(ButtonType.DeleteButton);
            return list;
        }
        
    }
}
