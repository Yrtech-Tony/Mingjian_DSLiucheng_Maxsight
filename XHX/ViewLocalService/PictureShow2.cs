using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX;
using System.IO;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class PictureShow2 : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();

        public PictureShow2()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            this.Shown += new EventHandler(PictureShow2_Shown);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="picName">图片的名字</param>
        /// <param name="shopName">项目名+经销商名</param>
        /// <param name="path">图片存储的路径</param>
        public PictureShow2(string picName, string shopName,string subjectCode,string path)
            : this()
        {
            //service.Url = "http://192.168.1.99/DSAT_Pad/service.asmx";
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            Image image = null ;
            byte[] b = service.SearchAnswerDtl2Pic(picName, shopName,subjectCode,"","");
            //查看服务器是否有对应的图片，如果没有的话读取本地的图片
            if (b == null)
            {
                string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = appDomainPath + @"UploadImage\" + shopName + @"\" + picName + ".jpg";
                if (File.Exists(filePath))
                {
                    image = Image.FromFile(filePath);
                }
                else
                {
                    return;
                }
            }
            //查看服务器是否有对应的图片，如果有的话显示到页面
            else
            {
                MemoryStream buf = new MemoryStream(b);
                image = Image.FromStream(buf, true);
            }

            kpImageViewer1.Image = image as Bitmap;
        }
        public PictureShow2(byte[] b)
            : this()
        {
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            MemoryStream buf = new MemoryStream(b);
            Image image = Image.FromStream(buf, true);
            kpImageViewer1.Image = image as Bitmap;
        }
        public PictureShow2(string filePath, string[] fileName)
            : this()
        {
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            string[] picType = new string[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };
            for (int i = 0; i < fileName.Length; i++)
            {
                DevExpress.XtraEditors.PictureEdit pic = new DevExpress.XtraEditors.PictureEdit();
                if (i % 2 == 0)
                {
                    pic.Location = new System.Drawing.Point(10, 10 + 500 * (i / 2));
                }
                else
                {
                    pic.Location = new System.Drawing.Point(10 + 500, 10 + 500 * ((i + 1) / 2 - 1));
                }
                //pic.Size = new System.Drawing.Size(1024, 1024);
                pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                if (!fileName[i].ToLower().Contains(".jpg")
                    && !fileName[i].ToLower().Contains(".bmp")
                    && !fileName[i].ToLower().Contains(".jpeg")
                    && !fileName[i].ToLower().Contains(".png")
                    && !fileName[i].ToLower().Contains(".gif"))
                {
                    for (int j = 0; j < picType.Length; j++)
                    {
                        fileName[i] = fileName[i] + picType[j];
                        if (File.Exists(filePath + fileName[i]))
                        {
                            //using (FileStream fs = new FileStream(filePath + fileName[i], FileMode.Open))
                            //{
                                //pic.Image = Image.FromStream(fs);
                                pic.Image = Image.FromFile(filePath + fileName[i]);
                                break;
                            //}
                        }
                    }

                }
                pic.Dock = DockStyle.Fill;
                //pic.Image = Image.FromFile(filePath + fileName[i]);
                //panelControl1.Dock = DockStyle.Fill;
                //panelControl1.Controls.Add(pic);
            }
        }

        private void PictureShow2_Shown(object sender, EventArgs e)
        {
            this.kpImageViewer1.FitToScreen();
        }
    }
}
