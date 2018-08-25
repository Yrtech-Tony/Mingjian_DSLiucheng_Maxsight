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
    public partial class AllPictureShow2 : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service service = new XHX.localhost.Service();

        public AllPictureShow2()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";

            this.Shown += new EventHandler(AllPictureShow2_Shown);
        }

        void AllPictureShow2_Shown(object sender, EventArgs e)
        {
            this.kpImageViewer1.FitToScreen();
        }

        public AllPictureShow2(string filePath, string[] fileName, string shopName, string subjectCode,string type, string code)
            : this()
        {
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            List<Image> pictures = new List<Image>();

            for (int i = 0; i < fileName.Length; i++)
            {
                byte[] bytes = null;
                if (type == "SpecialCase" || type == "Notice")
                {
                    bytes = service.SearchAnswerDtl2Pic(fileName[i], shopName, subjectCode, type, code);
                }
                else
                {
                    bytes = service.SearchAnswerDtl2Pic(fileName[i].Replace(".jpg", ""), shopName, subjectCode, type, code);
                }
                if (bytes != null && bytes.Length != 0)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    Image image = Image.FromStream(ms);
                    pictures.Add(image);
                }
            }

            if (pictures.Count != 0)
            {
                this.kpImageViewer1.ImageList = pictures;
            }
            else
            {
                for (int i = 0; i < fileName.Length; i++)
                {
                    if (type != "SpecialCase")
                    {
                        if (File.Exists(filePath + fileName[i] + ".jpg"))
                        {
                            Image image = Image.FromFile(filePath + fileName[i] + ".jpg");
                            pictures.Add(image);
                        }
                    }
                    else
                    {
                        if (File.Exists(filePath + fileName[i]))
                        {

                            Image image = Image.FromFile(filePath + fileName[i]);
                            pictures.Add(image);
                        }
                    }
                }
                this.kpImageViewer1.ImageList = pictures;
            }
        }
       
        
    }
}
