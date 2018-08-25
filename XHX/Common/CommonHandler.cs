using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using XHX.Common;
using System.Drawing;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using ICSharpCode.SharpZipLib.Zip;

namespace XHX
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommonHandler
    {
        public static string Skin_Name = string.Empty;
        public static OleDbConnection conn = null;
        public static localhost.Service serviceCommon = new localhost.Service();
        public static localhost.Service localservice = new localhost.Service();
       // public static LocalService localservice = new LocalService();

        public static bool IsNetWork { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static void DBConnect()
        {
            try
            {
                //数据库连接
                if (conn == null)
                {
                    conn = new OleDbConnection();

                    //conn.ConnectionString = "provider=sqloledb.1;data source=10.202.101.107;initial catalog=XHX_DEV;user id=fanfan;pwd=1";
                    //conn.ConnectionString = "provider=sqloledb.1;data source=192.168.1.108;initial catalog=XHX_DEV;user id=fanfan;pwd=1";
                    conn.ConnectionString = "provider=sqloledb.1;data source=60.247.70.133;initial catalog=XinHuaXin_pad;user id=DSAT;pwd=DSAT;";
                    conn.CreateCommand().CommandTimeout = 0;



                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();//打开连接  
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.Information, "本地数据库异常：\n\r"+ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void connClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public static DataSet query(string sql)
        {
            DataSet ds = new DataSet();//创建dataSet对象  
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);//适配器，用于填充dataSet或dataTable  
            OleDbCommand command = conn.CreateCommand();
            command.CommandTimeout = 60000;
            //command.
            da.Fill(ds);//使用Fill()方法填充dataSet 
            connClose();//关闭连接 
            return ds;//返回DataSet
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        public static void ExcelExport(GridView gridView)
        {
            if (gridView.DataRowCount == 0)
            {
                //MessageBox.Show("Data is not available.");
                return;
            }

            SaveFileDialog sfdExcelDown = new SaveFileDialog();
            sfdExcelDown.Filter = "Microsoft Excel|*.xls";
            DialogResult result = sfdExcelDown.ShowDialog();
            if (result != DialogResult.OK) return;
            gridView.ExportToExcelOld(sfdExcelDown.FileName);
           // gridView.ExportToXls(sfdExcelDown.FileName,false);
        }
        public static void ExcelExportByExporter(GridView gridView)
        {
            if (gridView.DataRowCount == 0)
            {
                //MessageBox.Show("Data is not available.");
                return;
            }

            SaveFileDialog sfdExcelDown = new SaveFileDialog();
            sfdExcelDown.Filter = "Microsoft Excel|*.xlsx";
            DialogResult result = sfdExcelDown.ShowDialog();
            if (result != DialogResult.OK) return;
            XtraGridExcelExporter exporter = new XtraGridExcelExporter(sfdExcelDown.FileName, gridView);
            //exporter.ExportByInfra(0, 0, sfdExcelDown.FileName);
            exporter.Export(0, 0, sfdExcelDown.FileName);
            ShowMessage(MessageType.Information, "导出完毕。");
        }
        /// <summary>
        /// 设置Grid行号
        /// </summary>
        /// <param name="gridView"></param>
        public static void SetRowNumberIndicator(GridView gridView)
        {
            gridView.BeginUpdate();
            gridView.OptionsView.ShowIndicator = true;
            gridView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(
                delegate(object sender, RowIndicatorCustomDrawEventArgs e)
                {
                    if (e.RowHandle >= 0)
                    {
                        int rowNumber = e.RowHandle + 1;
                        e.Info.DisplayText = rowNumber.ToString();
                    }
                }
            );

            gridView.DataSourceChanged += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    gridView.IndicatorWidth = 22 + gridView.DataRowCount.ToString().Length * ((int)gridView.Appearance.HeaderPanel.Font.Size);
                }
            );

            gridView.EndUpdate();
        }

        /// <summary>
        /// 绑定Grid中的ComboBox的DataSource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="list"></param>
        /// <param name="displayMemberPropertyName"></param>
        /// <param name="valueMemberPropertyName"></param>
        public static void BindComboBoxItems<T>(RepositoryItemComboBox control, object list, string displayMemberPropertyName, string valueMemberPropertyName)
        {
            if (list == null) return;
            ICollection collection = list as ICollection;
            if (collection == null) return;

            CustomDisplayDataSource items = new CustomDisplayDataSource();

            PropertyInfo propInfo = null;

            foreach (T entity in collection)
            {
                try
                {
                    propInfo = entity.GetType().GetProperty(displayMemberPropertyName);
                    object displayMember = propInfo.GetValue(entity, null);
                    propInfo = entity.GetType().GetProperty(valueMemberPropertyName);
                    object valueMember = propInfo.GetValue(entity, null);
                    if (displayMember != null && valueMember != null) items.AddItem(valueMember, displayMember.ToString());
                }
                catch { }
            }

            BindComboBoxItems(control, items);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="items"></param>
        private static void BindComboBoxItems(RepositoryItemComboBox control, CustomDisplayDataSource items)
        {
            control.BeginUpdate();
            control.Items.Clear();
            control.Items.AddRange((System.Collections.ICollection)items);
            control.EditFormat.FormatType = control.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            control.EditFormat.Format = control.DisplayFormat.Format = items.FormatProvider;
            control.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            control.EndUpdate();
        }

        //Bind ComboBox in Condition
        static object _dataSource = null;
        /// <summary>
        /// 绑定查询条件的ComboBox的DataSource
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="value"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        public static void SetComboBoxEditItems(ComboBoxEdit cbo, object value, string displayMember, string valueMember)
        {
            _dataSource = value;
            cbo.Properties.Items.Clear();

            if (value != null)
            {
                ICollection collection = value as ICollection;
                if (collection != null)
                {
                    foreach (object item in collection)
                    {
                        cbo.Properties.Items.Add(new ComboBoxItem(
                            ReflectionUtil.GetPropertyValue(item, displayMember),
                            ReflectionUtil.GetPropertyValue(item, valueMember),
                            item));
                    }
                }
            }

            if (cbo.Properties.Items.Count > 0) cbo.SelectedIndex = 0;
        }
        /// <summary>
        /// 获取查询条件的ComboBox的DataSource
        /// </summary>
        /// <returns></returns>
        public static object GetComboBoxEditItems()
        {
            return _dataSource;
        }
        /// <summary>
        /// 设置查询条件的ComboBox的SelectedValue
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="value"></param>
        public static void SetComboBoxSelectedValue(ComboBoxEdit cbo, object value)
        {
            if (value == null) return;

            foreach (ComboBoxItem item in cbo.Properties.Items)
            {
                if (item.Value == null) continue;
                if (value.Equals(item.Value))
                {
                    cbo.SelectedItem = item;
                    break;
                }
            }
        }
        /// <summary>
        /// 获取查询条件的ComboBox的SelectedValue
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static object GetComboBoxSelectedValue(ComboBoxEdit cbo)
        {
            if (cbo.SelectedItem == null) return null;
            if (!(cbo.SelectedItem is ComboBoxItem))
            {
                return cbo.SelectedItem;
            }
            else
            {
                return ((ComboBoxItem)cbo.SelectedItem).Value;
            }
        }
        //Message
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowMessage(MessageType messageType, string message)
        {
            MessageForm ms = new MessageForm(messageType, message);
            return ms.ShowDialog();
        }
        /// <summary>
        /// 显示报错信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static DialogResult ShowMessage(Exception ex)
        {
            MessageForm ms = new MessageForm(MessageType.Information, ex.Message);
            return ms.ShowDialog();
        }

        /// <summary>
        /// 设置Grid中按钮图标
        /// </summary>
        /// <param name="buttonEdit"></param>
        /// <param name="type"></param>
        public static void SetButtonImage(RepositoryItemButtonEdit buttonEdit, ButtonImageType type)
        {
            EditorButton button = buttonEdit.Buttons[0];
            if (button == null) return;

            buttonEdit.BorderStyle = BorderStyles.NoBorder;
            buttonEdit.ButtonsStyle = BorderStyles.UltraFlat;
            buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            switch (type)
            {
                case ButtonImageType.DETAIL:
                    button.Image = XHX.Properties.Resources.grid_detail;
                    break;
                case ButtonImageType.POPUP:
                    button.Image = XHX.Properties.Resources.grid_popup;
                    break;
                case ButtonImageType.TAB:
                    button.Image = XHX.Properties.Resources.grid_pagego;
                    break;
            }
            button.ImageLocation = ImageLocation.MiddleCenter;
            button.Kind = ButtonPredefines.Glyph;
            button.Appearance.BackColor = Color.Transparent;
            button.Appearance.Options.UseBackColor = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileID"></param>
        /// <param name="shopName"></param>
        public static void UploadImage(string filePath, string fileID,string shopName)
        {
            string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            string uploadImagePath = appDomainPath + @"UploadImage\" + shopName + @"\";

            if (!Directory.Exists(uploadImagePath))
            {
                Directory.CreateDirectory(uploadImagePath);
            }

            string[] existFilesPath = Directory.GetFiles(uploadImagePath, fileID + "*", SearchOption.TopDirectoryOnly);
            foreach (string existFilePath in existFilesPath)
            {
                File.Delete(existFilePath);
            }

            if (fileID.ToLower().Contains(".jpg") || fileID.ToLower().Contains(".bmp") || fileID.ToLower().Contains(".gif") || fileID.ToLower().Contains(".jpeg"))
                File.Copy(filePath, uploadImagePath + fileID , true);
            else
                File.Copy(filePath, uploadImagePath + fileID + Path.GetExtension(filePath), true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromView"></param>
        /// <param name="viewClassName"></param>
        /// <param name="viewTitleName"></param>
        /// <param name="args"></param>
        public static void LoadView(BaseForm fromView, string viewClassName, string viewTitleName, params object[] args)
        {
            MainForm mainForm = fromView.CSParentForm;
            if (viewTitleName != "照片类" && viewTitleName != "交叉类" && viewTitleName != "资料类")
            {
                foreach (XtraTabPage page in mainForm.tbcPages.TabPages)
                {
                    if (page.Text == viewTitleName)
                    {
                        mainForm.tbcPages.SelectedTabPage = page;
                        return;
                    }
                }
            }
            Assembly asmb = Assembly.Load("MBH");
            BaseForm pageControl = null;
            if (fromView.UserInfoDto.IsNetWork)
            {
                if (args == null || args.Length == 0)
                    pageControl = asmb.CreateInstance("XHX.View." + viewClassName) as BaseForm;
                else
                {
                    Type t = Type.GetType("XHX.View." + viewClassName);
                    pageControl = System.Activator.CreateInstance(t, args) as BaseForm;
                    //pageControl = asmb.CreateInstance("XHX.View." + viewClassName, false, BindingFlags.Instance, null, args, null, null) as BaseForm;
                }
            }
            else
            {
                if (args == null || args.Length == 0)
                    pageControl = asmb.CreateInstance("XHX.ViewLocalService." + viewClassName) as BaseForm;
                else
                {
                    Type t = Type.GetType("XHX.ViewLocalService." + viewClassName);
                    pageControl = System.Activator.CreateInstance(t, args) as BaseForm;
                    //pageControl = asmb.CreateInstance("XHX.ViewLocalService." + viewClassName, false, BindingFlags.Instance, null, args, null, null) as BaseForm;
                }
            }
            
            pageControl.CSParentForm = mainForm;
            pageControl.AutoScroll = true;
            pageControl.Dock = DockStyle.Fill;
            pageControl.UserInfoDto = fromView.UserInfoDto;
          
            List<XHX.BaseForm.ButtonType> list = pageControl.CreateButton();
            List<ToolStripItem> toollist = new List<ToolStripItem>();
            toollist = mainForm.CreatButtons(list);

            string name = viewTitleName;
            if (name == "照片类")
            {
                pageControl.Tag = "照片类";

            }
            else if (name == "资料类")
            {
                pageControl.Tag = "资料类";
            }
            else if (name == "交叉类")
            {
                pageControl.Tag = "交叉类";
            }
            XtraTabPage tpg = new XtraTabPage();
            tpg.Text = viewTitleName;
            tpg.Controls.Add(pageControl);
            tpg.Tag = toollist;
            mainForm.tbcPages.TabPages.Add(tpg);
            mainForm.tbcPages.SelectedTabPage = tpg;
            mainForm.toolStrip1.Items.Clear();
            mainForm.toolStrip1.Items.AddRange(toollist.ToArray());
        }
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="source">图片的原始路径</param>
        /// <param name="outFilePath">图片压缩后的路径</param>
        public static void CompressionPicCommon(string source, string outFilePath)
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            // Create a Bitmap object based on a BMP file.
            myBitmap = new Bitmap(source);
            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);
            // Save the bitmap as a JPEG file with quality level 25.
            myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            try
            {
                myBitmap.Save(outFilePath, myImageCodecInfo, myEncoderParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 页面调用的共同方法，传入相应的参数
        /// </summary>
        /// <param name="projectCode">项目代码</param>
        /// <param name="userID">用户ID</param>
        /// <param name="source">原始路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="shopName">经销商名</param>
        public static void  CompressionPic(string projectCode,string userID,string source, string fileName, string shopName)
        {
            string appDomainPath = string.Empty;
            if (!IsNetWork)
            {
                localservice.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
                appDomainPath = localservice.getImagePath(projectCode, userID);
            }
            else
            {
                appDomainPath = serviceCommon.getImagePath(projectCode, userID);
            }
            if (string.IsNullOrEmpty(appDomainPath))
            {
                appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            string uploadImagePath = appDomainPath+@"\" + @"UploadImage\" + shopName + @"\";
            try
            {
                if (!Directory.Exists(appDomainPath +@"\"+ @"UploadImage\" + shopName))
                {
                    Directory.CreateDirectory(appDomainPath +@"\"+ @"UploadImage\" + shopName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            CompressionPicCommon(source, uploadImagePath + fileName + ".jpg");
        }
        /// <summary>
        /// 获得图片类型
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ColumnInfoType"></typeparam>
        /// <param name="gridView"></param>
        /// <param name="columnInfoList"></param>
        /// <param name="dtoList"></param>
        /// <param name="rowNameCaption"></param>
        /// <returns></returns>
        public static Dictionary<int, GridColumn> BuildDynamicColumn<ColumnInfoType>(BandedGridView gridView, List<ColumnInfoType> columnInfoList, List<DefaultDynamicColumnDto> dtoList, string rowNameCaption)
         where ColumnInfoType : DynamicColumnInfo
        {
            gridView.BeginUpdate();
            gridView.GridControl.DataSource = null;

            if (gridView.Columns.ColumnByName("RowName") == null)
            {
                GridBand band = null;
                BandedGridColumn column = null;
                band = gridView.Bands.AddBand(rowNameCaption);
                column = gridView.Columns.Add();
                column.Name = column.FieldName = "RowName";
                column.Visible = true;
                band.Columns.Add(column);
            }

            gridView.EndUpdate();
            return BuildDynamicColumn<ColumnInfoType, DefaultDynamicColumnDto>(gridView, columnInfoList, dtoList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ColumnInfoType"></typeparam>
        /// <typeparam name="DtoType"></typeparam>
        /// <param name="gridView"></param>
        /// <param name="columnInfoList"></param>
        /// <param name="dtoList"></param>
        /// <returns></returns>
        public static Dictionary<int, GridColumn> BuildDynamicColumn<ColumnInfoType, DtoType>(BandedGridView gridView, List<ColumnInfoType> columnInfoList, List<DtoType> dtoList)
            where ColumnInfoType : DynamicColumnInfo
            where DtoType : BufferColumnDto
        {
            gridView.BeginUpdate();
            gridView.GridControl.DataSource = null;

            ArrayList bandCollection = new ArrayList(gridView.Bands);
            GridBand band = null;
            for (int i = 0; i < bandCollection.Count; i++)
            {
                band = (GridBand)bandCollection[i];
                if (band.Name.StartsWith(DynamicColumnInfo.UNIQUE_NAME_PREFIX)) gridView.Bands.Remove(band);
            }

            ArrayList columnCollection = new ArrayList(gridView.Columns);
            BandedGridColumn column = null;
            for (int i = 0; i < columnCollection.Count; i++)
            {
                column = (BandedGridColumn)columnCollection[i];
                if (column.Name.StartsWith(DynamicColumnInfo.UNIQUE_NAME_PREFIX)) gridView.Columns.Remove(column);
            }

            DynamicColumnUtil.SortDynamicColumnInfo<ColumnInfoType>(columnInfoList);
            Dictionary<int, GridColumn> columnDic = new Dictionary<int, GridColumn>();
            foreach (DynamicColumnInfo columnInfo in columnInfoList)
            {
                AddBandAndColumn(gridView, columnDic, columnInfo);
            }

            gridView.EndUpdate();
            gridView.GridControl.DataSource = dtoList;
    
            return columnDic;
        }

        private static void AddBandAndColumn(BandedGridView gridView, Dictionary<int, GridColumn> columnDic, DynamicColumnInfo columnInfo)
        {
            OneLevelColumnInfo oneLevelColumnInfo = columnInfo as OneLevelColumnInfo;
            if (oneLevelColumnInfo != null)
            {
                AddOneLevelBandAndColumn(gridView, columnDic, oneLevelColumnInfo);
            }
            else
            {
                AddTwoLevelBandAndColumn(gridView, columnDic, columnInfo as TwoLevelColumnInfo);
            }
        }///
        private static void AddOneLevelBandAndColumn(BandedGridView gridView, Dictionary<int, GridColumn> columnDic, OneLevelColumnInfo columnInfo)
        {
            GridBand band = null;
            BandedGridColumn column = null;
            band = gridView.Bands.AddBand(columnInfo.Caption);
            band.Name = columnInfo.UniqueName;
            band.Caption = columnInfo.Caption;
            column = gridView.Columns.Add();
            column.Name = columnInfo.UniqueName;
            column.Caption = columnInfo.Caption;
            column.Width = 50;
            column.FieldName = String.Format("Cell{0:000}", columnInfo.Order + 1);
            column.Visible = true;
            band.Columns.Add(column);
            columnDic.Add(columnInfo.Order, column);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="columnDic"></param>
        /// <param name="columnInfo"></param>
        private static void AddTwoLevelBandAndColumn(BandedGridView gridView, Dictionary<int, GridColumn> columnDic, TwoLevelColumnInfo columnInfo)
        {
            GridBand topBand = null, band = null;
            BandedGridColumn column = null;
            string topBandUniqueName = DynamicColumnInfo.MakeUniqueName(columnInfo.Column1);
            topBand = gridView.Bands[topBandUniqueName];
            if (topBand == null)
            {
                topBand = gridView.Bands.AddBand(columnInfo.Caption1);
                topBand.Name = topBandUniqueName;
                topBand.Caption = columnInfo.Caption1;
                topBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            
            band = topBand.Children.AddBand(columnInfo.Caption1);
            band.AppearanceHeader.Options.UseTextOptions = true;
            //band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.Name = columnInfo.UniqueName;
            band.Caption = columnInfo.Caption2;
            //band.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            //band.RowCount = 3;
            //band.Width = 100;
           // band.AutoFillDown = true;
            column = gridView.Columns.Add();
            column.Name = columnInfo.UniqueName;
            column.Caption = columnInfo.Caption2;
            column.FieldName = String.Format("Cell{0:000}", columnInfo.Order + 1);
            column.Visible = true;
            column.OptionsColumn.ShowCaption = true;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
           // column.OptionsColumn.FixedWidth = true;
            column.Width = 100;
            band.Columns.Add(column);
            columnDic.Add(columnInfo.Order, column);
        }
        /// <summary>
        /// 解压功能(解压压缩文件到指定目录)
        /// </summary>
        /// <param name="FileToUpZip">待解压的文件</param>
        /// <param name="ZipedFolder">指定解压目标目录</param>
        public static void UnZip(string FileToUpZip, string ZipedFolder, string Password)
        {
            if (!File.Exists(FileToUpZip))
            {
                return;
            }

            if (!Directory.Exists(ZipedFolder))
            {
                Directory.CreateDirectory(ZipedFolder);
            }

            ZipInputStream s = null;
            ZipEntry theEntry = null;

            string fileName;
            FileStream streamWriter = null;
            try
            {
                s = new ZipInputStream(File.OpenRead(FileToUpZip));
                s.Password = Password;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        fileName = Path.Combine(ZipedFolder, theEntry.Name);
                        ///判断文件路径是否是文件夹
                        if (fileName.EndsWith("/") || fileName.EndsWith("//"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }
                        DirectoryInfo dir = new DirectoryInfo(fileName);
                        if (!dir.Exists)
                        {
                            dir.Parent.Create();
                        }
                        streamWriter = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }
                if (theEntry != null)
                {
                    theEntry = null;
                }
                if (s != null)
                {
                    s.Close();
                    s = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
        }
    }

    [Serializable]
    public class StatusTypes
    {
        public const char DELETE = 'D';
        public const char INSERT = 'I';
        public const char NONE = 'N';
        public const string STATUS_PROPERTY_NAME = "StatusType";
        public const char UPDATE = 'U';

        public StatusTypes() { }
    }

    public class ComboBoxItem
    {
        string _displayText = String.Empty;
        object _item = null;
        object _value = null;

        public ComboBoxItem(object displayObject, object value)
        {
            this._displayText = displayObject.ToString();
            this._value = value;
        }

        public ComboBoxItem(object displayObject, object value, object item)
            : this(displayObject, value)
        {
            this._item = item;
        }

        public object Value
        {
            get { return _value; }
        }

        public object Item
        {
            get { return _item; }
        }

        public override string ToString()
        {
            if (_displayText == null) return string.Empty;
            else return _displayText.ToString();
        }
    }

    public enum MessageType
    { 
        Information,
        Confirm
    }

    public enum ButtonImageType
    {
        DETAIL,
        POPUP,
        TAB
    }

}

