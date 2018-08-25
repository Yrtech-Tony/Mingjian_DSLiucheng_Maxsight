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
    public partial class ScoreSet : Form
    {
        #region :Field
        localhost.Service service = new localhost.Service();
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        XtraGridDataHandler<ScoreSetDto> dataHandler = null;
        #endregion
        #region :Constructor
        private string _projectCode;
        private string _subjectCode;
        private string _userID;
        public ScoreSet(string projectCode,string subjectCode,string userID)
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            //初始化Button
            btnSave.Enabled = false;
            btnAddRow.Enabled = false;
            btnDeleteRow.Enabled = false;

            //初始化Grid样式
            CommonHandler.SetRowNumberIndicator(grvScoreSet);

            dataHandler = new XtraGridDataHandler<ScoreSetDto>(grvScoreSet);
            grcScoreSet.DataSource = new List<ScoreSetDto>();
            selection = new GridCheckMarksSelection(grvScoreSet);
            selection.CheckMarkColumn.VisibleIndex = 0;

            this._projectCode = projectCode;
            this._subjectCode = subjectCode;
            this._userID = userID;

            SearchScoreSet(_projectCode, _subjectCode);


        }
        #endregion
        #region :Private Mothod

        private void SearchScoreSet(string projectCode, string subjectCode)
        {
            List<ScoreSetDto> scoreSetList = new List<ScoreSetDto>();

            DataSet ds = service.SearchScoreSet(projectCode, subjectCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ScoreSetDto scoreDto = new ScoreSetDto();
                    scoreDto.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    scoreDto.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    scoreDto.SeqNO = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNO"]);
                    scoreDto.Score = Convert.ToDecimal(ds.Tables[0].Rows[i]["Score"]);
                    scoreDto.InUserID = Convert.ToString(ds.Tables[0].Rows[i]["InUserID"]);
                    scoreDto.InDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["InDateTime"]);
                    scoreSetList.Add(scoreDto);
                }
            }
            grcScoreSet.DataSource = scoreSetList;

            btnSave.Enabled = true;
            btnAddRow.Enabled = true;
            if (grvScoreSet.DataRowCount > 0)
                btnDeleteRow.Enabled = true;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要保存吗？") == DialogResult.Yes)
            {
                List<ScoreSetDto> scoretList = dataHandler.DataList;
                foreach (ScoreSetDto score in scoretList)
                {
                    if (score.StatusType == 'D')
                    {
                        service.DeleteScoreSet(score.ProjectCode, score.SubjectCode, score.SeqNO);
                    }
                    else if (score.StatusType == 'I')
                    {
                        service.InsertScoreSet(score.ProjectCode, score.SubjectCode, score.SeqNO, score.Score, score.NotInvolved, score.InUserID,DateTime.Now);
                    }

                }
                SearchScoreSet(_projectCode, _subjectCode);
            }
            else
            {
                return;
            }
            
            CommonHandler.ShowMessage(MessageType.Information, "保存完毕");
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            ScoreSetDto score = new ScoreSetDto();
            List<ScoreSetDto> scoreList = grcScoreSet.DataSource as List<ScoreSetDto>;
            int seqNO = 0;
            if (scoreList == null || scoreList.Count == 0)
            {
                score.SeqNO = 1;
            }
            else
            {

                foreach (ScoreSetDto sco in scoreList)
                {
                    if (sco.SeqNO > seqNO)
                    {
                        seqNO = Convert.ToInt32(sco.SeqNO);

                    }
                }
            }
            score.SeqNO = seqNO + 1;
            score.NotInvolved = true;
            score.InUserID = this._userID;
            score.InDateTime = DateTime.Now;
            score.ProjectCode = this._projectCode;
            score.SubjectCode = this._subjectCode;
            dataHandler.AddRow(score);
            btnDeleteRow.Enabled = true;
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            dataHandler.DelCheckedRow(selection.CheckMarkColumn);

            if (grvScoreSet.DataRowCount == 0)
                btnDeleteRow.Enabled = false;

            selection.ClearSelection();
        }

   
        
    }
}
