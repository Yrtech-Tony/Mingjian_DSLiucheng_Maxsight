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
    public partial class StandardRate : BaseForm
    {
        localhost.Service webService = new localhost.Service();
        XtraGridDataHandler<StandardRateAllDto> dataHandler = null;
        public StandardRate()
        {
            InitializeComponent();
            BindComBox.BindProject(cboProject);
            dataHandler = new XtraGridDataHandler<StandardRateAllDto>(grvStandardRateAll);
            CommonHandler.SetRowNumberIndicator(grvStandardRateAll);
        }
        private void SearchRateAll()
        {
            grcStandardRateAll.DataSource = null;
            List<StandardRateAllDto> fileList = new List<StandardRateAllDto>();
            //string sql = string.Format("EXEC up_XHX_StandardRate_R '{0}'", CommonHandler.GetComboBoxSelectedValue(cboProject).ToString());
            DataSet ds = webService.SearchRateAllByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    StandardRateAllDto file = new StandardRateAllDto();
                    file.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectName"]);
                    file.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    file.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    file.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);
                    file.StandYes = Convert.ToInt32(ds.Tables[0].Rows[i]["StandYes"]);
                    file.StandNO = Convert.ToInt32(ds.Tables[0].Rows[i]["StandNO"]);
                    file.NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["NotNovled"]);
                    file.Rate = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate"]);
                    fileList.Add(file);
                }
                grcStandardRateAll.DataSource = fileList;
            }
        }
        private void SearchRateArea()
        {
            grcArea.DataSource = null;
            List<StandardRateArea> fileList = new List<StandardRateArea>();
            //string sql = string.Format("EXEC up_XHX_StandardRateByArea_R '{0}'", CommonHandler.GetComboBoxSelectedValue(cboProject).ToString());
            DataSet ds = webService.SearchRateAllByArea(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    StandardRateArea file = new StandardRateArea();
                    file.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectName"]);
                    file.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    //file.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    file.InspectionStandardName = Convert.ToString(ds.Tables[0].Rows[i]["InspectionStandardName"]);

                    file.Rate_01_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_01_YES"]);
                    file.Rate_01_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_01_NO"]);
                    //file.Rate_01_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_01_NotNovled"]);

                    file.Rate_02_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_02_YES"]);
                    file.Rate_02_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_02_NO"]);
                    //file.Rate_02_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_02_NotNovled"]);

                    file.Rate_03_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_03_YES"]);
                    file.Rate_03_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_03_NO"]);
                    //file.Rate_03_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_03_NotNovled"]);

                    file.Rate_04_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_04_YES"]);
                    file.Rate_04_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_04_NO"]);
                    //file.Rate_04_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_04_NotNovled"]);

                    file.Rate_05_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_05_YES"]);
                    file.Rate_05_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_05_NO"]);
                    //file.Rate_05_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_05_NotNovled"]);

                    file.Rate_06_YES = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_06_YES"]);
                    file.Rate_06_NO = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_06_NO"]);
                    //file.Rate_06_NotNovled = Convert.ToInt32(ds.Tables[0].Rows[i]["Rate_06_NotNovled"]);

                    
                    file.Rate_01 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_01"]);
                    file.Rate_02 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_02"]);
                    file.Rate_03 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_03"]);
                    file.Rate_04 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_04"]);
                    file.Rate_05 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_05"]);
                    file.Rate_06 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Rate_06"]);
                    fileList.Add(file);
                }
                grcArea.DataSource = fileList;
            }
        }
     
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(grcStandardRateAll.DataSource!=null)
            CommonHandler.ExcelExport(grvStandardRateAll);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (grcArea.DataSource != null)
                CommonHandler.ExcelExport(bandedGridView1);
        }
        public override void SearchButtonClick()
        {
            if (CommonHandler.GetComboBoxSelectedValue(cboProject) == null)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择项目");
                return;
            }
            SearchRateAll();
            SearchRateArea();
        }
        public override void InitButtonClick()
        {
            BindComBox.BindProject(cboProject);
            dataHandler = new XtraGridDataHandler<StandardRateAllDto>(grvStandardRateAll);
            CommonHandler.SetRowNumberIndicator(grvStandardRateAll);
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            return list;
        }
    }
}
