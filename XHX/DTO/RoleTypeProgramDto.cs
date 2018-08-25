using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class RoleTypeProgramDto
    {
        public string RoleTypeCode { get; set; }
        public string ProgramCode { get; set; }
        public string InUserID { get; set; }
        public int RoleTypeProgramID { get; set; }
        public char StatusType { get; set; }
        public DateTime InDateTime { get; set; }
    }
}
