using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using OfficeControl;

namespace XHX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("dsoframer.ocx"))
            {
                Stream ms = typeof(OfficeDisplayControl).Assembly.GetManifestResourceStream("OfficeControl.dsoframer.ocx");
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes, 0, bytes.Length);
                ms.Close();
                FileStream fs = new FileStream("dsoframer.ocx", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                Assembly thisExe = Assembly.GetExecutingAssembly();
                System.IO.Stream myS = thisExe.GetManifestResourceStream("NameSpaceName.dsoframer.ocx");
                string sPath = "dsoframer.ocx";
                ProcessStartInfo psi = new ProcessStartInfo("regsvr32", "/s " + sPath);
                psi.UseShellExecute = false;
                Process regsvr32 = Process.Start(psi);
                regsvr32.WaitForExit();
            }

            Application.EnableVisualStyles();
            string file = string.Format(@"{0}\DevExpress.BonusSkins.v9.1.dll", AppDomain.CurrentDomain.BaseDirectory);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(System.Reflection.Assembly.LoadFile(file));
            file = string.Format(@"{0}\DevExpress.OfficeSkins.v9.1.dll", AppDomain.CurrentDomain.BaseDirectory);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(System.Reflection.Assembly.LoadFile(file));
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
