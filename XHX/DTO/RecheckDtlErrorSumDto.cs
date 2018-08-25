using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
   public class RecheckDtlErrorSumDto
    {
       public string ProjectCode { get; set; }
       public string ShopCode { get; set; }
       public string ShopName { get; set; }
       public string ScoreError { get; set; }
       public string DescError { get; set; }
       public string PicLossError { get; set; }
       public string PicLazyError { get; set; }
       public string PicUploadError { get; set; }
       public string StanderdError { get; set; }
    }
}
