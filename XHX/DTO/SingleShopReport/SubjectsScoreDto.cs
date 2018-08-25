using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO.SingleShopReport
{
    /// <summary>
    /// 指标得分详情
    /// </summary>
    public class SubjectsScoreDto
    {
        /// <summary>
        /// 体系编号
        /// </summary>
        public string SubjectCode { get; set; }

        /// <summary>
        /// 满分
        /// </summary>
        public decimal FullScore { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// 失分说明
        /// </summary>
        public string LostDesc { get; set; }

        /// <summary>
        /// 照片名称
        /// </summary>
        public string PicName { get; set; }
    }
}
