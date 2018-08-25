using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using XHX.DTO;

namespace XHX.ViewLocalService
{
    public partial class SubjectOnePop : Form
    {
        localhost.Service webService = new localhost.Service();
        public SubjectOnePop()
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
        }
        public SubjectOnePop(string projectCode, string shopCode, string shopName, string subjectCode)
            : this()
        {
            txtProjectCode.Text = projectCode;
            txtShopCode.Text = shopCode;
            txtShopName.Text = shopName;
            txtSubjectCode.Text = subjectCode;
            this.SearchSubject(projectCode,subjectCode);

        }
        public void SearchSubject(string projectCode,string subjectCode)
        {
            DataSet ds = webService.SearchSubjectBySubjectCodeAndProjectCode(txtProjectCode.Text, txtSubjectCode.Text);
            List<SubjectDto> subjectList = new List<SubjectDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SubjectDto file = new SubjectDto();
                    txtApplyDesc.Text = Convert.ToString(ds.Tables[0].Rows[i]["Desc"]);
                    txtStand.Text = Convert.ToString(ds.Tables[0].Rows[i]["InspectionDesc"]);
                    txtCheckPoint.Text = Convert.ToString(ds.Tables[0].Rows[i]["CheckPoint"]);
                    textEdit1.Text = Convert.ToString(ds.Tables[0].Rows[i]["Implementation"]);
                    //subjectList.Add(file);
                }
                
            }
            
 
        }
        
    }
}
