using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    [Serializable]
    public class ScoreSetDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public int? SeqNO { get; set; }
        public decimal? Score { get; set; }
        public string InUserID { get; set; }
        public DateTime? InDateTime { get; set; }
        public char StatusType { get; set; }
        public Boolean? NotInvolved { get; set; }
    }
}
