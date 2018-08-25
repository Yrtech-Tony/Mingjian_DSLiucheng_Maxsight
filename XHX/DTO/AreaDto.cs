using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class AreaDto
    {
        public AreaDto() { }
        public AreaDto(string areaCode, string areaName, string upperAreaCode, string areaTypeCode)
        {
            AreaCode = areaCode;
            AreaName = areaName;
            UpperAreaCode = upperAreaCode;
            AreaTypeCode = areaTypeCode;
        }

        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public string UpperAreaCode { get; set; }
        public string AreaTypeCode { get; set; }
        public char StatusType { get; set; }
    }
}
