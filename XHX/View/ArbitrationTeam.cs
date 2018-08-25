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
    public partial class ArbitrationTeam : BaseForm
    {
        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<ExecuteTeamAlterDto> dataHandler = null;
        public ArbitrationTeam()
        {
            InitializeComponent();
            OnLoadView();
        }
        public void OnLoadView()
        {
            CommonHandler.SetRowNumberIndicator(grvArbitrationTeamAlter);

            grcArbitrationTeamAlter.DataSource = new List<ExecuteTeamAlterDto>();
            dataHandler = new XtraGridDataHandler<ExecuteTeamAlterDto>(grvArbitrationTeamAlter);
            XHX.Common.BindComBox.BindProject(cboProjects);
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天

            List<ArbitrationTeamAdviseDto> arbitrationTeamAdviseList = new List<ArbitrationTeamAdviseDto>();
            arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName="同意审核组",LastConfirmCode="01"});
            arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName = "同意执行组", LastConfirmCode = "02" });
            arbitrationTeamAdviseList.Add(new ArbitrationTeamAdviseDto() { LastConfirmName = "都不同意", LastConfirmCode = "03" });

            CommonHandler.BindComboBoxItems<ArbitrationTeamAdviseDto>(cboArbitrationTeamAdvise, arbitrationTeamAdviseList, "LastConfirmName", "LastConfirmCode");

            List<AgreeTypeDto> agreelist = new List<AgreeTypeDto>();
            agreelist.Add(new AgreeTypeDto() { TypeName = "同意", TypeCode = true });
            agreelist.Add(new AgreeTypeDto() { TypeName = "不同意", TypeCode = false });
            CommonHandler.BindComboBoxItems<AgreeTypeDto>(cboAgreeCheck, agreelist, "TypeName", "TypeCode");
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


        //保存

        //查看图片
        private void btnViewPic_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ExecuteTeamAlterDto dto = grvArbitrationTeamAlter.GetRow(grvArbitrationTeamAlter.FocusedRowHandle) as ExecuteTeamAlterDto;
            DataSet ds = service.SearchAnswerDtl2(dto.ProjectCode, dto.SubjectCode, dto.ShopCode);
            List<InspectionStandardDto> inspectionStandardlist = new List<InspectionStandardDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InspectionStandardDto inspectionStandardDto = new InspectionStandardDto();
                    inspectionStandardDto.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    inspectionStandardDto.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    inspectionStandardDto.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    inspectionStandardDto.FileName = Convert.ToString(ds.Tables[0].Rows[i]["FileName"]);
                    inspectionStandardDto.FileType = Convert.ToString(ds.Tables[0].Rows[i]["FileType"]);
                    inspectionStandardDto.CheckOptionCode = Convert.ToString(ds.Tables[0].Rows[i]["CheckOptionCode"]) == "" ? "01" : Convert.ToString(ds.Tables[0].Rows[i]["CheckOptionCode"]);
                    inspectionStandardlist.Add(inspectionStandardDto);
                }

               
            }
            if (inspectionStandardlist.Count > 0)
            {
                string[] filelist = new string[inspectionStandardlist.Count];
                for (int i = 0;i< inspectionStandardlist.Count;i++)
                {
                    filelist[i] = inspectionStandardlist[i].FileName;
                }
                AllPictureShow2 pic = new AllPictureShow2("", filelist, dto.ProjectCode+dto.ShopName,dto.SubjectCode,"","");
                pic.ShowDialog();
            }
            
        }


        private void grvArbitrationTeamAlter_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvArbitrationTeamAlter.FocusedColumn == gcSubjectCode
                || grvArbitrationTeamAlter.FocusedColumn == gcProjectCode
                || grvArbitrationTeamAlter.FocusedColumn == gcShopCode
                || grvArbitrationTeamAlter.FocusedColumn == gcReCheckType
                || grvArbitrationTeamAlter.FocusedColumn == gcReCheckTypeCode
                || grvArbitrationTeamAlter.FocusedColumn == gcPassReCheck
                || grvArbitrationTeamAlter.FocusedColumn == gcOrgScore
                || grvArbitrationTeamAlter.FocusedColumn == gcShopName
                || grvArbitrationTeamAlter.FocusedColumn == gcStatusCode
                || grvArbitrationTeamAlter.FocusedColumn == gcAgreeCheck
                || grvArbitrationTeamAlter.FocusedColumn == gcAgreeReason
                || grvArbitrationTeamAlter.FocusedColumn == gcNewScore
                || grvArbitrationTeamAlter.FocusedColumn == gcReCheckContent
                //||((grvArbitrationTeamAlter.FocusedColumn == gcLastConfirm
                //|| grvArbitrationTeamAlter.FocusedColumn == gcConfirmReason) 
                //&& Convert.ToInt32(grvArbitrationTeamAlter.GetRowCellValue(grvArbitrationTeamAlter.FocusedRowHandle, gcStatusCode)) >= 04)
                )
                e.Cancel = true;
        }

        public override void InitButtonClick()
        {
            cboProjects.SelectedIndex = 0;
            btnShopCode.Text = "";
            txtShopName.Text = "";
            dateStart.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day); // 本月第一天
            dateEnd.DateTime = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1); // 本月最后一天
            grcArbitrationTeamAlter.DataSource = null;
        }
        public override void SearchButtonClick()
        {
            DataSet ds = service.GetAllArbitrationTeamAlter(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString(), btnShopCode.Text, "", dateStart.DateTime, dateEnd.DateTime);
            List<ExecuteTeamAlterDto> executeTeamAlterlist = new List<ExecuteTeamAlterDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ExecuteTeamAlterDto dto = new ExecuteTeamAlterDto();
                    dto.ProjectCode = ds.Tables[0].Rows[i]["ProjectCode"].ToString();
                    dto.ShopCode = ds.Tables[0].Rows[i]["ShopCode"].ToString();
                    dto.SubjectCode = ds.Tables[0].Rows[i]["SubjectCode"].ToString();
                    if (ds.Tables[0].Rows[i]["ConfirmDate"] == DBNull.Value)
                    {
                        dto.ConfirmDate = null;
                    }
                    else
                    {
                        dto.ConfirmDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ConfirmDate"]);
                    }
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
                    dto.AgreeCheck = Convert.ToBoolean(ds.Tables[0].Rows[i]["AgreeCheck"]);
                    dto.AgreeReason = ds.Tables[0].Rows[i]["AgreeReason"].ToString();
                    dto.ReCheckContent = ds.Tables[0].Rows[i]["ReCheckContent"].ToString();
                    //dto.ReCheckType = ds.Tables[0].Rows[i]["ReCheckType"].ToString();
                    dto.ReCheckTypeCode = ds.Tables[0].Rows[i]["ReCheckTypeCode"].ToString();
                    dto.LastConfirm = ds.Tables[0].Rows[i]["LastConfirm"].ToString();
                    dto.ConfirmReason = ds.Tables[0].Rows[i]["ConfirmReason"].ToString();
                    dto.ShopName = ds.Tables[0].Rows[i]["ShopName"].ToString();
                    //dto.StatusCode = ds.Tables[0].Rows[i]["StatusCode"].ToString();
                    executeTeamAlterlist.Add(dto);
                }
            }
            grcArbitrationTeamAlter.DataSource = executeTeamAlterlist;
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvArbitrationTeamAlter);
        }
        public override void SaveButtonClick()
        {
            grvArbitrationTeamAlter.CloseEditor();
            grvArbitrationTeamAlter.UpdateCurrentRow();
            grvArbitrationTeamAlter.RefreshData();
            DialogResult reslut = CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？");
            if (reslut != DialogResult.Yes)
                return;
            foreach (ExecuteTeamAlterDto item in dataHandler.DataList)
            {
                if (item.StatusType == 'U')
                {
                    service.SaveArbitrationTeamAlter(item.ProjectCode, item.ShopCode, item.SubjectCode, item.ReCheckTypeCode
                        , item.LastConfirm, item.ConfirmReason, this.UserInfoDto.UserID);
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "保存成功!");
            this.SearchButtonClick();
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
    }
}
