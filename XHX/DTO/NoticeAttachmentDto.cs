using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class NoticeAttachmentDto
    {
        public string NoticeID { get; set; }
        public int SeqNO { get; set; }
        public string AttachName { get; set; }
        public string FilePath { get; set; }
        public char StatusType { get; set; }
        public bool FileExist { get; set; }
    }
}
