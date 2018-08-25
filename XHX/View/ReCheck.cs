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
    public partial class ReCheck : BaseForm
    {
        localhost.Service service = new localhost.Service();
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        XtraGridDataHandler<ReCheckDto> dataHandler = null;

        public ReCheck()
        {
            InitializeComponent();

            //初始化Button
            CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);

            //初始化Grid样式
            CommonHandler.SetRowNumberIndicator(grvReCheck);

            InitData();

            dataHandler = new XtraGridDataHandler<ReCheckDto>(grvReCheck);
            selection = new GridCheckMarksSelection(grvReCheck);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        #region Button Click Event


        #endregion

        #region Private Method

        private void InitData()
        {
            //初始化查询条件
            BindComBox.BindProject(cboProject);
            BindComBox.BindArea(cboArea);
            txtShopCode.Text = String.Empty;
            txtShopName.Text = String.Empty;
            grcReCheck.DataSource = new List<ReCheckDto>();
        }

        private void SearchReCheck()
        {
            CommonHandler.DBConnect();
            List<ReCheckDto> reCheckList = new List<ReCheckDto>();
            //string sql = string.Format("EXEC [up_XHX_ReCheck_R] @ProjectCode = '{0}', @AreaCode = '{1}', @ShopCode = '{2}' ",
            //    CommonHandler.GetComboBoxSelectedValue(cboProject), CommonHandler.GetComboBoxSelectedValue(cboArea), txtShopCode.Text.Trim());
            //DataSet ds = CommonHandler.query(sql);

            DataSet ds = service.SearchRecheckResult(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(),
                                                    CommonHandler.GetComboBoxSelectedValue(cboArea).ToString(), 
                                                    txtShopCode.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ReCheckDto recheckDto = new ReCheckDto();
                    recheckDto.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    recheckDto.CheckPoint = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                    recheckDto.Score = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    recheckDto.ReCheckChk = Convert.ToBoolean(ds.Tables[0].Rows[i]["ReCheckChk"]);
                    reCheckList.Add(recheckDto);
                }
            }
            grcReCheck.DataSource = reCheckList;

            CSParentForm.EnabelButton(ButtonType.SaveButton, true);
            CSParentForm.EnabelButton(ButtonType.AddRowButton, true);
            if (grvReCheck.DataRowCount > 0)
                CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);
        }

        #endregion

        public override void InitButtonClick()
        {
            //初始化Button
            CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);

            InitData();
        }
        public override void SearchButtonClick()
        {
            SearchReCheck();
        }
        public override void AddRowButtonClick()
        {
            dataHandler.AddRow(new ReCheckDto());

            CSParentForm.EnabelButton(ButtonType.DeleteRowButton, true);
        }
        public override void DeleteRowButtonClick()
        {
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);

            if (grvReCheck.DataRowCount == 0)
                CSParentForm.EnabelButton(ButtonType.DeleteRowButton, false);

            selection.ClearSelection();
        }
        public override void SaveButtonClick()
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<ReCheckDto> reCheckList = dataHandler.DataList;
                foreach (ReCheckDto reCheck in reCheckList)
                {
                    if (reCheck.StatusType == StatusTypes.INSERT)
                    {

                    }
                    else if (reCheck.StatusType == StatusTypes.DELETE)
                    {

                    }

                }
            }
            SearchReCheck();
            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.AddRowButton);
            list.Add(ButtonType.DeleteRowButton);
            list.Add(ButtonType.SaveButton);
            
            return list;
        }
    }
}
