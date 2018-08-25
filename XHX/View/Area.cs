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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
//using XHX.WebService;

namespace XHX.View
{
    public partial class Area : BaseForm
    {
        XtraGridDataHandler<AreaDto> dataHandler = null;
        localhost.Service webService = new localhost.Service();
        List<AreaDto> saleAreaList = new List<AreaDto>();//销售大区List
        List<AreaDto> serverAreaList = new List<AreaDto>();//售后大区List

        public Area()
        {
            InitializeComponent();
            OnLoadView();
        }
        public void OnLoadView()
        {
            //为查询条件中Cbo绑定
            BindComBox.BindAreaType(cboAreaType);
            //为Grid中Cbo绑定
            List<AreaTypeDto> areaTypeList = new List<AreaTypeDto>();
            DataSet ds = webService.GetAllAreaType();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AreaTypeDto areaType = new AreaTypeDto();
                    areaType.AreaTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeCode"]);
                    areaType.AreaTypeName = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeName"]);
                    areaTypeList.Add(areaType);
                }
            }
            CommonHandler.BindComboBoxItems<AreaTypeDto>(cboAreaTypeInGrid, areaTypeList, "AreaTypeName", "AreaTypeCode");

            dataHandler = new XtraGridDataHandler<AreaDto>(grvArea);
        }
        public void InitializeView()
        {
            cboAreaType.SelectedIndex = 0;
            grcArea.DataSource = null;
        }
        private void Shop_Load(object sender, EventArgs e)
        {
            this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
            this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
        }

        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.AddRowButton);
            list.Add(ButtonType.SaveButton);
            
            return list;
        }
        public override void InitButtonClick()
        {
            base.InitButtonClick();

            InitializeView();
        }
        public override void SearchButtonClick()
        {
            SearchArea();
            if (base.UserInfoDto.RoleType != "C")
            {
                this.CSParentForm.EnabelButton(ButtonType.AddRowButton, true);
                this.CSParentForm.EnabelButton(ButtonType.SaveButton, true);
            }
            else
            {
                this.CSParentForm.EnabelButton(ButtonType.AddRowButton, false);
                this.CSParentForm.EnabelButton(ButtonType.SaveButton, false);
            }
        }
        public override void AddRowButtonClick()
        {
            AreaDto area = new AreaDto();
            area.AreaTypeCode = CommonHandler.GetComboBoxSelectedValue(cboAreaType).ToString();
            dataHandler.AddRow(area);
        }
        public override void SaveButtonClick()
        {
            if (base.UserInfoDto.RoleType != "S")
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有权限");
                return;
            }
            grvArea.CloseEditor();
            grvArea.UpdateCurrentRow();

            foreach (AreaDto area in grcArea.DataSource as List<AreaDto>)
            {
                //验证 区域类型
                if (String.IsNullOrEmpty(area.AreaTypeCode))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "区域类型不能为空");
                    grvArea.FocusedColumn = gcAreaType;
                    grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                    return;
                }

                //验证 区域代码
                if (string.IsNullOrEmpty(area.AreaCode))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "区域代码不能为空");
                    grvArea.FocusedColumn = gcAreaCode;
                    grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                    return;
                }
                foreach (AreaDto s in dataHandler.DataList)
                {
                    if (s != area && s.AreaCode == area.AreaCode)
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "区域代码不能重复");
                        grvArea.FocusedColumn = gcAreaCode;
                        grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                        return;
                    }
                }

                //验证 区域名称
                if (string.IsNullOrEmpty(area.AreaName))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "区域名称不能为空");
                    grvArea.FocusedColumn = gcAreaName;
                    grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                    return;
                }
                foreach (AreaDto s in dataHandler.DataList)
                {
                    if (s != area && s.AreaName == area.AreaName)
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "区域名称不能重复");
                        grvArea.FocusedColumn = gcAreaName;
                        grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                        return;
                    }
                }

                //验证 上级区域
                if (area.AreaTypeCode == "02" || area.AreaTypeCode == "04")//如果是小区
                {
                    if (String.IsNullOrEmpty(area.UpperAreaCode))
                    {
                        CommonHandler.ShowMessage(MessageType.Information, "上级区域不能为空");
                        grvArea.FocusedColumn = gcUpperArea;
                        grvArea.FocusedRowHandle = (grcArea.DataSource as List<AreaDto>).IndexOf(area);
                        return;
                    }
                }
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<AreaDto> areaList = dataHandler.DataList;
                foreach (AreaDto area in areaList)
                {
                    if (area.StatusType == 'I' || area.StatusType == 'U')
                    {
                        webService.SaveArea(area.AreaCode, area.AreaName, area.UpperAreaCode, area.AreaTypeCode, base.UserInfoDto.UserID);
                    }
                }
            }
            SearchArea();
            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }

        private void SearchArea()
        {
            saleAreaList.Clear();
            DataSet ds = webService.SearchArea("01");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AreaDto area = new AreaDto();
                    area.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                    area.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                    area.UpperAreaCode = Convert.ToString(ds.Tables[0].Rows[i]["UpperAreaCode"]);
                    area.AreaTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeCode"]);
                    saleAreaList.Add(area);
                }
            }
            serverAreaList.Clear();
            ds = webService.SearchArea("03");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AreaDto area = new AreaDto();
                    area.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                    area.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                    area.UpperAreaCode = Convert.ToString(ds.Tables[0].Rows[i]["UpperAreaCode"]);
                    area.AreaTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeCode"]);
                    serverAreaList.Add(area);
                }
            }

            List<AreaDto> areaList = new List<AreaDto>();
            ds = webService.SearchArea(CommonHandler.GetComboBoxSelectedValue(cboAreaType).ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AreaDto area = new AreaDto();
                    area.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                    area.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                    area.UpperAreaCode = Convert.ToString(ds.Tables[0].Rows[i]["UpperAreaCode"]);
                    area.AreaTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeCode"]);
                    areaList.Add(area);
                }
            }
            grcArea.DataSource = areaList;
        }

        private void grvArea_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == gcUpperArea)
            {
                AreaDto areaDto = grvArea.GetRow(e.RowHandle) as AreaDto;
                RepositoryItemComboBox cboUpperArea = new RepositoryItemComboBox();

                if (areaDto.AreaTypeCode == "02")//如果是销售小区
                {
                    CommonHandler.BindComboBoxItems<AreaDto>(cboUpperArea, saleAreaList, "AreaName", "AreaCode");
                    e.RepositoryItem = cboUpperArea;
                }
                else if (areaDto.AreaTypeCode == "04")//如果是售后小区
                {
                    CommonHandler.BindComboBoxItems<AreaDto>(cboUpperArea, serverAreaList, "AreaName", "AreaCode");
                    e.RepositoryItem = cboUpperArea;
                }
                else
                {
                    cboUpperArea.ReadOnly = true;
                    e.RepositoryItem = cboUpperArea;
                }
            }
        }
    }


}
