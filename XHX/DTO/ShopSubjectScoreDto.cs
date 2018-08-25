using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
   public class ShopSubjectScoreDto
    {
        public string ShopCode { get; set; }
        public string SubjectCode { get; set; }
        public string Score { get; set; }

        public ShopSubjectScoreDto() { }
        public ShopSubjectScoreDto(string shopCode, string subjectCode, string score)
        {
            ShopCode = shopCode;
            SubjectCode = subjectCode;
            Score = score;
        }
    }
}
