using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class FileAndPictureDto
    {
        public string ProjectCode { get; set; }
        public string SubjectCode { get; set; }
        public int SeqNO { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public char StatusType { get; set; }
    }
}
