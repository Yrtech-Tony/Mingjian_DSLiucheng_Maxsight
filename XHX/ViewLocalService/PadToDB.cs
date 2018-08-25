using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using XHX.Common;
using System.Data.Common;
using XHX.DTO;
using DbAccess;

namespace XHX.ViewLocalService
{
    public partial class PadToDB : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        string ProjectCode_Golbal = "";
        string ShopCode_Golbal = "";

        public PadToDB()
        {
            InitializeComponent();
            service.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            XHX.Common.BindComBox.BindProject(cboProjects);
            XHX.Common.BindComBox.BindSubjectExamType(cboExamType);
        }

        public override List<XHX.BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            return list;
        }

        private void btnShopCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Shop_Popup pop = new Shop_Popup("", "", false);
            pop.ShowDialog();
            ShopDto dto = pop.Shopdto;
            if (dto != null)
            {
                btnShopCode.Text = dto.ShopCode;
                txtShopName.Text = dto.ShopName;
            }
            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;

            //卖场改变的时候对应的试卷类型也进行改变

            //List<ShopSubjectExamTypeDto> list = new List<ShopSubjectExamTypeDto>();
            ShopSubjectExamTypeDto shop = new ShopSubjectExamTypeDto();
            DataSet ds = service.SearchShopExamTypeByProjectCodeAndShopCode(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                shop.ExamTypeCode = ds.Tables[0].Rows[0]["SubjectTypeCodeExam"] == null ? "" : ds.Tables[0].Rows[0]["SubjectTypeCodeExam"].ToString();
            }
            else
            {
                shop.ExamTypeCode = "";
            }
            CommonHandler.SetComboBoxSelectedValue(cboExamType, shop.ExamTypeCode);
        }

        #region UploadData

        private void btnDataPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                btnDataPath.Text = fbd.SelectedPath;
            }
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //if (CommonHandler. == 0)
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "请选择\"项目\"");
            //    cboProjects.Focus();
            //    return;
            //}
            if (txtShopName.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择\"经销商\"");
                txtShopName.Focus();
                return;
            }
            if (btnDataPath.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择\"数据路径\"");
                btnDataPath.Focus();
                return;
            }

            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;

            DirectoryInfo dataDir = new DirectoryInfo(btnDataPath.Text);
            FileInfo[] filesInfo = dataDir.GetFiles();

            bool isExistDBFile = false;
            foreach (FileInfo fileInfo in filesInfo)
            {
                if (fileInfo.Name == "writeable.db")
                {
                    isExistDBFile = true;
                    SqliteHelper.SetConnectionString("Data Source=" + fileInfo.FullName, "");
                }
            }
            if (!isExistDBFile)
            {
                CommonHandler.ShowMessage(MessageType.Information, "路径中不存在数据库文件'writeable.db'");
                return;
            }
            #endregion

            #region 上传Answer表数据
            {
                List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,Score,Remark,ImageName,InUserID,'0','',AssessmentDate from Answer WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
                List<String> updateStringList = new List<string>();
                foreach (String data in dataList)
                {
                    String[] properties = data.Split('$');
                    String updateString = @"update Answer Set Flag=1 WHERE ProjectCode='{0}' " +
                                               "AND SubjectCode='{1}' " +
                                               "AND ShopCode='{2}'";
                    updateString = String.Format(updateString, properties[0], properties[1], properties[2]);
                    updateStringList.Add(updateString);

                }
                service.SaveAnswerList(dataList.ToArray());
                SqliteHelper.InsertOrUpdata(updateStringList);
            }
            #endregion

            #region 上传AnswerLog表数据
            {
                List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,Score,Desc,InUserID,StatusCode from AnswerLog WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
                List<String> updateStringList = new List<string>();
                foreach (String data in dataList)
                {
                    String[] properties = data.Split('$');
                    String updateString = @"update AnswerLog Set Flag=1 WHERE ProjectCode='{0}' " +
                                           "AND SubjectCode='{1}' " +
                                           "AND ShopCode='{2}'" +
                                           "AND StatusCode='{3}'";
                    updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[6]);
                    updateStringList.Add(updateString);

                }
                service.SaveAnswerLogList(dataList.ToArray());
                SqliteHelper.InsertOrUpdata(updateStringList);
            }
            #endregion

            #region 上传AnswerDtl表数据
            {
                List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,InUserID,CheckOptionCode,PicNameList from AnswerDtl WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
                List<String> updateStringList = new List<string>();
                foreach (String data in dataList)
                {
                    String[] properties = data.Split('$');
                    String updateString = @"update AnswerDtl Set Flag=1,PicNameList='{4}' WHERE ProjectCode='{0}' " +
                                               "AND SubjectCode='{1}' " +
                                               "AND ShopCode='{2}' " +
                                               "AND SeqNO={3}"; ;
                    updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3], properties[6]);
                    updateStringList.Add(updateString);

                }
                service.SaveAnswerDtlList(dataList.ToArray());
                SqliteHelper.InsertOrUpdata(updateStringList);
            }
            #endregion

            #region 上传AnswerDtl2表数据
            {
                List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,InUserID,CheckOptionCode from AnswerDtl2 WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
                List<String> updateStringList = new List<string>();
                foreach (String data in dataList)
                {
                    String[] properties = data.Split('$');
                    String updateString = @"update AnswerDtl2 Set Flag=1 WHERE ProjectCode='{0}' " +
                                               "AND SubjectCode='{1}' " +
                                               "AND ShopCode='{2}' " +
                                               "AND SeqNO={3}";
                    updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3]);
                    updateStringList.Add(updateString);

                }
                service.SaveAnswerDtl2StreamList(dataList.ToArray());
                SqliteHelper.InsertOrUpdata(updateStringList);
            }
            #endregion
            #region 上传AnswerDtl3表数据
            {
                List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,LossDesc,PicName from AnswerDtl3 WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
                List<String> updateStringList = new List<string>();
                foreach (String data in dataList)
                {
                    String[] properties = data.Split('$');
                    String updateString = @"update AnswerDtl3 Set Flag=1 WHERE ProjectCode='{0}' " +
                                               "AND SubjectCode='{1}' " +
                                               "AND ShopCode='{2}' " +
                                               "AND SeqNO={3}";
                    updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3]);
                    updateStringList.Add(updateString);

                }
                service.SaveAnswerDtl3StringList(dataList.ToArray());
                SqliteHelper.InsertOrUpdata(updateStringList);
            }
            #endregion


            #region 上传图片文件
            {
                DirectoryInfo[] dirInfos = dataDir.GetDirectories();
                foreach (DirectoryInfo dirInfo in dirInfos)
                {
                    if (dirInfo.Name == ProjectCode_Golbal + txtShopName.Text)
                    {
                        FileInfo[] fileList = dirInfo.GetFiles("Thumbs.db");
                        if (fileList != null && fileList.Length != 0)
                        {
                            foreach (FileInfo file in fileList)
                            {
                                if (file.Name == "Thumbs.db")
                                {
                                    file.Delete();
                                    break;
                                }
                            }
                        }
                        UploadImgZipFileBySubDirectory(dirInfo.FullName);
                    }
                }
            }
            #endregion
        }

        void UploadImgZipFileBySubDirectory(string dirPath)
        {
            DirectoryInfo shopDir = new DirectoryInfo(dirPath);
            double shopDirSize = 0;
            foreach (DirectoryInfo dir in shopDir.GetDirectories())
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    shopDirSize += fi.Length;
                }
                
            }
            DirectoryInfo[] dirInfos = shopDir.GetDirectories();

            for (int i = 0; i < dirInfos.Length; i++)
            {
                DirectoryInfo subjectDir = dirInfos[i];
                double subjectDirSize = 0;
                foreach (FileInfo fi in subjectDir.GetFiles())
                {
                    subjectDirSize += fi.Length;
                }
                string tempFile = Path.Combine(Path.GetTempPath(), subjectDir.Name + ".zip");
                if (ZipHelper.Zip(subjectDir.FullName, tempFile, ""))
                {
                    FileStream fs = new FileStream(tempFile, FileMode.Open);
                    byte[] zipFile = new byte[fs.Length];
                    fs.Read(zipFile, 0, zipFile.Length);
                    fs.Close();
                    service.UploadImgZipFile(shopDir.Name, zipFile);
                    try
                    {
                        pbrProgressForUpload.Value += (int)((subjectDirSize / shopDirSize) * 100D);
                    }
                    catch (Exception)
                    {
                        
                    }
                    Application.DoEvents();
                }
                else
                {
                    CommonHandler.ShowMessage(MessageType.Information, "压缩图片文件夹\"" + subjectDir.FullName + "\"失败。");
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "数据上传完毕。");
            pbrProgressForUpload.Value = 0;
        }

        #endregion

        #region DownloadData

        private void tbnSQLitePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbnSQLitePath.Text = fbd.SelectedPath;
            }
        }

        private void btnDownloadData_Click(object sender, EventArgs e)
        {
            if (tbnSQLitePath.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择\"数据路径\"");
                tbnSQLitePath.Focus();
                return;
            }

            string sqlConnString = GetSqlServerConnectionString("192.168.1.99", "XinHuaXin_YQ", "DSAT", "DSAT");
            string sqlitePath = Path.Combine(tbnSQLitePath.Text.Trim(), "readonly.db");
            this.Cursor = Cursors.WaitCursor;
            SqlConversionHandler handler = new SqlConversionHandler(delegate(bool done,
                bool success, int percent, string msg)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    pbrProgress.Value = percent;

                    if (done)
                    {
                        this.Cursor = Cursors.Default;

                        if (success)
                        {
                            File.Copy(sqlitePath, Path.Combine(Path.GetDirectoryName(sqlitePath), "writeable.db"), true);
                            CommonHandler.ShowMessage(MessageType.Information, "下载成功");
                            pbrProgress.Value = 0;
                        }
                        else
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "下载失败\r\n" + msg);
                            pbrProgress.Value = 0;
                        }
                    }
                }));
            });
            SqlTableSelectionHandler selectionHandler = new SqlTableSelectionHandler(delegate(List<TableSchema> schema)
            {
                return schema;
            });

            FailedViewDefinitionHandler viewFailureHandler = new FailedViewDefinitionHandler(delegate(ViewSchema vs)
            {
                return null;
            });

            string password = null;
            SqlServerToSQLite.ConvertSqlServerToSQLiteDatabase(sqlConnString, sqlitePath, password, handler,
                selectionHandler, viewFailureHandler, false, false);
        }

        private static string GetSqlServerConnectionString(string address, string db, string user, string pass)
        {
            string res = @"Data Source=" + address.Trim() +
                ";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + pass.Trim();
            return res;
        }

        #endregion

        #region UpdateData

        private void tbnSQLitePathForUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbnSQLitePathForUpdate.Text = fbd.SelectedPath;
            }
        }

        private void btnDownloadDataForUpdate_Click(object sender, EventArgs e)
        {
            if (tbnSQLitePathForUpdate.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择\"数据路径\"");
                tbnSQLitePathForUpdate.Focus();
                return;
            }

            string sqlConnString = GetSqlServerConnectionString("192.168.1.99", "XinHuaXin_YQ", "DSAT", "DSAT");
            string sqlitePath = Path.Combine(tbnSQLitePathForUpdate.Text.Trim(), "readonly.db");
            this.Cursor = Cursors.WaitCursor;
            SqlConversionHandler handler = new SqlConversionHandler(delegate(bool done,
                bool success, int percent, string msg)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    pbrProgressForUpdate.Value = percent;

                    if (done)
                    {
                        this.Cursor = Cursors.Default;

                        if (success)
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "下载成功");
                            pbrProgressForUpdate.Value = 0;
                        }
                        else
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "下载失败\r\n" + msg);
                            pbrProgressForUpdate.Value = 0;
                        }
                    }
                }));
            });
            SqlTableSelectionHandler selectionHandler = new SqlTableSelectionHandler(delegate(List<TableSchema> schema)
            {
                return schema;
            });

            FailedViewDefinitionHandler viewFailureHandler = new FailedViewDefinitionHandler(delegate(ViewSchema vs)
            {
                return null;
            });

            string password = null;
            SqlServerToSQLite.ConvertSqlServerToSQLiteDatabase(sqlConnString, sqlitePath, password, handler,
                selectionHandler, viewFailureHandler, false, false);
        }

        #endregion

    }
}