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
using Microsoft.Office.Interop.Excel;
using System.Data.Common;
using XHX.DTO;
using DbAccess;
using System.Threading;

namespace XHX.View
{
    public partial class PadToDB : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        string ProjectCode_Golbal = "";
        string ShopCode_Golbal = "";
        MSExcelUtil msExcelUtil = new MSExcelUtil();
        UploadFileToAliyun aliyun = new UploadFileToAliyun();
        public PadToDB()
        {
            InitializeComponent();
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

            //�����ı��ʱ���Ӧ���Ծ�����Ҳ���иı�

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
            #region ������֤
            //if (CommonHandler. == 0)
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "��ѡ��\"��Ŀ\"");
            //    cboProjects.Focus();
            //    return;
            //}
            if (txtShopName.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "��ѡ��\"������\"");
                txtShopName.Focus();
                return;
            }
            if (btnDataPath.Text == "")
            {
                CommonHandler.ShowMessage(MessageType.Information, "��ѡ��\"����·��\"");
                btnDataPath.Focus();
                return;
            }

            ProjectCode_Golbal = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            ShopCode_Golbal = btnShopCode.Text;

            DirectoryInfo dataDir = new DirectoryInfo(btnDataPath.Text);
            FileInfo[] filesInfo = dataDir.GetFiles();

            bool isExistDBFile = false;
            //foreach (FileInfo fileInfo in filesInfo)
            //{
            //    if (fileInfo.Name == "writeable.db")
            //    {
            //        isExistDBFile = true;
            //        SqliteHelper.SetConnectionString("Data Source=" + fileInfo.FullName, "");
            //    }
            //}
            //if (!isExistDBFile)
            //{
            //    CommonHandler.ShowMessage(MessageType.Information, "·���в��������ݿ��ļ�'writeable.db'");
            ////    return;
            ////}
            #endregion

            //#region �ϴ�Answer������
            //{
            //    List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,Score,Remark,ImageName,InUserID,'0','',AssessmentDate,InDateTime from Answer WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
            //    List<String> updateStringList = new List<string>();
            //    foreach (String data in dataList)
            //    {
            //        String[] properties = data.Split('$');
            //        String updateString = @"update Answer Set Flag=1 WHERE ProjectCode='{0}' " +
            //                                   "AND SubjectCode='{1}' " +
            //                                   "AND ShopCode='{2}'";
            //        updateString = String.Format(updateString, properties[0], properties[1], properties[2]);
            //        updateStringList.Add(updateString);

            //    }
            //    service.SaveAnswerList(dataList.ToArray());
            //    SqliteHelper.InsertOrUpdata(updateStringList);
            //}
            //#endregion

            //#region �ϴ�AnswerLog������
            //{
            //    List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,Score,Desc,InUserID,StatusCode from AnswerLog WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
            //    List<String> updateStringList = new List<string>();
            //    foreach (String data in dataList)
            //    {
            //        String[] properties = data.Split('$');
            //        String updateString = @"update AnswerLog Set Flag=1 WHERE ProjectCode='{0}' " +
            //                               "AND SubjectCode='{1}' " +
            //                               "AND ShopCode='{2}'" +
            //                               "AND StatusCode='{3}'";
            //        updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[6]);
            //        updateStringList.Add(updateString);

            //    }
            //    service.SaveAnswerLogList(dataList.ToArray());
            //    SqliteHelper.InsertOrUpdata(updateStringList);
            //}
            //#endregion

            //#region �ϴ�AnswerDtl������
            //{
            //    List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,InUserID,CheckOptionCode,PicNameList from AnswerDtl WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
            //    List<String> updateStringList = new List<string>();
            //    foreach (String data in dataList)
            //    {
            //        String[] properties = data.Split('$');
            //        String updateString = @"update AnswerDtl Set Flag=1,PicNameList='{4}' WHERE ProjectCode='{0}' " +
            //                                   "AND SubjectCode='{1}' " +
            //                                   "AND ShopCode='{2}' " +
            //                                   "AND SeqNO={3}"; ;
            //        updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3], properties[6]);
            //        updateStringList.Add(updateString);

            //    }
            //    service.SaveAnswerDtlList(dataList.ToArray());
            //    SqliteHelper.InsertOrUpdata(updateStringList);
            //}
            //#endregion

            //#region �ϴ�AnswerDtl2������
            //{
            //    List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,InUserID,CheckOptionCode from AnswerDtl2 WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
            //    List<String> updateStringList = new List<string>();
            //    foreach (String data in dataList)
            //    {
            //        String[] properties = data.Split('$');
            //        String updateString = @"update AnswerDtl2 Set Flag=1 WHERE ProjectCode='{0}' " +
            //                                   "AND SubjectCode='{1}' " +
            //                                   "AND ShopCode='{2}' " +
            //                                   "AND SeqNO={3}";
            //        updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3]);
            //        updateStringList.Add(updateString);

            //    }
            //    service.SaveAnswerDtl2StreamList(dataList.ToArray());
            //    SqliteHelper.InsertOrUpdata(updateStringList);
            //}
            //#endregion
            //#region �ϴ�AnswerDtl3������
            //{
            //    List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode,SeqNO,LossDesc,PicName from AnswerDtl3 WHERE Flag=0 AND ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "'");
            //    List<String> updateStringList = new List<string>();
            //    foreach (String data in dataList)
            //    {
            //        String[] properties = data.Split('$');
            //        String updateString = @"update AnswerDtl3 Set Flag=1 WHERE ProjectCode='{0}' " +
            //                                   "AND SubjectCode='{1}' " +
            //                                   "AND ShopCode='{2}' " +
            //                                   "AND SeqNO={3}";
            //        updateString = String.Format(updateString, properties[0], properties[1], properties[2], properties[3]);
            //        updateStringList.Add(updateString);

            //    }
            //    service.SaveAnswerDtl3StringList(dataList.ToArray());
            //    SqliteHelper.InsertOrUpdata(updateStringList);
            //}
            //#endregion


            #region �ϴ�ͼƬ�ļ�
            {
                //DateTime st = DateTime.Now;
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
                //TimeSpan ts = DateTime.Now - st;
                //CommonHandler.ShowMessage(MessageType.Information,ts.ToString());
            }
            #endregion
        }
        string fail = string.Empty;
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
                try
                {
                    DirectoryInfo subjectDir = dirInfos[i];
                    double subjectDirSize = 0;
                    foreach (FileInfo fi in subjectDir.GetFiles())
                    {
                        subjectDirSize += fi.Length;
                    }

                    // List<String> dataList = SqliteHelper.Search("SELECT ProjectCode,SubjectCode,ShopCode from PictureUploadLog WHERE  ProjectCode='" + ProjectCode_Golbal + "' AND ShopCode='" + ShopCode_Golbal + "' AND SubjectCode='"+dirInfos[i]+"'");
                    //if(dataList.Count!=0)
                    //{
                    //    continue;
                    //}
                    //FileInfo[] picInfos = subjectDir.GetFiles();
                    //for (int j = 0; j < picInfos.Length; j++)
                    //{
                    //    string tempFile = Path.Combine(Path.GetTempPath(), subjectDir.Name + picInfos[j].Name + ".zip");
                    //    if (ZipHelper.Zip(picInfos[j].FullName, tempFile, ""))
                    //    {
                    //        FileStream fs = new FileStream(tempFile, FileMode.Open);
                    //        byte[] zipFile = new byte[fs.Length];
                    //        fs.Read(zipFile, 0, zipFile.Length);
                    //        fs.Close();
                    //        service.UploadImgZipFile1(shopDir.Name, subjectDir.Name, zipFile);
                    //        try
                    //        {
                    //            pbrProgressForUpload.Value += (int)((subjectDirSize / shopDirSize) * 100D);
                    //        }
                    //        catch (Exception)
                    //        {

                    //        }
                    //        Application.DoEvents();
                    //        // File.Delete(subjectDir.FullName);
                    //    }
                    //    else
                    //    {
                    //        CommonHandler.ShowMessage(MessageType.Information, "ѹ��ͼƬ�ļ���\"" + subjectDir.FullName + "\"ʧ�ܡ�");
                    //    }
                    //}
                    //Thread.Sleep(500);
                    //List<String> updateStringList = new List<string>();
                    //String updateString = @"insert into [PictureUploadLog](ProjectCode,ShopCode,SubjectCode,UploadChk)VALUES('{0}','{1}','{2}','{3}')";
                    //updateString = String.Format(updateString, ProjectCode_Golbal, ShopCode_Golbal, dirInfos[i],"Y");
                    //updateStringList.Add(updateString);

                    //SqliteHelper.InsertOrUpdata(updateStringList);

                }
                catch (UnauthorizedAccessException exx)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    fail += dirInfos[i].FullName + ";";
                    continue;
                }
            }
            if (string.IsNullOrEmpty(fail))
            {
                CommonHandler.ShowMessage(MessageType.Information, "�����ϴ���ϡ�");
            }
            else
            {
                CommonHandler.ShowMessage(MessageType.Information, "�����ϴ���ϡ�" + fail + "δ�ϴ��ɹ�");
            }
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
                CommonHandler.ShowMessage(MessageType.Information, "��ѡ��\"����·��\"");
                tbnSQLitePath.Focus();
                return;
            }

            string sqlConnString = GetSqlServerConnectionString("123.57.229.128", "Toyota", "sa", "mxT1@mfb");
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
                            CommonHandler.ShowMessage(MessageType.Information, "���سɹ�");
                            pbrProgress.Value = 0;
                        }
                        else
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "����ʧ��\r\n" + msg);
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
                CommonHandler.ShowMessage(MessageType.Information, "��ѡ��\"����·��\"");
                tbnSQLitePathForUpdate.Focus();
                return;
            }

            string sqlConnString = GetSqlServerConnectionString("123.57.229.128", "Toyota", "sa", "mxT1@mfb");
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
                            CommonHandler.ShowMessage(MessageType.Information, "���سɹ�");
                            pbrProgressForUpdate.Value = 0;
                        }
                        else
                        {
                            CommonHandler.ShowMessage(MessageType.Information, "����ʧ��\r\n" + msg);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnDataPath.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "��ѡ��·��");
                return;
            }
            DirectoryInfo dataDir = new DirectoryInfo(btnDataPath.Text);
            // DirectoryInfo[] dirInfos = dataDir.GetDirectories();
            FileInfo[] fileList = dataDir.GetFiles();
            foreach (FileInfo file in fileList)
            {
                try
                {
                    aliyun.PutObject("yrtech", "BENZReport" + @"/" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + @"/" + file.Name,
                                        file.FullName);

                    // pbrProgressForUpload.Value += (int)((subjectDirSize / shopDirSize) * 100D);
                }
                catch (Exception)
                {

                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "�ϴ����");

        }
        void UploadImgZipFileBySubDirectory1(string dirPath)
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
                try
                {
                    DirectoryInfo subjectDir = dirInfos[i];
                    double subjectDirSize = 0;
                    foreach (FileInfo fi in subjectDir.GetFiles())
                    {
                        subjectDirSize += fi.Length;
                    }
                    FileInfo[] picInfos = subjectDir.GetFiles();
                    for (int j = 0; j < picInfos.Length; j++)
                    {
                        aliyun.PutObject("yrtech", "BENZReport" + @"/" + CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString() + @"/" + picInfos[j].Name,
                                    picInfos[j].FullName);
                        try
                        {
                            pbrProgressForUpload.Value += (int)((subjectDirSize / shopDirSize) * 100D);
                        }
                        catch (Exception)
                        {

                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                catch (UnauthorizedAccessException exx)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    fail += dirInfos[i].FullName + ";";
                    continue;
                }
            }
            if (string.IsNullOrEmpty(fail))
            {
                CommonHandler.ShowMessage(MessageType.Information, "�����ϴ���ϡ�");
            }
            else
            {
                CommonHandler.ShowMessage(MessageType.Information, "�����ϴ���ϡ�" + fail + "δ�ϴ��ɹ�");
            }
            pbrProgressForUpload.Value = 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(buttonEdit1.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["Sheet1"] as Worksheet;
           //string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 800; i++)
            {
                string projectCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    string salesName = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    string salesType = msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString();
                    string inUserName = msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString();
                   // string score = msExcelUtil.GetCellValue(worksheet_FengMian, "F", i).ToString();
                    //service.UploadSalesContantInfo(projectCode, shopCode, salesType, salesName, score, "", orderNO_All, orderNO_SmallArea, this.UserInfoDto.UserID);
                    for (int j = 6; j < 500; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        string subjectScore = msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString();
                        string score = "";
                        string lossDesc = "";
                        if (subjectScore.Trim() == @"\"||subjectScore.Trim() == "/")
                        {
                            score = "9999";
                            lossDesc = "";
                        }
                        else if (isNumberic(subjectScore))
                        {
                            score = subjectScore;
                            lossDesc = "";
                        }
                        else
                        {
                            score = "";
                            lossDesc = subjectScore;
                        }
                        if (!string.IsNullOrEmpty(subjectCode) && !string.IsNullOrEmpty(subjectScore))
                        {
                            service.SaveSalesConsultant_Upload(projectCode, shopCode, subjectCode, salesName,score,lossDesc,inUserName,salesType);
                        }
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "�ϴ����");
        }
        public bool RecheckStatus()
        {
            DataSet ds = service.SearchRecheckStatus(ProjectCode_Golbal, ShopCode_Golbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //btnSpecialCaseApply.Enabled = false;
                //grcFileAndPic.DragEnter -= new DragEventHandler(grcFileAndPic_DragEnter);
                //grcLoss.DragEnter -= new DragEventHandler(grcLoss_DragEnter);
                //btnAddRowLoss.Enabled = false;
                //btnDeleteLoss.Enabled = false;
                //txtScore.Enabled = false;
                //chkNotinvolved.Enabled = false;
                //txtRemark.Enabled = false;
                return true;
            }
            else
            {
                //btnSpecialCaseApply.Enabled = true; ;
                //grcFileAndPic.DragEnter += new DragEventHandler(grcFileAndPic_DragEnter);
                //grcLoss.DragEnter += new DragEventHandler(grcLoss_DragEnter);
                //btnAddRowLoss.Enabled = true; ;
                //btnDeleteLoss.Enabled = true;
                //txtScore.Enabled = true;
                //chkNotinvolved.Enabled = true;
                //txtRemark.Enabled = true;
                return false;
            }


        }
        protected bool isNumberic(string message)
        {
            //�ж��Ƿ�Ϊ�����ַ���
            //�ǵĻ�����ת��Ϊ���ֲ�������Ϊout���͵����ֵ������true, ����Ϊfalse
            //result = -1;   //result ����Ϊout �������ֵ
            try
            {
                //�������ַ�����Ϊ������4ʱ���������ֶ�����ת������ѡһ��
                //���λ������4�Ļ�����ѡ��Convert.ToInt32() ��int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                double result = Convert.ToDouble(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "Excel(*.xlsx)|";
            ofp.FilterIndex = 2;
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = ofp.FileName;
            }
        }

    }
}