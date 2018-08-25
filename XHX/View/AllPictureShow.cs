using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace XHX.View
{
    public partial class AllPictureShow : DevExpress.XtraEditors.XtraForm
    {
        localhost.Service service = new localhost.Service();
        public AllPictureShow()
        {
            InitializeComponent();
        }

        public AllPictureShow(string filePath, string[] fileName,string shopName,string subjectCode):this()
        {
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);
            List<PictureDto> pictures = new List<PictureDto>();
            for (int i = 0; i < fileName.Length; i++)
            {
                if (service.SearchAnswerDtl2Pic(fileName[i], shopName,subjectCode,"","") != null)
                {
                    PictureDto pic = new PictureDto();
                    MemoryStream ms = new MemoryStream(service.SearchAnswerDtl2Pic(fileName[i], shopName,subjectCode,"",""));
                    Image image = Image.FromStream(ms);
                    pic.Picture = image;
                    pic.PictureName = fileName[i];
                    pictures.Add(pic);
                }
            }

            if (pictures.Count != 0)
            {
                grcShop.DataSource = pictures;
            }
            else
            {
                for (int i = 0; i < fileName.Length; i++)
                {
                    if (File.Exists(filePath + fileName[i] + ".jpg"))
                    {
                        PictureDto pictureDto = new PictureDto();
                        using (FileStream fs = new FileStream(filePath + fileName[i] + ".jpg", FileMode.Open))
                        {
                            pictureDto.Picture = Image.FromStream(fs);
                            pictureDto.PictureName = fileName[i];
                            pictures.Add(pictureDto);
                        }
                    }
                }


                grcShop.DataSource = pictures;
            }
        }
    }

    class PictureDto
    {
        public Image Picture { get; set; }
        public string PictureName { get; set; }
    }
}