using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    public class AllShopScoreDto11
    {
        /// <summary>
        /// 权重
        /// </summary>
        public string projectCode{ get; set; }

        /// <summary>
        /// 经销商代码
        /// </summary>
        public string ShopCode { get; set; }
        /// <summary>
        /// 经销商
        /// </summary>
        public decimal ScoreShop { get; set; }
        /// <summary>
        /// A:销售
        /// B:服务
        /// </summary>
        public string Type { get; set; }
    }
    public class AllShopScoreDto16
    {
        /// <summary>
        /// 权重
        /// </summary>
        public string projectCode { get; set; }

        /// <summary>
        /// 经销商代码
        /// </summary>
        public string ShopCode { get; set; }
        /// <summary>
        /// 经销商
        /// </summary>
        public decimal ScoreShop { get; set; }
        /// <summary>
        /// A:销售
        /// B:服务
        /// </summary>
        public string Type { get; set; }
    }
}
