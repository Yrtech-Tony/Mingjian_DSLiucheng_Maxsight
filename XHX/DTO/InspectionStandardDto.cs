using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XHX.DTO
{
    public class InspectionStandardDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public int SeqNO { get; set; }
        public string InspectionStandardName { get; set; }
        public char StatusType { get; set; }
        public string UserID { get; set; }
        public bool Checked { get; set; } //Add By ChaiYunChun Don't Delete~
        public string CheckOptionCode { get; set; } //Add By ChaiYunChun Don't Delete~
        public string FileName { get; set; }
        public string FileType { get; set; }
        public bool Selected { set; get; }
        public string FilePath { get; set; } //图片上传时的临时图片路径 Add By ChaiYunChun Don't Delete~
        //public byte[] ImageContet { get; set; }
        public byte[] ImageContent { get; set; }
        public string FileExtend { get; set; }
    }
}
