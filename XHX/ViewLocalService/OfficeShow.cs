using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeControl;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class OfficeShow : Form
    {
        localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        public OfficeShow()
        {
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            InitializeComponent();
        }
        public OfficeShow(string picName, string shopName, string subjectCode,string fileExtend)
            :this()
        {
            OfficeControl.OfficeDisplayControl office = new OfficeControl.OfficeDisplayControl();
            this.Controls.Add(office);
            office.Dock = System.Windows.Forms.DockStyle.Fill;
            string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = "";
            if (!Directory.Exists(appDomainPath + @"UploadImage\" + "DownLoad"))
            {
                Directory.CreateDirectory(appDomainPath + @"UploadImage\" + "DownLoad");
            }

            filePath = appDomainPath + @"UploadImage\" + "DownLoad" + @"\" + picName + fileExtend;

            //if (!File.Exists(filePath))
            //{
            //    filePath = appDomainPath + @"UploadImage\" + "aa" + @"\" + picName + fileExtend;
            //}
            byte[] b = service.SearchAnswerDtl2Pic(picName, shopName,subjectCode, "", "");
            if (b == null)
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        office.Open(filePath, null, null);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MemoryStream buf = new MemoryStream(b);
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                }
                //using(FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate))
                //{
                //byte[] byteDatas = new byte[buf.Length];
                //buf.Write(byteDatas, 0, byteDatas.Length);
                //fs.Seek(0, SeekOrigin.Begin);//指定偏移位置
                //fs.Write(byteDatas, 0, byteDatas.Length);//
                //fs.Close();
                //}
                //buf.Close();
                office.Open(filePath, null, null);
            }

            //kpImageViewer1.Image = image as Bitmap;

           // office.Open(filePath, null, null);
        }
        //public void Init()
        //{
        //    Stream ms = typeof(OfficeDisplayControl).Assembly.GetManifestResourceStream("OfficeControl.dsoframer.ocx");
        //    byte[] bytes = new byte[ms.Length];
        //    ms.Read(bytes,0,bytes.Length);
        //    ms.Close();
        //    FileStream fs = new FileStream("dsoframer.ocx", FileMode.Create, FileAccess.ReadWrite);
        //    fs.Write(bytes, 0, bytes.Length);
        //    fs.Close();

        //    Assembly thisExe = Assembly.GetExecutingAssembly();
        //    System.IO.Stream myS = thisExe.GetManifestResourceStream("NameSpace.dsoframer.ocx");
        //    string sPath = "dsoframer.ocx";
        //    ProcessStartInfo psi = new ProcessStartInfo("regsvr32", "/s" + sPath);
        //    Process.Start(psi);


        //}
    }
}
