using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    /// <summary>
    /// 经销商得分明细
    /// </summary>
    public class LinkScoreDto
    {
        public int CharterCode { get; set; }

        public string CharterName { get; set; }

        /// <summary>
        /// 二级指标编号
        /// </summary>
        public string LinkCode { get; set; }

        /// <summary>
        /// 二级指标名称
        /// </summary>
        public string LinkName { get; set; }

        /// <summary>
        /// 经销商
        /// </summary>
        public decimal ScoreShop { get; set; }

        /// <summary>
        /// 区域平均
        /// </summary>
        public decimal ScoreArea_AVG { get; set; }

        /// <summary>
        /// 区域最高
        /// </summary>
        public decimal ScoreArea_MAX { get; set; }

        /// <summary>
        /// 全国平均
        /// </summary>
        public decimal ScoreAll_AVG { get; set; }

        /// <summary>
        /// 全国最高
        /// </summary>
        public decimal ScoreAll_MAX { get; set; }
    }
}
