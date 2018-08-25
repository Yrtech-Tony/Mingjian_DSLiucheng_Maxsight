using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;

namespace XHX.ViewLocalService
{
    public partial class UserInfo : BaseForm
    {
        #region :Field

        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<UserInfoDto> dataHandler = null;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        #endregion

        public UserInfo()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            //初始化Grid样式
            CommonHandler.SetRowNumberIndicator(grvUserInfo);

            InitData();

            dataHandler = new XtraGridDataHandler<UserInfoDto>(grvUserInfo);
            selection = new GridCheckMarksSelection(grvUserInfo);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        #region :Private Mothod

        private void InitData()
        {
            //初始化查询条件
            List<RoleTypeDto> roleTypeList = new List<RoleTypeDto>();
            DataSet ds = service.SearchAllRoleType();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RoleTypeDto roleType = new RoleTypeDto();
                    roleType.RoleTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["RoleTypeCode"]);
                    roleType.RoleTypeName = Convert.ToString(ds.Tables[0].Rows[i]["RoleTypeName"]);
                    roleTypeList.Add(roleType);
                }
            }


            CommonHandler.SetComboBoxEditItems(cboRoleType, roleTypeList, "RoleTypeName", "RoleTypeCode");
            CommonHandler.BindComboBoxItems<RoleTypeDto>(cboRoleTypeInGrid, roleTypeList, "RoleTypeName", "RoleTypeCode");
            grcUserInfo.DataSource = new List<UserInfoDto>();
        }

        private void SearchUserInfo()
        {
            List<UserInfoDto> userInfoList = new List<UserInfoDto>();
            DataSet ds = service.SearchUserInfoDto(txtUserID.Text.Trim(), CommonHandler.GetComboBoxSelectedValue(cboRoleType).ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserInfoDto userInfoDto = new UserInfoDto();
                    userInfoDto.UserID = Convert.ToString(ds.Tables[0].Rows[i]["UserID"]);
                    userInfoDto.UserName = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                    userInfoDto.RoleType = Convert.ToString(ds.Tables[0].Rows[i]["RoleType"]);
                    userInfoDto.PSW = Convert.ToString(ds.Tables[0].Rows[i]["PSW"]);
                    userInfoDto.MacAddress = Convert.ToString(ds.Tables[0].Rows[i]["MacAddress"]);
                    userInfoList.Add(userInfoDto);
                }
            }
            grcUserInfo.DataSource = userInfoList;
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, true);
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, true);

            if (grvUserInfo.DataRowCount > 0)
                this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);

        }

        #endregion



        private void grvRoleTypeProgram_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvUserInfo.FocusedColumn == gcUserID)
            {
                UserInfoDto dto = grvUserInfo.GetFocusedRow() as UserInfoDto;

                if (dto.StatusType != StatusTypes.INSERT)
                {
                    e.Cancel = true;
                }
            }
        }
        public override void InitButtonClick()
        {
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);

            InitData();
        }
        public override void SearchButtonClick()
        {
            SearchUserInfo();
        }
        public override void AddRowButtonClick()
        {
            UserInfoDto dto = new UserInfoDto();
            dto.InUserID = UserInfoDto.UserID;
            dto.PSW = "1234";
            dto.RoleType = CommonHandler.GetComboBoxSelectedValue(cboRoleType).ToString();
            dataHandler.AddRow(dto);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);

        }
        public override void DeleteRowButtonClick()
        {
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);

            if (grvUserInfo.DataRowCount == 0)
                this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);

            selection.ClearSelection();
        }
        public override void SaveButtonClick()
        {
            grvUserInfo.CloseEditor();
            grvUserInfo.UpdateCurrentRow();
            grvUserInfo.RefreshData();
            List<UserInfoDto> currentList = grvUserInfo.DataSource as List<UserInfoDto>;
            List<UserInfoDto> allList = new List<UserInfoDto>();
            DataSet ds = service.SearchUserInfoDto("", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserInfoDto userInfoDto = new UserInfoDto();
                    userInfoDto.UserID = Convert.ToString(ds.Tables[0].Rows[i]["UserID"]);
                    userInfoDto.RoleType = Convert.ToString(ds.Tables[0].Rows[i]["RoleType"]);
                    allList.Add(userInfoDto);
                }
            }
            foreach (UserInfoDto InsertDto in currentList)
            {
                if (InsertDto.StatusType == StatusTypes.UPDATE || InsertDto.StatusType == StatusTypes.INSERT)
                {
                    if (String.IsNullOrEmpty(InsertDto.PSW))
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "密码不能为空。");
                        grvUserInfo.FocusedRowHandle = currentList.IndexOf(InsertDto);
                        grvUserInfo.FocusedColumn = gcPSW;
                        return;
                    }
                }

                if (InsertDto.StatusType == StatusTypes.INSERT)
                {
                    foreach (UserInfoDto dto in allList)
                    {
                        if (InsertDto.UserID == dto.UserID)
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "用户ID已存在。");
                            grvUserInfo.FocusedRowHandle = currentList.IndexOf(InsertDto);
                            grvUserInfo.FocusedColumn = gcUserID;
                            return;
                        }
                    }
                }
            }


            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<UserInfoDto> userInfoDtoList = dataHandler.DataList;
                foreach (UserInfoDto dto in userInfoDtoList)
                {
                    if (dto.StatusType == 'D')
                    {
                        service.DeleteUserInfoDto(dto.UserID);
                    }
                    else if (dto.StatusType == 'I')
                    {
                        service.InsertUserInfo(dto.UserID, dto.PSW, dto.RoleType, base.UserInfoDto.UserID,dto.UserName,dto.MacAddress);
                    }
                    else if (dto.StatusType == 'U')
                    {
                        service.UpdateUserInfoDto(dto.UserID, dto.PSW, dto.RoleType, base.UserInfoDto.UserID,dto.UserName,dto.MacAddress);
                    }
                }
                SearchUserInfo();
            }
            else
            {
                return;
            }

            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }
        public override void ExcelDownButtonClick()
        {
            if (grcUserInfo.DataSource != null)
            {
                CommonHandler.ExcelExport(grvUserInfo);
            }
        }

        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.AddRowButton);
            list.Add(ButtonType.DeleteRowButton);
            list.Add(ButtonType.SaveButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            //初始化Button
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);
        }
    }
}
