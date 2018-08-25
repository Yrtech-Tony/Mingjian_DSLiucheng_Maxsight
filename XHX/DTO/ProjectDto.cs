using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ProjectDto
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string InUserID { get; set; }
        public int OrderNO { get; set; }
        public char StatusType { get; set; }
    }
}
