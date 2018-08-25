using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class SubjectTypeDto
    {
        public string SubjectTypeCode { get; set; }
        public string SubjectTypeName { get; set; }
        public SubjectTypeDto(string _subjectTypeCode, string _subjectTypeName)
        {
            this.SubjectTypeCode = _subjectTypeCode;
            this.SubjectTypeName = _subjectTypeName;
        }
        public SubjectTypeDto()
        { 
        
        }
    }
}
