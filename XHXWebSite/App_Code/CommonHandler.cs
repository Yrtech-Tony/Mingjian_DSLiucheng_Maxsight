using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;

/// <summary>
/// Summary description for CommonHandle
/// </summary>
public class CommonHandler
{
    public static OleDbConnection conn = null;
    public CommonHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void DBConnect()
    {
        //数据库连接
        if (conn == null)
        {
            conn = new OleDbConnection();
            //conn.ConnectionString = "provider=sqloledb.1;data source=10.202.101.107;initial catalog=XHX_DEV;user id=fanfan;pwd=1";
            //conn.ConnectionString = "provider=sqloledb.1;data source=192.168.0.101;initial catalog=XHX_2.0;user id=XHX;pwd=XHX";
            //conn.ConnectionString = "Provider=sqloledb;Data Source=w4bdb.51.net;Initial Catalog=y184483;user id=y184483;pwd=7505067;";
            conn.ConnectionString = "Provider=sqloledb;Data Source=.;Initial Catalog=DS_Liucheng;user id=sa;pwd=mxT1@mfb;";
            //conn.ConnectionString = "Provider=sqloledb;Data Source=.;Initial Catalog=XinHuaXin;user id=xhx;pwd=XHX;";
        }
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();//打开连接  
        }
    }
    public static void connClose()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    public static DataSet query(string sql)
    {
        DataSet ds = new DataSet(); //创建dataSet对象 
        string ConnectionString = "Provider=sqloledb;Data Source=123.57.229.128;Initial Catalog=DS_Liucheng;user id=sa;pwd=mxT1@mfb;timeout = 0";
        using (OleDbConnection conn = new OleDbConnection(ConnectionString))
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(sql, conn))
            {
                try
                {
                    conn.Open();
                    da.Fill(ds);//使用Fill()方法填充dataSet
                }
                catch (Exception ex)
                {

                    log(ex.ToString() + " " + "\r\n" + sql);
                }
            }
        }

        //try
        //{
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);//适配器，用于填充dataSet或dataTable  
        //    da.Fill(ds);//使用Fill()方法填充dataSet 
        //    connClose();//关闭连接 
        //    //return ds;//返回DataSet
        //}
        //catch (Exception ex)
        //{

        //}
        return ds;
    }
    public static void log(string message)
    {
        string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = appDomainPath + @"\" + "Log" + @"\" + DateTime.Now.ToString("yyyyMMdd") + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        //File.Create(fileName);
        if (!Directory.Exists(appDomainPath + @"\" + "Log"))
        {
            Directory.CreateDirectory(appDomainPath + @"\" + "Log");
        }
        if (!Directory.Exists(appDomainPath + @"\" + "Log" + @"\" + DateTime.Now.ToString("yyyyMMdd")))
        {
            Directory.CreateDirectory(appDomainPath + @"\" + "Log" + @"\" + DateTime.Now.ToString("yyyyMMdd"));
        }
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            byte[] by = WriteStringToByte(message, fs);
            fs.Flush();
        }
    }
    public static byte[] WriteStringToByte(string str, FileStream fs)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(str);
        fs.Write(info, 0, info.Length);
        return info;
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
