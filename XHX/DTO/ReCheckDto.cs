using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XHX.DTO
{
    public class ReCheckDto
    {
        public string SubjectCode { get; set; }
        public string CheckPoint { get; set; }
        public decimal Score { get; set; }
        public bool ReCheckChk { get; set; }

        [DefaultValue(StatusTypes.NONE)]
        public char StatusType { get; set; }
    }
}
