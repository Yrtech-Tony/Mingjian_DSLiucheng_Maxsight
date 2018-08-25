using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ShopSubjectExamTypeDto
    {
        public string ProjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ExamTypeCode { get; set; }
        public char StatusType { get; set; }
        public string CheckUserId {get;set;}
        public DateTime? CheckDate { get; set; }
    }
}
