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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace XHX.ViewLocalService
{
    public partial class ExecuteTeamAlter : BaseForm
    {
        localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        XtraGridDataHandler<ExecuteTeamAlterDto> dataHandler = null;

        public ExecuteTeamAlter()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            OnLoadView();
        }
        public void OnLoadView()
        {
            CommonHandler.SetRowNumberIndicator(grvExecuteTeamAlter);

            grcExecuteTeamAlter.DataSource = new List<ExecuteTeamAlterDto>();
            dataHandler = new XtraGridDataHandler<ExecuteTeamAlterDto>(grvExecuteTeamAlter);
            XHX.Common.BindComBox.BindProject(cboProjects);
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天

            List<AgreeTypeDto> agreelist = new List<AgreeTypeDto>();
            agreelist.Add(new AgreeTypeDto() { TypeName = "", TypeCode = null });
            agreelist.Add(new AgreeTypeDto(){TypeName= "同意",TypeCode=true});
            agreelist.Add(new AgreeTypeDto(){TypeName= "不同意",TypeCode=false});
            BindComBox.BindSubjectType(cboRecheckStep);
            //审核区分，直接把ArbitrationTeamAdviseDto拿来用了
            //List<ArbitrationTeamAdviseDto> arbitrationTeamAdviseList = new List<ArbitrationTeamAdviseDto>();
            //arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName = "一次复审", LastConfirmCode = "01" });
            //arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName = "二次复审", LastConfirmCode = "02" });
            //arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName = "最终审核", LastConfirmCode = "03" });

            btnRecheckComplete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "一审修改完毕", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});


            CommonHandler.BindComboBoxItems<AgreeTypeDto>(cboAgreeCheck, agreelist, "TypeName", "TypeCode");
            //CommonHandler.SetComboBoxEditItems(cboRecheckStep, arbitrationTeamAdviseList, "LastConfirmName", "LastConfirmCode");
            gcSubjectCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcProjectCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcShopCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcReCheckType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcReCheckTypeCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcPassReCheck.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcOrgScore.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcLastConfirm.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcConfirmReason.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcReCheckContent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcShopName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gcReCheckComplete.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gcStatusCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcReCheckComplete.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gcAgreeCheck.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcAgreeReason.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcView.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gcNewScore.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            

            grcExecuteTeamAlter.MouseClick += new MouseEventHandler(grcExecuteTeamAlter_MouseClick);
        }

        void grcExecuteTeamAlter_MouseClick(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = grvExecuteTeamAlter.CalcHitInfo(e.X, e.Y);
            if (hitInfo.Column == gcReCheckComplete && hitInfo.InRow)
            {
                btnRecheckComplete_ButtonClick(null, null);
            }
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

        private void grvExecuteTeamAlter_ShowingEditor(object sender, CancelEventArgs e)
        {
            ExecuteTeamAlterDto dto = grvExecuteTeamAlter.GetRow(grvExecuteTeamAlter.FocusedRowHandle) as ExecuteTeamAlterDto;
            if (grvExecuteTeamAlter.FocusedColumn == gcSubjectCode
                || grvExecuteTeamAlter.FocusedColumn == gcProjectCode
                || grvExecuteTeamAlter.FocusedColumn == gcShopCode
                || grvExecuteTeamAlter.FocusedColumn == gcReCheckType
                || grvExecuteTeamAlter.FocusedColumn == gcReCheckTypeCode
                || grvExecuteTeamAlter.FocusedColumn == gcPassReCheck
                || grvExecuteTeamAlter.FocusedColumn == gcOrgScore
                || grvExecuteTeamAlter.FocusedColumn == gcLastConfirm
                || grvExecuteTeamAlter.FocusedColumn == gcConfirmReason
                || grvExecuteTeamAlter.FocusedColumn == gcReCheckContent
                || grvExecuteTeamAlter.FocusedColumn == gcShopName
                || grvExecuteTeamAlter.FocusedColumn == gcStatusCode
                //|| ((grvExecuteTeamAlter.FocusedColumn == gcReCheckComplete
                //       || grvExecuteTeamAlter.FocusedColumn == gcAgreeCheck
                //       || grvExecuteTeamAlter.FocusedColumn == gcAgreeReason
                //       || grvExecuteTeamAlter.FocusedColumn == gcNewScore) &&
                //                ((Convert.ToInt32(dto.StatusCode) >= 04 && dto.ReCheckTypeCode == "01")
                //                || (Convert.ToInt32(dto.StatusCode) >= 06 && dto.ReCheckTypeCode == "02")
                //                 || (Convert.ToInt32(dto.StatusCode) >= 08 && dto.ReCheckTypeCode == "03")))
                )
                e.Cancel = true;
           

        }

        private void grvExecuteTeamAlter_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column == gcShopName)
            {
                if (e.CellValue1 == e.CellValue2)
                {
                    //e.Handled = true;
                    e.Merge = true;
                }
            }
            else if (e.Column == gcReCheckComplete)
            {
                if (grvExecuteTeamAlter.GetRowCellValue(e.RowHandle1, gcShopCode).ToString() == grvExecuteTeamAlter.GetRowCellValue(e.RowHandle2, gcShopCode).ToString())
                {
                    e.Handled = true;
                    e.Merge = true;
                }
            }
            else
            {
                e.Merge = false;
            }
        }

        private void btnRecheckComplete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.UserInfoDto.RoleType == "C") return;
            ExecuteTeamAlterDto dto = grvExecuteTeamAlter.GetRow(grvExecuteTeamAlter.FocusedRowHandle) as ExecuteTeamAlterDto;
            DataSet ds = service.GetShopRecheckStatus(dto.ProjectCode, dto.ShopCode);
            List<string> strlistTotal = new List<string>();
            List<string> strCurrent = new List<string>();
            List<string> strLeft = new List<string>();
            
            strlistTotal.Add("照片类");
            strlistTotal.Add("资料类");
            strlistTotal.Add("交叉类");

            
            int num = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[i]["StatusCode"]) == "S1")
                    {
                        num++;
                        break;
                    }
                    
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string statusCode = Convert.ToString(ds.Tables[0].Rows[i]["StatusCode"]);
                    if (statusCode == "SA")
                    {
                        strCurrent.Add("照片类");
                    }
                    if (statusCode == "SB")
                    {
                        strCurrent.Add("资料类");
                    }
                    if (statusCode == "SC")
                    {
                        strCurrent.Add("交叉类");
                    }
                    
                }
                foreach (string item in strlistTotal)
                {
                    if (!strCurrent.Contains(item))
                    {
                        strLeft.Add(item);
                    }
                }
            }
            string strleftResult = "";
            foreach (string item in strLeft)
            {
                strleftResult += item + " ";
            }
            if (strCurrent.Count<3)
            {
                CommonHandler.ShowMessage(MessageType.Information, strleftResult + "没有复审完毕，不能提交复审修改完毕");
                return;
            }
            if (num != 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "已经提交过修改审核完毕申请，请不要重复提交!");
                return;
            
            }
            int a = Convert.ToInt32(service.SearchExecuteTeamUnAgreeCount(dto.ProjectCode, dto.ShopCode,dto.ReCheckTypeCode).Tables[0].Rows[0]["Count"]);
            if (a > 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "存在不同意的审核事项,请确认");
                return;
            }
            else
            {
                DialogResult reslut = CommonHandler.ShowMessage(MessageType.Confirm, "确定所有的执行文件已经修改完毕，提交修改完毕申请吗？");
                if (reslut == DialogResult.Yes || reslut == DialogResult.OK)
                {
                    //string finalCode = "";
                    //switch (dto.ReCheckTypeCode)
                    //{
                    //    case "01": finalCode = "04"; break;
                    //    case "02": finalCode = "06"; break;
                    //    case "03": finalCode = "08"; break;
 
                    //}
                    service.SaveReCheckStatus(dto.ProjectCode, dto.ShopCode, "S1", this.UserInfoDto.UserID);
                }
                else
                    return;
            }
            CommonHandler.ShowMessage(MessageType.Information, "提交成功!");
            this.SearchButtonClick();
        }


        public override void InitButtonClick()
        {
            cboProjects.SelectedIndex = 0;
            btnShopCode.Text = "";
            txtShopName.Text = "";
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天
            grcExecuteTeamAlter.DataSource = null;
        }
        public override void SearchButtonClick()
        {
            string buttonName = "";
            //switch (CommonHandler.GetComboBoxSelectedValue(cboRecheckStep).ToString())
            //{
            //    case "01": buttonName = "一审修改完毕"; break;
            //    case "02": buttonName = "二审修改完毕"; break;
            //    case "03": buttonName = "终审修改完毕"; break;
            //}
            btnRecheckComplete.Buttons.Clear();
            btnRecheckComplete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, buttonName, -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            DataSet ds = service.GetAllExecuteTeamAlter(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(),
                CommonHandler.GetComboBoxSelectedValue(cboRecheckStep).ToString() == "" ? "" : CommonHandler.GetComboBoxSelectedValue(cboRecheckStep).ToString().Replace("S","0"), 
                                                        btnShopCode.Text, "", dateStart.DateTime, 
                                                        dateEnd.DateTime,chkPassRecheck.Checked);
            List<ExecuteTeamAlterDto> executeTeamAlterlist = new List<ExecuteTeamAlterDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ExecuteTeamAlterDto dto = new ExecuteTeamAlterDto();
                    dto.ProjectCode = ds.Tables[0].Rows[i]["ProjectCode"].ToString();
                    dto.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                    dto.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                    //decimal? newScore;
                    if (ds.Tables[0].Rows[i]["NewScore"] == DBNull.Value)
                    {
                        dto.NewScore = null;
                    }
                    else
                    {
                        dto.NewScore = Convert.ToDecimal(ds.Tables[0].Rows[i]["NewScore"]);
                    }
                    dto.OrgScore = ds.Tables[0].Rows[i]["OrgScore"].ToString();
                    dto.PassReCheck = Convert.ToBoolean(ds.Tables[0].Rows[i]["PassReCheck"]);
                    if (ds.Tables[0].Rows[i]["AgreeCheck"] == DBNull.Value)
                    {
                        dto.AgreeCheck = null;
                    }
                    else
                    {
                        dto.AgreeCheck = Convert.ToBoolean(ds.Tables[0].Rows[i]["AgreeCheck"]);
                    }
                    dto.AgreeReason = ds.Tables[0].Rows[i]["AgreeReason"].ToString();
                    dto.ReCheckContent = ds.Tables[0].Rows[i]["ReCheckContent"].ToString();
                   // dto.ReCheckType = ds.Tables[0].Rows[i]["ReCheckType"].ToString();
                    //dto.ReCheckTypeCode = ds.Tables[0].Rows[i]["ReCheckTypeCode"].ToString();
                    dto.LastConfirm = ds.Tables[0].Rows[i]["LastConfirm"].ToString();
                    dto.ConfirmReason = ds.Tables[0].Rows[i]["ConfirmReason"].ToString();
                    dto.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                   // dto.StatusCode = ds.Tables[0].Rows[i]["StatusCode"].ToString();
                    executeTeamAlterlist.Add(dto);
                }
            }
            grcExecuteTeamAlter.DataSource = executeTeamAlterlist;
        }
        public override void SaveButtonClick()
        {
            grvExecuteTeamAlter.CloseEditor();
            grvExecuteTeamAlter.UpdateCurrentRow();
            grvExecuteTeamAlter.RefreshData();
            DialogResult reslut = CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？");
            if (reslut != DialogResult.Yes)
                return;
            foreach (ExecuteTeamAlterDto item in dataHandler.DataList)
            {
                if (item.StatusType == 'U')
                {
                    bool agreeCheck = false;
                    if (item.AgreeCheck != null)
                    {
                        agreeCheck = Convert.ToBoolean(item.AgreeCheck);
                        service.SaveExecuteTeamAlter(item.ProjectCode, item.ShopCode, item.SubjectCode, item.ReCheckTypeCode
                           , agreeCheck, item.AgreeReason, item.NewScore == null ? Convert.ToDecimal(item.OrgScore == "未涉及" ? Convert.ToDecimal(9999.00) : Convert.ToDecimal(item.OrgScore)) : item.NewScore, this.UserInfoDto.UserID);
                    }
                    else {

                        return;
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "保存成功!");
            this.SearchButtonClick();
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvExecuteTeamAlter);
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);

            list.Add(ButtonType.SaveButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }

        private void btnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.UserInfoDto.RoleType == "C") return;
            string projectCode = grvExecuteTeamAlter.GetRowCellValue(grvExecuteTeamAlter.FocusedRowHandle, gcProjectCode).ToString();
            string subjectCode = grvExecuteTeamAlter.GetRowCellValue(grvExecuteTeamAlter.FocusedRowHandle, gcSubjectCode).ToString();
            string shopCode = grvExecuteTeamAlter.GetRowCellValue(grvExecuteTeamAlter.FocusedRowHandle,gcShopCode).ToString();
            string shopName = grvExecuteTeamAlter.GetRowCellValue(grvExecuteTeamAlter.FocusedRowHandle,gcShopName).ToString();
            DataSet ds = service.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
            int order = 0;
            string examType = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                examType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);
            }
            //SubjectOnePop sub = new SubjectOnePop(projectCode, shopCode, shopName, subjectCode);
            //sub.ShowDialog();
            AnswerSubjectForm answer = new AnswerSubjectForm(projectCode, subjectCode, shopCode, shopName, order, '1', this.UserInfoDto, examType, "ExecuteTeamAlter");
            answer.ShowDialog();


        }
    }
}
