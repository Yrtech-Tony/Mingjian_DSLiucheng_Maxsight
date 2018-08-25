using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class SpecialCaseDto
    {
        public string SpecialCaseCode { get; set; }
        public string ProjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string SubjectCode { get; set; }
        public string Title { get; set; }
        public string ApplyDesc { get; set; }
        public string FinalAdvice { get; set; }
        public string FinalStatus { get; set; }
        public string ImageName { get; set; }
        public string ApplyId { get; set; }
        public string ApplyDate { get; set; }
        public string ConfirmId { get; set; }
        public string ConfirmDate { get; set; }
        public DateTime IndateTime { get; set; }
        public string InUserID { get; set; }
        public string CheckPoint { get; set; }
        public bool NeedVICoConfirmChk { get; set; }
        public string VICoAdvice { get; set; }
        public char StatusType { get; set; }
    }
}
