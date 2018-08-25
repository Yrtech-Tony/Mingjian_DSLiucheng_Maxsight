using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace XHX
{
    public partial class MessageForm : XtraForm
    {
        public MessageForm()
        {
            InitializeComponent();

            this.Text = "提示";
        }

        public MessageForm(MessageType messageType, string message):this()
        {
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);

            if (messageType == MessageType.Information)
            {
                picMessage.Image = XHX.Properties.Resources.Information;
                btnCancel.Visible = false;
                btnOK.Visible = true;
            }
            else if (messageType == MessageType.Confirm)
            {
                picMessage.Image = XHX.Properties.Resources.Warning;
                btnCancel.Text = "No";
                btnCancel.Visible = true;
                btnOK.Text = "Yes";
                btnOK.Visible = true;
            }

            txtMessage.Text = message;

            picMessage.BackColor = Color.Transparent;
            picMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtMessage.BackColor = this.BackColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
