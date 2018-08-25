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

namespace XHX.View
{
    public partial class RoleTypeProgram : BaseForm
    {
        #region :Field

        localhost.Service service = new localhost.Service();
        XtraGridDataHandler<RoleTypeProgramDto> dataHandler = null;
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        #endregion

        public RoleTypeProgram()
        {
            InitializeComponent();

            

            //初始化Grid样式
            CommonHandler.SetRowNumberIndicator(grvRoleTypeProgram);

            InitData();

            dataHandler = new XtraGridDataHandler<RoleTypeProgramDto>(grvRoleTypeProgram);
            selection = new GridCheckMarksSelection(grvRoleTypeProgram);
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
            List<ProgramDto> programList = new List<ProgramDto>();
            ds = service.SearchAllProgram();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProgramDto programType = new ProgramDto();
                    programType.ProgramCode = Convert.ToString(ds.Tables[0].Rows[i]["ProgramCode"]);
                    programType.ProgramName = Convert.ToString(ds.Tables[0].Rows[i]["ProgramName"]);
                    programList.Add(programType);
                }
            }


            CommonHandler.SetComboBoxEditItems(cboRoleType, roleTypeList, "RoleTypeName", "RoleTypeCode");
            CommonHandler.BindComboBoxItems<RoleTypeDto>(cboRoleTypeInGrid, roleTypeList, "RoleTypeName", "RoleTypeCode");
            CommonHandler.BindComboBoxItems<ProgramDto>(cboProgram, programList, "ProgramName", "ProgramCode");
            grcRoleTypeProgram.DataSource = new List<RoleTypeProgramDto>();
        }

        private void SearchRoleTypeProgram()
        {
            List<RoleTypeProgramDto> roleTypeProgramList = new List<RoleTypeProgramDto>();
            DataSet ds = service.SearchRoleTypeProgramByRoleTypeCode(CommonHandler.GetComboBoxSelectedValue(cboRoleType).ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RoleTypeProgramDto roleTypeProgramDto = new RoleTypeProgramDto();
                    roleTypeProgramDto.RoleTypeProgramID = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleTypeProgramID"]);
                    roleTypeProgramDto.RoleTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["RoleTypeCode"]);
                    roleTypeProgramDto.ProgramCode = Convert.ToString(ds.Tables[0].Rows[i]["ProgramCode"]);
                    roleTypeProgramList.Add(roleTypeProgramDto);
                }
            }
            grcRoleTypeProgram.DataSource = roleTypeProgramList;
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, true);
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, true);
            
            
            if (grvRoleTypeProgram.DataRowCount > 0)
                this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);
        }

        #endregion
    

        private void grvRoleTypeProgram_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvRoleTypeProgram.FocusedColumn == gridColumn1)
            {
                RoleTypeProgramDto roleTypeProgramDto = grvRoleTypeProgram.GetFocusedRow() as RoleTypeProgramDto;

                if (roleTypeProgramDto.StatusType != StatusTypes.INSERT)
                {
                    e.Cancel = true;
                }
            }
        }
        public override void SearchButtonClick()
        {
            SearchRoleTypeProgram();
        }
        public override void InitButtonClick()
        {
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);
         

            InitData();
        }
        public override void AddRowButtonClick()
        {
            RoleTypeProgramDto score = new RoleTypeProgramDto();
            score.InUserID = UserInfoDto.UserID;
            score.InDateTime = DateTime.Now;
            score.RoleTypeCode = CommonHandler.GetComboBoxSelectedValue(cboRoleType).ToString();
            dataHandler.AddRow(score);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);
            
        }
        public override void DeleteRowButtonClick()
        {
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);

            if (grvRoleTypeProgram.DataRowCount == 0)
                this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);

            selection.ClearSelection();
        }
        public override void SaveButtonClick()
        {
            grvRoleTypeProgram.CloseEditor();
            grvRoleTypeProgram.UpdateCurrentRow();
            List<RoleTypeProgramDto> currentList = grvRoleTypeProgram.DataSource as List<RoleTypeProgramDto>;
            List<RoleTypeProgramDto> noneList = new List<RoleTypeProgramDto>();
            foreach (RoleTypeProgramDto dto in currentList)
            {
                if (dto.StatusType == StatusTypes.NONE)
                {
                    noneList.Add(dto);
                }
            }
            foreach (RoleTypeProgramDto InsertDto in currentList)
            {
                if (InsertDto.StatusType == StatusTypes.INSERT)
                {
                    foreach (RoleTypeProgramDto dto in noneList)
                    {
                        if (InsertDto.RoleTypeCode == dto.RoleTypeCode && InsertDto.ProgramCode == dto.ProgramCode)
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "存在重复项。");
                            grvRoleTypeProgram.FocusedRowHandle = currentList.IndexOf(InsertDto);
                            grvRoleTypeProgram.FocusedColumn = gridColumn1;
                            return;
                        }
                    }
                }
            }


            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<RoleTypeProgramDto> roleTypeProgramList = dataHandler.DataList;
                foreach (RoleTypeProgramDto score in roleTypeProgramList)
                {
                    if (score.StatusType == 'D')
                    {
                        service.DeleteRoleTypeProgram(score.RoleTypeProgramID);
                    }
                    else if (score.StatusType == 'I')
                    {
                        service.InsertRoleTypeProgram(score.RoleTypeCode, score.ProgramCode, score.InUserID, DateTime.Now);
                    }

                }
                SearchRoleTypeProgram();
            }
            else
            {
                return;
            }

            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }
        public override void ExcelDownButtonClick()
        {
            if (grcRoleTypeProgram.DataSource != null)
            {
                CommonHandler.ExcelExport(grvRoleTypeProgram);
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

        private void RoleTypeProgram_Load(object sender, EventArgs e)
        {
            //初始化Button
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            this.CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);
        }
    }
}
