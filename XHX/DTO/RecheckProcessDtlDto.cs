using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
   public class RecheckProcessDtlDto
    {
       public string ProjectCode { get; set; }
       public string ShopCode { get; set; }
       public string ShopName { get; set; }
       public string StepStartUserName { get; set; }
       public string StepApplyStartUserName { get; set; }
       public string StepPhotoUserName { get; set; }
       public string StepFileUserName { get; set; }
       public string StepCrossUserName { get; set; }
       public string StepRecheck1UserName { get; set; }
       public string StepRecheck1ModifyUserName { get; set; }
       public DateTime? StepStartDate { get; set; }
       public DateTime? StepApplyStartDate { get; set; }
       public DateTime? StepPhotoDate { get; set; }
       public DateTime? StepFileDate { get; set; }
       public DateTime? StepCrossDate { get; set; }
       public DateTime? StepRecheck1Date { get; set; }
       public DateTime? StepRecheck1ModifyDate { get; set; }
    }
}
