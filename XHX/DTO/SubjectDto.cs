using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class SubjectDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public string Implementation { get; set; }
        public string CheckPoint { get; set; }
        public string Desc { get; set; }
        public string AdditionalDesc { get; set; }
        public string InspectionDesc { get; set; }
        public string InspectionNeedFile { get; set; }
        public string Remark { get; set; }
        public int OrderNO { get; set; }
        public bool DelChk { get; set; }
        public Decimal? Score { get; set; }
        public Decimal? PhoteScore { get; set; }
        public Decimal? SimulationScore { get; set; }
        public string MemberType { get; set; }//01:销售顾问 02:接待人员

        public string ImageName { get; set; }
        public char StatusType { get; set; }
        public bool PassReCheck { get; set; } //是否通过复查
        public string ReCheckContent { get; set; }
        public bool CheckYesOrNO { get; set; } //是否复查过
        public DateTime AssessmentDate { get; set; } //考评日期
        public string LinkCode { get; set; }
        public string LinkName { get; set; }
        public decimal? FullScore { get; set; }
        public decimal? LowestScore { get; set; }
        public decimal? PhotoFullScore { get; set; }
        public decimal? PhotoLowestScore { get; set; }
        public string ChapterName { get; set; }
        public bool ScoreCheck { get; set; }
        public decimal? LastProjectScore { get; set; }

        public string SubjectTypeCode { get; set; }
        public string SubjectTypeCodeExam { get; set; }
        public bool SubjectDelChk { get; set; }//非本期检查题目
        public bool AddErrorChk { get; set; }//是否加入错误率计算

        public object AllCountry { get; set; }
        public object EastArea { get; set; }
        public object SouthArea { get; set; }
        public object WestArea { get; set; }
        public object NorthArea { get; set; }
        public bool AdminModifyChk { get; set; }
        
    }
}
