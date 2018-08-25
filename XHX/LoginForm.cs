using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.DTO;
using System.Configuration;
using XHX.Common;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Management;

namespace XHX
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service webService = new localhost.Service();
        //localhost1.Service localService = new localhost1.Service();
        //LocalService localService = new LocalService();

        public LoginForm()
        {
            try
            {
                InitializeComponent();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                Ping ping = new Ping();
                PingReply pingReply = ping.Send(config.AppSettings.Settings["ServerIPAddress"].Value);
                //this.chkNet.Checked = (pingReply.Status == IPStatus.Success);
                this.chkNet.Checked = true;

                LookAndFeel.SetSkinStyle(config.AppSettings.Settings["SkinName"].Value);

                webService.SearchUserByUserIDCompleted += new XHX.localhost.SearchUserByUserIDCompletedEventHandler(webService_SearchUserByUserIDCompleted);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string pwd = txtPWD.Text.Trim();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string clientVersion = config.AppSettings.Settings["CurrentVersion"].Value;
            string serverVersion = "";

            if (chkNet.Checked)
            {
                //localhost.Service webService = new localhost.Service();
                // webService.Url = "http://60.247.70.133/DSAT_Pad/service.asmx";
                DateTime now = webService.ReturnDateTimeNow();

                //if (now.Date > new DateTime(2015, 11, 1) && now.Date < new DateTime(2015, 12, 1))
                //{
                //    CommonHandler.ShowMessage(MessageType.Information, "系统还有" + (30 - now.Day).ToString() + "天使用期限，请尽快续费");
                //}
                if (now.Date == new DateTime(2015, 12, 1))
                {
                    //CommonHandler.ShowMessage(MessageType.Information, "已经过期，如需继续使用请续费");
                    //return;
                }
                DataSet ds = webService.getCurrentVersion();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    serverVersion = Convert.ToString(ds.Tables[0].Rows[0]["CurrentVersion"]);
                }

                if (serverVersion != clientVersion)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "有新版本，请先进行版本更新。"); return;
                }
                webService.SearchUserByUserIDAsync(userID);
                this.Enabled = false;
            }
            else
            {
                localhost.Service localService = new localhost.Service();
                localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
                DataSet ds1 = localService.getCurrentVersion();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    serverVersion = Convert.ToString(ds1.Tables[0].Rows[0]["CurrentVersion"]);
                }
                if (serverVersion != clientVersion)
                {
                    CommonHandler.ShowMessage(MessageType.Information, "有新版本，请先进行版本更新。"); return;
                }
                DataSet ds = localService.SearchUserByUserID(userID);

                UserInfoDto userInfoDto = new UserInfoDto();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    userInfoDto.UserID = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    userInfoDto.PSW = Convert.ToString(ds.Tables[0].Rows[0]["PSW"]);
                    userInfoDto.RoleType = Convert.ToString(ds.Tables[0].Rows[0]["RoleType"]);
                    userInfoDto.MacAddress = Convert.ToString(ds.Tables[0].Rows[0]["MacAddress"]);
                }
                //string[] macList = userInfoDto.MacAddress.Split('$');
                //bool macExitst = false;
                //foreach (string mac in macList)
                //{
                //    if (mac == getMacAddr_Local())
                //    { macExitst = true; break; }
                //}
                //if (!string.IsNullOrEmpty(userInfoDto.MacAddress) && !macExitst)
                ////if (!macExitst)
                //{
                //    CommonHandler.ShowMessage(MessageType.Information, "请使用固定电脑登陆");
                //    return;
                //}
                if (!userID.Equals(userInfoDto.UserID))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "用户名错误。"); return;
                }
                if (!pwd.Equals(userInfoDto.PSW))
                {
                    CommonHandler.ShowMessage(MessageType.Information, "密码错误。"); return;
                }
                userInfoDto.IsNetWork = false;

                MainForm mainForm = new MainForm();
                mainForm.UserInfoDto = userInfoDto;
                mainForm.Show();

                this.Hide();
            }
        }

        void webService_SearchUserByUserIDCompleted(object sender, XHX.localhost.SearchUserByUserIDCompletedEventArgs e)
        {
            this.Enabled = true;

            DataSet ds = e.Result;

            UserInfoDto userInfoDto = new UserInfoDto();
            if (ds.Tables[0].Rows.Count > 0)
            {
                userInfoDto.UserID = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                userInfoDto.PSW = Convert.ToString(ds.Tables[0].Rows[0]["PSW"]);
                userInfoDto.RoleType = Convert.ToString(ds.Tables[0].Rows[0]["RoleType"]);
                userInfoDto.MacAddress = Convert.ToString(ds.Tables[0].Rows[0]["MacAddress"]);
            }
            string[] macList = userInfoDto.MacAddress.Split('$');
            bool macExitst = false;
            foreach (string mac in macList)
            {
                if (mac == getMacAddr_Local())
                { macExitst = true; break; }
            }
            if (!string.IsNullOrEmpty(userInfoDto.MacAddress) && !macExitst)
            //if (!macExitst)
            {
                CommonHandler.ShowMessage(MessageType.Information, "请使用固定电脑登陆");
                return;
            }
            string userID = txtUserID.Text.Trim();
            string pwd = txtPWD.Text.Trim();

            if (!userID.Equals(userInfoDto.UserID))
            {
                CommonHandler.ShowMessage(MessageType.Information, "用户名错误。"); return;
            }
            if (!pwd.Equals(userInfoDto.PSW))
            {
                CommonHandler.ShowMessage(MessageType.Information, "密码错误。"); return;
            }
            userInfoDto.IsNetWork = true;

            MainForm mainForm = new MainForm();
            mainForm.UserInfoDto = userInfoDto;
            mainForm.Show();

            this.Hide();
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPWD.Focus();
            }
        }

        private void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(btnLogin, null);
            }
        }
        public static string getMacAddr_Local()
        {
            string madAddr = null;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                    {
                        madAddr = mo["MacAddress"].ToString(); madAddr = madAddr.Replace(':', '-');
                    } mo.Dispose();
                }

            }
            catch
            {


            }
            return madAddr;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://123.57.229.128/SDliuchengClient/publish.htm");
        }
    }
}