using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    public class ShopReportDto
    {
        public string ProjectCode { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string AreaName { get; set; }
        public string SalesContant { get; set; }
        public string ShopScore { get; set; }
        public string SmallAreaScore { get; set; }
        public string BigAreaScore { get; set; }
        public string AllScore { get; set; }
        public string OrderNO_Area { get; set; }
        public string OrderNO_All { get; set; }
        public string MustLoss { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public List<ShopCharterScoreInfoDto> ShopCharterScoreInfoDtoList { get; set; }
        public List<ShopSubjectScoreInfoDto> ShopSubjectScoreInfoDtoList { get; set; }
        public List<BDCORRepScoreInfoDto> BDCORRepScoreInfoDtoList { get; set; }
        public List<ShopSubjectScoreInfo_BDCOrRepDto> BDCShopSubjectScoreInfoList { get; set; }

        public List<SaleContantScoreInfoDto> SaleContantScoreInfoList { get; set; }
        public List<SaleContantScoreInfo_AreaDto> SaleContantScoreInfo_AreaList { get; set; }
        public List<SaleContantCharterScoreInfoDto> SaleContantCharterScoreInfoDtoList { get; set; }
        public List<SaleAreaCharterScoreDto> SaleAreaCharterScoreDtoList { get; set; }
        public List<SaleContantSubjectScoreDto> SaleContantSubjectScoreDtoList { get; set; }
        #region Old
        public ShopChapterScoreDto23To29 ShopChapterScoreDto23To29 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AllScoreDto26> AllScoreDtoList26 { get; set; }
        public List<AllScoreDto31> AllScoreDtoList31 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AllScoreSumDto> AllScoreSumDtoList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AllShopScoreDto11> AllShopScoreDtoList11 { get; set; }
        public List<AllShopScoreDto16> AllShopScoreDtoList16 { get; set; }

        /// <summary>
        /// 服务现场审核得分率 List
        /// </summary>
        public List<ChaptersScoreDto27To30> ChaptersScoreDtoList27To30 { get; set; }
        public List<ChaptersScoreDto32To35> ChaptersScoreDtoList32To35 { get; set; }


        ///// <summary>
        ///// 经销商得分明细 List
        ///// </summary>
        //public List<LinkScoreDto> LinkScoreDtoList { get; set; }

        /// <summary>
        /// 指标得分详情 List
        /// </summary>
        public List<SubjectsScoreDto> SubjectsScoreDtoList { get; set; }
        #endregion
    }
    public class ShopCharterScoreInfoDto
    {
        public string CharterCode { get; set; }
        public string ShopScore { get; set; }
        public string SmallScore { get; set; }
        public string BigScore { get; set; }
        public string AllScore { get; set; }
    }
    public class ShopSubjectScoreInfoDto
    {
        public string SubjectCode { get; set; }
        public string CheckPoint { get; set; }
        public string Score { get; set; }
        public string LossDesc { get; set; }
        public string Remark { get; set; }
    }
    public class BDCORRepScoreInfoDto
    {
        public string Score { get; set; }
        public string SaleName { get; set; }
        public string SmallAreaScore { get; set; }
        public string BigAreaScore { get; set; }
        public string AllScore { get; set; }
        public string SalesType { get; set; }
    }
    public class ShopSubjectScoreInfo_BDCOrRepDto
    {
        public string SubjectCode { get; set; }
        public string CheckPoint { get; set; }
        public string Score { get; set; }
        public string LossDesc { get; set; }
        public string Remark { get; set; }

    }

    public class SaleContantScoreInfoDto
    {
        public string SaleName { get; set; }
        public string Score { get; set; }
    }
    public class SaleContantScoreInfo_AreaDto
    {
        public string SmallAreaScore { get; set; }
        public string BigAreaScore { get; set; }
        public string AllScore { get; set; }
    }
    public class SaleContantCharterScoreInfoDto
    {
        public string CharterCode { get; set; }
        public string SaleName { get; set; }
        public string Score { get; set; }
    }
    public class SaleAreaCharterScoreDto
    {
        public string CharterCode { get; set; }
        public string SmallCharterScore { get; set; }
        public string BigCharterScore { get; set; }
        public string AllCharterScore { get; set; }
    }
    public class SaleContantSubjectScoreDto
    {
        public string SubjectCode { get; set; }
        public string SaleName { get; set; }
        public string Score { get; set; }
        public string Remark { get; set; }

    }
}
