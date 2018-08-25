using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
   public class AnswerStatusTypeCodeDto
    {
       public string ProjectCode { get; set; }
       public string ShopCode { get; set; }
       public string ShopName { get; set; }
       public string StatusCode { get; set; }
       public string StatusName { get; set; }
       public string RecheckRegister { get; set; }
       public string RecheckProcess { get; set; }
       public string ReCheckFinish { get; set; }
       public string ModifyFinish { get; set; }
       public string SecondFinish { get; set; }
       public string ThirdFinish { get; set; }
       public bool SpecialCaseChk { get; set; }
    }
}
