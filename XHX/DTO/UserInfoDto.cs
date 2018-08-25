using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.DTO
{
    public class UserInfoDto
    {
        public string UserID { get; set; }
        public string PSW { get; set; }
        public string RoleType { get; set; }
        public string UserName { get; set; }
        public string InUserID { get; set; }
        public bool IsNetWork { get; set; }
        public string MacAddress { get; set; }

        private char _statusType = StatusTypes.NONE;
        public char StatusType { get { return _statusType; } set { _statusType = value; } }
    }
}
