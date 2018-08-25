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
    public partial class AnswerErrorData : BaseForm
    {
        localhost.Service webService = new localhost.Service();
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        public AnswerErrorData()
        {
            InitializeComponent();
            InitData();
            CommonHandler.SetRowNumberIndicator(grvReCheckDtl);
            grcReCheckDtl.DataSource = new List<ReCheckDtlDto>();
            selection = new GridCheckMarksSelection(grvReCheckDtl);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }
        private void InitData()
        {
            BindComBox.BindProject(cboProject);
            BindErrorType();

        }
        private void BindErrorType()
        {
            List<ExamTypeDto> list = new List<ExamTypeDto>();
            ExamTypeDto e1 = new ExamTypeDto();
            e1.ExamTypeCode = "1";
            e1.ExamTypeName = "体系得分和平均分不匹配";
            list.Add(e1);

            ExamTypeDto e2 = new ExamTypeDto();
            e2.ExamTypeCode = "2";
            e2.ExamTypeName = "模拟题登记了照片得分";
            list.Add(e2);

            ExamTypeDto e3 = new ExamTypeDto();
            e3.ExamTypeCode = "3";
            e3.ExamTypeName = "照片题登记了模拟得分";
            list.Add(e3);

            CommonHandler.SetComboBoxEditItems(cboErrorType, list, "ExamTypeName", "ExamTypeCode");
        }
        public override List<ButtonType> CreateButton()
        {
            List<ButtonType> list = new List<ButtonType>();
            list.Add(ButtonType.InitButton);
            list.Add(ButtonType.SearchButton);

            return list;
        }

        public override void InitButtonClick()
        {
            base.InitButtonClick();
            InitData();
        }
        public override void SearchButtonClick()
        {
            SearchRecheckDtl();
            
        }

        private void SearchRecheckDtl()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
            string errorType = CommonHandler.GetComboBoxSelectedValue(cboErrorType).ToString();

            List<AnswerErrorDataDto> reCheckDtlList = new List<AnswerErrorDataDto>();
            DataSet ds = new DataSet();

            if (errorType == "1")
            {
                ds = webService.SearchAnswerErrorScore_SubjectScore(projectCode);

            }
            else if (errorType == "2")
            {
                ds = webService.SearchAnswerErrorScore_MScore(projectCode);
            }
            else
            {
                ds = webService.SearchAnswerErrorScore_PhotoScore(projectCode);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AnswerErrorDataDto reCheckDtl = new AnswerErrorDataDto();
                    reCheckDtl.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                    reCheckDtl.SubjectCode = Convert.ToString(ds.Tables[0].Rows[i]["SubjectCode"]);
                    reCheckDtl.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    reCheckDtl.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);

                    reCheckDtlList.Add(reCheckDtl);
                }
                grcReCheckDtl.DataSource = reCheckDtlList;
            }
            else
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有数据");
                grcReCheckDtl.DataSource = null;
            }
        }

        private void grcReCheckDtl_DoubleClick(object sender, EventArgs e)
        {
            AnswerErrorDataDto answer = grvReCheckDtl.GetFocusedRow() as AnswerErrorDataDto;
            if (answer != null)
            {
                int order = 0;
                char checkType = '0';
                string examType = "";
                string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProject).ToString();
                string subjectCode = answer.SubjectCode;
                DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(projectCode, subjectCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    order = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderNO"]);
                    examType = Convert.ToString(ds.Tables[0].Rows[0]["SubjectTypeCodeExam"]);

                }
                DataSet dsCheckType = webService.SearchPassReCheckBySubjectCodeAndShopCode(projectCode, subjectCode, answer.ShopCode);
                if (dsCheckType.Tables[0].Rows.Count > 0)
                {
                    //checkType = Convert.ToChar(dsCheckType.Tables[0].Rows[0]["CheckType"]);
                }
                AnswerSubjectForm a = new AnswerSubjectForm(projectCode,
                    subjectCode,
                    answer.ShopCode, answer.ShopName, order, checkType, this.UserInfoDto, examType, "");
                a.ShowDialog();
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            string errorType = CommonHandler.GetComboBoxSelectedValue(cboErrorType).ToString();
            if (errorType == "1")
            {
                CommonHandler.ShowMessage(MessageType.Information, "操作不能执行");
                return;
            }
            List<AnswerErrorDataDto> list_subject = new List<AnswerErrorDataDto>();

            for (int i = 0; i < grvReCheckDtl.RowCount; i++)
            {
                if (grvReCheckDtl.GetRowCellValue(i, "CheckMarkSelection") != null && grvReCheckDtl.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    list_subject.Add(grvReCheckDtl.GetRow(i) as AnswerErrorDataDto);
                }
            }


            if (list_subject.Count == 0)
            {
                CommonHandler.ShowMessage(MessageType.Information, "没有选择任何执行数据");
                return;
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "确定要删除数据吗？") == DialogResult.Yes)
            {
                if (errorType == "2")
                {

                    foreach (AnswerErrorDataDto subject in list_subject)
                    {
                        webService.DeleteAnswerErrorScore_MScore(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), subject.ShopCode, subject.SubjectCode);
                    }

                }
                if (errorType == "3")
                {
                    foreach (AnswerErrorDataDto subject in list_subject)
                    {
                        webService.DeleteAnswerErrorScore_PhotoScore(CommonHandler.GetComboBoxSelectedValue(cboProject).ToString(), subject.ShopCode, subject.SubjectCode);
                    }

                }
            }

            SearchRecheckDtl();
            CommonHandler.ShowMessage(MessageType.Information, "删除完毕");
        }

        private void cboErrorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRecheckDtl();
        }
    }
}
