using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class ShopDto
    {
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        //public string AreaCode { get; set; }
        //public string AreaName { get; set; }
        public string SaleSmall { get; set; }
        public string SaleBig { get; set; }
        public string AfterSmall { get; set; }
        public string AfterBig { get; set; }
        public bool UseChk { get; set; }
        public char StatusType { get; set; }
        public string UserName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string SalesOrAftersales { get; set; }
        public string GroupName { get; set; }
        public string CarType { get; set; }
    }
}
