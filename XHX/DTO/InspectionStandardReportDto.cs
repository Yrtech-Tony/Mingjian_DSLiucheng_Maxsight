using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{
    [Serializable]
    public class InspectionStandardReportDto : BufferColumnDto, IInspectionStandardReportDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IInspectionStandardReportDto that = data as IInspectionStandardReportDto;
            if (that == null) return null;
            that.SubjectCodeSeqNO = this.SubjectCodeSeqNO;
            return data;
        }
        public string SubjectCodeSeqNO
        {
            get;
            set;
        }
        public string SubjectCode { get; set; }
        public string InspectionStandardName
        {
            get;
            set;
        }
        public int SeqNO { get; set; }

    }
    public interface IInspectionStandardReportDto
    {
        string SubjectCodeSeqNO { get; set; }
    }
    [Serializable]
    public class InspectionStandardReportBodyDto : TwoLevelColumnData, IInspectionStandardReportDto
    {
        public string SubjectCodeSeqNO
        {
            get;
            set;
        }
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IInspectionStandardReportDto that = data as IInspectionStandardReportDto;
            if (that == null) return null;
            that.SubjectCodeSeqNO = this.SubjectCodeSeqNO;

            return data;
        }

        public override bool IsSameRow(BufferColumnDto dto)
        {
            IInspectionStandardReportDto that = dto as IInspectionStandardReportDto;
            if (that == null) return false;
            return this.SubjectCodeSeqNO.Equals(that.SubjectCodeSeqNO);
        }
    }
}
