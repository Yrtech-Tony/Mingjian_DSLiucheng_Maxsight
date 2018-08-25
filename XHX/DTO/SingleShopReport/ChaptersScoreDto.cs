using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    /// <summary>
    /// 服务现场审核得分率
    /// </summary>
    public class ChaptersScoreDto27To30
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        public int CharterCode { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string CharterName { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public decimal Weight { get; set; }



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
        public string Type { get; set; }
    }
    public class ChaptersScoreDto32To35
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        public int CharterCode { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string CharterName { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public decimal Weight { get; set; }



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
        public string Type { get; set; }
    }
}
