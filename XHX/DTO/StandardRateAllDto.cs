using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class StandardRateAllDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public int SeqNO { get; set; }
        public string InspectionStandardName { get; set; }
        public string CheckOptionCode { get; set; }
        public string CheckOptionName { get; set; }
        public int Count { get; set; }
        public decimal Rate { get; set; }
        public int StandYes { get; set; }
        public int StandNO { get; set; }
        public int NotNovled { get; set; }
    }
}
