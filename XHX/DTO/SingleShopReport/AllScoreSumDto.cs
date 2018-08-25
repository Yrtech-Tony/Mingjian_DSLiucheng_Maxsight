using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    public class AllScoreSumDto
    {

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
