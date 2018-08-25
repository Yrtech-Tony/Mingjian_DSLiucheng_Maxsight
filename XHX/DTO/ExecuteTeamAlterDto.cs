using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ExecuteTeamAlterDto
    {
        public string SubjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ProjectCode { get; set; }
        public string OrgScore { get; set; }
        public string ReCheckTypeCode { get; set; }
        public string ReCheckType { get; set; }
        public bool PassReCheck { get; set; }
        public string ReCheckContent { get;set;}
        public bool? AgreeCheck { get; set; }
        public string AgreeReason { get; set; }
        public decimal? NewScore { get; set; }
        public string LastConfirm { get; set; }
        public string ConfirmReason { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public char StatusType { get; set; }
        public string StatusCode { get; set; } //当前的状态
    }
}

