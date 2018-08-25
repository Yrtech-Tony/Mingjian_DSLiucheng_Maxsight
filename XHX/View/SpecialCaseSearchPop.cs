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
    public partial class SpecialCaseSearchPop : Form
    {

        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<SpecialCaseDto> dataHandler = null;
        UserInfoDto _userInfo;
        GridCheckMarksSelection selection;

        public SpecialCaseSearchPop()
        {
            InitializeComponent();
            OnLoadView();
        }
        public SpecialCaseSearchPop(string projectCode, string shopCode, string shopName, string subjectCode, UserInfoDto userinfo)
            : this()
        {
            _userInfo = userinfo;
            if (!string.IsNullOrEmpty(projectCode))
            {
                CommonHandler.SetComboBoxSelectedValue(cboProjects, projectCode);
            }

            btnShopCode.Text = shopCode;
            txtShopName.Text = shopName;
            txtSubjectCode.Text = subjectCode;
            this.SearchButtonClick();
        }
        public void OnLoadView()
        {
            CommonHandler.SetRowNumberIndicator(grvSpecialCase);

            grcSpecialCase.DataSource = new List<SpecialCaseDto>();
            dataHandler = new XtraGridDataHandler<SpecialCaseDto>(grvSpecialCase);
            XHX.Common.BindComBox.BindProjectWithAll(cboProjects);
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天
            selection = new GridCheckMarksSelection(grvSpecialCase);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

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


   

        private void grvSpecialCase_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvSpecialCase.FocusedColumn == gcApplyDate
                || grvSpecialCase.FocusedColumn == gcApplyId
                || grvSpecialCase.FocusedColumn == gcConfirmDate
                || grvSpecialCase.FocusedColumn == gcConfirmId
                || grvSpecialCase.FocusedColumn == gcProjectCode
                || grvSpecialCase.FocusedColumn == gcShopCode
                || grvSpecialCase.FocusedColumn == gcShopName
                || grvSpecialCase.FocusedColumn == gcSubjectCode
                || grvSpecialCase.FocusedColumn == gcTitle
                || grvSpecialCase.FocusedColumn == gcFinalStatus
                || grvSpecialCase.FocusedColumn == gcCheckPoint
                || grvSpecialCase.FocusedColumn == gcApplyDesc
                || grvSpecialCase.FocusedColumn == gcFinalAdvice
                || grvSpecialCase.FocusedColumn == gcNeedVICoConfirmChk
                || grvSpecialCase.FocusedColumn == gcVICoAdvice)
                e.Cancel = true;
        }

        private void btnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SpecialCaseDto dto = grvSpecialCase.GetRow(grvSpecialCase.FocusedRowHandle) as SpecialCaseDto;
            SpecialCasePop pop = new SpecialCasePop(dto.SpecialCaseCode, _userInfo);
            pop.ShowDialog();
        }
        //public override List<ButtonType> CreateButton()
        //{
        //    List<ButtonType> list = new List<ButtonType>();
        //    list.Add(ButtonType.InitButton);
        //    list.Add(ButtonType.SearchButton);
        //    list.Add(ButtonType.DeleteButton);
        //    return list;
        //}
        public  void DeleteButtonClick()
        {
            DialogResult reslut = CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除选中的行吗？");
            if (reslut != DialogResult.Yes)
                return;
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);
            selection.ClearSelection();

            foreach (SpecialCaseDto item in dataHandler.DataList)
            {
                if (item.StatusType == 'D')
                {
                    service.DeleteSpecialCase(item.SpecialCaseCode);
                }
            }
            this.SearchButtonClick();
        }
        public  void InitButtonClick()
        {
            cboProjects.SelectedIndex = 0;
            btnShopCode.Text = "";
            txtShopName.Text = "";
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天
            grcSpecialCase.DataSource = null;
        }
        public  void SearchButtonClick()
        {
            DataSet ds = service.GetAllSpecialCase(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text, txtSubjectCode.Text, dateStart.DateTime, dateEnd.DateTime);
            List<SpecialCaseDto> specialCaselist = new List<SpecialCaseDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SpecialCaseDto dto = new SpecialCaseDto();
                    dto.ProjectCode = ds.Tables[0].Rows[i]["ProjectCode"].ToString();
                    dto.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                    dto.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                    dto.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                    dto.ApplyDate = Convert.ToString(ds.Tables[0].Rows[i]["ApplyDate"]);
                    dto.ConfirmDate = Convert.ToString(ds.Tables[0].Rows[i]["ConfirmDate"]);
                    dto.FinalStatus = ds.Tables[0].Rows[i]["FinalStatus"].ToString();
                    dto.ApplyId = ds.Tables[0].Rows[i]["ApplyId"].ToString();
                    dto.ConfirmId = ds.Tables[0].Rows[i]["ConfirmId"].ToString();
                    dto.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    dto.CheckPoint = ds.Tables[0].Rows[i]["CheckPoint"].ToString();
                    dto.ApplyDesc = ds.Tables[0].Rows[i]["ApplyDesc"].ToString();
                    dto.FinalAdvice = ds.Tables[0].Rows[i]["FinalAdvice"].ToString();
                    dto.NeedVICoConfirmChk = Convert.ToBoolean(ds.Tables[0].Rows[i]["NeedVICoConfirmChk"]);
                    dto.VICoAdvice = ds.Tables[0].Rows[i]["VICoAdvice"].ToString();
                    dto.SpecialCaseCode = ds.Tables[0].Rows[i]["SpecialCaseCode"].ToString();
                    specialCaselist.Add(dto);
                }
            }

            grcSpecialCase.DataSource = specialCaselist;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.InitButtonClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchButtonClick();
        }
    }
}
