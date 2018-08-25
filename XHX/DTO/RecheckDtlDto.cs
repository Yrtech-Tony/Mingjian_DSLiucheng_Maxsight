using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ReCheckDtlDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public string CheckPoint { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ReCheckType { get; set; }
        public string ErrorType { get; set; }
        public string ErrorTypeName { get; set; }
        public string Remark { get; set; }
        public string InUserID { get; set; }
        public bool Selected { get; set; }
        public DateTime InDateTime { get; set; }
    }
}
