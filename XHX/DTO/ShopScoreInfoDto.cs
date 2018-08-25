using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.Common;

namespace XHX.DTO
{
    [Serializable]
    public class ShopScoreInfoDto : BufferColumnDto,IShopScoreInfoDto
    {
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IShopScoreInfoDto that = data as IShopScoreInfoDto;
            if (that == null) return null;
            that.SubjectCode = this.SubjectCode;
            return data;
        }
        public string SubjectCode
        {
            get;
            set;
        }
        public int SubjectOrderNO
        { get; set; }
        String _checkPoint;

        public String CheckPoint
        {
            get { return _checkPoint; }
            set { _checkPoint = value; }
        }
        public string Order
        {
            get;
            set;
        }
    }
    public interface IShopScoreInfoDto
    {
        string SubjectCode { get; set; }
    }
    [Serializable]
    public class ShopScoreBodyDto : TwoLevelColumnData, IShopScoreInfoDto
    {
        public string SubjectCode
        {
            get;
            set;
        }
        public override DynamicData CopyKeyMembers(DynamicData data)
        {
            IShopScoreInfoDto that = data as IShopScoreInfoDto;
            if (that == null) return null;
            that.SubjectCode = this.SubjectCode;
            return data;
        }

        public override bool IsSameRow(BufferColumnDto dto)
        {
            IShopScoreInfoDto that = dto as IShopScoreInfoDto;
            if (that == null) return false;
            return this.SubjectCode.Equals(that.SubjectCode);
        }
    }
}
