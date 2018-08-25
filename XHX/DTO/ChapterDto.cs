using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ChapterDto
    {
        public string ProjectCode { get; set; }
        public string CharterCode { get; set; }
        public string CharterName { get; set; }
        public string CharterContent { get; set; }
        public int OrderNo { get; set; }
        public string InUserID { get; set; }
        public DateTime InDateTime { get; set; }
        public char StatusType { get; set; }
        public decimal Weight { get; set; }

    }
}
