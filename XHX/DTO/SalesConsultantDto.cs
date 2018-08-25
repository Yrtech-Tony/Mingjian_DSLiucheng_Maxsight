using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class SalesConsultantDto
    {
        public string SubjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ProjectCode { get; set; }
        public int SeqNO { get; set; }
        public string SalesConsultant { get; set; }
        public decimal? Score { get; set; }
        public bool Notinvolved { get; set; }
        public string LossDesc { get; set; }
        public string InUserId { get; set; }
        public string MemberType { get; set; }
        public char StatusType { get; set; }
    }
}
