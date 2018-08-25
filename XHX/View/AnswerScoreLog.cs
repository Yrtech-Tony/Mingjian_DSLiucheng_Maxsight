using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;

namespace XHX.View
{
    public partial class AnswerScoreLog : BaseForm
    {
        #region Field
        localhost.Service service = new localhost.Service();
        #endregion
        #region Contructor
        public AnswerScoreLog()
        {
            InitializeComponent();
            InitView();
            InitData();
        }
        #endregion
        #region Private Method
        private void InitData()
        {
            XHX.Common.BindComBox.BindProject(cboProjects);
            grcAnswerLog.DataSource = new List<AnswerScoreLog>();
            CommonHandler.SetRowNumberIndicator(grvAnswerLog);
        }
        private void InitView()
        {
            btnShopCode.Text = "";
            txtShopName.Text = "";
        }
        private void SearchAnswerLog()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            string shopCode = btnShopCode.Text;
            List<AnswerLogDto> list = new List<AnswerLogDto>();
            DataSet ds = service.SearchAnswerLog(projectCode, shopCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    AnswerLogDto answer = new AnswerLogDto();
                    answer.ShopCode = Convert.ToString(ds.Tables[0].Rows[j]["ShopCode"]);
                    answer.ShopName = Convert.ToString(ds.Tables[0].Rows[j]["ShopName"]);
                    answer.SubjectCode = Convert.ToString(ds.Tables[0].Rows[j]["SubjectCode"]);
                    if (ds.Tables[0].Rows[j]["Score"] == DBNull.Value)
                    {
                        answer.Score = null;
                    }
                    else
                    {
                        answer.Score = Convert.ToDecimal(ds.Tables[0].Rows[j]["Score"]);
                    }
                    if (ds.Tables[0].Rows[j]["ScoreModifiDateTime"] == DBNull.Value)
                    {
                        answer.ScoreModifiDateTime = null;
                    }
                    else
                    {
                        answer.ScoreModifiDateTime = Convert.ToDateTime(ds.Tables[0].Rows[j]["ScoreModifiDateTime"]);
                    }
                    if (ds.Tables[0].Rows[j]["LastModiDateTime"] == DBNull.Value)
                    {
                        answer.LastModiDateTime = null;
                    }
                    else
                    {
                        answer.FirstscoreModifiDateTime = Convert.ToDateTime(ds.Tables[0].Rows[j]["LastModiDateTime"]);
                    }
                    if (ds.Tables[0].Rows[j]["LastScore"] == DBNull.Value)
                    {
                        answer.LastScore = null;
                    }
                    else
                    {
                        answer.LastScore = Convert.ToDecimal(ds.Tables[0].Rows[j]["LastScore"]);
                    }
                    if (ds.Tables[0].Rows[j]["Secondscore"] == DBNull.Value)
                    {
                        answer.Secondscore = null;
                    }
                    else
                    {
                        answer.Secondscore = Convert.ToDecimal(ds.Tables[0].Rows[j]["Secondscore"]);
                    }
                    if (ds.Tables[0].Rows[j]["SecondscoreModifiDateTime"] == DBNull.Value)
                    {
                        answer.SecondscoreModifiDateTime = null;
                    }
                    else
                    {
                        answer.SecondscoreModifiDateTime = Convert.ToDateTime(ds.Tables[0].Rows[j]["SecondscoreModifiDateTime"]);
                    }
                    list.Add(answer);
                }
                grcAnswerLog.DataSource = list;
            }

        }

        #endregion
        #region Event
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
        #endregion
        #region Common Button
        public override void InitButtonClick()
        {
            InitView();
            InitData();
        }
        public override void ExcelDownButtonClick()
        {
            CommonHandler.ExcelExport(grvAnswerLog);
        }
        #endregion
        public override void SearchButtonClick()
        {
            SearchAnswerLog();

        }
        
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);
            list.Add(ButtonType.ExcelDownButton);
            return list;
        }

        private void grvAnswerLog_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column == gcScore || e.Column == gcLastScore || e.Column == gcSecondRecheckScore )
                &&(e.DisplayText.ToString()=="9999"||e.DisplayText=="9999.00"))
            {
                e.DisplayText = ".";
            }
        }

        
    }
}
