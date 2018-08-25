using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{
    public interface IScoreRateForChapterDto
    {
        string ChapterCode { get; set; }
    }
    [Serializable]
    public class ScoreRateForChapterDto : BufferColumnDto, IScoreRateForChapterDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IScoreRateForChapterDto that = data as IScoreRateForChapterDto;
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
    public class ScoreRateForChapterBodyDto : TwoLevelColumnData, IScoreRateForChapterDto
    {
        public string ChapterCode
        {
            get;
            set;
        }
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IScoreRateForChapterDto that = data as IScoreRateForChapterDto;
            if (that == null) return null;
            that.ChapterCode = this.ChapterCode;
            return data;
        }
        public override bool IsSameRow(BufferColumnDto dto)
        {
            IScoreRateForChapterDto that = dto as IScoreRateForChapterDto;
            if (that == null) return false;
            return this.ChapterCode.Equals(that.ChapterCode);
        }
    }

    public interface IScoreRateForLinkDto
    {
        string LinkCode { get; set; }
    }
    [Serializable]
    public class ScoreRateForLinkDto : BufferColumnDto, IScoreRateForLinkDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IScoreRateForLinkDto that = data as IScoreRateForLinkDto;
            if (that == null) return null;
            that.LinkCode = this.LinkCode;
            return data;
        }
        public string LinkCode
        {
            get;
            set;
        }
        public string LinkName
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
    public class ScoreRateForLinkBodyDto : TwoLevelColumnData, IScoreRateForLinkDto
    {
        public string LinkCode
        {
            get;
            set;
        }
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IScoreRateForLinkDto that = data as IScoreRateForLinkDto;
            if (that == null) return null;
            that.LinkCode = this.LinkCode;
            return data;
        }
        public override bool IsSameRow(BufferColumnDto dto)
        {
            IScoreRateForLinkDto that = dto as IScoreRateForLinkDto;
            if (that == null) return false;
            return this.LinkCode.Equals(that.LinkCode);
        }
    }
}
