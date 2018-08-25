using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{
    [Serializable]
    public class SalesConsultantReportDto : BufferColumnDto, ISalesConsultantReportDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            ISalesConsultantReportDto that = data as ISalesConsultantReportDto;
            if (that == null) return null;
            that.ShopCode = this.ShopCode;
            that.ProjectCode = this.ProjectCode;
            that.SeqNO = this.SeqNO;
            that.SalesConsultant = this.SalesConsultant;
                
            return data;
        }
        public string ProjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string SeqNO { get; set; }
        public string SalesConsultant { get; set; }
        public string City { get; set; }
        public string GroupName { get; set; }
        public string AreaCode { get; set; }
    }
    public interface ISalesConsultantReportDto
    {
        string ProjectCode { get; set; }
        string ShopCode { get; set; }
        string SeqNO { get; set; }
        string SalesConsultant { get; set; }
    }
    [Serializable]
    public class SalesConsultantReportBodyDto : TwoLevelColumnData, ISalesConsultantReportDto
    {
        public string ProjectCode { get; set; }
        public string ShopCode { get; set; }
        public string SeqNO { get; set; }
        public string SalesConsultant { get; set; }

        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            ISalesConsultantReportDto that = data as ISalesConsultantReportDto;
            if (that == null) return null;
            that.ProjectCode =this.ProjectCode;
            that.ShopCode = this.ShopCode;
            that.SeqNO = this.SeqNO;
            that.SalesConsultant = this.SalesConsultant;
            return data;
        }

        public override bool IsSameRow(BufferColumnDto dto)
        {
            ISalesConsultantReportDto that = dto as ISalesConsultantReportDto;
            if (that == null) return false;
            return this.ProjectCode.Equals(that.ProjectCode)&&
                this.ShopCode.Equals(that.ShopCode) &&
                this.SeqNO.Equals(that.SeqNO) &&
                this.SalesConsultant.Equals(that.SalesConsultant);
        }
    }
}
