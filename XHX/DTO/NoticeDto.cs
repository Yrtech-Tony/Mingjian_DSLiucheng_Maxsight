using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    //公告DTO
    public class NoticeDto
    {
        public string NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeContent { get; set; }
        public string InUserID { get; set; }
        public DateTime InDateTime { get; set; }
        public string FileExist { get; set; }//是否存在文件
        public char StatusType { get; set; }

    }
}
