using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
  public class AnswerLogDto
    {
      public string SubjectCode { get; set; }
      public decimal? Score { get; set; }
      public decimal? LastScore { get; set; }
      public DateTime? ScoreModifiDateTime { get; set; }
      public DateTime? LastModiDateTime { get; set; }
      public DateTime? FirstscoreModifiDateTime { get; set; }
      public decimal? Firstscore { get; set; }
      public decimal? Secondscore { get; set; }
      //public decimal? LastCheckScore { get; set; }
      public DateTime? SecondscoreModifiDateTime { get; set; }
      //public string LastCheckDesc { get; set; }
      public string ShopCode { get; set; }
      public string ShopName { get; set; }

      
    }
}
