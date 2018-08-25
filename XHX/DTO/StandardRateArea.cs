using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
   public class StandardRateArea
    {
       public string ProjectCode { get; set; }
       public string SubjectCode { get; set; }
       public string SeqNO { get; set; }
       public string InspectionStandardName { get; set; }
       public int Rate_01_YES { get; set; }
       public int Rate_01_NO { get; set; }
       public int Rate_01_NotNovled { get; set; }

       public int Rate_02_YES { get; set; }
       public int Rate_02_NO { get; set; }
       public int Rate_02_NotNovled { get; set; }

       public int Rate_03_YES { get; set; }
       public int Rate_03_NO { get; set; }
       public int Rate_03_NotNovled { get; set; }

       public int Rate_04_YES { get; set; }
       public int Rate_04_NO { get; set; }
       public int Rate_04_NotNovled { get; set; }

       public int Rate_05_YES { get; set; }
       public int Rate_05_NO { get; set; }
       public int Rate_05_NotNovled { get; set; }

       public int Rate_06_YES { get; set; }
       public int Rate_06_NO { get; set; }
       public int Rate_06_NotNovled { get; set; }

       public decimal Rate_01 { get; set; }
       public decimal Rate_02 { get; set; }
       public decimal Rate_03 { get; set; }
       public decimal Rate_04 { get; set; }
       public decimal Rate_05 { get; set; }
       public decimal Rate_06 { get; set; }
    }
}
