using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class LinkDto
    {
        public string CharterCode { get; set; }
        public string CharterName { get; set; }
        public string LinkCode { get; set; }
        public string LinkName { get; set; }
        public string LinkContent { get; set; }
        public string InUserID { get; set; }
        public DateTime InDateTime { get; set; }
        public int OrderNO { get; set; }
        public char StatusType { get; set; }
    }
}
