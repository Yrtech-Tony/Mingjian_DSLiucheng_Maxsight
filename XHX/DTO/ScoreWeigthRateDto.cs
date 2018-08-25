using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{

       public interface IScoreWeigthRateDto
       {
           string ChapterCode { get; set; }
       }
       [Serializable]
       public class ScoreWeigthRateDto : BufferColumnDto, IScoreWeigthRateDto
       {
           public override DynamicData CopyKeyMembers(DynamicData data)
           {
               IScoreWeigthRateDto that = data as IScoreWeigthRateDto;
               if (that == null) return null;
               that.ChapterCode = this.ChapterCode;
               return data;
           }
           public string ChapterCode
           {
               get;
               set;
           }
           public string ChapterName
           {
               get;
               set;
           }
           public string Order
           {
               get;
               set;
           }
       }
       public class ScoreWeigthBodayRateDto : TwoLevelColumnData, IScoreWeigthRateDto
       {
           public string ChapterCode
           {
               get;
               set;
           }
           public override DynamicData CopyKeyMembers(DynamicData data)
           {
               IScoreWeigthRateDto that = data as IScoreWeigthRateDto;
               if (that == null) return null;
               that.ChapterCode = this.ChapterCode;
               return data;
           }
           public override bool IsSameRow(BufferColumnDto dto)
           {
               IScoreWeigthRateDto that = dto as IScoreWeigthRateDto;
               if (that == null) return false;
               return this.ChapterCode.Equals(that.ChapterCode);
           }
       }
    
}
