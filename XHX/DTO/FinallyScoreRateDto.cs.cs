using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{
    public interface IFinallyScoreRateDto
    {
        string ChapterCode { get; set; }
    }
    public class FinallyScoreRateDto : BufferColumnDto, IFinallyScoreRateDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IFinallyScoreRateDto that = data as IFinallyScoreRateDto;
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
        public decimal Weight
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
    public class FinallyScoreRateBodyDto : TwoLevelColumnData, IFinallyScoreRateDto
    {
        public string ChapterCode
        {
            get;
            set;
        }
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IFinallyScoreRateDto that = data as IFinallyScoreRateDto;
            if (that == null) return null;
            that.ChapterCode = this.ChapterCode;
            return data;
        }
        public override bool IsSameRow(BufferColumnDto dto)
        {
            IFinallyScoreRateDto that = dto as IFinallyScoreRateDto;
            if (that == null) return false;
            return this.ChapterCode.Equals(that.ChapterCode);
        }
    }

    public class FinallyScoreRateRankDto
    {
        public string ProjectCode { get; set; }
        public string ShopName { get; set; }
        public decimal Rate { get; set; }
        public int RANK { get; set; }
    }
}
