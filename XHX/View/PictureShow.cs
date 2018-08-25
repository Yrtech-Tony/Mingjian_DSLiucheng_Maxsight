using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XHX.View
{
    public partial class PictureShow : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service service = new localhost.Service();

        public PictureShow()
        {
        }
        public PictureShow(string picName, string shopName,string subjectCode,string path)
        {
            InitializeComponent();
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            DevExpress.XtraEditors.PictureEdit pic = new DevExpress.XtraEditors.PictureEdit();
            Image image = null;
            byte[] b = service.SearchAnswerDtl2Pic(picName, shopName,subjectCode,"","");
            if (b == null)
            {
                string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = appDomainPath + @"UploadImage\" + shopName + @"\" + picName + ".jpg";
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        image = Image.FromStream(fs,true);
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
                image = Image.FromStream(buf, true);
            }

             
            pic.Image = image;
            //pic.AutoScrollOffset = true;
            pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pic.Dock = DockStyle.Fill;
            //pic.Image = Image.FromFile(filePath + fileName[i]);
            panelControl1.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(pic);
        }
        public PictureShow(byte[] b)
        {
            InitializeComponent();
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            DevExpress.XtraEditors.PictureEdit pic = new DevExpress.XtraEditors.PictureEdit();
            MemoryStream buf = new MemoryStream(b);

           Image image = Image.FromStream(buf, true);


            pic.Image = image;
            //pic.AutoScrollOffset = true;
            pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pic.Dock = DockStyle.Fill;
            //pic.Image = Image.FromFile(filePath + fileName[i]);
            panelControl1.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(pic);
        }
        public PictureShow(string filePath,string[] fileName)
        {
            InitializeComponent();


            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            string[] picType = new string[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif"};
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
                        if (File.Exists(filePath+fileName[i]))
                        {
                            using (FileStream fs = new FileStream(filePath + fileName[i], FileMode.Open))
                            {
                                pic.Image = Image.FromStream(fs);
                                break;
                            }
                        }
                    }
                       
                }
                pic.Dock = DockStyle.Fill;
                //pic.Image = Image.FromFile(filePath + fileName[i]);
                panelControl1.Dock = DockStyle.Fill;
                panelControl1.Controls.Add(pic);
            }
        }

        private void PictureShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }

    }
}
