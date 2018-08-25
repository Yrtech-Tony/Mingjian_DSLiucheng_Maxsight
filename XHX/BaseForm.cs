using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO;

namespace XHX
{
    public partial class BaseForm : UserControl
    {
        //localhost.Service service = new XHX.localhost.Service();
        private UserInfoDto _userInfoDto = null;
        public UserInfoDto UserInfoDto
        {
            get { return _userInfoDto; }
            set { _userInfoDto = value; }
        }

        public BaseForm()
        {
            InitializeComponent();
           // service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            //CommonHandler.DBConnect();
        }
        MainForm mainForm;
        public MainForm CSParentForm
        {
            set { mainForm = value; }
            get { return mainForm; }
        }
        public virtual void SearchButtonClick() { }
        public virtual void SaveButtonClick() { }
        public virtual void ConfirmButtonClick() { }
        public virtual void DeleteButtonClick() { }
        public virtual void AddButtonClick() { }
        public virtual void AddRowButtonClick() { }
        public virtual void DeleteRowButtonClick() { }
        public virtual void InitButtonClick() { }
        public virtual void ExcelDownButtonClick() { }
        public virtual void NoteButtonClick() { }
        public virtual List<ButtonType> CreateButton() { return null; }

        public enum ButtonType
        {
            SearchButton,
            DeleteButton,
            SaveButton,
            ConfirmButton,
            AddButton,
            AddRowButton,
            DeleteRowButton,
            ExcelDownButton,
            InitButton,
            NoteButton
        }
    }
}
